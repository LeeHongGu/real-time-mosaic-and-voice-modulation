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
    public partial class Form2 : Form
    {
        Form1 form1;
        Voice_Modulation voice_mod = new Voice_Modulation();
        bool btn_ck = false;
        bool temp = false;
        string text = null;
        public int rm_num = 0;

        public Form2(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;
            this.KeyPreview = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Text = "On";
            label1.Text = "If you want to turn it on or off, press 'G'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp = !btn_ck;

            if (btn_ck == false)
            {
                button1.Text = "Off";
                setRm_Num(1);

                while (text == "G")
                {
                    voice_mod.realtime_mod(rm_num); 
                }
            }
            else if (btn_ck == true)
            {
                button1.Text = "On";
                setRm_Num(0);
            }
            else
                return;

            btn_ck = temp;

        }

        public void setRm_Num(int num)
        {
            rm_num = num;
        }

        public int getRm_Num()
        {
            return rm_num;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            voice_mod.matlab.Quit();
            form1.Close();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
            {
                text = "G";
                button1_Click(sender, e);
            }
        }
    }
}
