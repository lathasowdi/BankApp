using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekenen
{
    public class Credit:Rekening
    {
        public int CVV { get; set; }
        public Credit(string eigenaar, string accountNumber, double saldo, int leeftijd, int cvv) : base(eigenaar, accountNumber, saldo, leeftijd)
        {
            CVV = cvv;
        }
        public override string Beschrijf()
        {
            return base.Beschrijf() + $" CVV: {CVV}.";
        }
        

    }
}
