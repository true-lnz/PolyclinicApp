using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace COMPANY_DB
{
    public partial class Diagnosis : Form
    {
        int Access_level = 3;
        static int DoctorIdentifier = 3;

        public delegate void PatientSearchEventHandler(int patientID);
        public event PatientSearchEventHandler PatientSearchRequested;
        public Diagnosis(int Option, int DoctorID)
        {
            InitializeComponent();
            Access_level = Option;
            DoctorIdentifier = DoctorID;
        }

        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;

        bool dataRead = false;
        public string query = $"SELECT Diagnosis.* FROM Patient_new JOIN Questionnaire ON " +
                  $"Patient_new.PatientID = Questionnaire.PatientID " +
                  $"JOIN Diagnosis ON Questionnaire.DiagnosisID = Diagnosis.DiagnosisID " +
                  $"WHERE Questionnaire.DoctorID_A = {DoctorIdentifier}   OR Questionnaire.DoctorID_D = {DoctorIdentifier};";
        public void LoadData()
        {
            try
            {
                this.polDataSet.Diagnosis.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(this.polDataSet.Diagnosis);
                    }
                }
                diagnosisDataGridView.Refresh();

                //this.diagnosisTableAdapter.Fill(this.polDataSet.Diagnosis);
                dataRead = true;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке!\nПроверьте подключение базе данных.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataRead = false;
            }
            diagnosisDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);
            //diagnosisDataGridView.Sort(dataGridViewTextBoxColumn5, ListSortDirection.Ascending);
            diagnosisDataGridView.EnableHeadersVisualStyles = false;
            dataRead = false;
        }
        private void Diagnosis_Load(object sender, EventArgs e)
        {
            query = $"SELECT Diagnosis.* FROM Patient_new JOIN Questionnaire ON " +
                  $"Patient_new.PatientID = Questionnaire.PatientID " +
                  $"JOIN Diagnosis ON Questionnaire.DiagnosisID = Diagnosis.DiagnosisID " +
                  $"WHERE Questionnaire.DoctorID_A = {DoctorIdentifier}   OR Questionnaire.DoctorID_D = {DoctorIdentifier};";
            if (Access_level == 2 || Access_level == 0)
            {
                query = "SELECT * FROM Diagnosis";
            }
            LoadData();
        }
        public bool isUpdated = false;

        public void diagnosisBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNewDiagnose)
                {
                    MessageBox.Show("Произошла ошибка при сохранении!\nCначало сохраните новую запись.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.Validate();
                this.diagnosisBindingSource.EndEdit();
                this.diagnosisTableAdapter.Update(this.polDataSet);
                status.Text = "Таблица сохранена";
                status.ForeColor = Color.Green;
                isUpdated = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении!\nПроверьте корректность введенных значений."+ex.Message,
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
            Color.WhiteSmoke, 1, ButtonBorderStyle.Solid,  // left
            Color.White, 1, ButtonBorderStyle.Solid, // top 
            Color.White, 1, ButtonBorderStyle.Solid,    // right
            Color.White, 1, ButtonBorderStyle.Solid);    // bottom

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
            if (isNewDiagnose)
            {
                if (MessageBox.Show("Добавление записи не закончено! Вы можете потерять данные.\n" +
                                "Хотите продолжить все равно?", "Ограничение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                                DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    diagnoseAddCancel();
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

            // Устанавливаем флаг поиска в true, чтобы отключить событие SelectionChanged
            isSearching = true;

            if (!string.IsNullOrEmpty(selectedText))
            {
                if (currentColumnIndex == -1)
                {
                    for (int i = 1; i < diagnosisDataGridView.ColumnCount; i++)
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

                    diagnosisDataGridView.CurrentCell = cell;
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

                diagnosisDataGridView.CurrentCell = cell;

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
            foreach (DataGridViewRow row in diagnosisDataGridView.Rows)
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
            for (int j = 0; j < diagnosisDataGridView.RowCount; j++)
            {
                var value = diagnosisDataGridView.Rows[j].Cells[columnIndex].Value;
                if (value != null)
                {
                    string cellValue = value.ToString().ToLower();
                    if (cellValue.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                    {
                        DataGridViewCell cell = diagnosisDataGridView[columnIndex, j];
                        cell.Style.BackColor = Color.FromArgb(97, 117, 209);
                        cell.Style.ForeColor = Color.White;
                        matchedCells.Add(cell);
                        totalMatches++;
                    }
                }
            }
        }
        private void aloneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void diagnosisDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            diagnosisDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);

            ComboBoxesUpdate();
            isUpdated = true;

            status.Text = "Редактирование ...";
            status.ForeColor = Color.Silver;
        }

        private void ComboBoxesUpdate()
        {
            if (isSearching) return;

            aloneComboBox1.Items.Clear();
            aloneComboBox1.Items.Insert(0, "Все столбцы");
            foreach (DataGridViewColumn column in diagnosisDataGridView.Columns)
            {
                if (!column.Visible)
                    continue;
                aloneComboBox1.Items.Add(column.HeaderText);
            }

            if (diagnosisDataGridView.CurrentCell != null)
            {
                int columnIndex = diagnosisDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0 && columnIndex < aloneComboBox1.Items.Count)
                {
                    aloneComboBox1.SelectedIndex = columnIndex;
                }
            }

            aloneComboBox2.Items.Clear();
            aloneComboBox2.Items.Insert(0, "Свое значение");
            if (diagnosisDataGridView.CurrentCell != null)
            {
                int columnIndex = diagnosisDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0)
                {
                    List<string> uniqueValues = new List<string>();
                    for (int i = 0; i < diagnosisDataGridView.Rows.Count; i++)
                    {
                        object cellValue = diagnosisDataGridView[columnIndex, i].Value;
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

                if (diagnosisDataGridView.CurrentCell != null)
                {
                    int rowIndex = diagnosisDataGridView.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        string cellValue = diagnosisDataGridView[diagnosisDataGridView.CurrentCell.ColumnIndex, rowIndex].Value.ToString();
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

        private void diagnosisDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell errorCell = diagnosisDataGridView[e.ColumnIndex, e.RowIndex];
            MessageBox.Show(e.Exception.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isNewDiagnose = false;
        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (isNewDiagnose && (!successNameInput || !successCodeInput))
            {
                MessageBox.Show("Один из обязательных параметров не отредактирован!\n" +
                                "Возможно имееются недопустимые символы.", "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isNewDiagnose)
            {
                polDataSet.DiagnosisRow newDiagnosisRow = polDataSet.Diagnosis.NewDiagnosisRow();
                newDiagnosisRow.DiagnosisName = diagnoseNameLabel.Text;
                newDiagnosisRow.Description = descriptionTextBox.Text;
                newDiagnosisRow.DiagnosisCode = codeLabel.Text;
                newDiagnosisRow.DiagnosisDate = DateTime.ParseExact(diagnoseDateTextBox.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                polDataSet.Diagnosis.AddDiagnosisRow(newDiagnosisRow);
                diagnosisBindingSource.ResetBindings(false);

                status.Text = "Запись добавлена";
                status.ForeColor = Color.Green;
                parrotButton3_Click(null, new EventArgs());
                Bubble.Visible = false;
                Bubble2.Visible = false;

                diagnosisBindingSource.ResumeBinding();

                newDiagnoseButton.Text = "Новый";
                newDiagnoseButton.Invalidate();
                patientLabel.Visible = true;
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;

                cyberSwitch1.Checked = true;
                isNewDiagnose = false;

                return;
            }

            isNewDiagnose = true;
            status.Text = "Добавление новой записи ...";
            status.ForeColor = Color.Silver;
            Bubble.Visible = true;
            Bubble2.Visible = true;

            diagnosisBindingSource.SuspendBinding();

            patientLabel.Visible = false;
            diagnoseNameLabel.Text = "Название *";
            codeLabel.Text = "Код диагноза *";
            diagnoseDateTextBox.Text = "01.02.1970";
            newDiagnoseButton.Text = "Сохранить";
            newDiagnoseButton.Invalidate();
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;
            cyberSwitch1.Checked = true;

            hopeButton1.PrimaryColor = Color.FromArgb(99, 124, 234);
            hopeButton1.Invalidate();
        }

        private void hopeButton3_Click(object sender, EventArgs e)
        {
            if (isNewDiagnose)
            {
                diagnoseNameLabel.Text = "Название *";
                codeLabel.Text = "Код диагноза *";
                diagnoseDateTextBox.Text = "01.02.1970";
                newDiagnoseButton.Text = "Сохранить";

                return;
            }
            diagnosisBindingSource.RemoveCurrent();
        }

        private bool successNameInput = false;
        private bool successCodeInput = false;

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            isUpdated = true;
            status.Text = "Запись удалена";
            status.ForeColor = Color.Green;
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            isUpdated = true;
            hopeButton1_Click(null, new EventArgs());
        }

        private void diagnoseAddCancel()
        {
            isNewDiagnose = false;

            status.Text = "Операция отклонена";
            status.ForeColor = Color.Silver;
            parrotButton3_Click(null, new EventArgs());
            Bubble.Visible = false;
            Bubble2.Visible = false;

            try
            {
                patientLabel.Visible = true;
                diagnosisBindingSource.ResumeBinding();
            }
            catch { }
            newDiagnoseButton.Text = "Новый";
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = true;
        }

        private void Bubble_Click(object sender, EventArgs e)
        {
            Bubble.Visible = false;
            diagnosisDataGridView.ReadOnly = true;

        }
        private void Bubble2_Click(object sender, EventArgs e)
        {
            Bubble2.Visible = false;
        }

        private void hopeButton1_Click_1(object sender, EventArgs e)
        {
            diagnoseAddCancel();
            diagnosisBindingSource.ResumeBinding();
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
            if (isNewDiagnose) return;
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);

        }

        private void diagnosisDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            getPatientData();
            ComboBoxesUpdate();
        }

        private void patientLabel_MouseHover(object sender, EventArgs e)
        {
            getPatientData();
        }

        int PatientID = 0;
        bool patientRequest = false;
        private void getPatientData()
        {
            if (dataRead) return;
            if (diagnosisDataGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = diagnosisDataGridView.SelectedRows[0];

                if (selectedRow.Cells["dataGridViewTextBoxColumn1"].Value != null)
                {
                    int DiagnosisID = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn1"].Value);

                    string query = "SELECT DISTINCT P.PatientID, P.Surname, P.FirstName, P.MiddleName, P.BirthDate, P.Address, P.PhoneNumber " +
                                   "FROM Questionnaire Q JOIN Patient_new P ON Q.PatientID = P.PatientID JOIN Diagnosis D " +
                                  $"ON Q.DiagnosisID = D.DiagnosisID WHERE Q.DiagnosisID = {DiagnosisID};";

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

                                patientLabel.ForeColor = Color.Black;
                                patientLabel.Text = $"{surname} {firstName.Substring(0, 1)}.{middleName.Substring(0, 1)}.";
                                toolTip1.SetToolTip(patientLabel, patientData + "\n\nДвойной клик, чтобы узнать подробнее.");

                                patientRequest = true;
                            }
                            else
                            {
                                patientLabel.ForeColor = Color.Red;
                                patientLabel.Text = $"Не указан пациент!";
                                toolTip1.SetToolTip(patientLabel, "Двойной клик, чтобы задать пациента.");

                                patientRequest = false;
                            }
                        }
                    }
                }
                else
                    toolTip1.SetToolTip(patientLabel, "\nДля отображения данных о пациенте выберите диагноз");
            }
        }

        private void patientLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!patientRequest) return;
            PatientSearchRequested?.Invoke(PatientID);
        }

        private void diagnoseNameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода название диагноза." +
            "\nПример: Грипп\n\n\nНазвание:", isNewDiagnose ? "Добавление данных" : "Редактирование данных", diagnoseNameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                diagnoseNameLabel.Text = input;
                status.Text = isNewDiagnose ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewDiagnose)
                {
                    successNameInput = true;
                    return;
                }
                diagnosisBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Отчество не отредактировано";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewDiagnose)
                {
                    successNameInput = false;
                }
            }
        }

        private void diagnoseDateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                e.Handled = true;
                return;
            }
            TextBox textBox = (TextBox)sender;

            // Разрешаем ввод цифр и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            // Если введена цифра, добавляем ее в текстовое поле
            if (char.IsDigit(e.KeyChar))
            {
                // Проверяем, не превышает ли длина введенной даты 10 символов (максимальная длина)
                if (textBox.Text.Length < 10)
                {
                    textBox.Text += e.KeyChar;

                    // Если введено более двух символов для дня или месяца, автоматически добавляем точку
                    if (textBox.Text.Length == 2 || textBox.Text.Length == 5)
                    {
                        textBox.Text += '.';
                    }
                }
            }

            // Если введен Backspace, удаляем последний символ
            if (e.KeyChar == (char)Keys.Back && textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }

            // Проверяем, является ли введенная дата корректной (длина равна 10)
            if (textBox.Text.Length == 10)
            {
                if (!IsValidDate(textBox.Text))
                {
                    textBox.Focus();
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    diagnosisBindingSource.EndEdit();
                }
            }

            textBox.SelectionStart = textBox.Text.Length;
            e.Handled = true;
        }
        private bool IsValidDate(string date)
        {
            return DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
        private void codeLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода код диагноза." +
            "\nПример: J20.6\n\n\nКод диагноза:", isNewDiagnose ? "Добавление данных" : "Редактирование данных", codeLabel.Text);

            if (!string.IsNullOrEmpty(input))
            {
                codeLabel.Text = input;
                status.Text = isNewDiagnose ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewDiagnose)
                {
                    successCodeInput = true;
                    return;
                }
                diagnosisBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Код диагноза не отредактирован";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewDiagnose)
                {
                    successCodeInput = false;
                }
            }
        }

        private void chatBubbleRight1_MouseLeave(object sender, EventArgs e)
        {
            chatBubbleRight1.Visible = false;
        }

        private void Bubble_VisibleChanged(object sender, EventArgs e)
        {
            chatBubbleRight1.Visible = false;
        }

        public delegate void MedicationSearchEventHandler(string searchterm);
        public event MedicationSearchEventHandler MedicationSearchRequested;
        private void ListByDiagnoseButton_Click(object sender, EventArgs e)
        {
            if (diagnosisDataGridView.CurrentCell != null)
            {
                int rowIndex = diagnosisDataGridView.CurrentCell.RowIndex;
                if (rowIndex >= 0)
                {
                    object cellValue = diagnosisDataGridView[0, rowIndex].Value;

                    MedicationSearchRequested?.Invoke(cellValue.ToString());

                }
                else
                {
                    MedicationSearchRequested?.Invoke("1");
                }
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void descriptionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                e.Handled = true;
                return;
            }
        }

        private void cyberSwitch1_CheckedChanged()
        {
            if (!cyberSwitch1.Checked)
            {
                diagnosisDataGridView.ReadOnly = true;
            }
            else
            {
                diagnosisDataGridView.ReadOnly = false;
            }
        }

        private void aloneComboBox1_Resize(object sender, EventArgs e)
        {
            aloneComboBox1.Invalidate();
        }

        private void hopeButton2_Click(object sender, EventArgs e)
        {
            polDataSet.DiagnosisRow newDiagnosisRow = polDataSet.Diagnosis.NewDiagnosisRow();
            newDiagnosisRow.DiagnosisName = diagnoseNameLabel.Text;
            newDiagnosisRow.Description = descriptionTextBox.Text;
            newDiagnosisRow.DiagnosisCode = codeLabel.Text;
            newDiagnosisRow.DiagnosisDate = DateTime.ParseExact(diagnoseDateTextBox.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            polDataSet.Diagnosis.AddDiagnosisRow(newDiagnosisRow);
        }
    }
}
