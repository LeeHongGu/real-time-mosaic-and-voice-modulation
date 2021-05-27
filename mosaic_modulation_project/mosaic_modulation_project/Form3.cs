using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mosaic_modulation_project
{
    public partial class Form3 : Form
    {
        Form2 form2;

        public Form3(Form2 f2)
        {
            InitializeComponent();
            form2 = f2;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Check Audio. Is it ok?";
            button1.Text = "Yes";
            button2.Text = "No";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1(this);
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Close();
            Application.Exit();
        }
    }
}
