using DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Abstractions;
using DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Concretes;
using DesignPatternSamples.BehavioralPatterns.Command.Commands;
using DesignPatternSamples.BehavioralPatterns.Command.Invokers;
using DesignPatternSamples.BehavioralPatterns.Command.Receivers;
using DesignPatternSamples.BehavioralPatterns.Interpreter;
using DesignPatternSamples.BehavioralPatterns.Interpreter.AbstractExpressions;
using DesignPatternSamples.BehavioralPatterns.Interpreter.TerminalExpressions;
using DesignPatternSamples.BehavioralPatterns.Iterator.Aggregates;
using DesignPatternSamples.BehavioralPatterns.Mediator.Colleagues;
using DesignPatternSamples.BehavioralPatterns.Mediator.Mediators;
using DesignPatternSamples.BehavioralPatterns.Memento.Caretakers;
using DesignPatternSamples.BehavioralPatterns.Memento.Originators;
using DesignPatternSamples.BehavioralPatterns.Observer;
using DesignPatternSamples.BehavioralPatterns.Observer.Observers;
using DesignPatternSamples.BehavioralPatterns.Observer.Subjects;
using DesignPatternSamples.BehavioralPatterns.State;
using DesignPatternSamples.BehavioralPatterns.Strategy;
using DesignPatternSamples.BehavioralPatterns.Strategy.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.ConsoleAPP.Services
{
    public static class BehavioralService
    {
        #region Chain of Responsibility
        public static void RunChainOfResponsibilitySample()
        {
            //Contexto, o obejto passada para ser tratado na chain
            var context = new BehavioralPatterns.ChainOfResponsibility.Context();
            //Contador para o laço
            int count = 1;
            //IHandler: interface comum a toda chain
            //StartedHandler: concrete Handler - prmeiro nó da chain
            IHandler chain = new StartedHandler();
            //chain.SetNext: Metodo de controle para adicionar o próximo nó da chain
            //Adicionado FinishedHandler e após ele MiddleHandler
            chain.SetNext(new FinishedHandler())
                 .SetNext(new MiddleHandler());

            Console.WriteLine("CONTEXTO ANTES CHAIN");
            Console.WriteLine(context);

            //Equanto houver dado em alguma das listas do contexto a chain vai rodar para trata-los, cada um em seu especifico nó            
            while (context.Finished.Any() || context.Started.Any() || context.Middle.Any())
            {
                Console.WriteLine($"\nEXECUÇÃO DA CHAIN PELA {count} VEZ");
                //Executando a Chain
                chain.Execute(context);

                Console.WriteLine("\nCONTEXTO DEPOIS CHAIN");
                Console.WriteLine(context);
                count++;
            }
        }
        #endregion
        #region Command
        public static void RunCommandSample()
        {
            //Criando o Receiver
            var receiver = new PromotionService();

            //Criando o commando
            var command = CreateCommand(receiver, new List<string>() { "Carla", "Saulo", "Lucina" }, DateTime.Now.AddDays(20), "Toys");

            //Criando o Invoker
            var invoker = new Invoker();
            //Associando o comando ao invoker
            invoker.SetCommand(command);

            //Fazendo outras coisas
            Console.WriteLine("\nClient fazendo outras coisas...");

            //Solicitando ao comando para executar a solitiação
            Console.WriteLine("Client sinaliza ao invoker para executar o comando\n");
            invoker.ExecuteComand();

            //Atrelando outro comando ao invoker e executando
            Console.WriteLine("\nAtrelando outro comando ao invoker  e executando");
            var command2 = CreateCommand(receiver, new List<string>() { "Pablo", "Eliana", "Isa" }, DateTime.Now.AddDays(10), "Beauty");
            invoker.SetCommand(command2);
            invoker.ExecuteComand();
        }
        private static ICommand CreateCommand(PromotionService receiver, List<string> clients, DateTime expirationDate, string department)
        {
            //Criando o comando
            var command = new AlertCommand(receiver, clients, expirationDate, department);
            return command;
        }
        #endregion
        #region Interpreter
        public static void RunInterpreterSample()
        {
            //expression: Definição da expressão
            var expression = "1A8";
            //context: o contexto a ser interpretado
            var context = new Context(expression);

            //Expressões terminais, uma para cada simbolo da linguagem, nesse caso são as casa decimais
            var oneExpression = new OneExpression();
            var tenExpression = new TenExpression();
            var hundredExpression = new HundredExpression();
            //Criação da arvore de analise de acordo com a expressão que sera tratada, pode ser mudada
            List<IAbstractExpression> tree = new() { hundredExpression, tenExpression, oneExpression };

            //Execução da interpretação na arvore
            tree.ForEach(e => e.Interpret(context));

            Console.WriteLine($"\n Interpretado {expression} em hexadecimal para {context.Output} em decimal");
        }
        #endregion
        #region Iterator
        public static void RunIteratorSample()
        {
            //FruitAggregate: ConcreteAggregate - Sendo criado
            var fruitCollection = new FruitAggregate();
            //Alimentando a collection do FruitAggregate
            fruitCollection.AddFruit("Limão");
            fruitCollection.AddFruit("Laranja");
            fruitCollection.AddFruit("Morango");
            fruitCollection.AddFruit("Ameixa");
            fruitCollection.AddFruit("Melão");
            fruitCollection.AddFruit("Melância");
            fruitCollection.AddFruit("Manga");

            //Obtendo o iterator para percorrer a lista fruitCollection
            //imparIterator: um IIterator com a instancia ImparIterator
            var imparIterator = fruitCollection.GetIterator();

            //Colocando o iterator no inicio
            imparIterator.First();

            //Enquanto não chegar ao fim continua a percorrer a lista
            while (!imparIterator.IsDone())
            {
                //trocar o item da lista
                imparIterator.Next();
            }
        }
        #endregion
        #region Mediator
        public static void RunMediatorSample()
        {
            //Colleagues: Precisam acionar ações entre si quando determinados metodos são acionados
            var colleague1 = new Colleague1();
            var colleague2 = new Colleague2();
            var colleague3 = new Colleague3();

            //mediator: mediador encapsula a comunicação entre os objetos Colleagues fazendo que só dependam dele
            IMediator mediator = new ConcreteMediator(colleague1, colleague2, colleague3);

            //Simulando ações do cliente ao executar comportamentos dos componentes eles alertam ao mediator que por sua vez chama o obejtos que deveriam interagir com aquele evento
            Console.WriteLine($"Cliente executando um metodo do componente {nameof(colleague1)} que por sua vez sinaliza ao mediator:\n");
            colleague1.DoSomeThing();

            Console.WriteLine($"\nCliente executando um metodo do componente {nameof(colleague2)} que por sua vez sinaliza ao mediator:\n");
            colleague2.DoSomeThing();

            Console.WriteLine($"\nCliente executando um metodo do componente {nameof(colleague3)} que por sua vez sinaliza ao mediator:\n");
            colleague3.DoSomeThing();
        }
        #endregion
        #region Mementos
        public static void RunMementosSample()
        {
            //Caretaker - criando o cuidador
            var manager = new MementoManager();

            //Originator: Bill - criando a conta
            var bill = new Bill(152.50M, "Carlos");

            //Exibido o estado atual
            Console.WriteLine("Exibindo o estado atual da conta");
            bill.Show();

            //Salvar o Estado Atual do Bill para altera-lo
            Console.WriteLine("\nCriando o retrato da conta antes de altera-la");
            manager.SetMemento(bill.CreateMemento());
            bill.SetDiscount(20);

            //Exibe o estado alterado
            Console.WriteLine("\nExibindo o estado da conta após alteração, mudança no desconto");
            bill.Show();

            //Restaurando o estado antes da alteração
            Console.WriteLine("\nResturando o estado da conta com o memento para antes do desconto");
            var memento = manager.GetLast();
            bill.Restore(memento);

            //Exibindo o status restaurado
            Console.WriteLine("\nExibindo o estado da conta após Restauração sem o desconto");
            bill.Show();
        }
        #endregion
        #region Observer
        public static void RunObserverSample()
        {
            //Criando o observador
            var observer = new Separation();
            //Criando o subject
            var subject = new Pedido();

            //Executando funções do subject, como são intermediárias não estou disparando a notificação que também podia ser chamad aqui diretamente pelo cliente
            subject.AddProduct(new SaleProduct() { Description = "Uva", Amount = 16 });
            subject.AddProduct(new SaleProduct() { Description = "Monitor", Amount = 3 });
            subject.AddProduct(new SaleProduct() { Description = "Teclado", Amount = 1 });

            //Adiconando um observador no pedido
            Console.WriteLine("O cliente adiciona um observador no pedido");
            subject.AddObserver(observer);

            //Executando a operação que muda o estado do subject e deve avisar ao obeserver
            Console.WriteLine("\nO pedido é finalizado");
            subject.Complete();
        }
        #endregion
        #region State
        public static void RunStateSample()
        {
            //Criando o contexto com um estado default            
            var context = new Water(500);

            //Tentando beber a agua - Checando se possível no status
            Console.WriteLine("\nTentando beber a agua");
            context.Drink(200);

            //Esquentando a agua - Muda o estado
            Console.WriteLine("\nEsquentando a agua");
            context.WarmUp();
            Console.WriteLine("Esquentando a agua, novamente");
            context.WarmUp();

            Console.WriteLine("\nTentando beber a agua, novamente");
            context.Drink(200);

            //Esfriando a agua
            Console.WriteLine("\nEsfriando a agua");
            context.Freeze();

            //bebendo
            Console.WriteLine("\nTentando beber a agua, novamente");
            context.Drink(200);
        }
        #endregion
        #region Strategy
        public static void RunStrategySample()
        {
            //Criando o contexto com uma estrategia inicial
            var context = new VacationService(new TimeInCompanyStrategy());

            //Exibindo a lista de funcionarios
            context.ShowEmployees();
            Console.WriteLine();
            //Obtendo o proximo funcionário a sair de ferias com base nas estrategias
            context.CalculateNextEmployeeToVacation();

            //Mudando a estrategy e calculando novamente
            context.ChangeStrategy(new FastToReturnStrategy());
            context.CalculateNextEmployeeToVacation();

            //Mudando a estrategy e calculando novamente
            context.ChangeStrategy(new LongestOverdueStrategy());
            context.CalculateNextEmployeeToVacation();
        }
        #endregion
    }
}
