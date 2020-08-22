using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rekenen
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }
        public static RekenenLijst mijnrekenen = new RekenenLijst();
        private void button1_Click(object sender, EventArgs e)
        {
            overzicht oef = new overzicht();
            oef.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accountmaken oef = new Accountmaken();
            oef.Show();
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            Rekening reken1 = new Debit("Latha","BE68 5390 0754 7034", 100000,26);
            Rekening reken2 = new Debit("Atchaya", "BE68 5390 0754 7025", 100000, 36);
            Rekening reken3 = new Debit("Swetha", "BE68 5390 0754 7021", 100000, 41);
            Rekening reken4 = new Credit("Bhavana", "BE68 5390 0754 5000", 100000, 56, "577");
            Rekening reken5 = new Credit("Saravana", "BE68 5390 0754 5001", 100000, 81, "771");
            Rekening reken6 = new SpaarRekening("Priya", "BE68 5390 0754 6000", 100000,52);
            Rekening reken7 = new SpaarRekening("kavitha", "BE68 5390 0754 5014", 100000, 29);
            Rekening reken8 = new SpaarRekening("Vishnu", "BE68 5390 0754 4561", 100000, 27);
            mijnrekenen.RekenLijst.Add(reken1);
            mijnrekenen.RekenLijst.Add(reken2);
            mijnrekenen.RekenLijst.Add(reken3);
            mijnrekenen.RekenLijst.Add(reken4);
            mijnrekenen.RekenLijst.Add(reken5);
            mijnrekenen.RekenLijst.Add(reken6);
            mijnrekenen.RekenLijst.Add(reken7);
            mijnrekenen.RekenLijst.Add(reken8);



        }
    }
}
