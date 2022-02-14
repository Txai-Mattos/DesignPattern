using DesignPatternSamples.CrossCutting.Extensions;
using System;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Command.Receivers
{
    public class PromotionService
    {
        public void SendPromotionVoucher(List<string> clients, DateTime expirationDate, string department)
        {
            clients.ForEach(client =>
            {
                this.Write($"parabens {client}! você recebeu um voucher de promoção no setor {department}, com validade {expirationDate:d}");
            });
        }
    }
}
