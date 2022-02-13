using DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Abstractions;
using DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Concretes;
using DesignPatternSamples.BehavioralPatterns.Command.Commands;
using DesignPatternSamples.BehavioralPatterns.Command.Invokers;
using DesignPatternSamples.BehavioralPatterns.Command.Receivers;
using DesignPatternSamples.BehavioralPatterns.Interpreter;
using DesignPatternSamples.BehavioralPatterns.Interpreter.AbstractExpressions;
using DesignPatternSamples.BehavioralPatterns.Interpreter.TerminalExpressions;
using DesignPatternSamples.BehavioralPatterns.Iterator.Aggregates;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Factories;
using DesignPatternSamples.CreationalPatterns.Builder.Entities.Builders;
using DesignPatternSamples.CreationalPatterns.Builder.Entities.Director;
using DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Abstracts;
using DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Concrete.PC;
using DesignPatternSamples.CreationalPatterns.Prototype.Entities;
using DesignPatternSamples.CreationalPatterns.Prototype.Interfaces;
using DesignPatternSamples.CreationalPatterns.Singleton.Entitie;
using DesignPatternSamples.CrossCutting.Enums;
using DesignPatternSamples.StructuralPatterns.Adapter.Entities.Adaptees;
using DesignPatternSamples.StructuralPatterns.Adapter.Entities.Adapters;
using DesignPatternSamples.StructuralPatterns.Bridge.AbstractionSide;
using DesignPatternSamples.StructuralPatterns.Bridge.ImplementationSide;
using DesignPatternSamples.StructuralPatterns.Composite.Composites;
using DesignPatternSamples.StructuralPatterns.Composite.Leafs;
using DesignPatternSamples.StructuralPatterns.Decorator.Components;
using DesignPatternSamples.StructuralPatterns.Decorator.Decorators;
using DesignPatternSamples.StructuralPatterns.Facade.Facades;
using DesignPatternSamples.StructuralPatterns.Facade.Subsystem;
using DesignPatternSamples.StructuralPatterns.Flyweight.Entities.Context;
using DesignPatternSamples.StructuralPatterns.Flyweight.Entities.Flyweights.FlyweightFactories;
using DesignPatternSamples.StructuralPatterns.Proxy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IComponentComposite = DesignPatternSamples.StructuralPatterns.Composite.Abstractions.IComponent;

