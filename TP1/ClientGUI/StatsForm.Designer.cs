﻿namespace ClientGUI
{
    partial class StatsForm
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
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.quoteMeasure1 = new System.Windows.Forms.Label();
            this.quoteMeasure2 = new System.Windows.Forms.Label();
            this.quoteMeasure3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.title.Location = new System.Drawing.Point(11, 9);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(302, 25);
            this.title.TabIndex = 9;
            this.title.Text = "Diginote Exchange System Client";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(318, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(27, 22);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Quote";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "O";
            // 
            // quoteMeasure1
            // 
            this.quoteMeasure1.AutoSize = true;
            this.quoteMeasure1.Location = new System.Drawing.Point(14, 185);
            this.quoteMeasure1.Name = "quoteMeasure1";
            this.quoteMeasure1.Size = new System.Drawing.Size(28, 13);
            this.quoteMeasure1.TabIndex = 14;
            this.quoteMeasure1.Text = "2,22";
            // 
            // quoteMeasure2
            // 
            this.quoteMeasure2.AutoSize = true;
            this.quoteMeasure2.Location = new System.Drawing.Point(14, 140);
            this.quoteMeasure2.Name = "quoteMeasure2";
            this.quoteMeasure2.Size = new System.Drawing.Size(28, 13);
            this.quoteMeasure2.TabIndex = 15;
            this.quoteMeasure2.Text = "2,22";
            // 
            // quoteMeasure3
            // 
            this.quoteMeasure3.AutoSize = true;
            this.quoteMeasure3.Location = new System.Drawing.Point(14, 95);
            this.quoteMeasure3.Name = "quoteMeasure3";
            this.quoteMeasure3.Size = new System.Drawing.Size(28, 13);
            this.quoteMeasure3.TabIndex = 16;
            this.quoteMeasure3.Text = "2,22";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.quoteMeasure3);
            this.Controls.Add(this.quoteMeasure2);
            this.Controls.Add(this.quoteMeasure1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label quoteMeasure1;
        private System.Windows.Forms.Label quoteMeasure2;
        private System.Windows.Forms.Label quoteMeasure3;
    }
}