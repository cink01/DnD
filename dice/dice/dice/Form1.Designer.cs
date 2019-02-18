namespace dice
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.bt_roll = new System.Windows.Forms.Button();
            this.nud_pocet = new System.Windows.Forms.NumericUpDown();
            this.nud_dice = new System.Windows.Forms.NumericUpDown();
            this.tb_final = new System.Windows.Forms.TextBox();
            this.lb_pocet = new System.Windows.Forms.Label();
            this.lb_kostky = new System.Windows.Forms.Label();
            this.rtb_final = new System.Windows.Forms.RichTextBox();
            this.tc_main = new System.Windows.Forms.TabControl();
            this.tb_rolly = new System.Windows.Forms.TabPage();
            this.tp_stats = new System.Windows.Forms.TabPage();
            this.bt_random = new System.Windows.Forms.Button();
            this.richTextBox_staty = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pocet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dice)).BeginInit();
            this.tc_main.SuspendLayout();
            this.tb_rolly.SuspendLayout();
            this.tp_stats.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_roll
            // 
            this.bt_roll.Location = new System.Drawing.Point(137, 6);
            this.bt_roll.Name = "bt_roll";
            this.bt_roll.Size = new System.Drawing.Size(53, 46);
            this.bt_roll.TabIndex = 0;
            this.bt_roll.Text = "ROLL";
            this.bt_roll.UseVisualStyleBackColor = true;
            this.bt_roll.Click += new System.EventHandler(this.bt_roll_Click);
            // 
            // nud_pocet
            // 
            this.nud_pocet.Location = new System.Drawing.Point(73, 6);
            this.nud_pocet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_pocet.Name = "nud_pocet";
            this.nud_pocet.Size = new System.Drawing.Size(58, 20);
            this.nud_pocet.TabIndex = 1;
            this.nud_pocet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_pocet.ValueChanged += new System.EventHandler(this.nud_pocet_ValueChanged);
            // 
            // nud_dice
            // 
            this.nud_dice.Location = new System.Drawing.Point(73, 32);
            this.nud_dice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dice.Name = "nud_dice";
            this.nud_dice.Size = new System.Drawing.Size(58, 20);
            this.nud_dice.TabIndex = 2;
            this.nud_dice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dice.ValueChanged += new System.EventHandler(this.nud_dice_ValueChanged);
            // 
            // tb_final
            // 
            this.tb_final.Location = new System.Drawing.Point(197, 22);
            this.tb_final.Name = "tb_final";
            this.tb_final.ReadOnly = true;
            this.tb_final.Size = new System.Drawing.Size(88, 20);
            this.tb_final.TabIndex = 3;
            // 
            // lb_pocet
            // 
            this.lb_pocet.AutoSize = true;
            this.lb_pocet.Location = new System.Drawing.Point(26, 8);
            this.lb_pocet.Name = "lb_pocet";
            this.lb_pocet.Size = new System.Drawing.Size(34, 13);
            this.lb_pocet.TabIndex = 4;
            this.lb_pocet.Text = "počet";
            // 
            // lb_kostky
            // 
            this.lb_kostky.AutoSize = true;
            this.lb_kostky.Location = new System.Drawing.Point(21, 34);
            this.lb_kostky.Name = "lb_kostky";
            this.lb_kostky.Size = new System.Drawing.Size(39, 13);
            this.lb_kostky.TabIndex = 5;
            this.lb_kostky.Text = "kostka";
            // 
            // rtb_final
            // 
            this.rtb_final.Location = new System.Drawing.Point(24, 60);
            this.rtb_final.Name = "rtb_final";
            this.rtb_final.ReadOnly = true;
            this.rtb_final.Size = new System.Drawing.Size(261, 92);
            this.rtb_final.TabIndex = 6;
            this.rtb_final.Text = "";
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tb_rolly);
            this.tc_main.Controls.Add(this.tp_stats);
            this.tc_main.Location = new System.Drawing.Point(0, 2);
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.Size = new System.Drawing.Size(308, 182);
            this.tc_main.TabIndex = 2;
            this.tc_main.SelectedIndexChanged += new System.EventHandler(this.tc_main_SelectedIndexChanged);
            // 
            // tb_rolly
            // 
            this.tb_rolly.Controls.Add(this.rtb_final);
            this.tb_rolly.Controls.Add(this.lb_pocet);
            this.tb_rolly.Controls.Add(this.lb_kostky);
            this.tb_rolly.Controls.Add(this.bt_roll);
            this.tb_rolly.Controls.Add(this.nud_pocet);
            this.tb_rolly.Controls.Add(this.tb_final);
            this.tb_rolly.Controls.Add(this.nud_dice);
            this.tb_rolly.Location = new System.Drawing.Point(4, 22);
            this.tb_rolly.Name = "tb_rolly";
            this.tb_rolly.Padding = new System.Windows.Forms.Padding(3);
            this.tb_rolly.Size = new System.Drawing.Size(300, 156);
            this.tb_rolly.TabIndex = 0;
            this.tb_rolly.Text = "Roll";
            this.tb_rolly.UseVisualStyleBackColor = true;
            // 
            // tp_stats
            // 
            this.tp_stats.Controls.Add(this.bt_random);
            this.tp_stats.Controls.Add(this.richTextBox_staty);
            this.tp_stats.Location = new System.Drawing.Point(4, 22);
            this.tp_stats.Name = "tp_stats";
            this.tp_stats.Padding = new System.Windows.Forms.Padding(3);
            this.tp_stats.Size = new System.Drawing.Size(300, 156);
            this.tp_stats.TabIndex = 1;
            this.tp_stats.Text = "Stats";
            this.tp_stats.UseVisualStyleBackColor = true;
            // 
            // bt_random
            // 
            this.bt_random.Location = new System.Drawing.Point(35, 64);
            this.bt_random.Name = "bt_random";
            this.bt_random.Size = new System.Drawing.Size(75, 23);
            this.bt_random.TabIndex = 1;
            this.bt_random.Text = "Narolluj";
            this.bt_random.UseVisualStyleBackColor = true;
            this.bt_random.Click += new System.EventHandler(this.bt_random_Click);
            // 
            // richTextBox_staty
            // 
            this.richTextBox_staty.Location = new System.Drawing.Point(172, 20);
            this.richTextBox_staty.Name = "richTextBox_staty";
            this.richTextBox_staty.ReadOnly = true;
            this.richTextBox_staty.Size = new System.Drawing.Size(113, 116);
            this.richTextBox_staty.TabIndex = 0;
            this.richTextBox_staty.Text = "";
            this.richTextBox_staty.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(308, 185);
            this.Controls.Add(this.tc_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Kostky";
            ((System.ComponentModel.ISupportInitialize)(this.nud_pocet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dice)).EndInit();
            this.tc_main.ResumeLayout(false);
            this.tb_rolly.ResumeLayout(false);
            this.tb_rolly.PerformLayout();
            this.tp_stats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_roll;
        private System.Windows.Forms.Label lb_kostky;
        private System.Windows.Forms.Label lb_pocet;
        private System.Windows.Forms.TextBox tb_final;
        private System.Windows.Forms.NumericUpDown nud_dice;
        private System.Windows.Forms.NumericUpDown nud_pocet;
        private System.Windows.Forms.RichTextBox rtb_final;
        private System.Windows.Forms.TabControl tc_main;
        private System.Windows.Forms.TabPage tb_rolly;
        private System.Windows.Forms.TabPage tp_stats;
        private System.Windows.Forms.Button bt_random;
        private System.Windows.Forms.RichTextBox richTextBox_staty;
    }
}