namespace DesignPatternSamples.ConsoleAPP
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Creational Patterns
            RunFactoryMethodSample();
            RunAbstractFactorySample();
            RunBuilderSample();
            RunPrototypeSample();
            RunSingletonSample();

            //Structural Patterns
            RunAdapterSample();
            RunBrigdeSample();
            RunCompositeSample();
            RunDecoratorSample();
            RunFacadeSample();
            RunFlyweightSample();
            RunProxySample();

            //Behavioral Patterns
            RunChainOfResponsibilitySample();
            RunCommandSample();
            RunInterpreterSample();
            RunIteratorSample();


            Console.ReadKey();
        }

        #region Factory Method
        private static void RunFactoryMethodSample()
        {
            Register(true, nameof(RunFactoryMethodSample));

            var pc1 = new RedHatPC("PC1-RedHat");
            var pc2 = new OfficePC("PC2-Office");
            var pc3 = new ApplePC("PC3-Apple");

            LogIntoPcs(pc1, pc2, pc3);

            Register(false, nameof(RunFactoryMethodSample));
        }
        private static void LogIntoPcs(params PersonalComputerBase[] pcs)
        {
            foreach (var pc in pcs)
            {
                Console.WriteLine($"Tentativa de logar no {pc.Name}");
                pc.Login("ADMIN");
            }
        }
        #endregion
        #region Abstract Factory
        private static void RunAbstractFactorySample()
        {
            Register(true, nameof(RunAbstractFactorySample));

            IVehicleFactory factory = new PoliceVehicleFactory();
            Console.WriteLine($"Tipo de fabrica gerada: {factory.GetType().Name}");
            CreateSameTypeVehicle(factory);

            factory = new SportVehicleFactory();
            Console.WriteLine($"\nTipo de fabrica gerada: {factory.GetType().Name}");
            CreateSameTypeVehicle(factory);

            Register(false, nameof(RunAbstractFactorySample));
        }
        private static void CreateSameTypeVehicle(IVehicleFactory factory)
        {
            Console.WriteLine(factory.CreateAirplane());
            Console.WriteLine(factory.CreateCar());
            Console.WriteLine(factory.CreateShip());
        }
        #endregion
        #region Builder
        private static void RunBuilderSample()
        {
            Register(true, nameof(RunBuilderSample));

            WithoutDirectorSample();

            WithDirectorSample();

            Register(true, nameof(RunBuilderSample));
        }

        private static void WithoutDirectorSample()
        {
            //Create Dragon Builder            
            var dragonBuilder = new DragonBuilder();

            //Assembly dragon parts
            dragonBuilder.WithName("But")
                   .WithColor(EColor.Black)
                   .WithFeet("Bigest")
                   .WithMaster(true);
            //create wing builder and build the wing
            var wing =
                new WingBuilder()
                    .WithColor(EColor.Green)
                    .WithVelocity(200)
                    .WithHighestAltitude(800)
                    .Build();
            //using headBuild nested into dragon builder
            dragonBuilder
                .WithHead(x =>
                            x.WithColor(EColor.Blue)
                            .WithPersonality("Sad")
                            .WithPower("fire"));
            dragonBuilder
                .WithHead(x =>
                            x.WithColor(EColor.Red)
                            .WithPersonality("Wise")
                            .WithHorn(3)
                            .WithPower("Ice"));

            //pass wing to dragon builder and build dragon
            var dragon = dragonBuilder.WithWing(wing).Build();

            Console.WriteLine("Without Director Sample:\n" + dragon);
        }

        private static void WithDirectorSample()
        {
            //director
            var director = new DragonTrainer(new DragonBuilder());

            Console.WriteLine("\nWith Director Sample:\n" + director.CreateSmallerEarthDragon("Caçula"));
        }
        #endregion
        #region Prototype
        private static void RunPrototypeSample()
        {
            Register(true, nameof(RunPrototypeSample));

            var InfringementCassada = new Infringement()
            {
                Cod = "502-91",
                Name = "DIRIGIR VEICULO COM CNH CASSADA",
                TimeToExpiration = 20
            };

            IPenalty prototype = new TrafficPenalty(InfringementCassada);

            //DeepClone - Creates new aggregates object references
            var deepClone = prototype.DeepCopy();
            //Update Clone field competencyDate
            deepClone.Initializer(DateTime.Now);

            //ShallowClone - shared agregate references with prototype
            var shallowClone = prototype.ShallowCopy();

            //Change Prototype agregation            
            prototype.Infringement.Name = "Updated - DIRIGIR VEICULO COM CNH CASSADA";

            Console.WriteLine("Prototype:\n" + prototype);
            Console.WriteLine("\nDeep Cloned:\n" + deepClone);
            Console.WriteLine("\nShallow Clone:\n" + shallowClone);

            Register(false, nameof(RunPrototypeSample));
        }
        #endregion
        #region Singleton
        private static void RunSingletonSample()
        {
            Register(true, nameof(RunPrototypeSample));

            int[] threads = new int[100];
            var fsReturnedInstances = new ConcurrentBag<FileServer>();

            //Running parallel threads for thread safe verification
            Parallel.ForEach(threads, i =>
            {
                var fs = FileServer.GetInstance();
                fsReturnedInstances.Add(fs);
                fs.WriteFile();
            });

            if (fsReturnedInstances.Any(x => x.Id == fsReturnedInstances.Last().Id))
                Console.WriteLine($"\n Todas as {fsReturnedInstances.Count} instâncias de {nameof(FileServer)} obtidas foram a mesma grantindo o padrão singleton");

            Register(false, nameof(RunPrototypeSample));
        }
        #endregion

        #region Adpter
        private static void RunAdapterSample()
        {
            Register(true, nameof(RunAdapterSample));

            //IQuarterConsolidade = Interface do serviço a ser adptado a que o nosso cliente não consegue construir os parâmetros para comunicar com ela
            //QuarterConsolidade = Classe concreta do serviço a ser adpatado
            IQuarterConsolidade adaptee = new QuarterConsolidade();

            //ISale = target é a interface de dominio que o nosso client conhece
            //SaleProcessAdapter = é o adaptador, a classe concrete que será chamada e fará o vinculo com o objeto adaptado que recebeu no contrutor
            ISale target = new SaleProcessAdapter(adaptee);

            //SaleDto = o objeto do dominio que o cliente conhece e pode passar para o target, .Load() retornando uma lista de salesDto
            var list = SaleDto.Load();

            //Exibindo o objeto de conhecimento do cliente que será passado ao adptador
            Console.WriteLine($"Sales \n{string.Join('\n', list)}");

            //Chamando o adaptador para consolidar a lista de vendas
            var consolidadeSales = target.ProcessSaleConsolidate(list);

            //Exibição do resultado consolidado pela interface adpatada IQuarterConsolidade para uso do cliente, sem necessidade dele conhecer detalhes dessa comunicação
            Console.WriteLine($"\nConsolidade \n{string.Join('\n', consolidadeSales)}");
            Register(false, nameof(RunAdapterSample));
        }
        #endregion
        #region Bridge
        private static void RunBrigdeSample()
        {
            Register(true, nameof(RunBrigdeSample));

            //Implementation Abstraction = ISecurity
            //Implementation Concrete = GuardDog
            ISecurity caramelo = new GuardDog();
            ISecurity naldo = new MmaFighter();

            //Abstraction = Residence
            //Abstraction Refined = House
            Residence residence = new House(false, caramelo, false);

            //Usando a abstração para alterar comportamentos relacionados a casa e de forma transparente
            //ao usuário acionado a implementação para realizar as operações que lhe competem
            residence.Lock();
            residence.Open();
            residence.ResidentArrived();
            residence.Open();

            //O padrão também permite a alteração implementação em tempo de execução
            residence.ChangeSecurity(naldo);
            Console.WriteLine($"\nClient - Alterado a segurança de {nameof(GuardDog)} para {nameof(MmaFighter)} \n");
            //Atraves da nova implementação
            //Usando a abstração para alterar comportamentos relacionados a casa e de forma transparente
            //ao usuário acionado a implementação para realizar as operações que lhe competem
            residence.Lock();
            residence.ResidentLeft();
            residence.Open();
            residence.ResidentArrived();
            residence.Open();

            Register(false, nameof(RunBrigdeSample));
        }
        #endregion
        #region Composite
        private static void RunCompositeSample()
        {
            Register(true, nameof(RunCompositeSample));

            GenerateHouseStrucure(out IComponentComposite room, out IComponentComposite house);

            //Abrindo todos os obejtos compostos e não através da mesma interface
            Console.WriteLine("Abrindo todos os objetos");
            Console.WriteLine(house.Open());

            //Fechando somente o equivalente a um composite da arvore, e todos os seus filhos pela mesma interface
            Console.WriteLine("\n\nFechando somente o composite: quarto");
            Console.WriteLine(room.Close());

            //Demostrando como ficou a estrutura final da arvore
            Console.WriteLine("\n\nExibindo a casa");
            Console.WriteLine(house.Show());


            Register(false, nameof(RunCompositeSample));
        }
        private static void GenerateHouseStrucure(out IComponentComposite room, out IComponentComposite house)
        {
            //Criando o composite: generalbathroom com as folhas: Window, Door            
            IComponentComposite generalbathroom = new Room("Banheiro - Principal");
            generalbathroom.Add(new Window("Veneziana"), new Door("Porta"));

            //Criando o composite: room com os filhos: 2x Window, Door, e o composite:suitbathroom com os filhos dele
            IComponentComposite suitBathroom = new Room("Banheiro - Secundário");
            suitBathroom.Add(new Window("Veneziana"), new Door("Porta de banheiro"));
            room = new Room("Quarto");
            room.Add(new Window("Janela Esquerda"), new Window("Janela Frente"), new Door("Porta quarto"), suitBathroom);

            //Criando nosso compose raiz:house e adicionando os filhos:Door, room, generalbathroom
            house = new Room("Casa");
            house.Add(new Door("Porta da casa"), room, generalbathroom);
        }
        #endregion
        #region Decorator
        private static void RunDecoratorSample()
        {
            Register(true, nameof(RunDecoratorSample));
            //IComponent: IComponent - Interface que deve ser implementada pelos objetos que podem ser decorados
            //Componente Concreto: movie - O objeto que pode ser estendido pelos decoradores
            IComponent movie = new Movie();

            //Decorator: Decorator - Abstração comum a todos os decoradores
            //Decorador Concreto: postCreditDecorator - Decorador que adiciona comportamentos após a execução do comportamento padrão
            //do Componente concreto
            Decorator postCreditDecorator = new PostCreditDecorator(movie);
            //Decorador Concreto: trailerDecorator - Decorador que adiciona comportamentos antes da execução do comportamento padrão
            //do Componente concreto
            Decorator trailerDecorator = new TrailerDecorator(movie);
            //multiDecorator - Utilizando vários decoradores para adicionar vários comportamentos ao objeto
            var multiDecorator = new TrailerDecorator(new PostCreditDecorator(movie));

            //Resultados
            Console.WriteLine("--Usando o objeto sem decorar--");
            movie.Show();
            Console.WriteLine($"\n--Usando o objeto decorado com {nameof(PostCreditDecorator)}--");
            postCreditDecorator.Show();
            Console.WriteLine($"\n--Usando o objeto decorado com {nameof(TrailerDecorator)}--");
            trailerDecorator.Show();
            Console.WriteLine($"\n--Usando o objeto decorado com {nameof(PostCreditDecorator)} e {nameof(TrailerDecorator)}--");
            multiDecorator.Show();

            Register(false, nameof(RunDecoratorSample));
        }
        #endregion
        #region Facade
        private static void RunFacadeSample()
        {
            Register(true, nameof(RunDecoratorSample));

            //Exemplo sem o uso do facade
            ExecuteWithoutFacade();

            //Exemplo com o uso do facade
            ExecuteWithFacade();

            Register(false, nameof(RunDecoratorSample));
        }

        private static void ExecuteWithoutFacade()
        {
            Console.WriteLine($"--Exemplo sem o Facade--");
            //Necessário conhecimento das classes do subsistema no cliente que aumenta o acoplamento
            //Classes do subsistema de salarios: OfficerService, HumanResources
            var _officerService = new OfficerService();
            var _humanResources = new HumanResources();

            List<string> employees = new() { "10", "123", "15" };

            //O cliente tem que interagir diretamente com as classes do subsistema
            foreach (var employee in employees)
            {
                int branchOffice = _officerService.GetEmployeeBranchOffice(employee);
                int occupation = _officerService.GetEmployeeOccupation(employee);
                if (branchOffice == default || occupation == default)
                {
                    Console.WriteLine($"{employee} - Não é um funcionário");
                    continue;
                }
                var salary = _humanResources.GetSalary(occupation, branchOffice);

                //Apesar de toda complexadide e acoplamento o uso sem o facade permite ao cliente acessar
                //metodos para o subsistema que não estão acessíveis pelo facade
                string employeeName = _humanResources.GetEmployeeName(employee);
                Console.WriteLine($"Funcionário: {employee}-{employeeName}, Salario: R${salary:n2}");
            }
        }
        private static void ExecuteWithFacade()
        {
            Console.WriteLine($"\n--Exemplo com o uso do Facade--");
            //IFacade: interface simplicada para o subsistema de salarios
            //SalaryFacade: implementação do facade
            IFacade salaryFacade = new SalaryFacade();

            //Usuário chamando metodo pelo facade, sem necessidade de conhecer
            //nenhum detalhe das classes do subsistema
            salaryFacade.ShowSalary("10", "123", "15");
        }
        #endregion
        #region Flyweight
        private static void RunFlyweightSample()
        {
            Register(true, nameof(RunFlyweightSample));

            Console.WriteLine("Criando os Flyweights: ILampTypes e os Objetos de contexto com os dados extrínsecos: Lamps");
            //LampTypeFactory - FlyweightFactory, não acha o Flyweight no pool e o adiciona lá
            //WhiteType - Instancia do flyweight concreto
            var WhiteType = LampTypeFactory.GetLampType(EColor.White, 9, 5000);
            //Lamp -  objeto de contexto tem os dados extrínsecos e o link para o flyweight ILampType que contem dados intrínsecos
            var lamp1 = new Lamp(WhiteType, 1, 1);
            var lamp2 = new Lamp(WhiteType, 1, 3);

            //LampTypeFactory - FlyweightFactory, não acha o Flyweight no pool e o adiciona lá
            //yellowType - Instancia do flyweight concreto
            var yellowType = LampTypeFactory.GetLampType(EColor.Yellow, 12, 4500);
            //Lamp -  objeto de contexto tem os dados extrínsecos e o link para o flyweight ILampType que contem dados intrínsecos
            var lamp3 = new Lamp(yellowType, 3, 6);
            var lamp4 = new Lamp(yellowType, 5, 10);

            //LampTypeFactory - FlyweightFactory, retorna o Flyweight do pool que consegue encontrar pois ja foi adicionado acima
            //Lamp -  objeto de contexto tem os dados extrínsecos e o link para o flyweight ILampType que contem dados intrínsecos
            var lamp5 = new Lamp(LampTypeFactory.GetLampType(EColor.White, 9, 5000), 2, 8);
            var lamp6 = new Lamp(LampTypeFactory.GetLampType(EColor.Yellow, 12, 4500), 4, 7);

            //Shed - Objeto de contexto, contem os lamps
            var sheld = new Shed();
            sheld.SetLamps(lamp1, lamp2, lamp3, lamp4, lamp5, lamp6);
            //Shed ligando as luzes que estão nela, que chama os Lamps e eles passam ao metodo turnOn dos flyweight os dados necessários para executar a ação
            //Temos seis Lamps e apenas 2 flyweight deixando a aplicação mais leve
            Console.WriteLine("\nChamando comportamento dos flyweight passando os dados extrínsecos");
            sheld.TurnOnLamps();

            Register(false, nameof(RunFlyweightSample));
        }
        #endregion
        #region Proxy
        private static void RunProxySample()
        {
            Register(true, nameof(RunProxySample));

            string fileKey = "123456";

            //Criando o ConcreteSubject: Storage - Sem o uso do proxy, sem o controle do lazy load
            Console.WriteLine("--- SEM USO DO PROXY ---");
            IStorage storage = new Storage();
            storage = new Storage();
            //Chama os comportamentos padrões sem uso do proxy
            storage.GetFile(fileKey);
            storage.DeleteFile(fileKey);
            storage.CloseFile(fileKey);

            //Criando o Proxy: StorageProxy - com controle de lazy load para o objeto Real
            Console.WriteLine("\n--- COM USO DO PROXY ---");
            IStorage proxy = new StorageProxy();

            // Chama os comportamentos através do proxy

            // O proxý.GetFile - Adição de logs e só inicializa na hora de usar se já não estiver, passa ao objeto
            proxy.GetFile(fileKey);
            // O proxy.DeleteFile - Adição de logs e só inicializa na hora de usar se já não estiver, e trata bloqueio antes de passar ao objeto real - Bloaqueado
            proxy.DeleteFile(fileKey);
            // O proxý.CloseFile - Adição de logs e só inicializa na hora de usar se ja não estiver, passa ao objeto
            proxy.CloseFile(fileKey);
            // O proxý.DeleteFile - Adição de logs e só inicializa na hora de usar se ja não estiver, e trata bloqueio antes de passar ao objeto real - Desbloqueado
            proxy.DeleteFile(fileKey);

            Register(false, nameof(RunProxySample));

        }
        #endregion

        #region Chain of Responsibility
        private static void RunChainOfResponsibilitySample()
        {
            Register(true, nameof(RunChainOfResponsibilitySample));
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

            Register(false, nameof(RunChainOfResponsibilitySample));
        }
        #endregion
        #region Command
        private static void RunCommandSample()
        {
            Register(true, nameof(RunCommandSample));

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

            Register(false, nameof(RunCommandSample));
        }
        private static ICommand CreateCommand(PromotionService receiver, List<string> clients, DateTime expirationDate, string department)
        {
            //Criando o comando
            var command = new AlertCommand(receiver, clients, expirationDate, department);
            return command;
        }
        #endregion
        #region Interpreter
        private static void RunInterpreterSample()
        {
            Register(true, nameof(RunInterpreterSample));
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

            Register(false, nameof(RunInterpreterSample));
        }
        #endregion
        #region Iterator
        private static void RunIteratorSample()
        {
            Register(true, nameof(RunIteratorSample));

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

            Register(false, nameof(RunIteratorSample));
        }
        #endregion

        private static void Register(bool start, string method)
        {
            var prefix = start ? "Inicio" : "Fim";
            Console.WriteLine($"\n{prefix} - {method}\n");
        }
    }
}
