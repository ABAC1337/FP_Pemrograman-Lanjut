namespace BANKING
{
    partial class admin_or_user
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
            this.gunaElipsePanel2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.BTNnasabah = new Guna.UI.WinForms.GunaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNadmin = new Guna.UI.WinForms.GunaButton();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaElipsePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipsePanel2
            // 
            this.gunaElipsePanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.gunaElipsePanel2.Controls.Add(this.BTNnasabah);
            this.gunaElipsePanel2.Controls.Add(this.label3);
            this.gunaElipsePanel2.Controls.Add(this.BTNadmin);
            this.gunaElipsePanel2.Location = new System.Drawing.Point(559, 282);
            this.gunaElipsePanel2.Name = "gunaElipsePanel2";
            this.gunaElipsePanel2.Radius = 35;
            this.gunaElipsePanel2.Size = new System.Drawing.Size(419, 161);
            this.gunaElipsePanel2.TabIndex = 3;
            // 
            // BTNnasabah
            // 
            this.BTNnasabah.AnimationHoverSpeed = 0.07F;
            this.BTNnasabah.AnimationSpeed = 0.03F;
            this.BTNnasabah.BackColor = System.Drawing.Color.Transparent;
            this.BTNnasabah.BaseColor = System.Drawing.Color.White;
            this.BTNnasabah.BorderColor = System.Drawing.Color.Black;
            this.BTNnasabah.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTNnasabah.FocusedColor = System.Drawing.Color.Empty;
            this.BTNnasabah.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNnasabah.ForeColor = System.Drawing.Color.Black;
            this.BTNnasabah.Image = null;
            this.BTNnasabah.ImageSize = new System.Drawing.Size(20, 20);
            this.BTNnasabah.Location = new System.Drawing.Point(214, 81);
            this.BTNnasabah.Name = "BTNnasabah";
            this.BTNnasabah.OnHoverBaseColor = System.Drawing.Color.Gainsboro;
            this.BTNnasabah.OnHoverBorderColor = System.Drawing.Color.Gainsboro;
            this.BTNnasabah.OnHoverForeColor = System.Drawing.Color.White;
            this.BTNnasabah.OnHoverImage = null;
            this.BTNnasabah.OnPressedColor = System.Drawing.Color.Black;
            this.BTNnasabah.Radius = 20;
            this.BTNnasabah.Size = new System.Drawing.Size(139, 47);
            this.BTNnasabah.TabIndex = 16;
            this.BTNnasabah.Text = "NASABAH";
            this.BTNnasabah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTNnasabah.Click += new System.EventHandler(this.gunaButton2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(160, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "LOGIN";
//            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // BTNadmin
            // 
            this.BTNadmin.AnimationHoverSpeed = 0.07F;
            this.BTNadmin.AnimationSpeed = 0.03F;
            this.BTNadmin.BackColor = System.Drawing.Color.Transparent;
            this.BTNadmin.BaseColor = System.Drawing.Color.White;
            this.BTNadmin.BorderColor = System.Drawing.Color.Black;
            this.BTNadmin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTNadmin.FocusedColor = System.Drawing.Color.Empty;
            this.BTNadmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNadmin.ForeColor = System.Drawing.Color.Black;
            this.BTNadmin.Image = null;
            this.BTNadmin.ImageSize = new System.Drawing.Size(20, 20);
            this.BTNadmin.Location = new System.Drawing.Point(56, 81);
            this.BTNadmin.Name = "BTNadmin";
            this.BTNadmin.OnHoverBaseColor = System.Drawing.Color.Gainsboro;
            this.BTNadmin.OnHoverBorderColor = System.Drawing.Color.Gainsboro;
            this.BTNadmin.OnHoverForeColor = System.Drawing.Color.White;
            this.BTNadmin.OnHoverImage = null;
            this.BTNadmin.OnPressedColor = System.Drawing.Color.Black;
            this.BTNadmin.Radius = 20;
            this.BTNadmin.Size = new System.Drawing.Size(139, 47);
            this.BTNadmin.TabIndex = 10;
            this.BTNadmin.Text = "ADMIN";
            this.BTNadmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTNadmin.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.White;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(1407, 12);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(42, 23);
            this.gunaControlBox1.TabIndex = 21;
            this.gunaControlBox1.Click += new System.EventHandler(this.gunaControlBox1_Click);
            // 
            // admin_or_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1470, 780);
            this.Controls.Add(this.gunaControlBox1);
            this.Controls.Add(this.gunaElipsePanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "admin_or_user";
            this.Text = " ";
            this.gunaElipsePanel2.ResumeLayout(false);
            this.gunaElipsePanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel2;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaButton BTNadmin;
        private Guna.UI.WinForms.GunaButton BTNnasabah;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
    }
}