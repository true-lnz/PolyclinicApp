using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Xceed.Words.NET;
using static COMPANY_DB.Patient;

namespace COMPANY_DB
{
    public partial class Questionnaire : Form
    {
        int Access_level = 3;
        static int DoctorIdentifier = 0;
        public Questionnaire(int Option, int DoctorID)
        {
            InitializeComponent();
            Access_level = Option;
            DoctorIdentifier = DoctorID;
            questionnaireDetailsDataGridView.EnableHeadersVisualStyles = false;
        }
        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;
        public delegate void PatientSearchEventHandler(int patientID);
        public event PatientSearchEventHandler PatientSearchRequested;
        public delegate void NewQuestionnaireEventHandler();
        public event NewQuestionnaireEventHandler NewQues;

        bool dataRead = false;
        public string query = $"SELECT * FROM Questionnaire WHERE Questionnaire.DoctorID_A = {DoctorIdentifier} OR Questionnaire.DoctorID_D = {DoctorIdentifier};";

        public void LoadData()
        {
            polDataSet.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(this.polDataSet.Questionnaire);
                    }
                }
                questionnaireDetailsDataGridView.Refresh();
                dataRead = true;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке!\nНе удалось получить доступ к таблице.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataRead = false;
            }
            //questionnaireDetailsDataGridView.Sort(questionnaireDetailsDataGridView.Columns[2], ListSortDirection.Ascending);
            questionnaireDetailsDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);
            dataRead = false;
        }
        public void Questionnaire_Load(object sender, EventArgs e)
        {
            query = $"SELECT * FROM dbo.Questionnaire WHERE Questionnaire.DoctorID_A = {DoctorIdentifier} OR Questionnaire.DoctorID_D = {DoctorIdentifier};";
            if (Access_level == 2 || Access_level == 0)
            {
                query = "SELECT * FROM Questionnaire";
            }

            LoadData();
        }

        public bool isUpdated = false;

        public void questionnaireBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (isNewQues)
                {
                    MessageBox.Show("Произошла ошибка при сохранении!\nCначало сохраните новую запись.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.Validate();
                this.questionnaireBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.polDataSet);
                status.Text = "Таблица сохранена";
                status.ForeColor = Color.Green;
                isUpdated = false;
                LoadData();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при сохранении!\nПроверьте корректность введенных значений.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
            Color.WhiteSmoke, 1, ButtonBorderStyle.Solid,   // left
            Color.White, 1, ButtonBorderStyle.Solid,        // top 
            Color.White, 1, ButtonBorderStyle.Solid,        // right
            Color.White, 1, ButtonBorderStyle.Solid);       // bottom

        }
        private void hopeButton4_MouseDown(object sender, MouseEventArgs e)
        {
            hopeButton4.PrimaryColor = Color.FromArgb(184, 197, 255);

        }
        private void hopeButton4_MouseEnter(object sender, EventArgs e)
        {
            hopeButton4.PrimaryColor = Color.FromArgb(99, 124, 234);

        }
        private void hopeButton4_MouseLeave(object sender, EventArgs e)
        {
            hopeButton4.PrimaryColor = Color.FromArgb(184, 197, 255);
        }

        private List<DataGridViewCell> matchedCells = new List<DataGridViewCell>();
        private int totalMatches = 0;
        private int currentMatchIndex = -1;
        private int currentColumnIndex = -1;
        private bool isSearching = false;
        private string previousInput = "";

        private void hopeButton4_Click(object sender, EventArgs e)
        {
            if (isNewQues)
            {
                if (MessageBox.Show("Добавление записи не закончено! Вы можете потерять данные.\n" +
                                "Хотите продолжить все равно?", "Ограничение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                                DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    patientAddCancel();
                }
            }
            string selectedText = "";
            if (isInputSearch)
            {
                searchInput = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода значения поиска.\n\n\n\nНайти:", "Расширенный поиск", previousInput);
                if (!string.IsNullOrEmpty(searchInput))
                {
                    selectedText = searchInput;
                    previousInput = searchInput;
                    aloneComboBox2.Invalidate();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    return;
                }
            }
            else
            {
                selectedText = aloneComboBox2.GetItemText(aloneComboBox2.SelectedItem);
            }

            clearSelection();
            matchedCells.Clear();

            totalMatches = 0;
            currentMatchIndex = 0;

            isSearching = true;

            if (!string.IsNullOrEmpty(selectedText))
            {
                if (currentColumnIndex == -1)
                {
                    for (int i = 1; i < questionnaireDetailsDataGridView.ColumnCount; i++)
                    {
                        SearchInColumn(i, selectedText);
                    }
                }
                else
                {
                    SearchInColumn(currentColumnIndex, selectedText);
                }

                if (totalMatches > 0)
                {
                    DataGridViewCell cell = matchedCells[0];
                    DataGridViewRow row = cell.OwningRow;
                    row.Selected = true;

                    questionnaireDetailsDataGridView.CurrentCell = cell;
                }

                UpdateStatusLabel();

                cancelSearchButton.BackgroundColor = Color.FromArgb(99, 124, 234);
            }
        }
        private void UpdateStatusLabel()
        {
            if (totalMatches == 0)
            {
                label2.ForeColor = Color.Red;
                label2.Text = "0 из 0";
                status.Text = $"Cовпадений не найдено";
                status.ForeColor = Color.Silver;
                SystemSounds.Exclamation.Play();
            }
            else
            {
                label2.ForeColor = Color.Silver;
                label2.Text = $"{currentMatchIndex + 1} из {totalMatches}";
                status.Text = $"Найдено {totalMatches} совпадений";
                status.ForeColor = Color.Silver;
            }
        }

        private void MoveToMatch(Direction direction)
        {
            if (matchedCells.Count > 0)
            {
                if (direction == Direction.Forward)
                {
                    currentMatchIndex++;
                    if (currentMatchIndex >= matchedCells.Count)
                    {
                        currentMatchIndex = 0;
                    }
                }
                else if (direction == Direction.Backward)
                {
                    currentMatchIndex--;
                    if (currentMatchIndex < 0)
                    {
                        currentMatchIndex = matchedCells.Count - 1;
                    }
                }

                DataGridViewCell cell = matchedCells[currentMatchIndex];
                DataGridViewRow row = cell.OwningRow;
                row.Selected = true;

                questionnaireDetailsDataGridView.CurrentCell = cell;

                UpdateStatusLabel();
            }
        }
        private enum Direction
        {
            Forward,
            Backward
        }
        private void clearSelection()
        {
            foreach (DataGridViewRow row in questionnaireDetailsDataGridView.Rows)
            {
                row.Selected = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Selected = false;
                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.Black;
                }
            }
        }
        private void parrotButton1_Click(object sender, EventArgs e)
        {
            MoveToMatch(Direction.Forward);
        }
        private void parrotButton2_Click(object sender, EventArgs e)
        {
            MoveToMatch(Direction.Backward);
        }
        private void parrotButton3_Click(object sender, EventArgs e)
        {
            isSearching = false;
            clearSelection();
            label2.ForeColor = Color.Silver;
            label2.Text = "0 из 0";
            status.Text = $"...";
            status.ForeColor = Color.Silver;
            cancelSearchButton.BackgroundColor = Color.FromArgb(184, 197, 255);

        }
        private void SearchInColumn(int columnIndex, string searchText)
        {
            searchText = searchText.ToLower();
            for (int j = 0; j < questionnaireDetailsDataGridView.RowCount; j++)
            {
                var value = questionnaireDetailsDataGridView.Rows[j].Cells[columnIndex].Value;
                if (value != null)
                {
                    string cellValue = value.ToString().ToLower();
                    if (cellValue.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                    {
                        DataGridViewCell cell = questionnaireDetailsDataGridView[columnIndex, j];
                        cell.Style.BackColor = Color.FromArgb(97, 117, 209);
                        cell.Style.ForeColor = Color.White;
                        matchedCells.Add(cell);
                        totalMatches++;
                    }
                }
            }
        }
        private void aloneComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (aloneComboBox1.GetItemText(aloneComboBox1.SelectedItem) == "Все столбцы")
            {
                currentColumnIndex = -1;
            }
            else
            {
                currentColumnIndex = aloneComboBox1.SelectedIndex;
            }
        }

        private void questionnaireDetailsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            questionnaireDetailsDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);

            ComboBoxesUpdate();
            isUpdated = true;

            status.Text = "Редактирование ...";
            status.ForeColor = Color.Silver;
        }

        private void ComboBoxesUpdate()
        {
            if (isSearching) return;
            // Очистите ComboBox перед заполнением новыми данными
            aloneComboBox1.Items.Clear();
            aloneComboBox1.Items.Insert(0, "Все столбцы");
            foreach (DataGridViewColumn column in questionnaireDetailsDataGridView.Columns)
            {
                if (!column.Visible)
                    continue;
                aloneComboBox1.Items.Add(column.HeaderText);
            }

            if (questionnaireDetailsDataGridView.CurrentCell != null)
            {
                int columnIndex = questionnaireDetailsDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0 && columnIndex < aloneComboBox1.Items.Count)
                {
                    aloneComboBox1.SelectedIndex = columnIndex;
                }
            }

            aloneComboBox2.Items.Clear();
            aloneComboBox2.Items.Insert(0, "Свое значение");
            if (questionnaireDetailsDataGridView.CurrentCell != null)
            {
                int columnIndex = questionnaireDetailsDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0)
                {
                    List<string> uniqueValues = new List<string>();
                    for (int i = 0; i < questionnaireDetailsDataGridView.Rows.Count; i++)
                    {
                        object cellValue = questionnaireDetailsDataGridView[columnIndex, i].Value;
                        if (cellValue != null)
                        {
                            string value = cellValue.ToString();
                            if (!uniqueValues.Contains(value))
                            {
                                uniqueValues.Add(value);
                            }
                        }
                    }
                    aloneComboBox2.Items.AddRange(uniqueValues.ToArray());

                }

                if (questionnaireDetailsDataGridView.CurrentCell != null)
                {
                    int rowIndex = questionnaireDetailsDataGridView.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        string cellValue = questionnaireDetailsDataGridView[questionnaireDetailsDataGridView.CurrentCell.ColumnIndex, rowIndex].Value?.ToString();
                        int index = aloneComboBox2.FindString(cellValue);
                        if (index >= 0)
                        {
                            aloneComboBox2.SelectedIndex = index;
                        }
                        else
                        {
                            aloneComboBox2.SelectedIndex = -1;
                        }
                    }
                }
                aloneComboBox2.Invalidate();
            }
        }

        public bool isInputSearch = false;
        public string searchInput = "";

        private void aloneComboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (aloneComboBox2.GetItemText(aloneComboBox2.SelectedItem) == "Свое значение")
            {
                isInputSearch = true;
                hopeButton4_Click(null, new EventArgs());
            }
        }

        private void questionnaireDetailsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell errorCell = questionnaireDetailsDataGridView[e.ColumnIndex, e.RowIndex];
            MessageBox.Show(e.Exception.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isNewQues = false;
        private void hopeButton3_Click(object sender, EventArgs e)
        {
            questionnaireBindingSource.RemoveCurrent();
        }

        private bool successSurnameInput = false;
        private void surnameLabel_DoubleClick(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода фамилию пациента." +
                "\nПример: Иванов\n\n\nФамилия:", isNewQues ? "Добавление данных" : "Редактирование данных", patientLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                patientLabel.Text = input;
                status.Text = isNewQues ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewQues)
                {
                    successSurnameInput = true;
                    return;
                }
                questionnaireBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Фамилия не отредактирована";
                status.ForeColor = Color.Red;
                SystemSounds.Exclamation.Play();

                if (isNewQues)
                {
                    successSurnameInput = false;
                }
            }
        }

        private bool successNameInput = false;
        private void firstNameLabel_DoubleClick(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода имя пациента." +
    "\nПример: Иван\n\n\nИмя:", isNewQues ? "Добавление данных" : "Редактирование данных", doctorALabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                doctorALabel.Text = input;
                status.Text = isNewQues ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewQues)
                {
                    successNameInput = true;
                    return;
                }
                questionnaireBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Имя не отредактировано";
                status.ForeColor = Color.Red;
                SystemSounds.Exclamation.Play();

                if (isNewQues)
                {
                    successNameInput = false;
                }
            }
        }

        private bool successLastNameInput = false;
        private void LastNameLabel_DoubleClick(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода фамилию пациента." +
    "\nПример: Иванович\n\n\nОтчество:", isNewQues ? "Добавление данных" : "Редактирование данных", doctorDLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                doctorDLabel.Text = input;
                status.Text = isNewQues ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewQues)
                {
                    successLastNameInput = true;
                    return;
                }
                questionnaireBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Отчество не отредактировано";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewQues)
                {
                    successLastNameInput = false;
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            isUpdated = true;
            status.Text = "Запись удалена";
            status.ForeColor = Color.Green;
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            isUpdated = true;
            newQuesButton_Click(null, new EventArgs());
        }

        private void patientAddCancel()
        {
            isNewQues = false;

            status.Text = "Операция отклонена";
            status.ForeColor = Color.Silver;
            parrotButton3_Click(null, new EventArgs());
            Bubble.Visible = false;
            Bubble2.Visible = false;

            try
            {
                patientLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionnaireBindingSource, "Surname", true));
