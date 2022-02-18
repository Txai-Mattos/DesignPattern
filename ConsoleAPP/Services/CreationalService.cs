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
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternSamples.ConsoleAPP.Services
{
    public static class CreationalService
    {
        #region Factory Method
        public static void RunFactoryMethodSample()
        {
            var pc1 = new RedHatPC("PC1-RedHat");
            var pc2 = new OfficePC("PC2-Office");
            var pc3 = new ApplePC("PC3-Apple");

            LogIntoPcs(pc1, pc2, pc3);
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
        public static void RunAbstractFactorySample()
        {
            IVehicleFactory factory = new PoliceVehicleFactory();
            Console.WriteLine($"Tipo de fabrica gerada: {factory.GetType().Name}");
            CreateSameTypeVehicle(factory);

            factory = new SportVehicleFactory();
            Console.WriteLine($"\nTipo de fabrica gerada: {factory.GetType().Name}");
            CreateSameTypeVehicle(factory);
        }
        private static void CreateSameTypeVehicle(IVehicleFactory factory)
        {
            Console.WriteLine(factory.CreateAirplane());
            Console.WriteLine(factory.CreateCar());
            Console.WriteLine(factory.CreateShip());
        }
        #endregion
        #region Builder
        public static void RunBuilderSample()
        {
            WithoutDirectorSample();

            WithDirectorSample();
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
        public static void RunPrototypeSample()
        {
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
        }
        #endregion
        #region Singleton
        public static void RunSingletonSample()
        {
            int[] threads = new int[50];
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
        }
        #endregion
    }
}
