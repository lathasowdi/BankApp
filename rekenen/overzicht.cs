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
        public static List<string> customs = new List<string>();
        public static string vraag = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("DEBIT REKENING");
            listBox1.Items.Add("CREDIT REKENING");
            listBox1.Items.Add("SPAAR REKENING");
            listBox2.Visible = false;
            button2.Visible = false;
            button1.Enabled = false;
        }

        public void ListBoxData(string selectedItem)
        {
            switch (selectedItem)
            {
                case "DEBIT REKENING":
                    List<Debit> deb = new List<Debit>();

                    foreach (var item in MENU.mijnrekenen.RekenLijst.OfType<Debit>())
                    {
                        deb.Add(item);
                    }

                    listBox2.DataSource = null;
                    listBox2.DataSource = deb;
                    if (listBox2.DataSource != null && listBox2.Items.Count > 0)
                    {
                        button1.Enabled = true;
                    }
                    else
                    {
                        button1.Enabled = false;
                    }

                    break;

                case "CREDIT REKENING":
                    List<Credit> credit = new List<Credit>();

                    foreach (var item in MENU.mijnrekenen.RekenLijst.OfType<Credit>())
                    {
                        credit.Add(item);
                    }

                    listBox2.DataSource = null;
                    listBox2.DataSource = credit;
                    button1.Enabled = true;
                    break;

                case "SPAAR REKENING":
                    List<SpaarRekening> spaar = new List<SpaarRekening>();

                    foreach (var item in MENU.mijnrekenen.RekenLijst.OfType<SpaarRekening>())
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
                listBox2.Visible = true;
                listBox2.Text = selected.Beschrijf();
                if (selected.Saldo == 0 && listBox1.SelectedItem.ToString() == "DEBIT REKENING")
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
                listBox2.Visible = false;
                listBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ind = -1;
            int sel = -1;
            foreach (var item in MENU.mijnrekenen.RekenLijst)
            {
                ind++;
                if (item.AccountNumber == listBox2.SelectedItem.ToString())
                {
                    sel = ind;
                }
            }

            MENU.mijnrekenen.RekenLijst.RemoveAt(sel);

            LabelBeschrijving();
            ListBoxData(listBox1.SelectedItem.ToString());
            if (listBox2 != null && listBox2.SelectedItems.Count > 0)
            {
               button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           customs.Clear();
            foreach (var item in MENU.mijnrekenen.RekenLijst)
            {
                if (listBox2.SelectedItem.ToString() != item.AccountNumber.ToString())
                {
                    customs.Add(item.AccountNumber.ToString());
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
                ListBoxData(listBox1.SelectedItem.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxData(listBox1.SelectedItem.ToString());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelBeschrijving();
        }
    }
    }

