using DesignPatternSamples.CreationalPatterns.Prototype.Interfaces;
using System;

namespace DesignPatternSamples.CreationalPatterns.Prototype.Entities
{
    public class TrafficPenalty : IPenalty
    {
        //Private Fields
        private readonly decimal ApplicableDiscount;
        private readonly decimal BaseValue = 300M;

        public TrafficPenalty(Infringement infringement)
        {
            Id = Guid.NewGuid();
            Infringement = infringement;
            ApplicableDiscount = Infringement?.TimeToExpiration > 10 ? 0.10M : 0.20M;
            CompetencyDate = DateTime.Now.AddMonths(-1);
        }

        public Guid Id { get; private set; }
        public string Description { get { return $"Multa Transito {Infringement.Name} - {Value}"; } }
        public decimal Value { get => BaseValue * (1 - ApplicableDiscount); }
        public Infringement Infringement { get; private set; }
        public DateTime CompetencyDate { get; private set; }

        //DeepCopy method
        public IPenalty DeepCopy()
        {
            var Clone = (TrafficPenalty)MemberwiseClone();
            Clone.Infringement = (Infringement)Infringement.Clone();

            return Clone;
        }
        public IPenalty ShallowCopy()
        {
            return (IPenalty)MemberwiseClone();
        }

        //Can create a initializer method to cliente Customize some fields of clone
        public void Initializer(DateTime competencyDate)
        {
            Id = Guid.NewGuid();
            CompetencyDate = competencyDate;
        }

        public void SetInfringement(Infringement infringement)
        {
            if (infringement != default)
                Infringement = infringement;
        }

        public override string ToString()
        {
            return $"TrafficPenalty - Id:{Id}, Description:{Description}, Value:{Value:n2}, CompetencyDate:{CompetencyDate}, {Infringement};";
        }


    }

}
