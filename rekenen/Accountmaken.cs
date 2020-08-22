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
    public partial class Accountmaken : Form
    {
        public Accountmaken()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (groupBox1.Enabled == true && textBox1.Text.Trim().Length > 0 && textBox2.Text != " ")
            {
                foreach (RadioButton item in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (radioButton1.Checked == true)
                    {
                        Rekening deb = new Debit(textBox1.Text.Trim(), RekeningNummer(), 10000, Convert.ToInt32(textBox2.Text));
                        MENU.RekenLijst.Add(deb);
                        break;
                       
                    }
                    else if (radioButton2.Checked == true)
                    {
                        Rekening cre = new Credit(textBox1.Text.Trim(), RekeningNummer(), 10000, Convert.ToInt32(textBox2.Text), CVC());
                        MENU.RekenLijst.Add(cre);
                        break;
                        
                    }
                    else if (radioButton3.Checked == true)
                    {
                        Rekening spa = new SpaarRekening(textBox1.Text.Trim(), RekeningNummer(), 10000, Convert.ToInt32(textBox2.Text));
                        MENU.RekenLijst.Add(spa);
                        break;
                    }
                    else
                        MessageBox.Show("Account kiezen A.u.b");
                }
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Account created");
            }

            else if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Naam invullen A.u.B");
            }
            else if (textBox2.Text == " ")
            {
                MessageBox.Show("Leeftijd invullen A.u.B");
            }
            else if (groupBox1.Enabled == false)
            {
                MessageBox.Show("Account kiezen A.u.b");
            }
        }

       public static string RekeningNummer()
        {
            string rek = "BE";
            Random rnd = new Random();
            while (rek.Length < 16)
            {
                rek += rnd.Next(0, 9).ToString();
            }

            for (int i = 4; i < rek.Length; i += 5)
            {
                rek = rek.Insert(i, " ");
            }


            return rek;
        }
        public int CVC()
        {
            int cvc =10;
            for (int i = 0; i < 3; i++)
            {
                Random rnd = new Random();
                cvc = Convert.ToInt32(cvc.ToString() + rnd.Next(0, 9).ToString());
                System.Threading.Thread.Sleep(100);
            }
            return cvc;
        }

        private void Accountmaken_Load(object sender, EventArgs e)
        {
           
        }
    }
}
