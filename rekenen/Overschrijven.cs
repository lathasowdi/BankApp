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
    public partial class Overschrijven : Form
    {
        public Overschrijven()
        {
            InitializeComponent();
        }

        private void Overschrijven_Load(object sender, EventArgs e)
        {
            List<string> acc = new List<string>();
           comboBox1.DataSource = null;
           comboBox1.DataSource = overzicht.customs;

           comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Reek = overzicht.vraag;
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Select a rekening nummer");
            }
            double amt = 0;
            double min = 0;
            bool isDebit = false;

            foreach (var item in MENU.mijnrekenen.RekenLijst.OfType<Debit>())
            {
                if (item.AccountNumber == Reek)
                {
                    min = item.Saldo;
                    isDebit = true;
                }
            }


            if (textBox1.Text.Trim().Length < 1)
            {
                MessageBox.Show("Bedraag invullen A.U.B");
            }
            else
            {
                amt = Convert.ToDouble(textBox1.Text.Trim());

                if (isDebit && amt > min)
                {
                    MessageBox.Show("Kleiner Bedraag invullen A.u.B (" + min + ")");
                }
                else
                {
                    foreach (var item in MENU.mijnrekenen.RekenLijst)
                    {
                        if (item.AccountNumber == Reek)
                        {
                            item.Saldo -= amt;
                            label4.Text = $"Saldo:{item.Saldo}";
                        }
                        if (item.AccountNumber == comboBox1.SelectedItem.ToString())
                        {
                            item.Saldo += amt;
                            label4.Text = $"Saldo:{item.Saldo}";
                        }
                    }
                    
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
