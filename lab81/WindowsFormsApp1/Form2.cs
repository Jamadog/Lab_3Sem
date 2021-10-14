using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static int x = 0;
        public static int y = 0;
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Input Size";
            this.BackColor = Color.GreenYellow;

            textBox1.KeyPress += textBox1_KeyPress;
            textBox2.KeyPress += textBox2_KeyPress;

            button1.Text = "Enter";

            label1.Text = "width = " + x.ToString();
            label2.Text = "height = " + y.ToString();

        }

        private void label1_Click(object sender, EventArgs e){ }

        private void label2_Click(object sender, EventArgs e){ }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "width = " + textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "height = " + textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                x = int.Parse(textBox1.Text);
                y = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Вы ввели не правильные значения");
            }
            Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
