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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.BackColor = Color.IndianRed;
            this.Width = 255;
            this.Height = 145;

            toolStripMenuItem3.Enabled = false;
            toolStripMenuItem1.Text = "Input Size";
            toolStripMenuItem2.Text = "Choose";
            toolStripMenuItem3.Text = "Change";
            toolStripMenuItem4.Text = "Exit";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.Show();
            toolStripMenuItem3.Enabled = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form3 newForm3 = new Form3();
            newForm3.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Form3.choice == true)
            {
                this.Width += Form2.x;
                this.Height += Form2.y;
            }
            else
            {
                this.Width -= Form2.x;
                this.Height -= Form2.y;
                if (this.Width < 450 & this.Height < 120)
                {
                    this.Width += Form2.x;
                    this.Height += Form2.y;
                    MessageBox.Show("Ниже размеры поставить нельзя!\nНе увидете кнопки");
                }

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
