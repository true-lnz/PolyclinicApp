namespace COMPANY_DB
{
    partial class ParametrInput
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
            this.parametrLabel = new System.Windows.Forms.Label();
            this.aloneComboBox1 = new ReaLTaiizor.Controls.AloneComboBox();
            this.chooseButton = new ReaLTaiizor.Controls.HopeButton();
            this.hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            this.SuspendLayout();
            // 
            // parametrLabel
            // 
            this.parametrLabel.BackColor = System.Drawing.Color.GhostWhite;
            this.parametrLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.parametrLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parametrLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.parametrLabel.Location = new System.Drawing.Point(0, 0);
            this.parametrLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.parametrLabel.Name = "parametrLabel";
            this.parametrLabel.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.parametrLabel.Size = new System.Drawing.Size(299, 31);
            this.parametrLabel.TabIndex = 23;
            this.parametrLabel.Text = "Выберите отдел ...";
            this.parametrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aloneComboBox1
            // 
            this.aloneComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aloneComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aloneComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aloneComboBox1.EnabledCalc = true;
            this.aloneComboBox1.FormattingEnabled = true;
            this.aloneComboBox1.ItemHeight = 20;
            this.aloneComboBox1.Location = new System.Drawing.Point(12, 46);
            this.aloneComboBox1.Name = "aloneComboBox1";
            this.aloneComboBox1.Size = new System.Drawing.Size(275, 26);
            this.aloneComboBox1.TabIndex = 55;
            // 
            // chooseButton
            // 
            this.chooseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chooseButton.BackColor = System.Drawing.Color.DimGray;
            this.chooseButton.BorderColor = System.Drawing.Color.Blue;
            this.chooseButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.chooseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.chooseButton.DefaultColor = System.Drawing.Color.Black;
            this.chooseButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseButton.HoverTextColor = System.Drawing.Color.White;
            this.chooseButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.chooseButton.Location = new System.Drawing.Point(57, 83);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.chooseButton.Size = new System.Drawing.Size(100, 26);
            this.chooseButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.chooseButton.TabIndex = 56;
            this.chooseButton.Tag = "";
            this.chooseButton.Text = "Выбрать";
            this.chooseButton.TextColor = System.Drawing.Color.White;
            this.chooseButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // hopeButton1
            // 
            this.hopeButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.hopeButton1.BackColor = System.Drawing.Color.DimGray;
            this.hopeButton1.BorderColor = System.Drawing.Color.Blue;
            this.hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton1.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton1.DefaultColor = System.Drawing.Color.Black;
            this.hopeButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hopeButton1.HoverTextColor = System.Drawing.Color.White;
            this.hopeButton1.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton1.Location = new System.Drawing.Point(167, 83);
            this.hopeButton1.Name = "hopeButton1";
            this.hopeButton1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.hopeButton1.Size = new System.Drawing.Size(75, 26);
            this.hopeButton1.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton1.TabIndex = 57;
            this.hopeButton1.Tag = "";
            this.hopeButton1.Text = "Отмена";
            this.hopeButton1.TextColor = System.Drawing.Color.White;
            this.hopeButton1.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton1.Click += new System.EventHandler(this.hopeButton1_Click);
            // 
            // ParametrInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(299, 124);
            this.Controls.Add(this.hopeButton1);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.aloneComboBox1);
            this.Controls.Add(this.parametrLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParametrInput";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "deptInput";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        public ReaLTaiizor.Controls.AloneComboBox aloneComboBox1;
        public ReaLTaiizor.Controls.HopeButton chooseButton;
        public ReaLTaiizor.Controls.HopeButton hopeButton1;
        public System.Windows.Forms.Label parametrLabel;
    }
}