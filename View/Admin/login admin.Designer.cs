namespace BANKING
{
    partial class login_admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_admin));
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameAdmin = new Guna.UI.WinForms.GunaTextBox();
            this.passwordAdmin = new Guna.UI.WinForms.GunaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTNlogin = new Guna.UI.WinForms.GunaButton();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaElipsePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.gunaElipsePanel1.Controls.Add(this.label1);
            this.gunaElipsePanel1.Controls.Add(this.pictureBox1);
            this.gunaElipsePanel1.Controls.Add(this.label3);
            this.gunaElipsePanel1.Controls.Add(this.usernameAdmin);
            this.gunaElipsePanel1.Controls.Add(this.passwordAdmin);
            this.gunaElipsePanel1.Controls.Add(this.label5);
            this.gunaElipsePanel1.Controls.Add(this.BTNlogin);
            this.gunaElipsePanel1.Location = new System.Drawing.Point(302, 181);
            this.gunaElipsePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Radius = 25;
            this.gunaElipsePanel1.Size = new System.Drawing.Size(547, 251);
            this.gunaElipsePanel1.TabIndex = 2;
            this.gunaElipsePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaElipsePanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(201, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Login Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(379, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password";
            // 
            // usernameAdmin
            // 
            this.usernameAdmin.BackColor = System.Drawing.Color.Transparent;
            this.usernameAdmin.BaseColor = System.Drawing.Color.White;
            this.usernameAdmin.BorderColor = System.Drawing.Color.Silver;
            this.usernameAdmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameAdmin.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.usernameAdmin.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.usernameAdmin.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.usernameAdmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.usernameAdmin.Location = new System.Drawing.Point(123, 84);
            this.usernameAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.usernameAdmin.Name = "usernameAdmin";
            this.usernameAdmin.PasswordChar = '\0';
            this.usernameAdmin.Radius = 10;
            this.usernameAdmin.SelectedText = "";
            this.usernameAdmin.Size = new System.Drawing.Size(211, 35);
            this.usernameAdmin.TabIndex = 1;
            // 
            // passwordAdmin
            // 
            this.passwordAdmin.BackColor = System.Drawing.Color.Transparent;
            this.passwordAdmin.BaseColor = System.Drawing.Color.White;
            this.passwordAdmin.BorderColor = System.Drawing.Color.Silver;
            this.passwordAdmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordAdmin.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.passwordAdmin.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.passwordAdmin.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.passwordAdmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passwordAdmin.Location = new System.Drawing.Point(123, 137);
            this.passwordAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.passwordAdmin.Name = "passwordAdmin";
            this.passwordAdmin.PasswordChar = '●';
            this.passwordAdmin.Radius = 10;
            this.passwordAdmin.SelectedText = "";
            this.passwordAdmin.Size = new System.Drawing.Size(211, 35);
            this.passwordAdmin.TabIndex = 18;
            this.passwordAdmin.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Username";
            // 
            // BTNlogin
            // 
            this.BTNlogin.AnimationHoverSpeed = 0.07F;
            this.BTNlogin.AnimationSpeed = 0.03F;
            this.BTNlogin.BackColor = System.Drawing.Color.Transparent;
            this.BTNlogin.BaseColor = System.Drawing.Color.Transparent;
            this.BTNlogin.BorderColor = System.Drawing.Color.White;
            this.BTNlogin.BorderSize = 2;
            this.BTNlogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTNlogin.FocusedColor = System.Drawing.Color.Empty;
            this.BTNlogin.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNlogin.ForeColor = System.Drawing.Color.White;
            this.BTNlogin.Image = null;
            this.BTNlogin.ImageSize = new System.Drawing.Size(20, 20);
            this.BTNlogin.Location = new System.Drawing.Point(175, 199);
            this.BTNlogin.Margin = new System.Windows.Forms.Padding(2);
            this.BTNlogin.Name = "BTNlogin";
            this.BTNlogin.OnHoverBaseColor = System.Drawing.Color.PaleGreen;
            this.BTNlogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BTNlogin.OnHoverForeColor = System.Drawing.Color.White;
            this.BTNlogin.OnHoverImage = null;
            this.BTNlogin.OnPressedColor = System.Drawing.Color.Black;
            this.BTNlogin.Radius = 15;
            this.BTNlogin.Size = new System.Drawing.Size(120, 34);
            this.BTNlogin.TabIndex = 10;
            this.BTNlogin.Text = "Login";
            this.BTNlogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTNlogin.Click += new System.EventHandler(this.BTNlogin_Click_1);
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.White;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(1062, 10);
            this.gunaControlBox1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(32, 19);
            this.gunaControlBox1.TabIndex = 21;
            this.gunaControlBox1.Click += new System.EventHandler(this.gunaControlBox1_Click);
            // 
            // login_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1102, 634);
            this.Controls.Add(this.gunaControlBox1);
            this.Controls.Add(this.gunaElipsePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "login_admin";
            this.Text = "login_admin";
            this.gunaElipsePanel1.ResumeLayout(false);
            this.gunaElipsePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaTextBox usernameAdmin;
        private Guna.UI.WinForms.GunaTextBox passwordAdmin;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaButton BTNlogin;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
    }
}