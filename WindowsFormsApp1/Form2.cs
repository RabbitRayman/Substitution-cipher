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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static class filename
        {
            public static string fname { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название файла");
            }
            else
            {
                filename.fname = textBox1.Text;
                try
                {
                    FileStream fs = File.Open(filename.fname,FileMode.Open);
                    fs.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                    Close();
                }
                catch(Exception q)
                {
                    MessageBox.Show("Error: " + q.Message);
                }
            }
        }
    }
}
