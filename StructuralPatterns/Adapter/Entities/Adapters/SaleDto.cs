using System;
using System.Collections.Generic;

namespace DesignPatternSamples.StructuralPatterns.Adapter.Entities.Adapters
{
    public class SaleDto
    {
        public string SalerId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        public static List<SaleDto> Load()
        {
            var list = new List<SaleDto>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new SaleDto()
                {
                    SalerId = i.ToString(),
                    Value = (i + 1) * 1000M,
                    Date = DateTime.Now.AddMonths(i),
                });
            }
            return list;
        }

        public override string ToString()
        {
            return $"Date: {Date} - R$ {Value:n2}";
        }
    }
}
