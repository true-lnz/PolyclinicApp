using OfficeOpenXml;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPANY_DB
{
    public partial class Doctor : Form
    {
        int Access_level = 3;
        public Doctor(int Option)
        {
            InitializeComponent();
            Access_level = Option;
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "polDataSet.Doctor". При необходимости она может быть перемещена или удалена.
            this.doctorTableAdapter.Fill(this.polDataSet.Doctor);
            UpdateTable();
        }
        private bool getAccess(int requiredAccessLevel)
        {
            if (Access_level <= requiredAccessLevel)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Уровень доступа текущего пользователя слишком низкий.",
                    "Недопустимый уровень доступа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        private void UpdateTable()
        {
            try
            {
                string query = $"SELECT * FROM dbo.Doctor;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(this.polDataSet.Doctor);
                    }
                }
                //this.doctorTableAdapter.Fill(polDataSet.Doctor);

            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке!\nПроверьте подключение базе данных.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            doctorDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);
            doctorDataGridView.Sort(dataGridViewTextBoxColumn1, ListSortDirection.Ascending);
            doctorDataGridView.EnableHeadersVisualStyles = false;
        }

        /*        public delegate void PatientSearchEventHandler(int patientID);
                public event PatientSearchEventHandler PatientSearchRequested;*/

        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;

        public bool isUpdated = false;

        public void doctorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            if (isNewDoctor)
            {
                MessageBox.Show("Произошла ошибка при сохранении!\nCначало сохраните новую запись.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            try
            {
                this.Validate();
                FormatingNeeded = true;
                this.doctorBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.polDataSet);
                status.Text = "Таблица сохранена";
                status.ForeColor = Color.Green;
                isUpdated = false;
                UpdateTable();
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
            if (isNewDoctor)
            {
                if (MessageBox.Show("Добавление записи не закончено! Вы можете потерять данные.\n" +
                                "Хотите продолжить все равно?", "Ограничение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                                DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    doctorAddCancel();
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
                    for (int i = 2; i < doctorDataGridView.ColumnCount; i++)
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

                    doctorDataGridView.CurrentCell = cell;
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

                doctorDataGridView.CurrentCell = cell;

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
            foreach (DataGridViewRow row in doctorDataGridView.Rows)
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
            for (int j = 0; j < doctorDataGridView.RowCount; j++)
            {
                var value = doctorDataGridView.Rows[j].Cells[columnIndex].Value;
                if (value != null)
                {
                    string cellValue = value.ToString().ToLower();
                    if (cellValue.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                    {
                        DataGridViewCell cell = doctorDataGridView[columnIndex, j];
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
                currentColumnIndex = aloneComboBox1.SelectedIndex+1;
            }
        }

        private void doctorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            foreach (DataGridViewColumn column in doctorDataGridView.Columns)
            {
                if (!column.Visible)
                    continue;
                aloneComboBox1.Items.Add(column.HeaderText);
            }

            if (doctorDataGridView.CurrentCell != null)
            {
                int columnIndex = doctorDataGridView.CurrentCell.ColumnIndex-1;
                if (columnIndex >= 0 && columnIndex < aloneComboBox1.Items.Count)
                {
                    aloneComboBox1.SelectedIndex = columnIndex;
                }
            }

            aloneComboBox2.Items.Clear();
            aloneComboBox2.Items.Insert(0, "Свое значение");
            if (doctorDataGridView.CurrentCell != null)
            {
                int columnIndex = doctorDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0)
                {
                    List<string> uniqueValues = new List<string>();
                    for (int i = 0; i < doctorDataGridView.Rows.Count; i++)
                    {
                        object cellValue = doctorDataGridView[columnIndex, i].Value;
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

                if (doctorDataGridView.CurrentCell != null)
                {
                    int rowIndex = doctorDataGridView.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        string cellValue = doctorDataGridView[doctorDataGridView.CurrentCell.ColumnIndex, rowIndex].Value.ToString();
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

        private void doctorDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell errorCell = doctorDataGridView[e.ColumnIndex, e.RowIndex];
            MessageBox.Show(e.Exception.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isNewDoctor = false;
        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            if (isNewDoctor && (!successNameInput || !successSurnameInput || !successDeptInput || !successSpecializationInput))
            {
                MessageBox.Show("Один из обязательных параметров не отредактирован!\n" +
                                "Возможно имееются недопустимые символы.", "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isNewDoctor)
            {
                polDataSet.DoctorRow newDoctorRow = polDataSet.Doctor.NewDoctorRow();
                newDoctorRow.Surname = surnameLabel.Text;
                newDoctorRow.FirstName = firstNameLabel.Text;
                newDoctorRow.MiddleName = LastNameLabel.Text;
                newDoctorRow.Specialization = specializeLabel.Text;
                newDoctorRow.DepartmentID = Int32.Parse(textBox1.Text);
                newDoctorRow.PreviousExperience = byte.Parse(previousTextBox.Text);
                newDoctorRow.CurrentExperience = byte.Parse(currentTextBox.Text);
                newDoctorRow.Start_date = DateTime.Now;

                polDataSet.Doctor.AddDoctorRow(newDoctorRow);
                doctorBindingSource.ResetBindings(false);

                status.Text = "Запись добавлена";
                status.ForeColor = Color.Green;
                parrotButton3_Click(null, new EventArgs());
                Bubble.Visible = false;
                Bubble2.Visible = false;

                doctorBindingSource.ResumeBinding();

                newDiagnoseButton.Text = "Новый врач";
                newDiagnoseButton.Invalidate();
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;
                totalTextBox.Enabled = true;

                isNewDoctor = false;
                FormatingNeeded = true;
                doctorBindingNavigatorSaveItem_Click(null, new EventArgs());

                return;
            }

            isNewDoctor = true;
            status.Text = "Добавление новой записи ...";
            status.ForeColor = Color.Silver;
            Bubble.Visible = true;
            Bubble2.Visible = true;

            doctorBindingSource.SuspendBinding();

            surnameLabel.Text = "Фамилия *";
            firstNameLabel.Text = "Имя *";
            LastNameLabel.Text = "Отчество *";
            specializeLabel.Text = "Специальность *";
            deptLabel.Text = "Номер отдела *";
            previousTextBox.Text = "0";
            currentTextBox.Text = "0";
            totalTextBox.Enabled = false;
            newDiagnoseButton.Text = "Сохранить";
            newDiagnoseButton.Invalidate();
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;
            cyberSwitch1.Checked = true;
            FormatingNeeded = true;

            hopeButton1.PrimaryColor = Color.FromArgb(99, 124, 234);
            hopeButton1.Invalidate();
        }

        private void hopeButton3_Click(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            if (isNewDoctor)
            {
                surnameLabel.Text = "Фамилия *";
                firstNameLabel.Text = "Имя *";
                LastNameLabel.Text = "Отчество *";
                specializeLabel.Text = "Специальность *";
                deptLabel.Text = "Номер отдела *";
                previousTextBox.Text = "0";
                currentTextBox.Text = "0";
                newDiagnoseButton.Text = "Сохранить";
                totalTextBox.Enabled = false;

                return;
            }
            doctorBindingSource.RemoveCurrent();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            isUpdated = true;
            FormatingNeeded = true;
            status.Text = "Запись удалена";
            status.ForeColor = Color.Green;
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            isUpdated = true;
            hopeButton1_Click(null, new EventArgs());
        }

        private void doctorAddCancel()
        {
            isNewDoctor = false;

            status.Text = "Операция отклонена";
            status.ForeColor = Color.Silver;
            parrotButton3_Click(null, new EventArgs());
            Bubble.Visible = false;
            Bubble2.Visible = false;
            totalTextBox.Enabled = true;

            try
            {
                doctorBindingSource.ResumeBinding();
            }
            catch { }
            newDiagnoseButton.Text = "Новый врач";
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = true;
        }

        private void Bubble_Click(object sender, EventArgs e)
        {
            Bubble.Visible = false;
            doctorDataGridView.ReadOnly = true;

        }
        private void Bubble2_Click(object sender, EventArgs e)
        {
            Bubble2.Visible = false;
        }

        private void hopeButton1_Click_1(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            doctorAddCancel();
            doctorBindingSource.ResumeBinding();
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
            if (isNewDoctor) return;
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);

        }

        private void doctorDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            getDeptData();
            ComboBoxesUpdate();
        }

        int DepartmentID = 0;
        private void getDeptData()
        {
            if (doctorDataGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = doctorDataGridView.SelectedRows[0];

                if (selectedRow.Cells["dataGridViewTextBoxColumn6"].Value != null)
                {
                    DepartmentID = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn6"].Value);

                    string query = "SELECT distinct Dp.Name, Dp.Floor, Dp.NumberOfEmployees " +
                                    "FROM Department_new Dp " +
                                    "JOIN Doctor Dr ON Dr.DepartmentID = Dp.DepartmentID " +
                                   $"WHERE Dr.DepartmentID = {DepartmentID}";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                string name= reader["Name"].ToString();
                                int floor = Int32.Parse(reader["Floor"].ToString());
                                int num = Int32.Parse(reader["NumberOfEmployees"].ToString());

                                string patientData = $"\n{name}\n" +
                                                     $"\nЭтаж: {floor}\n" +
                                                     $"Количество сотрудников: {num}";

                                deptLabel.Text = $"{name}";
                                // Устанавливаем фактическое значение в ячейке
                                //doctorDataGridView.Rows[selectedRow.Index].Cells["dataGridViewTextBoxColumn6"].Value = name;
                                toolTip1.SetToolTip(deptLabel, patientData + "\n\nДвойной клик, чтобы изменить данныеы.");

                            }
                        }
                    }
                }
                else
                    toolTip1.SetToolTip(deptLabel, "\nДля отображения данных об отделе выберите врача");
            }
        }

        private String getDeptNameById(int ID)
        {
            string query = "SELECT distinct Dp.Name, Dp.Floor, Dp.NumberOfEmployees " +
                            "FROM Department_new Dp " +
                           $"WHERE Dp.DepartmentID = {ID}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        return name;

                    }
                }
            }
            return null;
        }

        private void diagnoseDateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            }

            textBox.SelectionStart = textBox.Text.Length;
            e.Handled = true;
        }
        private bool IsValidDate(string date)
        {
            return DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        bool FormatingNeeded = true;
        private void doctorDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что обрабатываем нужный столбец (например, ColumnIndex равен индексу вашего непривязанного столбца)
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                // Получаем значение Id отдела из второго столбца (замените на актуальный индекс)
                int departmentId = Convert.ToInt32(doctorDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value);

                // Получаем название отдела по Id (замените на свой способ получения названия отдела)
                string departmentName = getDeptNameById(departmentId);

                // Устанавливаем отформатированное значение для непривязанного столбца
                e.Value = departmentName;

                // Устанавливаем фактическое значение в ячейке
                doctorDataGridView.Rows[e.RowIndex].Cells["DeptName"].Value = departmentName;

                // Отменяем стандартное форматирование, так как мы сами устанавливаем значение
                e.FormattingApplied = true;
                FormatingNeeded = false;
            }
        }

        private void chatBubbleRight1_Click(object sender, EventArgs e)
        {
            chatBubbleRight1.Visible = false;
        }

        private bool successSurnameInput = false;
        private bool successNameInput = false;
        private bool successMiddleNameInput = false;
        private void surnameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;

            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода фамилию врача." +
              "\nПример: Иванов\n\n\nФамилия:", isNewDoctor ? "Добавление данных" : "Редактирование данных", surnameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                surnameLabel.Text = input;
                status.Text = isNewDoctor ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewDoctor)
                {
                    successSurnameInput = true;
                    FormatingNeeded = true;
                    return;
                }
                doctorBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Фамилия не отредактирована";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewDoctor)
                {
                    successSurnameInput = false;
                }
            }
        }

        private void firstNameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;

            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода имя врача." +
