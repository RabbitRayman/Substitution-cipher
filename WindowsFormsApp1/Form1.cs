using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = File.ReadAllText(Form2.filename.fname).ToUpper();
            textBox2.Text = File.ReadAllText(Form2.filename.fname).ToUpper();
            dataGridView1.DataSource = quant("2.txt").ToArray();
            dataGridView2.DataSource = quant(Form2.filename.fname).ToArray();
            dataGridView3.DataSource = quantbi("2.txt").ToArray();
            dataGridView5.DataSource = quantbi(Form2.filename.fname).ToArray();
            dataGridView4.DataSource = quanttri("2.txt").ToArray();
            dataGridView6.DataSource = quanttri(Form2.filename.fname).ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            cancel();
        }
        void cancel()
        {
            textBox3.Text = "А";
            textBox4.Text = "Б";
            textBox5.Text = "В";
            textBox8.Text = "Г";
            textBox7.Text = "Д";
            textBox6.Text = "Е";
            textBox11.Text = "Ё";
            textBox10.Text = "Ж";
            textBox9.Text = "З";
            textBox14.Text = "И";
            textBox13.Text = "Й";
            textBox12.Text = "К";
            textBox20.Text = "Л";
            textBox19.Text = "М";
            textBox18.Text = "Н";
            textBox17.Text = "О";
            textBox16.Text = "П";
            textBox15.Text = "Р";
            textBox35.Text = "С";
            textBox34.Text = "Т";
            textBox33.Text = "У";
            textBox32.Text = "Ф";
            textBox31.Text = "Х";
            textBox30.Text = "Ц";
            textBox29.Text = "Ч";
            textBox28.Text = "Ш";
            textBox27.Text = "Щ";
            textBox26.Text = "Ъ";
            textBox25.Text = "Ы";
            textBox24.Text = "Ь";
            textBox23.Text = "Э";
            textBox22.Text = "Ю";
            textBox21.Text = "Я";
        }
        Dictionary<string, double> quant(string fn)
        {
            Dictionary<string, double> quantity = new Dictionary<string, double>();
            double n1 = 0;
            foreach (char c in File.ReadAllText(fn))
            {
                if (((c >= 'А') && (c <= 'я')) || (c == 'ё') || (c == 'Ё'))
                {
                    if (quantity.ContainsKey(Char.ToUpper(c).ToString()))
                    {
                        quantity[Char.ToUpper(c).ToString()]++;
                    }
                    else
                    {
                        quantity.Add(Char.ToUpper(c).ToString(), 1);
                    }
                    n1++;
                  
                }
            }
            foreach (string s in quantity.Keys.ToList())
            {
                quantity[s] = quantity[s] / n1;
            }
            quantity = quantity.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return quantity;
        }
        Dictionary<string, double> quantbi(string fn)
        {
            Dictionary<string, double> quantity = new Dictionary<string, double>();
            string c2 = "";
            double n2 = 0;
            foreach (char c in File.ReadAllText(fn))
            {
                c2 += Char.ToUpper(c);
                if (((c >= 'А') && (c <= 'я')) || (c == 'ё') || (c == 'Ё'))
                {
                    if (c2.Length == 2)
                    {
                        if (quantity.ContainsKey(c2))
                        {
                            quantity[c2]++;
                        }
                        else
                        {
                            quantity.Add(c2, 1);
                        }
                        n2++;
                    }
                    c2 = Char.ToUpper(c).ToString();
                }
                else
                {
                    c2 = "";
                }
            }
            foreach (string s in quantity.Keys.ToList())
            {
                quantity[s] = quantity[s] / n2;
            }
            quantity = quantity.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return quantity;
        }
        Dictionary<string, double> quanttri(string fn)
        {
            Dictionary<string, double> quantity = new Dictionary<string, double>();
            string c2 = "";
            string c3 = "";
            double n3 = 0;
            foreach (char c in File.ReadAllText(fn))
            {
                c2 += Char.ToUpper(c);
                c3 += Char.ToUpper(c);
                if (((c >= 'А') && (c <= 'я')) || (c == 'ё') || (c == 'Ё'))
                {
                    if (c3.Length == 3)
                    {
                        if (quantity.ContainsKey(c3))
                        {
                            quantity[c3]++;
                        }
                        else
                        {
                            quantity.Add(c3, 1);
                        }
                        n3++;
                    }
                    c3 = c2;
                    c2 = Char.ToUpper(c).ToString();
                }
                else
                {
                    c2 = "";
                    c3 = "";
                }
            }
            foreach (string s in quantity.Keys.ToList())
            {
                quantity[s] = quantity[s] / n3;
            }
            quantity = quantity.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return quantity;
        }
        bool changetext(TextBox tb, char c1, char c2)
        {
            if (c1 == 8)
            {
                return true;
            }
            else if ((((c1 >= 'А') && (c1 <= 'я')) || (c1 == 'ё') || (c1 == 'Ё')) && (tb.TextLength == 0))
            {
                textBox2.Text = textBox2.Text.Replace(c2, Char.ToLower(c1));
                tb.Text = Char.ToLower(c1).ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox3,e.KeyChar,'А')) e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox4, e.KeyChar, 'Б')) e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox5, e.KeyChar, 'В')) e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox8, e.KeyChar, 'Г')) e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox7, e.KeyChar, 'Д')) e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox6, e.KeyChar, 'Е')) e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox11, e.KeyChar, 'Ё')) e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox10, e.KeyChar, 'Ж')) e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox9, e.KeyChar, 'З')) e.Handled = true;
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox14, e.KeyChar, 'И')) e.Handled = true;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox13, e.KeyChar, 'Й')) e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox12, e.KeyChar, 'К')) e.Handled = true;
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox20, e.KeyChar, 'Л')) e.Handled = true;
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox19, e.KeyChar, 'М')) e.Handled = true;
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox18, e.KeyChar, 'Н')) e.Handled = true;
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox17, e.KeyChar, 'О')) e.Handled = true;
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox16, e.KeyChar, 'П')) e.Handled = true;
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox15, e.KeyChar, 'Р')) e.Handled = true;
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox35, e.KeyChar, 'С')) e.Handled = true;

        }

        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox34, e.KeyChar, 'Т')) e.Handled = true;
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox33, e.KeyChar, 'У')) e.Handled = true;
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox32, e.KeyChar, 'Ф')) e.Handled = true;
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox31, e.KeyChar, 'Х')) e.Handled = true;
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox30, e.KeyChar, 'Ц')) e.Handled = true;
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox29, e.KeyChar, 'Ч')) e.Handled = true;
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox28, e.KeyChar, 'Ш')) e.Handled = true;
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox27, e.KeyChar, 'Щ')) e.Handled = true;
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox26, e.KeyChar, 'Ъ')) e.Handled = true;
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox25, e.KeyChar, 'Ы')) e.Handled = true;
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox24, e.KeyChar, 'Ь')) e.Handled = true;
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox23, e.KeyChar, 'Э')) e.Handled = true;
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox22, e.KeyChar, 'Ю')) e.Handled = true;
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!changetext(textBox21, e.KeyChar, 'Я')) e.Handled = true;
        }
    }
}
