using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Time_Voice_Modulation
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(350, 350);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Let's Talk!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form2 form2 = new Form2(this);
            form2.Show();

            //while (true)
            //{
            //    num = form2.getRm_Num();
            //    voice_mod.realtime_mod(num);

            //    if (num == 10) break;
            //}
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