"\nПример: Иван\n\n\nИмя:", isNewDoctor ? "Добавление данных" : "Редактирование данных", firstNameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                firstNameLabel.Text = input;
                status.Text = isNewDoctor ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewDoctor)
                {
                    successNameInput = true;
                    FormatingNeeded = true;
                    return;
                }
                doctorBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Имя не отредактировано";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewDoctor)
                {
                    successNameInput = false;
                }
            }
        }

        private void LastNameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;

            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода отчество врача." +
            "\nПример: Иванович\n\n\nОтчество:", isNewDoctor ? "Добавление данных" : "Редактирование данных", LastNameLabel.Text);

            if (string.IsNullOrEmpty(input) || Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                LastNameLabel.Text = input;
                status.Text = isNewDoctor ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewDoctor)
                {
                    successMiddleNameInput = true;
                    FormatingNeeded = true;
                    return;
                }
                doctorBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Отчество не отредактировано";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewDoctor)
                {
                    successMiddleNameInput = false;
                }
            }
        }


        private bool successDeptInput = false;
        private void deptLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;

            if (!cyberSwitch1.Checked)
            {
                return;
            }
            StringBuilder resultStringBuilder = new StringBuilder();

            for (int departmentId = 0; departmentId <= 25; departmentId++)
            {
                string formattedDepartment = getDeptNameById(departmentId);

                if (!string.IsNullOrEmpty(formattedDepartment))
                {
                    resultStringBuilder.AppendLine(formattedDepartment + " - " + departmentId);
                }
            }

            using (ParametrInput deptForm = new ParametrInput())
            {
                deptForm.aloneComboBox1.Items.Add("Выберите отдел");
                deptForm.aloneComboBox1.Items.AddRange(resultStringBuilder.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                deptForm.aloneComboBox1.Sorted = true;
                deptForm.aloneComboBox1.SelectedIndex = deptForm.aloneComboBox1.FindString(deptLabel.Text);

                if (deptForm.ShowDialog() == DialogResult.OK)
                {
                    string selectedDeptText = deptForm.aloneComboBox1.SelectedItem.ToString();
                    string[] parts = selectedDeptText.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    textBox1.Text = parts[1];

                    if (parts.Length == 2 && int.TryParse(parts[1], out int selectedDeptId))
                    {
                        // Записываем данные в соответствующие места
                        deptLabel.Text = parts[0].Trim();
                        if (!isNewDoctor)
                            doctorDataGridView.Rows[doctorDataGridView.CurrentCell.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value = selectedDeptId;
                        status.Text = isNewDoctor ? "Добавление данных" : "Отредактировано!";
                        status.ForeColor = Color.Silver;

                        if (isNewDoctor)
                        {
                            successDeptInput = true;
                            FormatingNeeded = true;
                            return;
                        }
                        doctorBindingSource.EndEdit();
                    }
                    else
                    {
                        status.Text = "Некорректный выбор отдела";
                        SystemSounds.Exclamation.Play();
                        status.ForeColor = Color.Red;

                        if (isNewDoctor)
                        {
                            successDeptInput = false;
                        }
                    }
                }
            }
        }


        private bool successSpecializationInput = false;
        private void specializeLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;

            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода специалиизацию." +
            "\nПример: Терапевт\n\n\nСпециалиальность:", isNewDoctor ? "Добавление данных" : "Редактирование данных", specializeLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                specializeLabel.Text = input;
                status.Text = isNewDoctor ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;

                if (isNewDoctor)
                {
                    successSpecializationInput = true;
                    FormatingNeeded = true;
                    return;
                }
                doctorBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Специальность не отредактирована";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewDoctor)
                {
                    successSpecializationInput = false;
                }
            }
        }

        private void currentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked || !getAccess(0))
            {
                e.Handled = true;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Получаем текущий текст в TextBox
                string currentText = currentTextBox.Text + e.KeyChar;

                // Пытаемся преобразовать введенное значение в число
                if (int.TryParse(currentText, out int enteredValue))
                {
                    // Проверяем, чтобы число не превышало 100
                    if (enteredValue > 100)
                    {
                        e.Handled = true; // Отменяем ввод, если число больше 100
                                          // Можно также вывести сообщение об ошибке или выполнить другие действия
                    }
                }
            }
        }


        private void totalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            SystemSounds.Exclamation.Play();
        }

        private void previousTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked || !getAccess(0))
            {
                e.Handled = true;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Получаем текущий текст в TextBox
                string currentText = previousTextBox.Text + e.KeyChar;

                // Пытаемся преобразовать введенное значение в число
                if (int.TryParse(currentText, out int enteredValue))
                {
                    // Проверяем, чтобы число не превышало 100
                    if (enteredValue > 100)
                    {
                        e.Handled = true; // Отменяем ввод, если число больше 100
                                          // Можно также вывести сообщение об ошибке или выполнить другие действия
                    }
                }
            }
        }

        private void chatBubbleRight1_MouseLeave(object sender, EventArgs e)
        {
            chatBubbleRight1.Visible = false;
        }

        private void cyberSwitch1_CheckedChanged()
        {
            if (!cyberSwitch1.Checked)
            {
                doctorDataGridView.ReadOnly = true;
            }
            else
            {
                doctorDataGridView.ReadOnly = false;
            }
        }

        private void aloneComboBox1_Resize(object sender, EventArgs e)
        {
            aloneComboBox1.Invalidate();
        }

        DataTable dataTable = new DataTable();
        int DoctorID = 0;
        private void hopeButton2_Click(object sender, EventArgs e)
        {
            if (doctorDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = doctorDataGridView.SelectedRows[0];

                if (selectedRow.Cells["dataGridViewTextBoxColumn1"].Value != null)
                {
                    DoctorID = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn1"].Value);

                    try
                    {
                        dataTable.Clear();
                        dataTable.Columns.Clear();

                        string query = $"SELECT * FROM dbo.DoctorSchedule WHERE [Идентификатор врача] = {DoctorID};";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlDataAdapter adapter = new SqlDataAdapter(command);
                                adapter.Fill(dataTable);
                            }
                        }
                        ShowSaveDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    return;
            }


        }
        private void ShowSaveDialog()
        {
            saveFileDialog1.Filter = "Файлы Excel|*.xlsx";
            saveFileDialog1.Title = "Сохранить расписание в Excel";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dataTable, saveFileDialog1.FileName);
            }
        }

        private void ExportToExcel(DataTable dataTable, string filePath)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Лист1");

                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i].Value = dataTable.Columns[i - 1].ColumnName;
                    }

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j].ToString();
                        }
                    }
                    FileInfo excelFile = new FileInfo(filePath);
                    excelPackage.SaveAs(excelFile);
                }

                if (MessageBox.Show("Отчет о расписании врача успешно создан.\n\nОтрыть в MS Excel?", "Успех", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(filePath);
                    }
                    catch
                    {
                        MessageBox.Show("Файл поврежден или не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при экспорте отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
