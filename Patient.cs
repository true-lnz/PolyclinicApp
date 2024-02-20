using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPANY_DB
{
    public partial class Patient : Form
    {
        int Access_level = 3;
        static int DoctorIdentifier = 3;

        public Patient(int Option, int DoctorID)
        {
            InitializeComponent();
            Access_level = Option;
            DoctorIdentifier = DoctorID;
            patient_newDataGridView.EnableHeadersVisualStyles = false;
        }

        public delegate void DataUpdatedEventHandler(object sender, DataUpdatedEventArgs e);
        public class DataUpdatedEventArgs : EventArgs
        {
            public string TableName { get; set; }
            public DataUpdatedEventArgs(string tableName)
            {
                TableName = tableName;
            }
        }
        public event DataUpdatedEventHandler DataUpdated;

        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;

        public bool isUpdated = false;
        public void patientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (isNewPatient)
            {
                MessageBox.Show("Произошла ошибка при сохранении!\nCначало сохраните новую запись.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            this.Validate();
            this.patient_newBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.polDataSet);
            status.Text = "Таблица сохранена";
            status.ForeColor = Color.Green;
            isUpdated = false;
            DataUpdated?.Invoke(this, new DataUpdatedEventArgs("Пациенты"));
            try
            {

            }
            catch
            {
                MessageBox.Show("Произошла ошибка при сохранении!\nПроверьте корректность введенных значений.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void Patient_Load(object sender, EventArgs e)
        {
            patient_newDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);
            query = $"SELECT DISTINCT Patient_new.* FROM Patient_new JOIN Questionnaire ON Patient_new.PatientID = Questionnaire.PatientID " +
                $"WHERE Questionnaire.DoctorID_A = {DoctorIdentifier} OR Questionnaire.DoctorID_D = {DoctorIdentifier};";

            if (Access_level == 2 || Access_level == 0)
            {
                query = "SELECT * FROM Patient_new";
            }
            LoadData();

            patient_newDataGridView.Sort(dataGridViewTextBoxColumn2, ListSortDirection.Ascending);

        }
        public string query = $"SELECT DISTINCT Patient_new.* FROM Patient_new JOIN Questionnaire ON Patient_new.PatientID = Questionnaire.PatientID " +
                $"WHERE Questionnaire.DoctorID_A = {DoctorIdentifier} OR Questionnaire.DoctorID_D = {DoctorIdentifier};";

        public void LoadData()
        {
            // Очистка данных перед обновлением
            this.polDataSet.Patient_new.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(this.polDataSet.Patient_new);
                }
            }
            patient_newDataGridView.Refresh();
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
            if (isNewPatient)
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

            // Устанавливаем флаг поиска в true, чтобы отключить событие SelectionChanged
            isSearching = true;

            if (!string.IsNullOrEmpty(selectedText))
            {
                if (currentColumnIndex == -1)
                {
                    for (int i = 1; i < patient_newDataGridView.ColumnCount; i++)
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

                    patient_newDataGridView.CurrentCell = cell;
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

                patient_newDataGridView.CurrentCell = cell;

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
            foreach (DataGridViewRow row in patient_newDataGridView.Rows)
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
            for (int j = 0; j < patient_newDataGridView.RowCount; j++)
            {
                var value = patient_newDataGridView.Rows[j].Cells[columnIndex].Value;
                if (value != null)
                {
                    string cellValue = value.ToString().ToLower();
                    if (cellValue.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                    {
                        DataGridViewCell cell = patient_newDataGridView[columnIndex, j];
                        cell.Style.BackColor = Color.FromArgb(97, 117, 209);
                        cell.Style.ForeColor = Color.White;
                        matchedCells.Add(cell);
                        totalMatches++;
                    }
                }
            }
        }
        public void SearchByID(int patientID)
        {
            clearSelection();
            foreach (DataGridViewRow row in patient_newDataGridView.Rows)
            {
                var value = row.Cells["dataGridViewTextBoxColumn1"].Value;
                if (value != null && Convert.ToInt32(value) == patientID)
                {
                    row.Selected = true;
                    patient_newDataGridView.CurrentCell = row.Cells[1];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.FromArgb(97, 117, 209);
                        cell.Style.ForeColor = Color.White;
                    }
                    break;
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

        private void patient_newDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            foreach (DataGridViewColumn column in patient_newDataGridView.Columns)
            {
                if (!column.Visible)
                    continue;
                aloneComboBox1.Items.Add(column.HeaderText);
            }

            if (patient_newDataGridView.CurrentCell != null)
            {
                int columnIndex = patient_newDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0 && columnIndex < aloneComboBox1.Items.Count)
                {
                    aloneComboBox1.SelectedIndex = columnIndex;
                }
            }

            aloneComboBox2.Items.Clear();
            aloneComboBox2.Items.Insert(0, "Свое значение");
            if (patient_newDataGridView.CurrentCell != null)
            {
                int columnIndex = patient_newDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0)
                {
                    List<string> uniqueValues = new List<string>();
                    for (int i = 0; i < patient_newDataGridView.Rows.Count; i++)
                    {
                        object cellValue = patient_newDataGridView[columnIndex, i].Value;
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

                if (patient_newDataGridView.CurrentCell != null)
                {
                    int rowIndex = patient_newDataGridView.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        string cellValue = patient_newDataGridView[patient_newDataGridView.CurrentCell.ColumnIndex, rowIndex].Value.ToString();
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

        private void patient_newDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell errorCell = patient_newDataGridView[e.ColumnIndex, e.RowIndex];

            // Выводим MessageBox с сообщением об исключении
            MessageBox.Show(e.Exception.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isNewPatient = false;
        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (isNewPatient && (!successSurnameInput || !successNameInput || !successLastNameInput))
            {
                MessageBox.Show("Один из обязательных параметров не отредактирован!\n" +
                                "Возможно имееются недопустимые символы.", "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isNewPatient)
            {
                polDataSet.Patient_newRow newPatientRow = polDataSet.Patient_new.NewPatient_newRow();
                newPatientRow.Surname = surnameLabel.Text;
                newPatientRow.FirstName = firstNameLabel.Text;
                newPatientRow.MiddleName = LastNameLabel.Text;
                newPatientRow.Allergies = allergies.Text;
                newPatientRow.ChronicDiseases = chronic.Text;
                newPatientRow.BirthDate = DateTime.ParseExact(birthDateLabel.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                newPatientRow.Address = address.Text;
                newPatientRow.PhoneNumber = telphone.Text;

                polDataSet.Patient_new.AddPatient_newRow(newPatientRow);
                patient_newBindingSource.ResetBindings(false);

                status.Text = "Запись добавлена";
                status.ForeColor = Color.Green;
                parrotButton3_Click(null, new EventArgs());
                Bubble.Visible = false;
                Bubble2.Visible = false;

                patient_newBindingSource.ResumeBinding();

                newPatientButton.Text = "Новый";
                newPatientButton.Invalidate();
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;

                isNewPatient = false;

                return;
            }

            isNewPatient = true;
            status.Text = "Добавление новой записи ...";
            status.ForeColor = Color.Silver;
            Bubble.Visible = true;
            Bubble2.Visible = true;
            cyberSwitch1.Checked = true;
            patient_newBindingSource.SuspendBinding();

            surnameLabel.Text = "Фамилия *";
            firstNameLabel.Text = "Имя *";
            LastNameLabel.Text = "Отчество *";
            birthDateLabel.Text = "01.02.1970";
            allergies.Text = "Нет";
            chronic.Text = "Нет";
            address.Text = "...";
            telphone.Text = "+79991230000";
            newPatientButton.Text = "Сохранить";
            newPatientButton.Invalidate();
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;

            hopeButton1.PrimaryColor = Color.FromArgb(99, 124, 234);
            hopeButton1.Invalidate();
        }

        private void hopeButton3_Click(object sender, EventArgs e)
        {
            if (isNewPatient)
            {
                surnameLabel.Text = "Фамилия *";
                firstNameLabel.Text = "Имя *";
                LastNameLabel.Text = "Отчество *";
                birthDateLabel.Text = "01.02.1970";
                allergies.Text = "Нет";
                chronic.Text = "Нет";
                address.Text = "...";
                telphone.Text = "+79991230000";
                newPatientButton.Text = "Сохранить";

                return;
            }
            patient_newBindingSource.RemoveCurrent();
        }

        private bool successSurnameInput = false;
        private void surnameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода фамилию пациента." +
                "\nПример: Иванов\n\n\nФамилия:", isNewPatient ? "Добавление данных" : "Редактирование данных", surnameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                surnameLabel.Text = input;
                status.Text = isNewPatient ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewPatient)
                {
                    successSurnameInput = true;
                    return;
                }
                patient_newBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Фамилия не отредактирована";
                status.ForeColor = Color.Red;
                SystemSounds.Exclamation.Play();

                if (isNewPatient)
                {
                    successSurnameInput = false;
                }
            }
        }

        private bool successNameInput = false;
        private void firstNameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода имя пациента." +
    "\nПример: Иван\n\n\nИмя:", isNewPatient ? "Добавление данных" : "Редактирование данных", firstNameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                firstNameLabel.Text = input;
                status.Text = isNewPatient ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewPatient)
                {
                    successNameInput = true;
                    return;
                }
                patient_newBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Имя не отредактировано";
                status.ForeColor = Color.Red;
                SystemSounds.Exclamation.Play();

                if (isNewPatient)
                {
                    successNameInput = false;
                }
            }
        }

        private bool successLastNameInput = false;
        private void LastNameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода фамилию пациента." +
    "\nПример: Иванович\n\n\nОтчество:", isNewPatient ? "Добавление данных" : "Редактирование данных", LastNameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                LastNameLabel.Text = input;
                status.Text = isNewPatient ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewPatient)
                {
                    successLastNameInput = true;
                    return;
                }
                patient_newBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Отчество не отредактировано";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewPatient)
                {
                    successLastNameInput = false;
                }
            }
        }
        private void birthDateLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода дату рождения пациента." +
                "\nПример: 01.10.1990\n\n\nДата рождения:", isNewPatient ? "Добавление данных" : "Редактирование данных", birthDateLabel.Text);

            DateTime parsedDate;
            bool valid = DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate) ||
                         DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedDate) ||
                         DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate);

            if (!string.IsNullOrEmpty(input) && valid)
            {
                birthDateLabel.Text = input;
                status.Text = isNewPatient ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;

                if (isNewPatient)
                {
                    return;
                }
                patient_newBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Дата не отредактирована";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;
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
            hopeButton1_Click(null, new EventArgs());
        }

        private void patientAddCancel()
        {
            isNewPatient = false;

            status.Text = "Операция отклонена";
            status.ForeColor = Color.Silver;
            parrotButton3_Click(null, new EventArgs());
            Bubble.Visible = false;
            Bubble2.Visible = false;

            try
            {
                patient_newBindingSource.ResumeBinding();
            }
            catch { }
            newPatientButton.Text = "Новый";
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = true;
        }

        private void Bubble_Click(object sender, EventArgs e)
        {
            Bubble.Visible = false;
            patient_newDataGridView.ReadOnly = true;

        }
        private void Bubble2_Click(object sender, EventArgs e)
        {
            Bubble2.Visible = false;
        }

        private void hopeButton1_Click_1(object sender, EventArgs e)
        {
            patientAddCancel();
            patient_newBindingSource.ResumeBinding();
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
            if (isNewPatient) return;
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);

        }
        private void telphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                e.Handled = true;
                return;
            }
            TextBox maskedTextBox = (TextBox)sender;

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
        private void getAge()
        {
            if (patient_newDataGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = patient_newDataGridView.SelectedRows[0];

                if (selectedRow.Cells["dataGridViewTextBoxColumn5"].Value != null)
                {
                    DateTime date = Convert.ToDateTime(selectedRow.Cells["dataGridViewTextBoxColumn5"].Value.ToString());

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Открытие подключения
                        connection.Open();

                        // Создание команды для вызова хранимой процедуры с использованием инлайн функции
                        using (SqlCommand command = new SqlCommand("SELECT dbo.CalculateAge(@Birthdate) AS Age", connection))
                        {
                            // Добавление параметра для передачи даты рождения
                            command.Parameters.Add("@Birthdate", SqlDbType.Date).Value = date;

                            // Выполнение команды и получение результата
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Получение возраста из результата запроса
                                    int age = Convert.ToInt32(reader["Age"]);
                                    toolTip1.SetToolTip(birthDateLabel, $"Возвраст: {age} год(а)");
                                }
                            }
                        }
                    }
                }
                else
                    toolTip1.SetToolTip(birthDateLabel, "\nНет данных о возрасте");
            }
        }

        private void patient_newDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ComboBoxesUpdate();
            getAge();
            if (patient_newDataGridView.CurrentCell != null)
            {
                int rowIndex = patient_newDataGridView.CurrentCell.RowIndex;
                genderTextBox.Text = patient_newDataGridView[5, rowIndex].Value.ToString();
            }


        }

        private void genderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (genderTextBox.Text == "М")
            {
                hopeRadioButton1.Checked = true;
            }
            else
                hopeRadioButton2.Checked = true;
        }

        private void hopeRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (hopeRadioButton2.Checked)
                genderTextBox.Text = "Ж";
            patient_newBindingSource.EndEdit();

        }

        private void hopeRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked && hopeRadioButton2.Checked)
            {
                hopeRadioButton1.Checked = false;
                hopeRadioButton2.Checked = true;
                return;
            }
            if (hopeRadioButton1.Checked)
                genderTextBox.Text = "М";
            patient_newBindingSource.EndEdit();

        }

        private void allergies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                e.Handled = true;
                return;
            }
        }

        private void chronic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                e.Handled = true;
                return;
            }
        }

        private void address_KeyPress(object sender, KeyPressEventArgs e)
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
                patient_newDataGridView.ReadOnly = true;
                panel8.Enabled = false;
            }
            else
            {
                patient_newDataGridView.ReadOnly = false;
                panel8.Enabled = true;
            }
        }

        private void hopeRadioButton2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void aloneComboBox1_Resize(object sender, EventArgs e)
        {
            aloneComboBox1.Invalidate();
        }
    }
}
