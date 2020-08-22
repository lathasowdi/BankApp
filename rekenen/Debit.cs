using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekenen
{
    public class Debit : Rekening
    {

        public Debit(string eigenaar, string accountNumber, double saldo, int leeftijd) : base(eigenaar, accountNumber, saldo, leeftijd)
        {

        }
          
        public override string Beschrijf()
        {
            return base.Beschrijf();
        }

    }
}
