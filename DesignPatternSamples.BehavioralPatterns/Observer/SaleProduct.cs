namespace DesignPatternSamples.BehavioralPatterns.Observer
{
    public class SaleProduct
    {
        public string Description { get; set; }
        public int Amount { get; set; }

        public override string ToString()
         => $"Descrição: {Description}, quantidade: {Amount}";
    }
}
