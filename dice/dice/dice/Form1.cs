using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dice
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            rtb_final.Text = "";
        }

        private void bt_roll_Click(object sender, EventArgs e)
        {
            int i = 0;
            int dice = 0;
            Random r = new Random();
            do
            {
                dice+= r.Next(1,(int)nud_dice.Value+1);
                i++;
            } while (i != nud_pocet.Value);
            tb_final.Text = dice.ToString();
            rtb_final.Text += dice.ToString()+"; ";
        }

        private void nud_dice_ValueChanged(object sender, EventArgs e)
        {
            rtb_final.Text =tb_final.Text ="";
        }

        private void nud_pocet_ValueChanged(object sender, EventArgs e)
        {
            rtb_final.Text = tb_final.Text = "";
        }

        private void tc_main_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_random_Click(object sender, EventArgs e)
        {

            richTextBox_staty.Text = "\n";
            int a, b, c, d, control;
            Random r = new Random();
            int i =0;
            do {
                a = 0;
                b = 0;
                c = 0;
                d = 0;
                control = 0;
                a = r.Next(1, 7);
                b = r.Next(1, 7);
                c = r.Next(1, 7);
                d = r.Next(1, 7);
                richTextBox_staty.Text += ("  ["+a.ToString()+"]" + " ["+ b.ToString() + "]" + " ["+c.ToString() + "]" + " ["+d.ToString() + "]  = ");
                int min = Math.Min(Math.Min(Math.Min(a, b), c), d);
                if ((a == min) && (control == 0))
                { 
                    a = 0;control++;
                }
                if ((b == min)&& (control == 0))
                {
                    b = 0; control++;
                }
                if ((c == min)&& (control == 0))
                {
                    c = 0; control++;
                }
                if ((d == min)&& (control == 0))
                {
                    d = 0; control++;
                }
                richTextBox_staty.Text += (a + b + c + d).ToString()+"\n";
                i++;
            } while (i != 6);
        }
    }
}
