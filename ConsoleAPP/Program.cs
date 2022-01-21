using CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories;
using CreationalPatterns.AbstractFactory.Entities.Concrete.Factories;
using CreationalPatterns.Builder.Entities;
using CreationalPatterns.Builder.Entities.Builders;
using CreationalPatterns.FactoryMethod;
using CreationalPatterns.FactoryMethod.Entites.Concrete.PC;
using System;

namespace ConsoleAPP
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            RunFactoryMethodSample();
            RunAbstractFactorySample();
            RunBuilderSample();

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
            var director = new DragonTrainer(new DragonBuilder());

            Console.WriteLine("\nWith Director Sample:\n" + director.CreateSmallerEarthDragon("Caçula"));
        }
        #endregion


        private static void Register(bool start, string method)
        {
            var prefix = start ? "Inicio" : "Fim";
            Console.WriteLine($"\n{prefix} - {method}\n");
        }
    }
}
