﻿namespace KEYLOGGER_V1
{
    partial class FrmHome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtTextoDigitado = new System.Windows.Forms.TextBox();
            this.tmEnviarEmail = new System.Windows.Forms.Timer(this.components);
            this.txtTextoDigitadoLimpo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KEYLOGGER_V1.Properties.Resources.matrix1__42_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 402);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KEYLOGGER_V1.Properties.Resources.matrix1__42_;
            this.pictureBox2.Location = new System.Drawing.Point(293, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(345, 402);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txtTextoDigitado
            // 
            this.txtTextoDigitado.Location = new System.Drawing.Point(45, 12);
            this.txtTextoDigitado.Multiline = true;
            this.txtTextoDigitado.Name = "txtTextoDigitado";
            this.txtTextoDigitado.Size = new System.Drawing.Size(552, 196);
            this.txtTextoDigitado.TabIndex = 2;
            this.txtTextoDigitado.TabStop = false;
            this.txtTextoDigitado.Text = "\\";
            this.txtTextoDigitado.TextChanged += new System.EventHandler(this.txtTextoDigitado_TextChanged);
            // 
            // tmEnviarEmail
            // 
            this.tmEnviarEmail.Enabled = true;
            this.tmEnviarEmail.Interval = 300000;
            this.tmEnviarEmail.Tick += new System.EventHandler(this.tmEnviarEmail_Tick);
            // 
            // txtTextoDigitadoLimpo
            // 
            this.txtTextoDigitadoLimpo.Location = new System.Drawing.Point(45, 214);
            this.txtTextoDigitadoLimpo.Multiline = true;
            this.txtTextoDigitadoLimpo.Name = "txtTextoDigitadoLimpo";
            this.txtTextoDigitadoLimpo.Size = new System.Drawing.Size(552, 203);
            this.txtTextoDigitadoLimpo.TabIndex = 3;
            this.txtTextoDigitadoLimpo.TabStop = false;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(637, 429);
            this.Controls.Add(this.txtTextoDigitadoLimpo);
            this.Controls.Add(this.txtTextoDigitado);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KEY";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHome_FormClosing);
            this.Load += new System.EventHandler(this.FrmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtTextoDigitado;
        private System.Windows.Forms.Timer tmEnviarEmail;
        public System.Windows.Forms.TextBox txtTextoDigitadoLimpo;
    }
}

