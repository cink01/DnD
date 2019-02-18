using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DnD
{
    public partial class FormMain : Form
    {
        private List<Hero> Hrdinove = new List<Hero>();
        private int testovacon;
        private int testovadex;
        //SqlConnection connection;
        //string CS = Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString");

        public FormMain()
        {
            InitializeComponent();
            statisiky Nove = new statisiky();
            Nove.RNGstaty();
            testovacon = Convert.ToInt32(lb_modif_con.Text);
            testovadex = Convert.ToInt32(lb_modif_dex.Text);
            DataAccess db = new DataAccess();
            for (int i = 1; i < 3; i++)
                cb_charclass.Items.Add(db.NamesHeroGet(i));
        }

        private void cisteniVybranych()
        {
            checkedListBox_savy.ClearSelected();
            checkedListBox_dovednosti.ClearSelected();
            bt_cisteni.Visible = false;
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.EXIT_MESSAGE, Properties.Resources.EXIT_TITLE,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void statyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statisiky Nove = new statisiky();
            Nove.RNGstaty();
            num_STR.Value = Nove.VratStat(0);
            num_DEX.Value = Nove.VratStat(1);
            num_CON.Value = Nove.VratStat(2);
            num_INT.Value = Nove.VratStat(3);
            num_WIS.Value = Nove.VratStat(4);
            num_CHA.Value = Nove.VratStat(5);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Modifier Novz = new Modifier();
            lb_modif_str.Text = (Novz.Modif((int)num_STR.Value)).ToString();
            checkDoved();
        }

        private void num_DEX_ValueChanged(object sender, EventArgs e)
        {
            Modifier Novz = new Modifier();
            lb_modif_dex.Text = (Novz.Modif((int)num_DEX.Value)).ToString();
            checkDoved();
        }

        private void num_CON_ValueChanged(object sender, EventArgs e)
        {
            Modifier Novz = new Modifier();
            lb_modif_con.Text = (Novz.Modif((int)num_CON.Value)).ToString();
            checkDoved();
        }

        private void num_INT_ValueChanged(object sender, EventArgs e)
        {
            Modifier Novz = new Modifier();
            lb_modif_int.Text = (Novz.Modif((int)num_INT.Value)).ToString();
            checkDoved();
        }

        private void num_WIS_ValueChanged(object sender, EventArgs e)
        {
            Modifier Novz = new Modifier();
            lb_modif_wis.Text = (Novz.Modif((int)num_WIS.Value)).ToString();
            checkDoved();
        }

        private void num_CHA_ValueChanged(object sender, EventArgs e)
        {
            Modifier Novz = new Modifier();
            lb_modif_cha.Text = (Novz.Modif((int)num_CHA.Value)).ToString();
            checkDoved();
        }

        private void nud_MAXHP_ValueChanged(object sender, EventArgs e)
        {
            nud_HPCURR.Maximum = nud_MAXHP.Value;
        }

        private void bt_roll_Click(object sender, EventArgs e)
        {
            //rollovaní
            int ro = 0, index = 0, dice = 0, i = 0;
            Random r = new Random();
            if (rb_save.Checked == true)
            {
                index = checkedListBox_savy.SelectedIndex;
                ro = PrideleniSave(index);
                Rollovani(ro);
                textBox3.Text = "Skill: " + checkedListBox_savy.SelectedItem + " ID: " + index.ToString() + " MODIF: " + ro.ToString();
                return;
            }
            if (rb_dov.Checked == true)
            {
                index = checkedListBox_dovednosti.SelectedIndex;
                ro = PrideleniDov(index);
                Rollovani(ro);
                textBox3.Text = "Skill: " + checkedListBox_dovednosti.SelectedItem + " ID: " + index.ToString() + " MODIF: " + ro.ToString();
                return;
            }
            //opakovani rolu a scinani jich dohromoady
            do
            {
                dice += r.Next(1, (int)nud_dice.Value + 1);
                i++;
            } while (i != nud_pocet.Value);
            //celkem + plus
            tb_final.Text = (dice + nud_plus.Value).ToString();
            //hodnoty pro zmenu hp
            decimal CurrHp = nud_HPCURR.Value;
            decimal MaxHp = nud_MAXHP.Value;
            int roll = Convert.ToInt32(tb_final.Text);
            //dmg
            if (CurrHp < roll && change_dmg.Checked == true)
                nud_HPCURR.Value = 0;
            if (CurrHp > roll && change_dmg.Checked == true)
                nud_HPCURR.Value = CurrHp - roll;
            //heal
            if ((CurrHp + roll <= MaxHp) && change_heal.Checked == true)
                nud_HPCURR.Value = CurrHp + roll;
            if ((CurrHp == MaxHp || CurrHp + roll >= MaxHp) && change_heal.Checked == true)
                nud_HPCURR.Value = MaxHp;
            //LVL_up
            if (change_lvl.Checked == true)
            {
                nud_MAXHP.Value = MaxHp + roll;
                nud_lvl.Value++;
            }
            cisteniVybranych();
        }

        private void b_STR_Click(object sender, EventArgs e)
        {
            tb_final.Text = (Convert.ToInt32(lb_modif_wis.Text) + Pocitani.Roll20()).ToString();
        }

        private void b_DEX_Click(object sender, EventArgs e)
        {
            tb_final.Text = (Convert.ToInt32(lb_modif_wis.Text) + Pocitani.Roll20()).ToString();
        }

        private void B_CON_Click(object sender, EventArgs e)
        {
            tb_final.Text = (Convert.ToInt32(lb_modif_wis.Text) + Pocitani.Roll20()).ToString();
        }

        private void b_INT_Click(object sender, EventArgs e)
        {
            tb_final.Text = (Convert.ToInt32(lb_modif_wis.Text) + Pocitani.Roll20()).ToString();
        }

        private void b_WIS_Click(object sender, EventArgs e)
        {
            tb_final.Text = (Pocitani.Roll20() + Convert.ToInt32(lb_modif_wis.Text)).ToString();
        }

        private void b_CHAR_Click(object sender, EventArgs e)
        {
            tb_final.Text = (Pocitani.Roll20() + Convert.ToInt32(lb_modif_cha.Text)).ToString();
        }

        private void nud_lvl_ValueChanged(object sender, EventArgs e)
        {
            nud_prof.Maximum = nud_prof.Minimum = (7 + nud_lvl.Value) / 4;
            nud_MaxHD.Maximum = nud_MaxHD.Minimum = nud_lvl.Value;
            checkDoved();
        }

        private void bt_HD_Click(object sender, EventArgs e)
        {
            if (nud_CurrHD.Value > 0)
            {
                nud_CurrHD.Value = nud_CurrHD.Value - 1;
                DataAccess db = new DataAccess();
                int dice = db.GDice(cb_charclass.SelectedItem.ToString());
                nud_HPCURR.Value += Pocitani.MyRandom(1, dice + 1) + Convert.ToInt32(lb_modif_con.Text);
                return;
            }
            else
            {
                MessageBox.Show("Nedostatek Hit dice!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }

        private void bt_DS_Click(object sender, EventArgs e)
        {
            if (nud_HPCURR.Value == 0)//Jen kdyz hp sou down
            {
                if (Pocitani.Roll20() < 10)// DS fail
                {
                    if (chb_fail1.Checked == false)
                    {
                        chb_fail1.Checked = true;
                        return;
                    }
                    if (chb_fail1.Checked == true && chb_fail2.Checked == false)
                    {
                        chb_fail2.Checked = true;
                        return;
                    }
                    if (chb_fail1.Checked == true && chb_fail2.Checked == true && chb_fail3.Checked == false)
                    {
                        chb_fail3.Checked = true;
                        return;
                    }
                }
                if (Pocitani.Roll20() > 10 && Pocitani.Roll20() < 20) //DS succ
                {
                    if (chb_succ1.Checked == false)
                    {
                        chb_succ1.Checked = true;
                        return;
                    }
                    if (chb_succ1.Checked == true && chb_succ2.Checked == false)
                    {
                        chb_succ2.Checked = true;
                        return;
                    }
                    if (chb_succ1.Checked == true && chb_succ2.Checked == true && chb_succ3.Checked == false)
                    {
                        chb_succ3.Checked = true;
                        return;
                    }
                }
                if (Pocitani.Roll20() == 20) //DS s NAT 20
                    nud_HPCURR.Value = 1;
            }
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void nud_HPCURR_ValueChanged(object sender, EventArgs e)
        {
            chb_succ2.Checked = chb_succ1.Checked = chb_succ3.Checked = false;
            chb_fail2.Checked = chb_fail1.Checked = chb_fail3.Checked = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: Tento řádek načte data do tabulky 'heroesDataSet.player'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.playerTableAdapter.Fill(this.heroesDataSet.player);
            // TODO: Tento řádek načte data do tabulky 'heroesDataSet.Staty'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.statyTableAdapter.Fill(this.heroesDataSet.Staty);
            // TODO: Tento řádek načte data do tabulky 'heroesDataSet.Hero'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.heroTableAdapter.Fill(this.heroesDataSet.Hero);
        }

        private void heroBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.heroBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.heroesDataSet);
        }

        private void heroBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
        }

        private void b_lvlup_Click(object sender, EventArgs e)
        {
            try
            {
                if (nud_lvl.Value != 20)
                {
                    int dice = ClassDice();
                    nud_MAXHP.Value += Pocitani.MyRandom(1, dice + 1) + Convert.ToInt32(lb_modif_con.Text);
                    nud_lvl.Value++;
                }
                else
                    throw new Exception("Již dosáhnut MAX level!");
            }
            catch
            {
                MessageBox.Show("Vyber class nez budes davat LEVEL", "Neni Class");
            }
        }

        private void lb_modif_con_TextChanged(object sender, EventArgs e)
        {
            int novy = Convert.ToInt32(lb_modif_con.Text);
            if (testovacon < novy)
                nud_MAXHP.Value += 1 * nud_lvl.Value;
            if (testovacon > novy)
                nud_MAXHP.Value -= 1 * nud_lvl.Value;
            testovacon = novy;
            lb_con_save.Text = lb_modif_con.Text;
        }

        private void cb_charclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nud_lvl.Value == 1)
                nud_MAXHP.Value = ClassDice() + testovacon;
        }

        private int ClassDice()
        {
            DataAccess db = new DataAccess();
            int dice = db.GDice(cb_charclass.SelectedItem.ToString());
            return dice;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GETSTATIKY(1);
        }

        private void tb_jmeno_TextChanged(object sender, EventArgs e)
        {
            string jemno = tb_jmeno.Text;
            DataAccess db = new DataAccess();
            int test = db.GetIDstatu(jemno);
            if (test != -1)
            {
                GETSTATIKY(test);
                nud_MAXHP.Value = db.GetHPplay(jemno);
                nud_lvl.Value = db.Getlvlplay(jemno);
            }
        }

        private void GETSTATIKY(int i)
        {
            DataAccess db = new DataAccess();
            int a, b, c, d, ee, f;
            a = b = c = d = ee = f = 0;
            db.GetStat(i, out a, out b, out c, out d, out ee, out f);
            num_STR.Value = a;
            num_DEX.Value = b;
            num_CON.Value = c;
            num_INT.Value = d;
            num_WIS.Value = ee;
            num_CHA.Value = f;
        }

        private void lb_modif_dex_TextChanged(object sender, EventArgs e)
        {
            int novy = Convert.ToInt32(lb_modif_dex.Text);
            if (testovadex < novy)
                nud_AC.Value++;
            if (testovadex > novy)
                nud_AC.Value--;
            testovadex = novy;
            lb_dex_save.Text = lb_modif_dex.Text;
            checkDoved();
        }

        private void lb_modif_str_TextChanged(object sender, EventArgs e)
        {
            lb_str_save.Text = lb_modif_str.Text;
            checkDoved();
        }

        private void lb_modif_int_TextChanged(object sender, EventArgs e)
        {
            lb_int_save.Text = lb_modif_int.Text;
            checkDoved();
        }

        private void lb_modif_wis_TextChanged(object sender, EventArgs e)
        {
            lb_wis_save.Text = lb_modif_wis.Text;
            checkDoved();
        }

        private void lb_modif_cha_TextChanged(object sender, EventArgs e)
        {
            lb_cha_save.Text = lb_modif_cha.Text;
            checkDoved();
        }

        private void lb_str_save_TextChanged(object sender, EventArgs e)
        {
            if (checkedListBox_savy.GetItemChecked(checkedListBox_savy.Items.IndexOf("Strenght")))
                lb_str_save.Text = (Convert.ToInt32(lb_modif_str.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
        }

        private void lb_dex_save_TextChanged(object sender, EventArgs e)
        {
            if (checkedListBox_savy.GetItemChecked(checkedListBox_savy.Items.IndexOf("Dexterity")))
                lb_dex_save.Text = (Convert.ToInt32(lb_modif_str.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
        }

        private void lb_con_save_TextChanged(object sender, EventArgs e)
        {
            if (checkedListBox_savy.GetItemChecked(checkedListBox_savy.Items.IndexOf("Constitution")))
                lb_con_save.Text = (Convert.ToInt32(lb_modif_str.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
        }

        private void lb_int_save_TextChanged(object sender, EventArgs e)
        {
            if (checkedListBox_savy.GetItemChecked(checkedListBox_savy.Items.IndexOf("Inteligence")))
                lb_int_save.Text = (Convert.ToInt32(lb_modif_str.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
        }

        private void lb_wis_save_TextChanged(object sender, EventArgs e)
        {
            if (checkedListBox_savy.GetItemChecked(checkedListBox_savy.Items.IndexOf("Wisdom")))
                lb_wis_save.Text = (Convert.ToInt32(lb_modif_str.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
        }

        private void lb_cha_save_TextChanged(object sender, EventArgs e)
        {
            if (checkedListBox_savy.GetItemChecked(checkedListBox_savy.Items.IndexOf("Charisma")))
                lb_cha_save.Text = (Convert.ToInt32(lb_modif_str.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
        }

        private void label11_TextChanged(object sender, EventArgs e)
        {
            checkDoved();
        }

        private void checkDoved()
        {
            if (checkedListBox_dovednosti.GetItemCheckState(0) == CheckState.Checked)
                lb_athletics.Text = (Convert.ToInt32(lb_modif_str.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_athletics.Text = lb_modif_str.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(1) == CheckState.Checked)
                lb_acrobatics.Text = (Convert.ToInt32(lb_modif_dex.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_acrobatics.Text = lb_modif_dex.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(2) == CheckState.Checked)
                lb_sleight.Text = (Convert.ToInt32(lb_modif_dex.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_sleight.Text = lb_modif_dex.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(3) == CheckState.Checked)
                lb_stealth.Text = (Convert.ToInt32(lb_modif_dex.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_stealth.Text = lb_modif_dex.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(4) == CheckState.Checked)
                lb_arcana.Text = (Convert.ToInt32(lb_modif_int.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_arcana.Text = lb_modif_int.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(5) == CheckState.Checked)
                lb_history.Text = (Convert.ToInt32(lb_modif_int.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_history.Text = lb_modif_int.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(6) == CheckState.Checked)
                lb_investigation.Text = (Convert.ToInt32(lb_modif_int.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_investigation.Text = lb_modif_int.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(7) == CheckState.Checked)
                lb_nature.Text = (Convert.ToInt32(lb_modif_int.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_nature.Text = lb_modif_int.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(8) == CheckState.Checked)
                lb_religion.Text = (Convert.ToInt32(lb_modif_cha.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_religion.Text = lb_modif_cha.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(9) == CheckState.Checked)
                lb_insight.Text = (Convert.ToInt32(lb_modif_wis.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_insight.Text = lb_modif_wis.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(10) == CheckState.Checked)
                lb_medicine.Text = (Convert.ToInt32(lb_modif_wis.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_medicine.Text = lb_modif_wis.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(11) == CheckState.Checked)
                lb_perception.Text = (Convert.ToInt32(lb_modif_wis.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_perception.Text = lb_modif_wis.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(12) == CheckState.Checked)
                lb_survival.Text = (Convert.ToInt32(lb_modif_wis.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_survival.Text = lb_modif_wis.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(13) == CheckState.Checked)
                lb_deception.Text = (Convert.ToInt32(lb_modif_cha.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_deception.Text = lb_modif_cha.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(14) == CheckState.Checked)
                lb_intimidation.Text = (Convert.ToInt32(lb_modif_cha.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_intimidation.Text = lb_modif_cha.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(15) == CheckState.Checked)
                lb_performance.Text = (Convert.ToInt32(lb_modif_cha.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_performance.Text = lb_modif_cha.Text;
            if (checkedListBox_dovednosti.GetItemCheckState(16) == CheckState.Checked)
                lb_persuasion.Text = (Convert.ToInt32(lb_modif_cha.Text) + Convert.ToInt32(nud_prof.Value)).ToString();
            else
                lb_persuasion.Text = lb_modif_cha.Text;
        }

        private void bt_cisteni_Click(object sender, EventArgs e)
        {
            cisteniVybranych();
        }

        private void checkedListBox_dovednosti_MouseClick(object sender, MouseEventArgs e)
        {
            bt_cisteni.Visible = true;
        }

        private void checkedListBox_savy_MouseClick(object sender, MouseEventArgs e)
        {
            bt_cisteni.Visible = true;
        }
        //nejspis nebude potreba predelat do roll tlacitka

        private void Rollovani(int i)
        {
            Random r = new Random();
            int dice = 0;
            dice += (r.Next(1, 21));
            tb_final.Text = (dice + i).ToString();
        }
        private int PrideleniSave(int i)
        {
            if (i == 0)
                return Convert.ToInt32(lb_str_save.Text);
            if (i == 1)
                return Convert.ToInt32(lb_dex_save.Text);
            if (i == 2)
                return Convert.ToInt32(lb_con_save.Text);
            if (i == 3)
                return Convert.ToInt32(lb_int_save.Text);
            if (i == 4)
                return Convert.ToInt32(lb_wis_save.Text);
            if (i == 5)
                return Convert.ToInt32(lb_cha_save.Text);
            return -1;
        }
        private int PrideleniDov(int i)
        {
            if (i == 0) 
                return Convert.ToInt32(lb_athletics.Text);
            if (i == 1)
                return Convert.ToInt32(lb_acrobatics.Text);
            if (i == 2)
                return Convert.ToInt32(lb_sleight.Text);
            if (i == 3)
                return Convert.ToInt32(lb_stealth.Text);
            if (i == 4)
                return Convert.ToInt32(lb_arcana.Text);
            if (i == 5)
                return Convert.ToInt32(lb_history.Text);
            if (i == 6)
                return Convert.ToInt32(lb_investigation.Text);
            if (i == 7)
                return Convert.ToInt32(lb_nature.Text);
            if (i == 8)
                return Convert.ToInt32(lb_religion.Text);
            if (i == 9)
                return Convert.ToInt32(lb_insight.Text);
            if (i == 10)
                return Convert.ToInt32(lb_medicine.Text);
            if (i == 11)
                return Convert.ToInt32(lb_perception.Text);
            if (i == 12)
                return Convert.ToInt32(lb_survival.Text);
            if (i == 13)
                return Convert.ToInt32(lb_deception.Text);
            if (i == 14)
                return Convert.ToInt32(lb_intimidation.Text);
            if (i == 15)
                return Convert.ToInt32(lb_performance.Text);
            if (i == 16)
                return Convert.ToInt32(lb_persuasion.Text);
            return -1;
        }
    }
}
//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="D:\MOJE APPs\DnD\Heroes.mdf";Integrated Security=True;Connect Timeout=30