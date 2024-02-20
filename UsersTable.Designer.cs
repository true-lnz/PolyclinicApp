using System.Windows.Forms;

namespace COMPANY_DB
{
    partial class UsersTable
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
            System.Windows.Forms.Label loginLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label access_LevelLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersTable));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.usersBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.usersBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.passwordTextBox = new ReaLTaiizor.Controls.HopeTextBox();
            this.loginTextBox = new ReaLTaiizor.Controls.HopeTextBox();
            this.AccessLevelNumeric = new ReaLTaiizor.Controls.HopeNumeric();
            this.deleteButton = new ReaLTaiizor.Controls.ParrotButton();
            this.newButton = new ReaLTaiizor.Controls.ParrotButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hopeCheckBox1 = new ReaLTaiizor.Controls.HopeCheckBox();
            this.hopeCheckBox2 = new ReaLTaiizor.Controls.HopeCheckBox();
            this.parrotButton1 = new ReaLTaiizor.Controls.ParrotButton();
            this.parrotButton2 = new ReaLTaiizor.Controls.ParrotButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            loginLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            access_LevelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingNavigator)).BeginInit();
            this.usersBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new System.Drawing.Point(18, 281);
            loginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(41, 13);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "Логин:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(135, 281);
            passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(48, 13);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Пароль:";
            // 
            // access_LevelLabel
            // 
            access_LevelLabel.AutoSize = true;
            access_LevelLabel.Location = new System.Drawing.Point(253, 281);
            access_LevelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            access_LevelLabel.Name = "access_LevelLabel";
            access_LevelLabel.Size = new System.Drawing.Size(72, 13);
            access_LevelLabel.TabIndex = 6;
            access_LevelLabel.Text = "Код доступа:";
            // 
            // usersBindingNavigator
            // 
            this.usersBindingNavigator.AddNewItem = null;
            this.usersBindingNavigator.AutoSize = false;
            this.usersBindingNavigator.BackColor = System.Drawing.Color.Transparent;
            this.usersBindingNavigator.BindingSource = this.bindingSource1;
            this.usersBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.usersBindingNavigator.DeleteItem = null;
            this.usersBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.usersBindingNavigator.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.usersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.usersBindingNavigatorSaveItem});
            this.usersBindingNavigator.Location = new System.Drawing.Point(0, 31);
            this.usersBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.usersBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.usersBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.usersBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.usersBindingNavigator.Name = "usersBindingNavigator";
            this.usersBindingNavigator.Padding = new System.Windows.Forms.Padding(2);
            this.usersBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.usersBindingNavigator.Size = new System.Drawing.Size(463, 41);
            this.usersBindingNavigator.TabIndex = 0;
            this.usersBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 37);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(41, 37);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_angle_left_3916954;
            this.bindingNavigatorMovePreviousItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(41, 37);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 37);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bindingNavigatorPositionItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(20, 37);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_angle_right_3916925;
            this.bindingNavigatorMoveNextItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(41, 37);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Enabled = false;
            this.bindingNavigatorMoveLastItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_step_forward_10436103;
            this.bindingNavigatorMoveLastItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(41, 37);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Enabled = false;
            this.bindingNavigatorAddNewItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_plus_39177571;
            this.bindingNavigatorAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(41, 37);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Enabled = false;
            this.bindingNavigatorDeleteItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_trash_3917772;
            this.bindingNavigatorDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(41, 37);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // usersBindingNavigatorSaveItem
            // 
            this.usersBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.usersBindingNavigatorSaveItem.Enabled = false;
            this.usersBindingNavigatorSaveItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_disk_39177731;
            this.usersBindingNavigatorSaveItem.Margin = new System.Windows.Forms.Padding(0);
            this.usersBindingNavigatorSaveItem.Name = "usersBindingNavigatorSaveItem";
            this.usersBindingNavigatorSaveItem.Padding = new System.Windows.Forms.Padding(10);
            this.usersBindingNavigatorSaveItem.Size = new System.Drawing.Size(41, 37);
            this.usersBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.usersBindingNavigatorSaveItem.Click += new System.EventHandler(this.usersBindingNavigatorSaveItem_Click);
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
            this.label2.Size = new System.Drawing.Size(450, 31);
            this.label2.TabIndex = 40;
            this.label2.Text = "Пользователи";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label2_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label2_MouseUp);
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.usersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.GridColor = System.Drawing.Color.Silver;
            this.usersDataGridView.Location = new System.Drawing.Point(13, 75);
            this.usersDataGridView.MultiSelect = false;
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usersDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.usersDataGridView.RowHeadersWidth = 51;
            this.usersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGridView.Size = new System.Drawing.Size(425, 194);
            this.usersDataGridView.TabIndex = 43;
            this.usersDataGridView.DataSourceChanged += new System.EventHandler(this.usersDataGridView_DataSourceChanged);
            this.usersDataGridView.SelectionChanged += new System.EventHandler(this.usersDataGridView_SelectionChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.BaseColor = System.Drawing.Color.White;
            this.passwordTextBox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.passwordTextBox.BorderColorB = System.Drawing.Color.Silver;
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.passwordTextBox.Hint = "";
            this.passwordTextBox.Location = new System.Drawing.Point(132, 299);
            this.passwordTextBox.MaxLength = 255;
            this.passwordTextBox.MinimumSize = new System.Drawing.Size(100, 32);
            this.passwordTextBox.Multiline = false;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '\0';
            this.passwordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTextBox.SelectedText = "";
            this.passwordTextBox.SelectionLength = 0;
            this.passwordTextBox.SelectionStart = 0;
            this.passwordTextBox.Size = new System.Drawing.Size(110, 32);
            this.passwordTextBox.TabIndex = 47;
            this.passwordTextBox.TabStop = false;
            this.passwordTextBox.UseSystemPasswordChar = false;
            // 
            // loginTextBox
            // 
            this.loginTextBox.BackColor = System.Drawing.Color.White;
            this.loginTextBox.BaseColor = System.Drawing.Color.White;
            this.loginTextBox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.loginTextBox.BorderColorB = System.Drawing.Color.Silver;
            this.loginTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.loginTextBox.Hint = "";
            this.loginTextBox.Location = new System.Drawing.Point(13, 299);
            this.loginTextBox.MaxLength = 255;
            this.loginTextBox.MinimumSize = new System.Drawing.Size(100, 32);
            this.loginTextBox.Multiline = false;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.PasswordChar = '\0';
            this.loginTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.loginTextBox.SelectedText = "";
            this.loginTextBox.SelectionLength = 0;
            this.loginTextBox.SelectionStart = 0;
            this.loginTextBox.Size = new System.Drawing.Size(110, 32);
            this.loginTextBox.TabIndex = 48;
            this.loginTextBox.TabStop = false;
            this.loginTextBox.UseSystemPasswordChar = false;
            // 
            // AccessLevelNumeric
            // 
            this.AccessLevelNumeric.BackColor = System.Drawing.Color.White;
            this.AccessLevelNumeric.BaseColor = System.Drawing.Color.White;
            this.AccessLevelNumeric.BorderColorA = System.Drawing.Color.Silver;
            this.AccessLevelNumeric.BorderColorB = System.Drawing.Color.Silver;
            this.AccessLevelNumeric.BorderHoverColorA = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.AccessLevelNumeric.ButtonTextColorA = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.AccessLevelNumeric.ButtonTextColorB = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.AccessLevelNumeric.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AccessLevelNumeric.Enabled = false;
            this.AccessLevelNumeric.EnterKey = true;
            this.AccessLevelNumeric.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.AccessLevelNumeric.ForeColor = System.Drawing.Color.DarkGray;
            this.AccessLevelNumeric.HoverButtonTextColorA = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.AccessLevelNumeric.HoverButtonTextColorB = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.AccessLevelNumeric.Location = new System.Drawing.Point(251, 299);
            this.AccessLevelNumeric.MaxNum = 2F;
            this.AccessLevelNumeric.MinNum = 0F;
            this.AccessLevelNumeric.Name = "AccessLevelNumeric";
            this.AccessLevelNumeric.Precision = 0;
            this.AccessLevelNumeric.Size = new System.Drawing.Size(100, 32);
            this.AccessLevelNumeric.Step = 1F;
            this.AccessLevelNumeric.Style = ReaLTaiizor.Controls.HopeNumeric.NumericStyle.LeftRight;
            this.AccessLevelNumeric.TabIndex = 50;
            this.AccessLevelNumeric.ValueNumber = 0F;
            this.AccessLevelNumeric.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AccessLevelNumeric_MouseClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.deleteButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.deleteButton.ButtonImage = global::COMPANY_DB.Properties.Resources.delete1;
            this.deleteButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.deleteButton.ButtonText = "";
            this.deleteButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(117)))), ((int)(((byte)(209)))));
            this.deleteButton.ClickTextColor = System.Drawing.Color.White;
            this.deleteButton.CornerRadius = 4;
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.deleteButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.deleteButton.HoverTextColor = System.Drawing.Color.White;
            this.deleteButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.deleteButton.Location = new System.Drawing.Point(406, 299);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(32, 32);
            this.deleteButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.deleteButton.TabIndex = 60;
            this.deleteButton.TextColor = System.Drawing.Color.DodgerBlue;
            this.deleteButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.deleteButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.newButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.newButton.ButtonImage = global::COMPANY_DB.Properties.Resources.new4;
            this.newButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.newButton.ButtonText = "";
            this.newButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(117)))), ((int)(((byte)(209)))));
            this.newButton.ClickTextColor = System.Drawing.Color.White;
            this.newButton.CornerRadius = 4;
            this.newButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.newButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.newButton.HoverTextColor = System.Drawing.Color.White;
            this.newButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.newButton.Location = new System.Drawing.Point(368, 299);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(32, 32);
            this.newButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.newButton.TabIndex = 59;
            this.newButton.TextColor = System.Drawing.Color.DodgerBlue;
            this.newButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.newButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::COMPANY_DB.Properties.Resources.icon1;
            this.pictureBox2.Location = new System.Drawing.Point(13, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 62;
            // 
            // hopeCheckBox1
            // 
            this.hopeCheckBox1.AutoSize = true;
            this.hopeCheckBox1.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeCheckBox1.DisabledColor = System.Drawing.Color.White;
            this.hopeCheckBox1.DisabledStringColor = System.Drawing.Color.White;
            this.hopeCheckBox1.Enable = true;
            this.hopeCheckBox1.Enabled = false;
            this.hopeCheckBox1.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeCheckBox1.EnabledStringColor = System.Drawing.Color.Black;
            this.hopeCheckBox1.EnabledUncheckedColor = System.Drawing.Color.LightGray;
            this.hopeCheckBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.hopeCheckBox1.ForeColor = System.Drawing.Color.Gray;
            this.hopeCheckBox1.Location = new System.Drawing.Point(13, 341);
            this.hopeCheckBox1.Name = "hopeCheckBox1";
            this.hopeCheckBox1.Size = new System.Drawing.Size(241, 20);
            this.hopeCheckBox1.TabIndex = 64;
            this.hopeCheckBox1.Text = "Вкл. аудит авторизации пользователей";
            this.hopeCheckBox1.UseVisualStyleBackColor = true;
            // 
            // hopeCheckBox2
            // 
            this.hopeCheckBox2.AutoSize = true;
            this.hopeCheckBox2.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeCheckBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeCheckBox2.DisabledColor = System.Drawing.Color.White;
            this.hopeCheckBox2.DisabledStringColor = System.Drawing.Color.White;
            this.hopeCheckBox2.Enable = true;
            this.hopeCheckBox2.Enabled = false;
            this.hopeCheckBox2.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeCheckBox2.EnabledStringColor = System.Drawing.Color.Black;
            this.hopeCheckBox2.EnabledUncheckedColor = System.Drawing.Color.LightGray;
            this.hopeCheckBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.hopeCheckBox2.ForeColor = System.Drawing.Color.Gray;
            this.hopeCheckBox2.Location = new System.Drawing.Point(13, 366);
            this.hopeCheckBox2.Name = "hopeCheckBox2";
            this.hopeCheckBox2.Size = new System.Drawing.Size(281, 20);
            this.hopeCheckBox2.TabIndex = 65;
            this.hopeCheckBox2.Text = "Вкл. аудит использования хранимых процедур";
            this.hopeCheckBox2.UseVisualStyleBackColor = true;
            // 
            // parrotButton1
            // 
            this.parrotButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.parrotButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.parrotButton1.ButtonImage = null;
            this.parrotButton1.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.parrotButton1.ButtonText = "История";
            this.parrotButton1.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(117)))), ((int)(((byte)(209)))));
            this.parrotButton1.ClickTextColor = System.Drawing.Color.White;
            this.parrotButton1.CornerRadius = 4;
            this.parrotButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parrotButton1.Enabled = false;
            this.parrotButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.parrotButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.parrotButton1.HoverTextColor = System.Drawing.Color.White;
            this.parrotButton1.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.parrotButton1.Location = new System.Drawing.Point(368, 337);
            this.parrotButton1.Name = "parrotButton1";
            this.parrotButton1.Size = new System.Drawing.Size(70, 49);
            this.parrotButton1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.parrotButton1.TabIndex = 66;
            this.parrotButton1.TextColor = System.Drawing.Color.White;
            this.parrotButton1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.parrotButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            // 
            // parrotButton2
            // 
            this.parrotButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.parrotButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.parrotButton2.ButtonImage = null;
            this.parrotButton2.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.parrotButton2.ButtonText = "Назад";
            this.parrotButton2.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(117)))), ((int)(((byte)(209)))));
            this.parrotButton2.ClickTextColor = System.Drawing.Color.White;
            this.parrotButton2.CornerRadius = 4;
            this.parrotButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parrotButton2.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.parrotButton2.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.parrotButton2.HoverTextColor = System.Drawing.Color.White;
            this.parrotButton2.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.parrotButton2.Location = new System.Drawing.Point(368, 5);
            this.parrotButton2.Name = "parrotButton2";
            this.parrotButton2.Size = new System.Drawing.Size(70, 26);
            this.parrotButton2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.parrotButton2.TabIndex = 67;
            this.parrotButton2.TextColor = System.Drawing.Color.White;
            this.parrotButton2.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.parrotButton2.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.parrotButton2.Click += new System.EventHandler(this.parrotButton2_Click);
            // 
            // UsersTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.parrotButton2);
            this.Controls.Add(this.parrotButton1);
            this.Controls.Add(this.hopeCheckBox2);
            this.Controls.Add(this.hopeCheckBox1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.AccessLevelNumeric);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usersDataGridView);
            this.Controls.Add(this.usersBindingNavigator);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(access_LevelLabel);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(loginLabel);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 0);
            this.Name = "UsersTable";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UsersTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingNavigator)).EndInit();
            this.usersBindingNavigator.ResumeLayout(false);
            this.usersBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingNavigator usersBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton usersBindingNavigatorSaveItem;
        private Label label2;
        private PictureBox pictureBox2;
        private DataGridView usersDataGridView;
        private ReaLTaiizor.Controls.HopeTextBox passwordTextBox;
        private ReaLTaiizor.Controls.HopeTextBox loginTextBox;
        private ReaLTaiizor.Controls.HopeNumeric AccessLevelNumeric;
        private ReaLTaiizor.Controls.ParrotButton newButton;
        private ReaLTaiizor.Controls.ParrotButton deleteButton;
        private TextBox textBox1;
        private ReaLTaiizor.Controls.HopeCheckBox hopeCheckBox1;
        private ReaLTaiizor.Controls.HopeCheckBox hopeCheckBox2;
        private ReaLTaiizor.Controls.ParrotButton parrotButton1;
        private ReaLTaiizor.Controls.ParrotButton parrotButton2;
        private ToolStripButton bindingNavigatorDeleteItem;
        private BindingSource bindingSource1;
    }
}