/*                birthDateLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionnaireDetailsBindingSource, "BirthDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, 0, "Дата рождения: dd.MM.yyyy"));
                telphone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionnaireDetailsBindingSource, "PhoneNumber", true));
                address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.questionnaireDetailsBindingSource, "Address", true));*/
            }
            catch { }
            newQuesButton.Text = "Новый";
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = true;
        }

        private void Bubble_Click(object sender, EventArgs e)
        {
            Bubble.Visible = false;
            questionnaireDetailsDataGridView.ReadOnly = true;

        }
        private void Bubble2_Click(object sender, EventArgs e)
        {
            Bubble2.Visible = false;
        }
        private void hopeButton1_Click_1(object sender, EventArgs e)
        {
            patientAddCancel();
            questionnaireBindingSource.ResumeBinding();
        }

        private void hopeButton1_MouseDown(object sender, MouseEventArgs e)
        {
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);

        }
        private void hopeButton1_MouseEnter(object sender, EventArgs e)
        {
            hopeButton1.PrimaryColor = Color.FromArgb(99, 124, 234);

        }
        private void hopeButton1_MouseLeave(object sender, EventArgs e)
        {
            if (isNewQues) return;
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);
        }
        private void telphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox maskedTextBox = (System.Windows.Forms.TextBox)sender;

            if (e.KeyChar != '\b' && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            string text = maskedTextBox.Text.Replace("+", "").Replace(" ", "");

            if (e.KeyChar == '\b' && text.Length == 0)
            {
                maskedTextBox.Text = "+";
                maskedTextBox.SelectionStart = maskedTextBox.Text.Length;
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && text.Length == 0)
            {
                maskedTextBox.Text = "+" + e.KeyChar;
                maskedTextBox.SelectionStart = maskedTextBox.Text.Length;
                e.Handled = true;
            }
            else if (e.KeyChar == '+')
            {
                maskedTextBox.Text = "+";
                maskedTextBox.SelectionStart = maskedTextBox.Text.Length;
                e.Handled = true;
            }

        }

        private void questionaireDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            getPatientData();
            getDoctorAData();
            getDoctorDData();
            ComboBoxesUpdate();
        }

        int PatientID = 0;
        String DoctorFullName = "";
        private void getPatientData()
        {
            if (dataRead) return;
            if (questionnaireDetailsDataGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = questionnaireDetailsDataGridView.SelectedRows[0];

                if (selectedRow.Cells["patientIDDataGridViewTextBoxColumn"].Value != null)
                {
                    int ID = Convert.ToInt32(selectedRow.Cells["patientIDDataGridViewTextBoxColumn"].Value);

                    string query = "SELECT P.PatientID, P.Surname, P.FirstName, P.MiddleName, P.BirthDate, P.Address, P.PhoneNumber " +
                                   $"FROM Questionnaire Q JOIN Patient_new P ON Q.PatientID = P.PatientID WHERE P.PatientID = {ID};";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                PatientID = Int32.Parse(reader["PatientID"].ToString());
                                string surname = reader["Surname"].ToString();
                                string firstName = reader["FirstName"].ToString();
                                string middleName = reader["MiddleName"].ToString();
                                string birthDate = ((DateTime)reader["BirthDate"]).ToString("dd.MM.yyyy");
                                string address = reader["Address"].ToString();
                                string phoneNumber = reader["PhoneNumber"].ToString();

                                string patientData = $"\nФИО: {surname} {firstName} {middleName}\n" +
                                                     $"\nДата рождения: {birthDate}\n" +
                                                     $"Адрес: {address}\n" +
                                                     $"Телефон: {phoneNumber}";

                                patientLabel.Text = $"{surname} {firstName.Substring(0, 1)}.{middleName.Substring(0, 1)}.";
                                toolTip1.SetToolTip(patientLabel, patientData + "\n\nДвойной клик, чтобы узнать подробнее.");


                            }
                        }
                    }
                }
                else
                    toolTip1.SetToolTip(patientLabel, "\nДля отображения данных о пациенте выберите строку");
            }
            try
            {

            }
            catch
            {
                patientLabel.Text = "-";
                toolTip1.SetToolTip(patientLabel, "\nНе удалось получить данные о пациенте. Нет подключения к БД.");
            }

        }
        private void getDoctorAData()
        {
            if (questionnaireDetailsDataGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = questionnaireDetailsDataGridView.SelectedRows[0];

                if (selectedRow.Cells["doctorIDADataGridViewTextBoxColumn"].Value != null)
                {
                    int DoctorID = Convert.ToInt32(selectedRow.Cells["doctorIDADataGridViewTextBoxColumn"].Value);

                    string query = "SELECT Surname, FirstName, MiddleName, Specialization, PreviousExperience, CurrentExperience, TotalExperience " +
                                    $"FROM Doctor WHERE DoctorID = {DoctorID};";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                string surname = reader["Surname"].ToString();
                                string firstName = reader["FirstName"].ToString();
                                string middleName = reader["MiddleName"].ToString();
                                string spec = reader["Specialization"].ToString();
                                string PreviousExperience = reader["PreviousExperience"].ToString();
                                string CurrentExperience = reader["CurrentExperience"].ToString();
                                string TotalExperience = reader["TotalExperience"].ToString();

                                string patientData = $"\nФИО: {surname} {firstName} {middleName}\n" +
                                                     $"\nСпециальность: {spec}\n" +
                                                     $"Текущий опыт: {CurrentExperience}\n" +
                                                     $"Предыдущий опыт: {PreviousExperience}\n" +
                                                     $"Общий опыт: {TotalExperience}";
                                toolTip1.SetToolTip(doctorALabel, patientData + "\n\nДвойной клик, чтобы узнать подробнее.");
                                doctorALabel.Text = $"{surname} {firstName} {middleName} {spec}";

                                if (DoctorID == DoctorIdentifier)
                                {
                                    DoctorFullName = $"{spec} {surname} {firstName[0]}.{middleName[0]}.";
                                }

                            }
                        }
                    }
                }
                else
                {
                    doctorALabel.Text = "Не указан!";
                    toolTip1.SetToolTip(doctorALabel, "\nДля отображения данных о враче выберите строку");
                }
            }
        }
        private void getDoctorDData()
        {
            try
            {
                if (questionnaireDetailsDataGridView.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = questionnaireDetailsDataGridView.SelectedRows[0];

                    if (selectedRow.Cells["doctorIDDDataGridViewTextBoxColumn"].Value != null)
                    {
                        int DoctorID = Convert.ToInt32(selectedRow.Cells["doctorIDDDataGridViewTextBoxColumn"].Value);

                        string query = "SELECT Surname, FirstName, MiddleName, Specialization, PreviousExperience, CurrentExperience, TotalExperience " +
                                        $"FROM Doctor WHERE DoctorID = {DoctorID};";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.Read())
                                {
                                    string surname = reader["Surname"].ToString();
                                    string firstName = reader["FirstName"].ToString();
                                    string middleName = reader["MiddleName"].ToString();
                                    string spec = reader["Specialization"].ToString();
                                    string PreviousExperience = reader["PreviousExperience"].ToString();
                                    string CurrentExperience = reader["CurrentExperience"].ToString();
                                    string TotalExperience = reader["TotalExperience"].ToString();

                                    string patientData = $"\nФИО: {surname} {firstName} {middleName}\n" +
                                                         $"\nСпециальность: {spec}\n" +
                                                         $"Текущий опыт: {CurrentExperience}\n" +
                                                         $"Предыдущий опыт: {PreviousExperience}\n" +
                                                         $"Общий опыт: {TotalExperience}";
                                    toolTip1.SetToolTip(doctorDLabel, patientData + "\n\nДвойной клик, чтобы узнать подробнее.");
                                    doctorDLabel.Text = $"{surname} {firstName} {middleName} - {spec}";
                                    if (DoctorID == DoctorIdentifier)
                                    {
                                        DoctorFullName = $"{spec} {surname} {firstName[0]}.{middleName[0]}.";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        toolTip1.SetToolTip(doctorDLabel, "\nДля отображения данных о пациенте выберите строку");
                        doctorDLabel.Text = "Не указан!";
                    }
                }
            } catch
            {
                doctorDLabel.Text = "Не указан!";
                toolTip1.SetToolTip(doctorDLabel, "\nНет данных о враче. Возможно нет подключения к БД или не указан врач-диагност.");
            }
        }

        private void LoadDiagnosis()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.KAZAKKULOV_EXP_CON))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT DiagnosisID, DiagnosisName FROM Diagnosis", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            foreach (DataGridViewRow row in questionnaireDetailsDataGridView.Rows)
                            {
                                string IdString = row.Cells["diagnosisIDDataGridViewTextBoxColumn"].Value?.ToString();

                                if (int.TryParse(IdString, out int Id))
                                {
                                    DataRow[] result = table.Select($"DiagnosisID = {Id}");

                                    if (result.Length > 0)
                                    {
                                        row.Cells["DiagnoseName"].Value = result[0]["DiagnosisName"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке диагнозов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatient()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.KAZAKKULOV_EXP_CON))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT PatientID, FirstName, Surname, MiddleName FROM Patient_new", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        foreach (DataGridViewRow row in questionnaireDetailsDataGridView.Rows)
                        {
                            string IdString = row.Cells["patientIDDataGridViewTextBoxColumn"].Value?.ToString();

                            if (int.TryParse(IdString, out int Id))
                            {
                                DataRow[] result = table.Select($"PatientID = {Id}");
                                row.Cells[2].Value = result[0]["Surname"].ToString() + " " + result[0]["FirstName"].ToString() + " " + result[0]["MiddleName"].ToString();
                            }
                        }
                    }
                }
            }
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке диагнозов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoctors()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.KAZAKKULOV_EXP_CON))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT DoctorID, FirstName, Surname, MiddleName FROM Doctor", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        foreach (DataGridViewRow row in questionnaireDetailsDataGridView.Rows)
                        {
                            string IdString1 = row.Cells["doctorIDADataGridViewTextBoxColumn"].Value?.ToString();

                            if (int.TryParse(IdString1, out int Id1))
                            {
                                DataRow[] result = table.Select($"DoctorID = {Id1}");
                                row.Cells[4].Value = result[0]["Surname"].ToString() + " " + result[0]["FirstName"].ToString() + " " + result[0]["MiddleName"].ToString();
                            }
                            string IdString2 = row.Cells["doctorIDDDataGridViewTextBoxColumn"].Value?.ToString();

                            if (int.TryParse(IdString2, out int Id2))
                            {
                                DataRow[] result = table.Select($"DoctorID = {Id2}");
                                row.Cells[12].Value = result[0]["Surname"].ToString() + " " + result[0]["FirstName"].ToString() + " " + result[0]["MiddleName"].ToString();
                            }
                        }
                    }
                }
            }
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке диагнозов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getQuestionnaire()
        {
            if (dataRead) return;
            try
            {
                if (questionnaireDetailsDataGridView.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = questionnaireDetailsDataGridView.SelectedRows[0];

                    if (selectedRow.Cells["patientIDDataGridViewTextBoxColumn"].Value != null)
                    {
                        int PatientID = Convert.ToInt32(selectedRow.Cells["patientIDDataGridViewTextBoxColumn"].Value);

                        string query = $"SELECT * FROM QuestionnaireDetails WHERE P.PatientID = {PatientID};";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.Read())
                                {
                                    PatientID = Int32.Parse(reader["PatientID"].ToString());
                                    string surname = reader["Surname"].ToString();
                                    string firstName = reader["FirstName"].ToString();
                                    string middleName = reader["MiddleName"].ToString();
                                    string birthDate = ((DateTime)reader["BirthDate"]).ToString("dd.MM.yyyy");
                                    string address = reader["Address"].ToString();
                                    string phoneNumber = reader["PhoneNumber"].ToString();

                                    string patientData = $"\nФИО: {surname} {firstName} {middleName}\n" +
                                                         $"\nДата рождения: {birthDate}\n" +
                                                         $"Адрес: {address}\n" +
                                                         $"Телефон: {phoneNumber}";

                                    patientLabel.Text = $"{surname} {firstName.Substring(0, 1)}.{middleName.Substring(0, 1)}.";
                                    /*                                birthDateLabel.Text = birthDate;
                                                                    this.address.Text = address;
                                                                    this.telphone.Text = phoneNumber;*/
                                    toolTip1.SetToolTip(patientLabel, patientData + "\n\nДвойной клик, чтобы узнать подробнее.");


                                }
                            }
                        }
                    }
                    else
                        toolTip1.SetToolTip(patientLabel, "\nДля отображения данных о пациенте выберите строку");
                }
            }
            catch
            {
                patientLabel.Text = "-";
                toolTip1.SetToolTip(patientLabel, "\nНе удалось получить данные о пациенте. Нет подключения к БД.");
            }

        }
        private void newQuesButton_Click(object sender, EventArgs e)
        {
            NewQues?.Invoke();
        }

        private void patientLabel_DoubleClick(object sender, EventArgs e)
        {
            PatientSearchRequested?.Invoke(PatientID);
        }

        private void aloneComboBox1_Resize(object sender, EventArgs e)
        {
            aloneComboBox1.Invalidate();
        }
        DataTable dataTable = new DataTable();
        private void hopeButton3_Click_1(object sender, EventArgs e)
        {
            GenerateAndSaveDocx(Convert.ToInt32(questionnaireDetailsDataGridView[0, questionnaireDetailsDataGridView.CurrentCell.RowIndex].Value.ToString()));
        }
        public class PatientData
        {
            public string PatientID { get; set; }
            public string PatientFullName { get; set; }

            public DateTime BirthDate { get; set; }

            public string Address { get; set; }

            public string DiagnosisCode { get; set; }

            public string DiagnosisName { get; set; }

        }
        private PatientData ExecuteGetPatientDataByQuestionnaireID(int questionnaireID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.KAZAKKULOV_EXP_CON))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("GetPatientDataByQuestionnaireID", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Добавление параметра для передачи айди анкеты
                        cmd.Parameters.Add(new SqlParameter("@QuestionnaireID", SqlDbType.Int)
                        {
                            Value = questionnaireID
                        });

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Создание объекта PatientData и заполнение его данными из результата запроса
                                PatientData patientData = new PatientData
                                {
                                    PatientFullName = reader["PatientFullName"].ToString(),
                                    BirthDate = (DateTime)reader["BirthDate"],
                                    Address = reader["Address"].ToString(),
                                    DiagnosisCode = reader["DiagnosisCode"].ToString(),
                                    DiagnosisName = reader["DiagnosisInfo"].ToString()
                                    // Добавьте другие свойства, если необходимо
                                };

                                return patientData;
                            }
                            else
                            {
                                return null; // В случае, если результат не был найден
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing stored procedure: {ex.Message}");
                // Обработка ошибок по вашему усмотрению
                return null;
            }
        }

        private void GenerateAndSaveDocx(int questionnaireID)
        {
            try
            {
                PatientData patientData = ExecuteGetPatientDataByQuestionnaireID(questionnaireID);

                if (patientData == null)
                {
                    MessageBox.Show("Нет данных для создания документа.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(documentsPath, $"Направление_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.docx");

                using (var doc = DocX.Create(filePath))
                {
                    var titleParagraph = doc.InsertParagraph();
                    titleParagraph.AppendLine($"Направление на Госпитализацию, Консультацию, Обследование").Bold().FontSize(12).Font("Times New Roman").Alignment = Alignment.center;
                    titleParagraph.AppendLine($"(нужное подчеркнуть)").Bold().FontSize(8).Font("Times New Roman").Alignment = Alignment.center;

                    titleParagraph.AppendLine().SpacingAfter(8); // Добавим отступ после надписи

                    // Добавляем данные о пациенте из объекта PatientData
                    var patientInfoParagraph = doc.InsertParagraph();
                    patientInfoParagraph.AppendLine($"Ф.И.О пациента: {patientData.PatientFullName},\nДата рождения: {patientData.BirthDate.ToString("dd.MM.yyyy")}," +
                        $"\nАдрес постоянного жительства: {patientData.Address},\n\nКод диагноза по МКБ: {patientData.DiagnosisCode}").FontSize(12).Font("Times New Roman").Alignment = Alignment.left;
                    patientInfoParagraph.AppendLine().SpacingAfter(10);
                    patientInfoParagraph.AppendLine($"Обоснование направления:").Bold().FontSize(10).Font("Times New Roman").Alignment = Alignment.left;
                    patientInfoParagraph.AppendLine($"\n{patientData.DiagnosisName}").FontSize(12).Font("Times New Roman").Alignment = Alignment.left;
                    patientInfoParagraph.AppendLine("__________________________________________________________________________\n").FontSize(12).Font("Times New Roman").Bold().Alignment = Alignment.left;
                    patientInfoParagraph.AppendLine("Направляется к врачу ___________________________________________________________________________").FontSize(12).Font("Times New Roman").Bold().Alignment = Alignment.left;
                    patientInfoParagraph.AppendLine("__________________________________________________________________________").FontSize(12).Font("Times New Roman").Bold().Alignment = Alignment.left;
                    // Добавляем поле для имени и подписи врача
                    var signatureParagraph = doc.InsertParagraph();
                    signatureParagraph.AppendLine().SpacingAfter(10);
                    signatureParagraph.Append($"Врач {DoctorFullName}").FontSize(12).Font("Times New Roman").Bold().Alignment = Alignment.right;
                    signatureParagraph.AppendLine("_____________________________").FontSize(12).Font("Times New Roman").Bold().Alignment = Alignment.right;
                    signatureParagraph.AppendLine("Подпись").FontSize(7).Font("Times New Roman").Alignment = Alignment.right;

                    doc.Save();

                    using (PrintDialog pd = new PrintDialog())
                    {
                        if (pd.ShowDialog() == DialogResult.OK)
                        {
                            ProcessStartInfo info = new ProcessStartInfo(filePath);
                            info.Verb = "Print";
                            Process.Start(info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании документа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void questionnaireDetailsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataRead) return;

            LoadDiagnosis();
            LoadPatient();
            LoadDoctors();

        }

        private void doctorDLabel_DoubleClick(object sender, EventArgs e)
        {
            StringBuilder resultStringBuilder = new StringBuilder();

            for (int departmentId = 0; departmentId <= 100; departmentId++)
            {
                string formattedDepartment = getNameById1(departmentId);

                if (!string.IsNullOrEmpty(formattedDepartment))
                {
                    resultStringBuilder.AppendLine(formattedDepartment + " - " + departmentId);
                }
            }

            using (ParametrInput deptForm = new ParametrInput())
            {
                deptForm.aloneComboBox1.Items.Add("Выберите диагноз");
                deptForm.aloneComboBox1.Items.AddRange(resultStringBuilder.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                deptForm.aloneComboBox1.Sorted = true;

                if (deptForm.ShowDialog() == DialogResult.OK)
                {
                    string selectedDeptText = deptForm.aloneComboBox1.SelectedItem.ToString();
                    string[] parts = selectedDeptText.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    textBox2.Text = parts[1];

                    if (parts.Length == 2 && int.TryParse(parts[1], out int selectedDeptId))
                    {
                        // Записываем данные в соответствующие места
                        questionnaireDetailsDataGridView["DoctorD", questionnaireDetailsDataGridView.CurrentRow.Index].Value = parts[0].Trim();

                        questionnaireBindingSource.EndEdit();
                    }
                    else
                    {
                        status.Text = "Некорректный выбор диагноза";
                        SystemSounds.Exclamation.Play();
                        status.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void doctorALabel_DoubleClick(object sender, EventArgs e)
        {

        }

        private String getNameById(int ID)
        {
            string query = "SELECT DiagnosisName, DiagnosisID " +
                            "FROM Diagnosis " +
                           $"WHERE DiagnosisID = {ID}";

/*            string query = "SELECT DiagnosisName, DiagnosisID " +
                "FROM Diagnosis " +
                "JOIN Questionnaire q ON q.DiagnosisID = Diagnosis.DiagnosisID " +
                $"WHERE Diagnosis.DiagnosisID = {ID} AND (q.DoctorID_A = {DoctorIdentifier} OR q.DoctorID_D = {DoctorIdentifier})";*/


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string name = reader["DiagnosisName"].ToString();
                        return name;
                    }
                }
            }
            return null;
        }

        private String getNameById1(int ID)
        {
            string query = "SELECT Surname, FirstName, MiddleName, Specialization, DoctorID " +
                            "FROM Doctor " +
                           $"WHERE DoctorID = {ID}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string name = reader["Surname"].ToString() + " " + reader["FirstName"].ToString() + " "+ reader["MiddleName"].ToString() + " "+ reader["Specialization"].ToString() + " ";
                        return name;
                    }
                }
            }
            return null;
        }

        private void hopeButton2_Click(object sender, EventArgs e)
        {
            StringBuilder resultStringBuilder = new StringBuilder();

            for (int departmentId = 0; departmentId <= 100; departmentId++)
            {
                string formattedDepartment = getNameById(departmentId);

                if (!string.IsNullOrEmpty(formattedDepartment))
                {
                    resultStringBuilder.AppendLine(formattedDepartment + " - " + departmentId);
                }
            }

            using (ParametrInput deptForm = new ParametrInput())
            {
                deptForm.aloneComboBox1.Items.Add("Выберите врача-диагноста");
                deptForm.aloneComboBox1.Items.AddRange(resultStringBuilder.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                deptForm.aloneComboBox1.Sorted = true;

                if (deptForm.ShowDialog() == DialogResult.OK)
                {
                    string selectedDeptText = deptForm.aloneComboBox1.SelectedItem.ToString();
                    string[] parts = selectedDeptText.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    textBox1.Text = parts[1];

                    if (parts.Length == 2 && int.TryParse(parts[1], out int selectedDeptId))
                    {
                        // Записываем данные в соответствующие места
                        questionnaireDetailsDataGridView[12, questionnaireDetailsDataGridView.CurrentRow.Index].Value = parts[0].Trim();

                        questionnaireBindingSource.EndEdit();
                    }
                    else
                    {
                        status.Text = "Некорректный выбор врача";
                        SystemSounds.Exclamation.Play();
                        status.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}