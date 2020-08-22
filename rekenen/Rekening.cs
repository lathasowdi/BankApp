using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekenen
{
    public class Rekening
    {
        public string Eigenaar { get; set; }
        public int Leeftijd { get; set; }
        public string AccountNumber { get; set; }
        public double Saldo { get; set; }
       

        public Rekening(string eigenaar, string accountNumber,double saldo, int leeftijd)
        {
            Eigenaar = eigenaar;
            AccountNumber = accountNumber;
            Saldo = saldo;
            Leeftijd= leeftijd;
        }
        public virtual string Beschrijf()
        {
            string beschrijving;
            beschrijving = $"Uw Naam is {Eigenaar}" + "\n"
                           + $"Uw Saldo is { Saldo }" + "\n"
                          + $"Uw AccountNumber is {AccountNumber }" + "\n"
                           + $"Uw Leeftijd is { Leeftijd }"; 
            return beschrijving;
        }

        public override string ToString()
        {
            return AccountNumber;
        }


    }
}
