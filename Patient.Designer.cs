﻿using System.Windows.Forms;

namespace COMPANY_DB
{
    partial class Patient
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
            System.Windows.Forms.Label chronicDiseasesLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label phoneNumberLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label allergiesLabel;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient));
            this.patient_newDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_newBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.polDataSet = new COMPANY_DB.polDataSet();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.hopeRadioButton2 = new ReaLTaiizor.Controls.HopeRadioButton();
            this.hopeRadioButton1 = new ReaLTaiizor.Controls.HopeRadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chronic = new ReaLTaiizor.Controls.HopeRichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.allergies = new ReaLTaiizor.Controls.HopeRichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.telphone = new ReaLTaiizor.Controls.HopeTextBox();
            this.address = new ReaLTaiizor.Controls.HopeTextBox();
            this.deletePatientButton = new ReaLTaiizor.Controls.HopeButton();
            this.newPatientButton = new ReaLTaiizor.Controls.HopeButton();
            this.hopeButton4 = new ReaLTaiizor.Controls.HopeButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.aloneComboBox2 = new ReaLTaiizor.Controls.AloneComboBox();
            this.aloneComboBox1 = new ReaLTaiizor.Controls.AloneComboBox();
            this.separator1 = new ReaLTaiizor.Controls.Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelSearchButton = new ReaLTaiizor.Controls.ParrotButton();
            this.backwardButton = new ReaLTaiizor.Controls.ParrotButton();
            this.forwardButton = new ReaLTaiizor.Controls.ParrotButton();
            this.patientBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.patientBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.status = new System.Windows.Forms.ToolStripLabel();
            this.Bubble = new ReaLTaiizor.Controls.ChatBubbleRight();
            this.Bubble2 = new ReaLTaiizor.Controls.ChatBubbleRight();
            this.genderTextBox = new System.Windows.Forms.TextBox();
            this.cyberSwitch1 = new ReaLTaiizor.Controls.CyberSwitch();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.patient_newTableAdapter = new COMPANY_DB.polDataSetTableAdapters.Patient_newTableAdapter();
            this.tableAdapterManager = new COMPANY_DB.polDataSetTableAdapters.TableAdapterManager();
            chronicDiseasesLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            phoneNumberLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            allergiesLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.patient_newDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patient_newBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingNavigator)).BeginInit();
            this.patientBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // chronicDiseasesLabel
            // 
            chronicDiseasesLabel.AutoSize = true;
            chronicDiseasesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            chronicDiseasesLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chronicDiseasesLabel.Location = new System.Drawing.Point(0, 0);
            chronicDiseasesLabel.Margin = new System.Windows.Forms.Padding(0);
            chronicDiseasesLabel.Name = "chronicDiseasesLabel";
            chronicDiseasesLabel.Size = new System.Drawing.Size(179, 19);
            chronicDiseasesLabel.TabIndex = 9;
            chronicDiseasesLabel.Text = "Хронические заболевания:";
            // 
            // addressLabel
            // 
            addressLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            addressLabel.AutoSize = true;
            addressLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            addressLabel.Location = new System.Drawing.Point(15, 331);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(50, 19);
            addressLabel.TabIndex = 13;
            addressLabel.Text = "Адрес:";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            phoneNumberLabel.Location = new System.Drawing.Point(15, 373);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new System.Drawing.Size(66, 19);
            phoneNumberLabel.TabIndex = 15;
            phoneNumberLabel.Text = "Телефон:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            label1.Location = new System.Drawing.Point(55, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(176, 30);
            label1.TabIndex = 67;
            label1.Text = "Детали пациента";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // allergiesLabel
            // 
            allergiesLabel.AutoSize = true;
            allergiesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            allergiesLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            allergiesLabel.Location = new System.Drawing.Point(0, 0);
            allergiesLabel.Margin = new System.Windows.Forms.Padding(0);
            allergiesLabel.Name = "allergiesLabel";
            allergiesLabel.Size = new System.Drawing.Size(71, 19);
            allergiesLabel.TabIndex = 69;
            allergiesLabel.Text = "Аллергии:";
            // 
            // label5
            // 
            label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label5.ForeColor = System.Drawing.Color.LightGray;
            label5.Location = new System.Drawing.Point(833, 17);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 19);
            label5.TabIndex = 77;
            label5.Text = "Вкл. ред.";
            // 
            // patient_newDataGridView
            // 
            this.patient_newDataGridView.AllowUserToAddRows = false;
            this.patient_newDataGridView.AutoGenerateColumns = false;
            this.patient_newDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.patient_newDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.patient_newDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.patient_newDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.patient_newDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patient_newDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.LastModified});
            this.patient_newDataGridView.DataSource = this.patient_newBindingSource;
            this.patient_newDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patient_newDataGridView.GridColor = System.Drawing.Color.Silver;
            this.patient_newDataGridView.Location = new System.Drawing.Point(0, 50);
            this.patient_newDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.patient_newDataGridView.Name = "patient_newDataGridView";
            this.patient_newDataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.patient_newDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.patient_newDataGridView.RowHeadersWidth = 51;
            this.patient_newDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patient_newDataGridView.Size = new System.Drawing.Size(663, 435);
            this.patient_newDataGridView.TabIndex = 57;
            this.patient_newDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.patient_newDataGridView_CellClick);
            this.patient_newDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.patient_newDataGridView_DataError);
            this.patient_newDataGridView.SelectionChanged += new System.EventHandler(this.patient_newDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PatientID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PatientID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Surname";
            this.dataGridViewTextBoxColumn2.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FirstName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MiddleName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Отчество";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BirthDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата рождения";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Gender";
            this.dataGridViewTextBoxColumn6.HeaderText = "Пол";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 63;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Allergies";
            this.dataGridViewTextBoxColumn7.HeaderText = "Аллергия";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ChronicDiseases";
            this.dataGridViewTextBoxColumn8.HeaderText = "Хронические заболевания";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn9.HeaderText = "Адрес";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PhoneNumber";
            this.dataGridViewTextBoxColumn10.HeaderText = "Номер телефона";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // LastModified
            // 
            this.LastModified.DataPropertyName = "LastModified";
            this.LastModified.HeaderText = "Изменено";
            this.LastModified.MinimumWidth = 6;
            this.LastModified.Name = "LastModified";
            this.LastModified.ReadOnly = true;
            this.LastModified.Visible = false;
            // 
            // patient_newBindingSource
            // 
            this.patient_newBindingSource.DataMember = "Patient_new";
            this.patient_newBindingSource.DataSource = this.polDataSet;
            // 
            // polDataSet
            // 
            this.polDataSet.DataSetName = "polDataSet";
            this.polDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // surnameLabel
            // 
            this.surnameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "Surname", true));
            this.surnameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surnameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.surnameLabel.Location = new System.Drawing.Point(0, 0);
            this.surnameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.surnameLabel.MaximumSize = new System.Drawing.Size(267, 246);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(267, 25);
            this.surnameLabel.TabIndex = 1;
            this.surnameLabel.Text = "Фамилия";
            this.surnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.surnameLabel.DoubleClick += new System.EventHandler(this.surnameLabel_DoubleClick);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "FirstName", true));
            this.firstNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNameLabel.Location = new System.Drawing.Point(0, 0);
            this.firstNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.firstNameLabel.MaximumSize = new System.Drawing.Size(267, 246);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(267, 25);
            this.firstNameLabel.TabIndex = 3;
            this.firstNameLabel.Text = "Имя";
            this.firstNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.firstNameLabel.DoubleClick += new System.EventHandler(this.firstNameLabel_DoubleClick);
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "MiddleName", true));
            this.LastNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LastNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastNameLabel.Location = new System.Drawing.Point(0, 0);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(267, 25);
            this.LastNameLabel.TabIndex = 5;
            this.LastNameLabel.Text = "Отчество";
            this.LastNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LastNameLabel.DoubleClick += new System.EventHandler(this.LastNameLabel_DoubleClick);
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "BirthDate", true));
            this.birthDateLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthDateLabel.Location = new System.Drawing.Point(133, 118);
            this.birthDateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new System.Drawing.Size(155, 16);
            this.birthDateLabel.TabIndex = 11;
            this.birthDateLabel.DoubleClick += new System.EventHandler(this.birthDateLabel_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.hopeButton1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.telphone);
            this.panel1.Controls.Add(this.address);
            this.panel1.Controls.Add(this.deletePatientButton);
            this.panel1.Controls.Add(this.newPatientButton);
            this.panel1.Controls.Add(phoneNumberLabel);
            this.panel1.Controls.Add(addressLabel);
            this.panel1.Controls.Add(this.birthDateLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(663, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 527);
            this.panel1.TabIndex = 25;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.hopeRadioButton2);
            this.panel8.Controls.Add(this.hopeRadioButton1);
            this.panel8.Enabled = false;
            this.panel8.Location = new System.Drawing.Point(61, 144);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(112, 25);
            this.panel8.TabIndex = 58;
            // 
            // hopeRadioButton2
            // 
            this.hopeRadioButton2.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeRadioButton2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hopeRadioButton2.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hopeRadioButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.hopeRadioButton2.Enable = true;
            this.hopeRadioButton2.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeRadioButton2.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hopeRadioButton2.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hopeRadioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hopeRadioButton2.ForeColor = System.Drawing.Color.Black;
            this.hopeRadioButton2.Location = new System.Drawing.Point(43, 0);
            this.hopeRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.hopeRadioButton2.Name = "hopeRadioButton2";
            this.hopeRadioButton2.Size = new System.Drawing.Size(45, 20);
            this.hopeRadioButton2.TabIndex = 70;
            this.hopeRadioButton2.TabStop = true;
            this.hopeRadioButton2.Text = "Ж";
            this.hopeRadioButton2.UseVisualStyleBackColor = true;
            this.hopeRadioButton2.CheckedChanged += new System.EventHandler(this.hopeRadioButton2_CheckedChanged);
            this.hopeRadioButton2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hopeRadioButton2_MouseDown);
            // 
            // hopeRadioButton1
            // 
            this.hopeRadioButton1.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeRadioButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hopeRadioButton1.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hopeRadioButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.hopeRadioButton1.Enable = true;
            this.hopeRadioButton1.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.hopeRadioButton1.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hopeRadioButton1.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hopeRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hopeRadioButton1.ForeColor = System.Drawing.Color.Black;
            this.hopeRadioButton1.Location = new System.Drawing.Point(0, 0);
            this.hopeRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.hopeRadioButton1.Name = "hopeRadioButton1";
            this.hopeRadioButton1.Size = new System.Drawing.Size(43, 20);
            this.hopeRadioButton1.TabIndex = 69;
            this.hopeRadioButton1.TabStop = true;
            this.hopeRadioButton1.Text = "М";
            this.hopeRadioButton1.UseVisualStyleBackColor = true;
            this.hopeRadioButton1.CheckedChanged += new System.EventHandler(this.hopeRadioButton1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 71;
            this.label4.Text = "Пол:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "Дата рождения:";
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
            this.hopeButton1.Location = new System.Drawing.Point(157, 457);
            this.hopeButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hopeButton1.Name = "hopeButton1";
            this.hopeButton1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.hopeButton1.Size = new System.Drawing.Size(133, 32);
            this.hopeButton1.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton1.TabIndex = 60;
            this.hopeButton1.Text = "Отмена";
            this.hopeButton1.TextColor = System.Drawing.Color.White;
            this.hopeButton1.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton1.Click += new System.EventHandler(this.hopeButton1_Click_1);
            this.hopeButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hopeButton1_MouseDown);
            this.hopeButton1.MouseEnter += new System.EventHandler(this.hopeButton1_MouseEnter);
            this.hopeButton1.MouseLeave += new System.EventHandler(this.hopeButton1_MouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 178);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 129);
            this.tableLayoutPanel1.TabIndex = 60;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.chronic);
            this.panel7.Controls.Add(chronicDiseasesLabel);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 64);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(273, 65);
            this.panel7.TabIndex = 62;
            // 
            // chronic
            // 
            this.chronic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chronic.BackColor = System.Drawing.Color.White;
            this.chronic.BorderColor = System.Drawing.Color.Gainsboro;
            this.chronic.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "ChronicDiseases", true));
            this.chronic.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chronic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.chronic.Hint = "";
            this.chronic.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.chronic.Location = new System.Drawing.Point(0, 22);
            this.chronic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chronic.MaximumSize = new System.Drawing.Size(273, 246);
            this.chronic.MaxLength = 255;
            this.chronic.MinimumSize = new System.Drawing.Size(273, 0);
            this.chronic.Multiline = true;
            this.chronic.Name = "chronic";
            this.chronic.PasswordChar = '\0';
            this.chronic.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.chronic.SelectedText = "";
            this.chronic.SelectionLength = 0;
            this.chronic.SelectionStart = 0;
            this.chronic.Size = new System.Drawing.Size(273, 38);
            this.chronic.TabIndex = 56;
            this.chronic.TabStop = false;
            this.chronic.UseSystemPasswordChar = false;
            this.chronic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chronic_KeyPress);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(allergiesLabel);
            this.panel6.Controls.Add(this.allergies);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(273, 64);
            this.panel6.TabIndex = 61;
            // 
            // allergies
            // 
            this.allergies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.allergies.BackColor = System.Drawing.Color.White;
            this.allergies.BorderColor = System.Drawing.Color.Gainsboro;
            this.allergies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "Allergies", true));
            this.allergies.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.allergies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.allergies.Hint = "";
            this.allergies.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.allergies.Location = new System.Drawing.Point(0, 22);
            this.allergies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.allergies.MaximumSize = new System.Drawing.Size(273, 246);
            this.allergies.MaxLength = 255;
            this.allergies.MinimumSize = new System.Drawing.Size(273, 0);
            this.allergies.Multiline = true;
            this.allergies.Name = "allergies";
            this.allergies.PasswordChar = '\0';
            this.allergies.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.allergies.SelectedText = "";
            this.allergies.SelectionLength = 0;
            this.allergies.SelectionStart = 0;
            this.allergies.Size = new System.Drawing.Size(273, 38);
            this.allergies.TabIndex = 70;
            this.allergies.TabStop = false;
            this.allergies.UseSystemPasswordChar = false;
            this.allergies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.allergies_KeyPress);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.surnameLabel);
            this.panel5.Location = new System.Drawing.Point(19, 36);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(273, 25);
            this.panel5.TabIndex = 59;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.firstNameLabel);
            this.panel4.Location = new System.Drawing.Point(19, 59);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 25);
            this.panel4.TabIndex = 58;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.LastNameLabel);
            this.panel3.Location = new System.Drawing.Point(19, 84);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 25);
            this.panel3.TabIndex = 57;
            // 
            // telphone
            // 
            this.telphone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.telphone.BackColor = System.Drawing.Color.White;
            this.telphone.BaseColor = System.Drawing.Color.White;
            this.telphone.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.telphone.BorderColorB = System.Drawing.Color.Gainsboro;
            this.telphone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "PhoneNumber", true));
            this.telphone.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.telphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.telphone.Hint = "";
            this.telphone.Location = new System.Drawing.Point(93, 363);
            this.telphone.Margin = new System.Windows.Forms.Padding(0);
            this.telphone.MaxLength = 12;
            this.telphone.Multiline = false;
            this.telphone.Name = "telphone";
            this.telphone.PasswordChar = '\0';
            this.telphone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.telphone.SelectedText = "";
            this.telphone.SelectionLength = 0;
            this.telphone.SelectionStart = 0;
            this.telphone.Size = new System.Drawing.Size(196, 38);
            this.telphone.TabIndex = 66;
            this.telphone.TabStop = false;
            this.telphone.UseSystemPasswordChar = false;
            this.telphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telphone_KeyPress);
            // 
            // address
            // 
            this.address.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.address.BackColor = System.Drawing.Color.White;
            this.address.BaseColor = System.Drawing.Color.White;
            this.address.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.address.BorderColorB = System.Drawing.Color.Gainsboro;
            this.address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "Address", true));
            this.address.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.address.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.address.Hint = "";
            this.address.Location = new System.Drawing.Point(93, 319);
            this.address.Margin = new System.Windows.Forms.Padding(0);
            this.address.MaxLength = 255;
            this.address.MinimumSize = new System.Drawing.Size(0, 31);
            this.address.Multiline = false;
            this.address.Name = "address";
            this.address.PasswordChar = '\0';
            this.address.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.address.SelectedText = "";
            this.address.SelectionLength = 0;
            this.address.SelectionStart = 0;
            this.address.Size = new System.Drawing.Size(196, 38);
            this.address.TabIndex = 65;
            this.address.TabStop = false;
            this.address.UseSystemPasswordChar = false;
            this.address.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.address_KeyPress);
            // 
            // deletePatientButton
            // 
            this.deletePatientButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deletePatientButton.BackColor = System.Drawing.Color.DimGray;
            this.deletePatientButton.BorderColor = System.Drawing.Color.Blue;
            this.deletePatientButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.deletePatientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletePatientButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.deletePatientButton.DefaultColor = System.Drawing.Color.Black;
            this.deletePatientButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deletePatientButton.HoverTextColor = System.Drawing.Color.White;
            this.deletePatientButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.deletePatientButton.Location = new System.Drawing.Point(16, 457);
            this.deletePatientButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deletePatientButton.Name = "deletePatientButton";
            this.deletePatientButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.deletePatientButton.Size = new System.Drawing.Size(133, 32);
            this.deletePatientButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.deletePatientButton.TabIndex = 49;
            this.deletePatientButton.Text = "Удалить";
            this.deletePatientButton.TextColor = System.Drawing.Color.White;
            this.deletePatientButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.deletePatientButton.Click += new System.EventHandler(this.hopeButton3_Click);
            // 
            // newPatientButton
            // 
            this.newPatientButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newPatientButton.BackColor = System.Drawing.Color.DimGray;
            this.newPatientButton.BorderColor = System.Drawing.Color.Blue;
            this.newPatientButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.newPatientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newPatientButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.newPatientButton.DefaultColor = System.Drawing.Color.Black;
            this.newPatientButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newPatientButton.HoverTextColor = System.Drawing.Color.White;
            this.newPatientButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.newPatientButton.Location = new System.Drawing.Point(16, 417);
            this.newPatientButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newPatientButton.Name = "newPatientButton";
            this.newPatientButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.newPatientButton.Size = new System.Drawing.Size(275, 32);
            this.newPatientButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.newPatientButton.TabIndex = 47;
            this.newPatientButton.Tag = "Создание новой записи";
            this.newPatientButton.Text = "Новый пациент";
            this.newPatientButton.TextColor = System.Drawing.Color.White;
            this.newPatientButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.newPatientButton.Click += new System.EventHandler(this.hopeButton1_Click);
            // 
            // hopeButton4
            // 
            this.hopeButton4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hopeButton4.BackColor = System.Drawing.Color.DimGray;
            this.hopeButton4.BorderColor = System.Drawing.Color.Blue;
            this.hopeButton4.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton4.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton4.DefaultColor = System.Drawing.Color.Black;
            this.hopeButton4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hopeButton4.HoverTextColor = System.Drawing.Color.White;
            this.hopeButton4.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton4.Location = new System.Drawing.Point(341, 21);
            this.hopeButton4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hopeButton4.Name = "hopeButton4";
            this.hopeButton4.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.hopeButton4.Size = new System.Drawing.Size(93, 32);
            this.hopeButton4.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton4.TabIndex = 52;
            this.hopeButton4.Text = "Поиск";
            this.hopeButton4.TextColor = System.Drawing.Color.White;
            this.hopeButton4.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton4.Click += new System.EventHandler(this.hopeButton4_Click);
            this.hopeButton4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hopeButton4_MouseDown);
            this.hopeButton4.MouseEnter += new System.EventHandler(this.hopeButton4_MouseEnter);
            this.hopeButton4.MouseLeave += new System.EventHandler(this.hopeButton4_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.separator1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cancelSearchButton);
            this.panel2.Controls.Add(this.backwardButton);
            this.panel2.Controls.Add(this.forwardButton);
            this.panel2.Controls.Add(this.hopeButton4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 92);
            this.panel2.TabIndex = 54;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.Controls.Add(this.aloneComboBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.aloneComboBox1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 17);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(317, 39);
            this.tableLayoutPanel2.TabIndex = 78;
            // 
            // aloneComboBox2
            // 
            this.aloneComboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aloneComboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aloneComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aloneComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aloneComboBox2.DropDownWidth = 200;
            this.aloneComboBox2.EnabledCalc = true;
            this.aloneComboBox2.FormattingEnabled = true;
            this.aloneComboBox2.ItemHeight = 20;
            this.aloneComboBox2.Location = new System.Drawing.Point(146, 4);
            this.aloneComboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.aloneComboBox2.MaximumSize = new System.Drawing.Size(532, 0);
            this.aloneComboBox2.Name = "aloneComboBox2";
            this.aloneComboBox2.Size = new System.Drawing.Size(167, 26);
            this.aloneComboBox2.TabIndex = 55;
            this.aloneComboBox2.SelectionChangeCommitted += new System.EventHandler(this.aloneComboBox2_SelectionChangeCommitted);
            // 
            // aloneComboBox1
            // 
            this.aloneComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aloneComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aloneComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aloneComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aloneComboBox1.EnabledCalc = true;
            this.aloneComboBox1.FormattingEnabled = true;
            this.aloneComboBox1.ItemHeight = 20;
            this.aloneComboBox1.Location = new System.Drawing.Point(4, 4);
            this.aloneComboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.aloneComboBox1.Name = "aloneComboBox1";
            this.aloneComboBox1.Size = new System.Drawing.Size(134, 26);
            this.aloneComboBox1.TabIndex = 54;
            this.aloneComboBox1.SelectedIndexChanged += new System.EventHandler(this.aloneComboBox1_SelectedIndexChanged_1);
            this.aloneComboBox1.Resize += new System.EventHandler(this.aloneComboBox1_Resize);
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.LineColor = System.Drawing.Color.WhiteSmoke;
            this.separator1.Location = new System.Drawing.Point(0, 0);
            this.separator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(663, 12);
            this.separator1.TabIndex = 56;
            this.separator1.Text = "separator1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(487, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 32);
            this.label2.TabIndex = 59;
            this.label2.Text = "0 из 0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelSearchButton
            // 
            this.cancelSearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelSearchButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.cancelSearchButton.ButtonImage = global::COMPANY_DB.Properties.Resources.icons8;
            this.cancelSearchButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.cancelSearchButton.ButtonText = "";
            this.cancelSearchButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(117)))), ((int)(((byte)(209)))));
            this.cancelSearchButton.ClickTextColor = System.Drawing.Color.White;
            this.cancelSearchButton.CornerRadius = 2;
            this.cancelSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelSearchButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.cancelSearchButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.cancelSearchButton.HoverTextColor = System.Drawing.Color.White;
            this.cancelSearchButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.cancelSearchButton.Location = new System.Drawing.Point(611, 21);
            this.cancelSearchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelSearchButton.Name = "cancelSearchButton";
            this.cancelSearchButton.Size = new System.Drawing.Size(36, 33);
            this.cancelSearchButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cancelSearchButton.TabIndex = 58;
            this.cancelSearchButton.TextColor = System.Drawing.Color.DodgerBlue;
            this.cancelSearchButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cancelSearchButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.cancelSearchButton.Click += new System.EventHandler(this.parrotButton3_Click);
            // 
            // backwardButton
            // 
            this.backwardButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.backwardButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.backwardButton.ButtonImage = global::COMPANY_DB.Properties.Resources.angle_w1;
            this.backwardButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.backwardButton.ButtonText = "";
            this.backwardButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(117)))), ((int)(((byte)(209)))));
            this.backwardButton.ClickTextColor = System.Drawing.Color.White;
            this.backwardButton.CornerRadius = 2;
            this.backwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backwardButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.backwardButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.backwardButton.HoverTextColor = System.Drawing.Color.White;
            this.backwardButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.backwardButton.Location = new System.Drawing.Point(443, 21);
            this.backwardButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(36, 33);
            this.backwardButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.backwardButton.TabIndex = 57;
            this.backwardButton.TextColor = System.Drawing.Color.DodgerBlue;
            this.backwardButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.backwardButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.backwardButton.Click += new System.EventHandler(this.parrotButton2_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.forwardButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.forwardButton.ButtonImage = global::COMPANY_DB.Properties.Resources.angle_w_21;
            this.forwardButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.forwardButton.ButtonText = "";
            this.forwardButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(117)))), ((int)(((byte)(209)))));
            this.forwardButton.ClickTextColor = System.Drawing.Color.White;
            this.forwardButton.CornerRadius = 2;
            this.forwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forwardButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.forwardButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.forwardButton.HoverTextColor = System.Drawing.Color.White;
            this.forwardButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.forwardButton.Location = new System.Drawing.Point(567, 21);
            this.forwardButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(36, 33);
            this.forwardButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.forwardButton.TabIndex = 56;
            this.forwardButton.TextColor = System.Drawing.Color.DodgerBlue;
            this.forwardButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.forwardButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.forwardButton.Click += new System.EventHandler(this.parrotButton1_Click);
            // 
            // patientBindingNavigator
            // 
            this.patientBindingNavigator.AddNewItem = null;
            this.patientBindingNavigator.AutoSize = false;
            this.patientBindingNavigator.BackColor = System.Drawing.Color.Transparent;
            this.patientBindingNavigator.BindingSource = this.patient_newBindingSource;
            this.patientBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.patientBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.patientBindingNavigator.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.patientBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.patientBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.status});
            this.patientBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.patientBindingNavigator.MinimumSize = new System.Drawing.Size(973, 50);
            this.patientBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.patientBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.patientBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.patientBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.patientBindingNavigator.Name = "patientBindingNavigator";
            this.patientBindingNavigator.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.patientBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.patientBindingNavigator.Size = new System.Drawing.Size(973, 50);
            this.patientBindingNavigator.TabIndex = 55;
            this.patientBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 46);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_trash_3917772;
            this.bindingNavigatorDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(41, 46);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(41, 46);
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
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(41, 46);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 46);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bindingNavigatorPositionItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(25, 30);
            this.bindingNavigatorPositionItem.Tag = "";
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_angle_right_3916925;
            this.bindingNavigatorMoveNextItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(41, 46);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_step_forward_10436103;
            this.bindingNavigatorMoveLastItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(41, 46);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_plus_39177571;
            this.bindingNavigatorAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.Padding = new System.Windows.Forms.Padding(10);
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(41, 46);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // patientBindingNavigatorSaveItem
            // 
            this.patientBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.patientBindingNavigatorSaveItem.Image = global::COMPANY_DB.Properties.Resources.free_icon_font_disk_39177731;
            this.patientBindingNavigatorSaveItem.Margin = new System.Windows.Forms.Padding(0);
            this.patientBindingNavigatorSaveItem.Name = "patientBindingNavigatorSaveItem";
            this.patientBindingNavigatorSaveItem.Padding = new System.Windows.Forms.Padding(10);
            this.patientBindingNavigatorSaveItem.Size = new System.Drawing.Size(41, 46);
            this.patientBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.patientBindingNavigatorSaveItem.Click += new System.EventHandler(this.patientBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.status.Size = new System.Drawing.Size(33, 43);
            this.status.Text = "...";
            // 
            // Bubble
            // 
            this.Bubble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bubble.BackColor = System.Drawing.Color.Transparent;
            this.Bubble.BubbleColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Bubble.DrawBubbleArrow = true;
            this.Bubble.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Bubble.Location = new System.Drawing.Point(433, 89);
            this.Bubble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bubble.Name = "Bubble";
            this.Bubble.Size = new System.Drawing.Size(331, 42);
            this.Bubble.SizeAuto = true;
            this.Bubble.SizeAutoH = true;
            this.Bubble.SizeAutoW = true;
            this.Bubble.SizeWidthLeft = false;
            this.Bubble.TabIndex = 56;
            this.Bubble.Text = "Двойной клик для редактирования";
            this.Bubble.Visible = false;
            this.Bubble.Click += new System.EventHandler(this.Bubble_Click);
            // 
            // Bubble2
            // 
            this.Bubble2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bubble2.BackColor = System.Drawing.Color.Transparent;
            this.Bubble2.BubbleColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Bubble2.DrawBubbleArrow = true;
            this.Bubble2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Bubble2.Location = new System.Drawing.Point(443, 505);
            this.Bubble2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bubble2.Name = "Bubble2";
            this.Bubble2.Size = new System.Drawing.Size(225, 42);
            this.Bubble2.SizeAuto = true;
            this.Bubble2.SizeAutoH = true;
            this.Bubble2.SizeAutoW = true;
            this.Bubble2.SizeWidthLeft = false;
            this.Bubble2.TabIndex = 57;
            this.Bubble2.Text = "Не забудьте сохранить";
            this.Bubble2.Visible = false;
            this.Bubble2.Click += new System.EventHandler(this.Bubble2_Click);
            // 
            // genderTextBox
            // 
            this.genderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patient_newBindingSource, "Gender", true));
            this.genderTextBox.Location = new System.Drawing.Point(620, 15);
            this.genderTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.Size = new System.Drawing.Size(0, 22);
            this.genderTextBox.TabIndex = 58;
            this.genderTextBox.TabStop = false;
            this.genderTextBox.TextChanged += new System.EventHandler(this.genderTextBox_TextChanged);
            // 
            // cyberSwitch1
            // 
            this.cyberSwitch1.Alpha = 50;
            this.cyberSwitch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cyberSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.cyberSwitch1.Background = true;
            this.cyberSwitch1.Background_WidthPen = 2F;
            this.cyberSwitch1.BackgroundPen = true;
            this.cyberSwitch1.Checked = false;
            this.cyberSwitch1.ColorBackground = System.Drawing.Color.White;
            this.cyberSwitch1.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.cyberSwitch1.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.cyberSwitch1.ColorBackground_Pen = System.Drawing.Color.Gainsboro;
            this.cyberSwitch1.ColorBackground_Value_1 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.cyberSwitch1.ColorBackground_Value_2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.cyberSwitch1.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.cyberSwitch1.ColorPen_1 = System.Drawing.Color.Empty;
            this.cyberSwitch1.ColorPen_2 = System.Drawing.Color.Empty;
            this.cyberSwitch1.ColorValue = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(124)))), ((int)(((byte)(234)))));
            this.cyberSwitch1.CyberSwitchStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cyberSwitch1.Font = new System.Drawing.Font("Arial", 11F);
            this.cyberSwitch1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cyberSwitch1.Lighting = false;
            this.cyberSwitch1.LinearGradient_Background = false;
            this.cyberSwitch1.LinearGradient_Value = false;
            this.cyberSwitch1.LinearGradientPen = false;
            this.cyberSwitch1.Location = new System.Drawing.Point(907, 12);
            this.cyberSwitch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cyberSwitch1.Name = "cyberSwitch1";
            this.cyberSwitch1.PenWidth = 10;
            this.cyberSwitch1.RGB = false;
            this.cyberSwitch1.Rounding = true;
            this.cyberSwitch1.RoundingInt = 90;
            this.cyberSwitch1.Size = new System.Drawing.Size(47, 25);
            this.cyberSwitch1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cyberSwitch1.TabIndex = 76;
            this.cyberSwitch1.Tag = "Cyber";
            this.cyberSwitch1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cyberSwitch1.Timer_RGB = 300;
            this.cyberSwitch1.CheckedChanged += new ReaLTaiizor.Controls.CyberSwitch.EventHandler(this.cyberSwitch1_CheckedChanged);
            // 
            // patient_newTableAdapter
            // 
            this.patient_newTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Department_newTableAdapter = null;
            this.tableAdapterManager.DepartmentTableAdapter = null;
            this.tableAdapterManager.DiagnosisTableAdapter = null;
            this.tableAdapterManager.DoctorTableAdapter = null;
            this.tableAdapterManager.MedicationListTableAdapter = null;
            this.tableAdapterManager.MedicationTableAdapter = null;
            this.tableAdapterManager.Patient_newTableAdapter = this.patient_newTableAdapter;
            this.tableAdapterManager.QuestionnaireTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = COMPANY_DB.polDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(968, 577);
            this.Controls.Add(label5);
            this.Controls.Add(this.cyberSwitch1);
            this.Controls.Add(this.genderTextBox);
            this.Controls.Add(this.Bubble);
            this.Controls.Add(this.patient_newDataGridView);
            this.Controls.Add(this.Bubble2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.patientBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Patient";
            this.Text = "Поликлиника: Пациенты";
            this.Load += new System.EventHandler(this.Patient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patient_newDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patient_newBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingNavigator)).EndInit();
            this.patientBindingNavigator.ResumeLayout(false);
            this.patientBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource patientBindingSource;
        private ReaLTaiizor.Controls.HopeButton deletePatientButton;
        private ReaLTaiizor.Controls.HopeButton newPatientButton;
        private ReaLTaiizor.Controls.HopeButton hopeButton4;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.HopeRichTextBox chronic;
        private ReaLTaiizor.Controls.HopeTextBox telphone;
        private ReaLTaiizor.Controls.HopeTextBox address;
        private ReaLTaiizor.Controls.HopeRichTextBox allergies;
        private System.Windows.Forms.Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private ReaLTaiizor.Controls.AloneComboBox aloneComboBox1;
        private ReaLTaiizor.Controls.AloneComboBox aloneComboBox2;
        private ReaLTaiizor.Controls.ParrotButton forwardButton;
        private ReaLTaiizor.Controls.ParrotButton backwardButton;
        private ReaLTaiizor.Controls.ParrotButton cancelSearchButton;
        private Label label2;
        private ReaLTaiizor.Controls.Separator separator1;
        public Label LastNameLabel;
        public Label surnameLabel;
        public Label firstNameLabel;
        private Label birthDateLabel;
        private BindingNavigator patientBindingNavigator;
        private ToolStripButton bindingNavigatorAddNewItem;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorDeleteItem;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private ToolStripButton patientBindingNavigatorSaveItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel status;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel6;
        private Panel panel7;
        private ReaLTaiizor.Controls.ChatBubbleRight Bubble;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
        private Label label3;
        private ReaLTaiizor.Controls.HopeRadioButton hopeRadioButton1;
        private Label label4;
        private ReaLTaiizor.Controls.HopeRadioButton hopeRadioButton2;
        private Panel panel8;
        private ReaLTaiizor.Controls.ChatBubbleRight Bubble2;
        private polDataSet polDataSet;
        private BindingSource patient_newBindingSource;
        private DataGridView patient_newDataGridView;
        private TextBox genderTextBox;
        private ReaLTaiizor.Controls.CyberSwitch cyberSwitch1;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn LastModified;
        public Panel panel1;
        private polDataSetTableAdapters.Patient_newTableAdapter patient_newTableAdapter;
        private polDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private TableLayoutPanel tableLayoutPanel2;
    }
}