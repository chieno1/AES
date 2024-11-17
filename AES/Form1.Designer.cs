namespace AES
{
    partial class Form1
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
            this.INPUT = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_ma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_khoa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rad256 = new System.Windows.Forms.RadioButton();
            this.rad192 = new System.Windows.Forms.RadioButton();
            this.rad128 = new System.Windows.Forms.RadioButton();
            this.txt_ro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_giai_thich = new System.Windows.Forms.TextBox();
            this.INPUT.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // INPUT
            // 
            this.INPUT.Controls.Add(this.button4);
            this.INPUT.Controls.Add(this.button3);
            this.INPUT.Controls.Add(this.button2);
            this.INPUT.Controls.Add(this.button1);
            this.INPUT.Controls.Add(this.txt_ma);
            this.INPUT.Controls.Add(this.label3);
            this.INPUT.Controls.Add(this.txt_khoa);
            this.INPUT.Controls.Add(this.label2);
            this.INPUT.Controls.Add(this.rad256);
            this.INPUT.Controls.Add(this.rad192);
            this.INPUT.Controls.Add(this.rad128);
            this.INPUT.Controls.Add(this.txt_ro);
            this.INPUT.Controls.Add(this.label1);
            this.INPUT.Dock = System.Windows.Forms.DockStyle.Left;
            this.INPUT.Location = new System.Drawing.Point(0, 0);
            this.INPUT.Margin = new System.Windows.Forms.Padding(2);
            this.INPUT.Name = "INPUT";
            this.INPUT.Padding = new System.Windows.Forms.Padding(2);
            this.INPUT.Size = new System.Drawing.Size(298, 640);
            this.INPUT.TabIndex = 0;
            this.INPUT.TabStop = false;
            this.INPUT.Text = "INPUT";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(139, 337);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 19);
            this.button4.TabIndex = 11;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 337);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 19);
            this.button3.TabIndex = 10;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 301);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 19);
            this.button2.TabIndex = 9;
            this.button2.Text = "Giải mã";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 301);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 19);
            this.button1.TabIndex = 8;
            this.button1.Text = "Mã hóa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_ma
            // 
            this.txt_ma.Location = new System.Drawing.Point(39, 258);
            this.txt_ma.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ma.Name = "txt_ma";
            this.txt_ma.Size = new System.Drawing.Size(229, 20);
            this.txt_ma.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bản mã";
            // 
            // txt_khoa
            // 
            this.txt_khoa.Location = new System.Drawing.Point(41, 188);
            this.txt_khoa.Margin = new System.Windows.Forms.Padding(2);
            this.txt_khoa.Name = "txt_khoa";
            this.txt_khoa.Size = new System.Drawing.Size(227, 20);
            this.txt_khoa.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khóa";
            // 
            // rad256
            // 
            this.rad256.AutoSize = true;
            this.rad256.Location = new System.Drawing.Point(178, 113);
            this.rad256.Margin = new System.Windows.Forms.Padding(2);
            this.rad256.Name = "rad256";
            this.rad256.Size = new System.Drawing.Size(57, 17);
            this.rad256.TabIndex = 3;
            this.rad256.TabStop = true;
            this.rad256.Text = "256-bit";
            this.rad256.UseVisualStyleBackColor = true;
            // 
            // rad192
            // 
            this.rad192.AutoSize = true;
            this.rad192.Location = new System.Drawing.Point(111, 113);
            this.rad192.Margin = new System.Windows.Forms.Padding(2);
            this.rad192.Name = "rad192";
            this.rad192.Size = new System.Drawing.Size(57, 17);
            this.rad192.TabIndex = 2;
            this.rad192.TabStop = true;
            this.rad192.Text = "192-bit";
            this.rad192.UseVisualStyleBackColor = true;
            // 
            // rad128
            // 
            this.rad128.AutoSize = true;
            this.rad128.Location = new System.Drawing.Point(39, 113);
            this.rad128.Margin = new System.Windows.Forms.Padding(2);
            this.rad128.Name = "rad128";
            this.rad128.Size = new System.Drawing.Size(57, 17);
            this.rad128.TabIndex = 2;
            this.rad128.TabStop = true;
            this.rad128.Text = "128-bit";
            this.rad128.UseVisualStyleBackColor = true;
            // 
            // txt_ro
            // 
            this.txt_ro.Location = new System.Drawing.Point(39, 52);
            this.txt_ro.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ro.Name = "txt_ro";
            this.txt_ro.Size = new System.Drawing.Size(229, 20);
            this.txt_ro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bản rõ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_giai_thich);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(302, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(794, 640);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OUTPUT";
            // 
            // txt_giai_thich
            // 
            this.txt_giai_thich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_giai_thich.Location = new System.Drawing.Point(2, 17);
            this.txt_giai_thich.Margin = new System.Windows.Forms.Padding(2);
            this.txt_giai_thich.Multiline = true;
            this.txt_giai_thich.Name = "txt_giai_thich";
            this.txt_giai_thich.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_giai_thich.Size = new System.Drawing.Size(790, 621);
            this.txt_giai_thich.TabIndex = 0;
            this.txt_giai_thich.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 640);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.INPUT);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.INPUT.ResumeLayout(false);
            this.INPUT.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox INPUT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_ma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_khoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rad256;
        private System.Windows.Forms.RadioButton rad192;
        private System.Windows.Forms.RadioButton rad128;
        private System.Windows.Forms.TextBox txt_ro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_giai_thich;
    }
}

