using CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories;
using CreationalPatterns.AbstractFactory.Entities.Concrete.Factories;
using CreationalPatterns.Builder.Entities;
using CreationalPatterns.Builder.Entities.Builders;
using CreationalPatterns.FactoryMethod;
using CreationalPatterns.FactoryMethod.Entites.Concrete.PC;
using CreationalPatterns.Prototype.Entities;
using CreationalPatterns.Prototype.Interfaces;
using CreationalPatterns.Singleton.Entitie;
using DesignPatternSamples.StructuralPatterns.Bridge.AbstractionSide;
using DesignPatternSamples.StructuralPatterns.Bridge.ImplementationSide;
using DesignPatternSamples.StructuralPatterns.Composite;
using StructuralPatterns.Adapter.Entities.Adaptees;
using StructuralPatterns.Adapter.Entities.Adapters;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAPP
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Creational patterns
            RunFactoryMethodSample();
            RunAbstractFactorySample();
            RunBuilderSample();
            RunPrototypeSample();
            RunSingletonSample();

            //Structural patterns
            RunAdapterSample();
            RunBrigdeSample();
            RunCompositeSample();

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

            IComponent room, house;
            GenerateHouseStrucure(out room, out house);

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
        private static void GenerateHouseStrucure(out IComponent room, out IComponent house)
        {
            //Criando o composite: generalbathroom com as folhas: Window, Door            
            IComponent generalbathroom = new Room("Banheiro - Principal");
            generalbathroom.Add(new Window("Veneziana"), new Door("Porta"));

            //Criando o composite: room com os filhos: 2x Window, Door, e o composite:suitbathroom com os filhos dele
            IComponent suitBathroom = new Room("Banheiro - Secundário");
            suitBathroom.Add(new Window("Veneziana"), new Door("Porta de banheiro"));
            room = new Room("Quarto");
            room.Add(new Window("Janela Esquerda"), new Window("Janela Frente"), new Door("Porta quarto"), suitBathroom);

            //Criando nosso compose raiz:house e adicionando os filhos:Door, room, generalbathroom
            house = new Room("Casa");
            house.Add(new Door("Porta da casa"), room, generalbathroom);
        }
        #endregion

        private static void Register(bool start, string method)
        {
            var prefix = start ? "Inicio" : "Fim";
            Console.WriteLine($"\n{prefix} - {method}\n");
        }
    }
}
