namespace INV_ID
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.btn_log = new MetroFramework.Controls.MetroButton();
            this.l_user = new MetroFramework.Controls.MetroLabel();
            this.l_pass = new MetroFramework.Controls.MetroLabel();
            this.i_user = new MetroFramework.Controls.MetroTextBox();
            this.i_pass = new MetroFramework.Controls.MetroTextBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.l_erro = new System.Windows.Forms.Label();
            this.i_modem = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(122, 346);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(75, 23);
            this.btn_log.TabIndex = 0;
            this.btn_log.Text = "Entrar";
            this.btn_log.UseSelectable = true;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // l_user
            // 
            this.l_user.AutoSize = true;
            this.l_user.Location = new System.Drawing.Point(59, 68);
            this.l_user.Name = "l_user";
            this.l_user.Size = new System.Drawing.Size(68, 19);
            this.l_user.TabIndex = 1;
            this.l_user.Text = "Username";
            // 
            // l_pass
            // 
            this.l_pass.AutoSize = true;
            this.l_pass.Location = new System.Drawing.Point(59, 149);
            this.l_pass.Name = "l_pass";
            this.l_pass.Size = new System.Drawing.Size(63, 19);
            this.l_pass.TabIndex = 2;
            this.l_pass.Text = "Password";
            // 
            // i_user
            // 
            // 
            // 
            // 
            this.i_user.CustomButton.Image = null;
            this.i_user.CustomButton.Location = new System.Drawing.Point(188, 1);
            this.i_user.CustomButton.Name = "";
            this.i_user.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.i_user.CustomButton.Style = MetroFramework.MetroColorStyle.Green;
            this.i_user.CustomButton.TabIndex = 1;
            this.i_user.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.i_user.CustomButton.UseSelectable = true;
            this.i_user.CustomButton.Visible = false;
            this.i_user.Lines = new string[0];
            this.i_user.Location = new System.Drawing.Point(67, 96);
            this.i_user.MaxLength = 32767;
            this.i_user.Name = "i_user";
            this.i_user.PasswordChar = '\0';
            this.i_user.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.i_user.SelectedText = "";
            this.i_user.SelectionLength = 0;
            this.i_user.SelectionStart = 0;
            this.i_user.ShortcutsEnabled = true;
            this.i_user.Size = new System.Drawing.Size(210, 23);
            this.i_user.TabIndex = 3;
            this.i_user.UseSelectable = true;
            this.i_user.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.i_user.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // i_pass
            // 
            // 
            // 
            // 
            this.i_pass.CustomButton.Image = null;
            this.i_pass.CustomButton.Location = new System.Drawing.Point(188, 1);
            this.i_pass.CustomButton.Name = "";
            this.i_pass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.i_pass.CustomButton.Style = MetroFramework.MetroColorStyle.Green;
            this.i_pass.CustomButton.TabIndex = 1;
            this.i_pass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.i_pass.CustomButton.UseSelectable = true;
            this.i_pass.CustomButton.Visible = false;
            this.i_pass.Lines = new string[0];
            this.i_pass.Location = new System.Drawing.Point(67, 176);
            this.i_pass.MaxLength = 32767;
            this.i_pass.Name = "i_pass";
            this.i_pass.PasswordChar = '\0';
            this.i_pass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.i_pass.SelectedText = "";
            this.i_pass.SelectionLength = 0;
            this.i_pass.SelectionStart = 0;
            this.i_pass.ShortcutsEnabled = true;
            this.i_pass.Size = new System.Drawing.Size(210, 23);
            this.i_pass.TabIndex = 4;
            this.i_pass.UseSelectable = true;
            this.i_pass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.i_pass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // l_erro
            // 
            this.l_erro.AutoSize = true;
            this.l_erro.BackColor = System.Drawing.Color.Transparent;
            this.l_erro.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_erro.ForeColor = System.Drawing.Color.DarkRed;
            this.l_erro.Location = new System.Drawing.Point(46, 310);
            this.l_erro.Name = "l_erro";
            this.l_erro.Size = new System.Drawing.Size(38, 13);
            this.l_erro.TabIndex = 15;
            this.l_erro.Text = "ERRO:";
            this.l_erro.Visible = false;
            // 
            // i_modem
            // 
            // 
            // 
            // 
            this.i_modem.CustomButton.Image = null;
            this.i_modem.CustomButton.Location = new System.Drawing.Point(188, 1);
            this.i_modem.CustomButton.Name = "";
            this.i_modem.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.i_modem.CustomButton.Style = MetroFramework.MetroColorStyle.Green;
            this.i_modem.CustomButton.TabIndex = 1;
            this.i_modem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.i_modem.CustomButton.UseSelectable = true;
            this.i_modem.CustomButton.Visible = false;
            this.i_modem.Lines = new string[0];
            this.i_modem.Location = new System.Drawing.Point(67, 260);
            this.i_modem.MaxLength = 32767;
            this.i_modem.Name = "i_modem";
            this.i_modem.PasswordChar = '\0';
            this.i_modem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.i_modem.SelectedText = "";
            this.i_modem.SelectionLength = 0;
            this.i_modem.SelectionStart = 0;
            this.i_modem.ShortcutsEnabled = true;
            this.i_modem.Size = new System.Drawing.Size(210, 23);
            this.i_modem.TabIndex = 17;
            this.i_modem.UseSelectable = true;
            this.i_modem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.i_modem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(59, 233);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(101, 19);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Name ou MAC:";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 400);
            this.Controls.Add(this.i_modem);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.l_erro);
            this.Controls.Add(this.i_pass);
            this.Controls.Add(this.i_user);
            this.Controls.Add(this.l_pass);
            this.Controls.Add(this.l_user);
            this.Controls.Add(this.btn_log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(342, 400);
            this.MinimumSize = new System.Drawing.Size(342, 400);
            this.Name = "login";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "INV_ID ESAN";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_log;
        private MetroFramework.Controls.MetroLabel l_user;
        private MetroFramework.Controls.MetroLabel l_pass;
        private MetroFramework.Controls.MetroTextBox i_user;
        private MetroFramework.Controls.MetroTextBox i_pass;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Label l_erro;
        private MetroFramework.Controls.MetroTextBox i_modem;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}