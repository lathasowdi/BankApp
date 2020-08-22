using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekenen
{
    public class SpaarRekening:Rekening
    {
        public SpaarRekening(string eigenaar, string accountNumber, double saldo, int leeftijd) : base(eigenaar, accountNumber, saldo, leeftijd)
        {

        }
        public override string Beschrijf()
        {
            return base.Beschrijf();
        }
    }
}
