using DesignPatternSamples.CrossCutting;
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
using System.Collections.Generic;
using IComponentComposite = DesignPatternSamples.StructuralPatterns.Composite.Abstractions.IComponent;

namespace DesignPatternSamples.ConsoleAPP.Services
{
    public static class StructuralService
    {
        #region Adpter
        public static void RunAdapterSample()
        {
            Execute.Register(true, nameof(RunAdapterSample));

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
            Execute.Register(false, nameof(RunAdapterSample));
        }
        #endregion
        #region Bridge
        public static void RunBrigdeSample()
        {
            Execute.Register(true, nameof(RunBrigdeSample));

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

            Execute.Register(false, nameof(RunBrigdeSample));
        }
        #endregion
        #region Composite
        public static void RunCompositeSample()
        {
            Execute.Register(true, nameof(RunCompositeSample));

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


            Execute.Register(false, nameof(RunCompositeSample));
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
        public static void RunDecoratorSample()
        {
            Execute.Register(true, nameof(RunDecoratorSample));
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

            Execute.Register(false, nameof(RunDecoratorSample));
        }
        #endregion
        #region Facade
        public static void RunFacadeSample()
        {
            Execute.Register(true, nameof(RunFacadeSample));

            //Exemplo sem o uso do facade
            ExecuteWithoutFacade();

            //Exemplo com o uso do facade
            ExecuteWithFacade();

            Execute.Register(false, nameof(RunFacadeSample));
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
        public static void RunFlyweightSample()
        {
            Execute.Register(true, nameof(RunFlyweightSample));

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

            Execute.Register(false, nameof(RunFlyweightSample));
        }
        #endregion
        #region Proxy
        public static void RunProxySample()
        {
            Execute.Register(true, nameof(RunProxySample));

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

            Execute.Register(false, nameof(RunProxySample));

        }
        #endregion
    }
}
