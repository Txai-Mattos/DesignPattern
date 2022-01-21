using CreationalPatterns.Builder.Entities.Builders;

namespace CreationalPatterns.Builder.Entities
{
    //Director
    public class DragonTrainer
    {
        //can be the builder common interface but a dont create then
        private readonly DragonBuilder _dragonBuilder;

        public DragonTrainer(DragonBuilder dragonBuilder)
        {
            _dragonBuilder = dragonBuilder;
        }

        public Dragon CreateSmallerEarthDragon(string name)
        {
            _dragonBuilder.WithName(name)
                .WithColor(EColor.Green)
                .WithMaster(false)
                .WithAge(1)
                .WithTail("Small")
                .WithFeet("Small")
                .WithWing(new WingBuilder()
                            .WithColor(EColor.Gray)
                            .WithVelocity(15)
                            .WithHighestAltitude(50)
                            .Build());
            _dragonBuilder
                    .WithHead(x =>
                            x.WithColor(EColor.Pink)
                            .WithPersonality("Brave")
                            .WithPower("Earth"));

            //because a have only one type of product and only one Builder type to dragons step a can return product directly
            return _dragonBuilder.Build();
        }
    }
}
