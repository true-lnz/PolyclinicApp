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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPANY_DB
{
    public partial class Department : Form
    {
        int Access_level = 3;
        public Department(int Option)
        {
            InitializeComponent();
            Access_level = Option;
        }

        public delegate void PatientSearchEventHandler(int patientID);
        public event PatientSearchEventHandler PatientSearchRequested;

        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;

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

        private void Department_Load(object sender, EventArgs e)
        {
            try
            {
                string query = $"SELECT * FROM dbo.Department_new;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(this.polDataSet.Department);
                    }
                }
                //this.diagnosisTableAdapter.Fill(this.polDataSet.Department);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке!\nПроверьте подключение базе данных.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            departmentDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);
            employeesDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);            
            departmentDataGridView.Sort(dataGridViewTextBoxColumn2, ListSortDirection.Ascending);
        }
        public bool isUpdated = false;

        public void departmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            try
            {
                if (isNewDepartment)
                {
                    MessageBox.Show("Произошла ошибка при сохранении!\nCначало завершите сохранение новой записи.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.Validate();
                this.departmentBindingSource.EndEdit();
                this.tableAdapterManager1.UpdateAll(this.polDataSet);
                status.Text = "Таблица сохранена";
                status.ForeColor = Color.Green;
                isUpdated = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении!\nПроверьте корректность введенных значений.\n\n"+ex.Message,
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (isNewDepartment)
            {
                if (MessageBox.Show("Добавление записи не закончено! Вы можете потерять данные.\n" +
                                "Хотите продолжить все равно?", "Ограничение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                                DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    departmentAddCancel();
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
                    for (int i = 1; i < departmentDataGridView.ColumnCount; i++)
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

                    departmentDataGridView.CurrentCell = cell;
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

                departmentDataGridView.CurrentCell = cell;

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
            foreach (DataGridViewRow row in departmentDataGridView.Rows)
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
            for (int j = 0; j < departmentDataGridView.RowCount; j++)
            {
                var value = departmentDataGridView.Rows[j].Cells[columnIndex].Value;
                if (value != null)
                {
                    string cellValue = value.ToString().ToLower();
                    if (cellValue.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                    {
                        DataGridViewCell cell = departmentDataGridView[columnIndex, j];
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

        private void departmentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            departmentDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);

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
            foreach (DataGridViewColumn column in departmentDataGridView.Columns)
            {
                if (!column.Visible)
                    continue;
                aloneComboBox1.Items.Add(column.HeaderText);
            }

            if (departmentDataGridView.CurrentCell != null)
            {
                int columnIndex = departmentDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0 && columnIndex < aloneComboBox1.Items.Count)
                {
                    aloneComboBox1.SelectedIndex = columnIndex;
                }
            }

            aloneComboBox2.Items.Clear();
            aloneComboBox2.Items.Insert(0, "Свое значение");
            if (departmentDataGridView.CurrentCell != null)
            {
                int columnIndex = departmentDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0)
                {
                    List<string> uniqueValues = new List<string>();
                    for (int i = 0; i < departmentDataGridView.Rows.Count; i++)
                    {
                        object cellValue = departmentDataGridView[columnIndex, i].Value;
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

                if (departmentDataGridView.CurrentCell != null)
                {
                    int rowIndex = departmentDataGridView.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        string cellValue = departmentDataGridView[departmentDataGridView.CurrentCell.ColumnIndex, rowIndex].Value.ToString();
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

        private void departmentDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell errorCell = departmentDataGridView[e.ColumnIndex, e.RowIndex];
            MessageBox.Show(e.Exception.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isNewDepartment = false;
        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            if (isNewDepartment && !successNameInput)
            {
                MessageBox.Show("Один из обязательных параметров не отредактирован!\n" +
                                "Возможно имееются недопустимые символы.", "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isNewDepartment)
            {
                polDataSet.Department_newRow newDepartmentRow = polDataSet.Department_new.NewDepartment_newRow();
                newDepartmentRow.Name = departmentNameLabel.Text;
                newDepartmentRow.Floor = byte.Parse(floorTextBox.Text);
                newDepartmentRow.NumberOfEmployees = 0;

                polDataSet.Department_new.AddDepartment_newRow(newDepartmentRow);

                departmentBindingSource.ResetBindings(false);

                status.Text = "Запись добавлена";
                status.ForeColor = Color.Green;
                parrotButton3_Click(null, new EventArgs());

                label3.Visible = true;
                label4.Visible = true;
                allCountLabel.Visible = true;

                departmentBindingSource.ResumeBinding();

                newDiagnoseButton.Text = "Новый";
                newDiagnoseButton.Invalidate();
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;

                isNewDepartment = false;

                return;
            }

            isNewDepartment = true;
            status.Text = "Добавление новой записи ...";
            status.ForeColor = Color.Silver;

            label3.Visible = false;
            label4.Visible = false;
            allCountLabel.Visible = false;

            departmentBindingSource.SuspendBinding();

            departmentNameLabel.Text = "Название *";
            floorTextBox.Text = "1";
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
            if (!getAccess(0)) return;
            if (isNewDepartment)
            {
                departmentNameLabel.Text = "Название *";
                floorTextBox.Text = "1";
                newDiagnoseButton.Text = "Сохранить";

                return;
            }
            departmentBindingSource.RemoveCurrent();
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
            if (!getAccess(0)) return;
            isUpdated = true;
            hopeButton1_Click(null, new EventArgs());
        }

        private void departmentAddCancel()
        {
            if (!getAccess(0)) return;

            isNewDepartment = false;

            status.Text = "Операция отклонена";
            status.ForeColor = Color.Silver;
            parrotButton3_Click(null, new EventArgs());

            label3.Visible = true;
            label4.Visible = true;
            allCountLabel.Visible = true;

            try
            {
                departmentBindingSource.ResumeBinding();
            }
            catch { }
            newDiagnoseButton.Text = "Новый";
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = true;
        }
        private void hopeButton1_Click_1(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            departmentAddCancel();
            departmentBindingSource.ResumeBinding();
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
            if (isNewDepartment) return;
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);
        }

        private void UpdateAllCount()
        {
            int total = departmentDataGridView.Rows.Cast<DataGridViewRow>()
                                         .Sum(row => Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn4"].Value));
            allCountLabel.Text = total.ToString();
        }

        private void UpdateDeptID()
        {
            if (departmentDataGridView.SelectedCells.Count > 0)
            {
                int rowIndex = departmentDataGridView.SelectedCells[0].RowIndex;
                int columnIndex = departmentDataGridView.SelectedCells[0].ColumnIndex;
                object cellValue = departmentDataGridView[columnIndex, rowIndex].Value;

                deptID = Convert.ToInt32(cellValue?.ToString());
            }

        }

        int deptID = 0;

        private void departmentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDeptID();
            ComboBoxesUpdate();
            UpdateAllCount();
        }

        private void departmentNameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked || !getAccess(0))
                return;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода название диагноза." +
            "\nПример: Грипп\n\n\nНазвание:", isNewDepartment ? "Добавление данных" : "Редактирование данных", departmentNameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z\s]+)$", RegexOptions.IgnoreCase))
            {
                departmentNameLabel.Text = input;
                status.Text = isNewDepartment ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;

                if (isNewDepartment)
                {
                    successNameInput = true;
                    return;
                }
                departmentDataGridView.EndEdit();
            }
            else
            {
                status.Text = "Не корректное название!";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewDepartment)
                {
                    successNameInput = false;
                }
            }
        }

        private void floorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked || !getAccess(0))
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
                if (textBox.Text.Length < 2)
                {
                    textBox.Text += e.KeyChar;
                }
            }

            if (e.KeyChar == (char)Keys.Back && textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }

            textBox.SelectionStart = textBox.Text.Length;
            e.Handled = true;
        }

        private void GetDoctors()
        {
            employeesDataGridView.DataSource = null;
            string query = $"EXEC GetEmployeesByDeptID {deptID}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable temp = new DataTable();
                    adapter.Fill(temp);
                    employeesDataGridView.DataSource = temp;
                }
            }
        }

        private void togglePanels()
        {
            panel2.Visible = panel2.Visible == true ? false : true;
            newDiagnoseButton.Visible = newDiagnoseButton.Visible == true ? false : true;
            deleteDiagnoseButton.Visible = deleteDiagnoseButton.Visible == true ? false : true;     
            hopeButton1.Visible = hopeButton1.Visible == true ? false : true;       
        }
        bool previewMode = false;
        private void getDoctors_Click(object sender, EventArgs e)
        {
            togglePanels();
            if (!previewMode)
            {
                GetDoctors();
                employeesDataGridView.Visible = true;
                getDoctors.Text = "Вернуться назад";
                previewMode = true;
                return;
            }
            previewMode = false;
            employeesDataGridView.Visible = false;
            getDoctors.Text = "Получить сотрудников";

        }

        private void employeesDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            employeesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cyberSwitch1_CheckedChanged()
        {
            if (cyberSwitch1.Checked)
                departmentDataGridView.ReadOnly = false;
            else
                departmentDataGridView.ReadOnly = true;
        }

        private void aloneComboBox1_Resize(object sender, EventArgs e)
        {
            aloneComboBox1.Invalidate();
        }
    }
}
