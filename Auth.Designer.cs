namespace COMPANY_DB
{
    partial class Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.user = new ReaLTaiizor.Controls.SmallTextBox();
            this.password = new ReaLTaiizor.Controls.SmallTextBox();
            this.hopePictureBox1 = new ReaLTaiizor.Controls.HopePictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.hopeRoundButton1 = new ReaLTaiizor.Controls.HopeRoundButton();
            this.label3 = new System.Windows.Forms.Label();
            this.parrotControlEllipse1 = new ReaLTaiizor.Controls.ParrotControlEllipse();
            this.hopeNotify1 = new ReaLTaiizor.Controls.HopeNotify();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(88, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Авторизация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(550, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "БД \"Поликлиника\"";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user
            // 
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.user.CustomBGColor = System.Drawing.Color.White;
            this.user.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user.ForeColor = System.Drawing.Color.Silver;
            this.user.Location = new System.Drawing.Point(50, 140);
            this.user.MaxLength = 32767;
            this.user.Multiline = false;
            this.user.Name = "user";
            this.user.ReadOnly = false;
            this.user.Size = new System.Drawing.Size(181, 30);
            this.user.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.user.TabIndex = 100;
            this.user.Text = "Логин";
            this.user.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.user.UseSystemPasswordChar = false;
            this.user.Enter += new System.EventHandler(this.user_Enter);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.password.CustomBGColor = System.Drawing.Color.White;
            this.password.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.ForeColor = System.Drawing.Color.Silver;
            this.password.Location = new System.Drawing.Point(50, 176);
            this.password.MaxLength = 32767;
            this.password.Multiline = false;
            this.password.Name = "password";
            this.password.ReadOnly = false;
            this.password.Size = new System.Drawing.Size(181, 30);
            this.password.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.password.TabIndex = 101;
            this.password.Text = "Пароль";
            this.password.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.password.UseSystemPasswordChar = true;
            this.password.Enter += new System.EventHandler(this.password_Enter);
            // 
            // hopePictureBox1
            // 
            this.hopePictureBox1.BackColor = System.Drawing.Color.White;
            this.hopePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("hopePictureBox1.Image")));
            this.hopePictureBox1.Location = new System.Drawing.Point(272, 57);
            this.hopePictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hopePictureBox1.Name = "hopePictureBox1";
            this.hopePictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.hopePictureBox1.Size = new System.Drawing.Size(234, 242);
            this.hopePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hopePictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.hopePictureBox1.TabIndex = 25;
            this.hopePictureBox1.TabStop = false;
            this.hopePictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::COMPANY_DB.Properties.Resources.icon1;
            this.pictureBox2.Location = new System.Drawing.Point(13, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // hopeRoundButton1
            // 
            this.hopeRoundButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeRoundButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeRoundButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeRoundButton1.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeRoundButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeRoundButton1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hopeRoundButton1.HoverTextColor = System.Drawing.Color.White;
            this.hopeRoundButton1.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeRoundButton1.Location = new System.Drawing.Point(50, 226);
            this.hopeRoundButton1.Name = "hopeRoundButton1";
            this.hopeRoundButton1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeRoundButton1.Size = new System.Drawing.Size(181, 32);
            this.hopeRoundButton1.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeRoundButton1.TabIndex = 31;
            this.hopeRoundButton1.Text = "Войти";
            this.hopeRoundButton1.TextColor = System.Drawing.Color.White;
            this.hopeRoundButton1.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeRoundButton1.Click += new System.EventHandler(this.hopeRoundButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.label3.Location = new System.Drawing.Point(111, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Помощь";
            // 
            // parrotControlEllipse1
            // 
            this.parrotControlEllipse1.CornerRadius = 8;
            this.parrotControlEllipse1.EffectedControl = null;
            // 
            // hopeNotify1
            // 
            this.hopeNotify1.BackColor = System.Drawing.Color.White;
            this.hopeNotify1.Close = true;
            this.hopeNotify1.CloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(148)))), ((int)(((byte)(154)))));
            this.hopeNotify1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.hopeNotify1.ErrorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeNotify1.ErrorTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeNotify1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hopeNotify1.InfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeNotify1.InfoTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeNotify1.Location = new System.Drawing.Point(50, 66);
            this.hopeNotify1.Name = "hopeNotify1";
            this.hopeNotify1.Size = new System.Drawing.Size(181, 34);
            this.hopeNotify1.SuccessBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeNotify1.SuccessTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeNotify1.TabIndex = 32;
            this.hopeNotify1.Text = "Успешный вход!";
            this.hopeNotify1.Type = ReaLTaiizor.Controls.HopeNotify.AlertType.Success;
            this.hopeNotify1.UseWaitCursor = true;
            this.hopeNotify1.Visible = false;
            this.hopeNotify1.WarningBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeNotify1.WarningTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = false;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(458, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.DimGray;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.DimGray;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 34;
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::COMPANY_DB.Properties.Resources.bg3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(550, 350);
            this.Controls.Add(this.nightControlBox1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hopeNotify1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.user);
            this.Controls.Add(this.hopeRoundButton1);
            this.Controls.Add(this.hopePictureBox1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1536, 834);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Auth";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приложение Поликлиника";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Auth_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.SmallTextBox user;
        private ReaLTaiizor.Controls.SmallTextBox password;
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton1;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.ParrotControlEllipse parrotControlEllipse1;
        private ReaLTaiizor.Controls.HopeNotify hopeNotify1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
    }
}