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
    public partial class overzicht : Form
    {
        public overzicht()
        {
            InitializeComponent();
        }
        public static List<string> Accountnumber = new List<string>();
        public static string vraag = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("DEBIT REKENING");
            comboBox1.Items.Add("CREDIT REKENING");
            comboBox1.Items.Add("SPAAR REKENING");
            button2.Visible = false;
            button1.Enabled = false;
        }

        public void ListBoxData(string selectedItem)
        {
            switch (selectedItem)
            {
                case "DEBIT REKENING":
                    List<Debit> deb = new List<Debit>();

                    foreach (var item in MENU.RekenLijst.OfType<Debit>())
                    {
                        deb.Add(item);
                    }
                    listBox2.DataSource = null;
                    listBox2.DataSource = deb;
                    if (listBox2.DataSource != null && listBox2.Items.Count > 0)
                    {
                        button1.Enabled = true;
                        button2.Visible = true;
                        button2.Enabled = true;
                    }
                    break;

                case "CREDIT REKENING":
                    List<Credit> credit = new List<Credit>();

                    foreach (var item in MENU.RekenLijst.OfType<Credit>())
                    {
                        credit.Add(item);
                    }
                    listBox2.DataSource = null;
                    listBox2.DataSource = credit;
                    if (listBox2.DataSource != null && listBox2.Items.Count > 0)
                    {
                        button1.Enabled = true;
                    }
                    break;

                case "SPAAR REKENING":
                    List<SpaarRekening> spaar = new List<SpaarRekening>();

                    foreach (var item in MENU.RekenLijst.OfType<SpaarRekening>())
                    {
                        spaar.Add(item);
                    }
                    listBox2.DataSource = null;
                    listBox2.DataSource = spaar;
                    button1.Enabled = false;
                    break;

                default:
                    break;
            }
        }
        public void LabelBeschrijving()
        {
           Rekening selected = (Rekening)listBox2.SelectedItem;

            if (listBox2.DataSource != null)
            {
                label1.Visible = true;
                label1.Text = selected.Beschrijf();
                if (selected.Saldo != 0 && comboBox1.SelectedItem.ToString() == "DEBIT REKENING")
                {
                    button2.Visible = true;
                }
                else
                {
                    button2.Visible = false;
                }
            }
            else
            {
                button2.Visible = false;
               label1.Visible = false;
               label1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ind = -1;
            int sel = -1;
            bool remove = false;
            foreach (var item in MENU.RekenLijst)
            {
                ind++;
                if (item.Saldo==0)
                {
                    sel = ind;
                    remove = true;
                }
            }
            MENU.RekenLijst.RemoveAt(sel);
            LabelBeschrijving();
            ListBoxData(comboBox1.SelectedItem.ToString());
            if (listBox2 != null && listBox2.SelectedItems.Count > 0)
            {
               button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            if (remove)
                MessageBox.Show($"{MENU.RekenLijst[sel] }is verwijderen");
            else
                MessageBox.Show("Alle RekeningNummber heeft geld");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accountnumber.Clear();
            foreach (var item in MENU.RekenLijst)
            {
                if (listBox2.SelectedItem.ToString() != item.AccountNumber.ToString())
                {
                    Accountnumber.Add(item.AccountNumber.ToString());
                }
                else
                {
                    vraag = item.AccountNumber.ToString();
                }
            }

            Overschrijven overschrijven = new Overschrijven();

            if (overschrijven.ShowDialog() == DialogResult.OK)
            {
                LabelBeschrijving();
                ListBoxData(comboBox1.SelectedItem.ToString());
                MessageBox.Show($"Overschrijven gedaan Rekening Nummber van {vraag} te {Overschrijven.ontvanger}");
            }
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelBeschrijving();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxData(comboBox1.SelectedItem.ToString());
        }
    }
    }

