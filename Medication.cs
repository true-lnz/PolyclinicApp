using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPANY_DB
{
    public partial class Medication : Form
    {
        int Access_level = 3;
        public delegate void MedicationSearchEventHandler(string searchterm);
        public event MedicationSearchEventHandler MedicationSearchRequested;
        public Medication(int Option)
        {
            InitializeComponent();
            Access_level = Option;
            medicationDataGridView.EnableHeadersVisualStyles = false;

        }
        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;

        private void Medication_Load(object sender, EventArgs e)
        {
            medicationDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);
            try
            {
                string query = $"SELECT * FROM dbo.Medication;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(this.polDataSet.Medication);
                    }
                }
                //this.medicationTableAdapter.Fill(this.polDataSet.Medication);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке!\nПроверьте подключение базе данных.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            medicationDataGridView.Sort(dataGridViewTextBoxColumn2, ListSortDirection.Ascending);

        }
        public bool isUpdated = false;
        public void medicationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNewMedication)
                {
                    MessageBox.Show("Произошла ошибка при сохранении!\nCначало сохраните новую запись.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.Validate();
                this.medicationBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.polDataSet);
                status.Text = "Таблица сохранена";
                status.ForeColor = Color.Green;
                isUpdated = false;
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
            if (isNewMedication)
            {
                if (MessageBox.Show("Добавление записи не закончено! Вы можете потерять данные.\n" +
                                "Хотите продолжить все равно?", "Ограничение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                                DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    medicationAddCancel();
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
                    for (int i = 1; i < medicationDataGridView.ColumnCount; i++)
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

                    medicationDataGridView.CurrentCell = cell;
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

                medicationDataGridView.CurrentCell = cell;

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
            foreach (DataGridViewRow row in medicationDataGridView.Rows)
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
            for (int j = 0; j < medicationDataGridView.RowCount; j++)
            {
                var value = medicationDataGridView.Rows[j].Cells[columnIndex].Value;
                if (value != null)
                {
                    string cellValue = value.ToString().ToLower();
                    if (cellValue.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                    {
                        DataGridViewCell cell = medicationDataGridView[columnIndex, j];
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
            foreach (DataGridViewRow row in medicationDataGridView.Rows)
            {
                var value = row.Cells["dataGridViewTextBoxColumn1"].Value;
                if (value != null && Convert.ToInt32(value) == patientID)
                {
                    row.Selected = true;
                    medicationDataGridView.CurrentCell = row.Cells[1];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.FromArgb(97, 117, 209);
                        cell.Style.ForeColor = Color.White;
                    }
                    break;
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

        private void medicationDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
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
            foreach (DataGridViewColumn column in medicationDataGridView.Columns)
            {
                if (!column.Visible)
                    continue;
                aloneComboBox1.Items.Add(column.HeaderText);
            }

            if (medicationDataGridView.CurrentCell != null)
            {
                int columnIndex = medicationDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0 && columnIndex < aloneComboBox1.Items.Count)
                {
                    aloneComboBox1.SelectedIndex = columnIndex;
                }
            }

            aloneComboBox2.Items.Clear();
            aloneComboBox2.Items.Insert(0, "Свое значение");
            if (medicationDataGridView.CurrentCell != null)
            {
                int columnIndex = medicationDataGridView.CurrentCell.ColumnIndex;
                if (columnIndex >= 0)
                {
                    List<string> uniqueValues = new List<string>();
                    for (int i = 0; i < medicationDataGridView.Rows.Count; i++)
                    {
                        object cellValue = medicationDataGridView[columnIndex, i].Value;
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

                if (medicationDataGridView.CurrentCell != null)
                {
                    int rowIndex = medicationDataGridView.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        string cellValue = medicationDataGridView[medicationDataGridView.CurrentCell.ColumnIndex, rowIndex].Value.ToString();
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

        private void medicationDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell errorCell = medicationDataGridView[e.ColumnIndex, e.RowIndex];

            // Выводим MessageBox с сообщением об исключении
            MessageBox.Show(e.Exception.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isNewMedication = false;
        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (isNewMedication && (!successNameInput || !successDosageInput))
            {
                MessageBox.Show("Один из обязательных параметров не отредактирован!\n" +
                                "Возможно имееются недопустимые символы.", "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isNewMedication)
            {
                polDataSet.MedicationRow newMedicationRow = polDataSet.Medication.NewMedicationRow();
                newMedicationRow.MedicationName = nameLabel.Text;
                newMedicationRow.DosageForm = dosageLabel.Text;
                newMedicationRow.Description = description.Text;
                newMedicationRow.Contraindications = contraindications.Text;
                newMedicationRow.Age = byte.Parse(ageTextBox.Text);

                polDataSet.Medication.AddMedicationRow(newMedicationRow);
                medicationBindingSource.ResetBindings(false);

                status.Text = "Запись добавлена";
                status.ForeColor = Color.Green;
                parrotButton3_Click(null, new EventArgs());
                Bubble.Visible = false;
                Bubble2.Visible = false;

                medicationBindingSource.ResumeBinding();

                newPatientButton.Text = "Новый медикамент";
                newPatientButton.Invalidate();
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;

                isNewMedication = false;

                return;
            }

            isNewMedication = true;
            status.Text = "Добавление новой записи ...";
            status.ForeColor = Color.Silver;
            Bubble.Visible = true;
            Bubble2.Visible = true;

            medicationBindingSource.SuspendBinding();

            nameLabel.Text = "Название *";
            dosageLabel.Text = "Форма выпуска *";
            description.Text = "Без описания";
            contraindications.Text = "Без противопоказаний";
            ageTextBox.Text = "0";
            newPatientButton.Text = "Сохранить";
            newPatientButton.Invalidate();
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;
            cyberSwitch1.Checked = true;

            hopeButton1.PrimaryColor = Color.FromArgb(99, 124, 234);
            hopeButton1.Invalidate();
        }

        private void hopeButton3_Click(object sender, EventArgs e)
        {
            if (isNewMedication)
            {
                nameLabel.Text = "Название *";
                dosageLabel.Text = "Форма выпуска *";
                description.Text = "Без описания";
                contraindications.Text = "Без противопоказаний";
                ageTextBox.Text = "0";
                newPatientButton.Text = "Сохранить";

                return;
            }
            medicationBindingSource.RemoveCurrent();
        }

        private bool successNameInput = false;

        private void nameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле для ввода название медикамента." +
            "\nПример: Ибупрофен\n\n\nНазвание:", isNewMedication ? "Добавление данных" : "Редактирование данных", nameLabel.Text);

            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                nameLabel.Text = input;
                status.Text = isNewMedication ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;


                if (isNewMedication)
                {
                    successNameInput = true;
                    return;
                }
                medicationBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Название не отредактировано";
                SystemSounds.Exclamation.Play();
                status.ForeColor = Color.Red;

                if (isNewMedication)
                {
                    successNameInput = false;
                }
            }
        }

        private bool successDosageInput = false;
        private void dosageLabel_DoubleClick(object sender, EventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                return;
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите в поле ввода форму выпуска." +
                "\nПример: Таблетка\n\n\nФорма выпуска:", isNewMedication ? "Добавление данных" : "Редактирование данных", dosageLabel.Text);

            if (string.IsNullOrEmpty(input) || Regex.IsMatch(input, @"^([а-яёa-z]+)$", RegexOptions.IgnoreCase))
            {
                dosageLabel.Text = input;
                status.Text = isNewMedication ? "Добавление данных" : "Отредактировано!";
                status.ForeColor = Color.Silver;

                if (isNewMedication)
                {
                    successDosageInput = true;
                    return;
                }
                medicationBindingSource.EndEdit();
            }
            else
            {
                status.Text = "Некорректная форма выпуска";
                status.ForeColor = Color.Red;
                SystemSounds.Exclamation.Play();

                if (isNewMedication)
                {
                    successDosageInput = false;
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
            hopeButton1_Click(null, new EventArgs());
        }

        private void medicationAddCancel()
        {
            isNewMedication = false;

            status.Text = "Операция отклонена";
            status.ForeColor = Color.Silver;
            parrotButton3_Click(null, new EventArgs());
            Bubble.Visible = false;
            Bubble2.Visible = false;

            try
            {
                medicationBindingSource.ResumeBinding();
            }
            catch { }
            newPatientButton.Text = "Новый";
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = true;
        }

        private void hopeButton1_Click_1(object sender, EventArgs e)
        {
            medicationAddCancel();
            medicationBindingSource.ResumeBinding();
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
            if (isNewMedication) return;
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);

        }

        private void patientDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ComboBoxesUpdate();
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
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
                string currentText = ageTextBox.Text + e.KeyChar;

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

        private void ListByDiagnoseButton_Click(object sender, EventArgs e)
        {
            MedicationSearchRequested?.Invoke("1");
        }

        private void GetDiagnosis()
        {

        }

        private void hopeButton2_Click(object sender, EventArgs e)
        {
            string MedicationID = "-1";
            DataTable diagnosisTable = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetDiagnosis", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            diagnosisTable = new DataTable();
                            adapter.Fill(diagnosisTable);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке врачей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (ParametrInput deptForm = new ParametrInput())
            {
                deptForm.aloneComboBox1.Items.Add("Выберите диагноз");
                deptForm.aloneComboBox1.DataSource = diagnosisTable;
                deptForm.aloneComboBox1.DisplayMember = "Diagnosis";
                deptForm.aloneComboBox1.ValueMember = "DiagnosisID";
                deptForm.aloneComboBox1.SelectedIndex = 0;

                if (deptForm.ShowDialog() == DialogResult.OK)
                {
                    string selectedID = deptForm.aloneComboBox1.GetItemText(deptForm.aloneComboBox1.SelectedValue);

                    if (selectedID != null)
                    {
                        string DiagnosisID = selectedID;

                        if (medicationDataGridView.CurrentCell != null)
                        {
                            int rowIndex = medicationDataGridView.CurrentCell.RowIndex;
                            if (rowIndex >= 0)
                            {
                                MedicationID = medicationDataGridView[0, rowIndex].Value.ToString();

                            }
                        }

                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (SqlCommand command = new SqlCommand($"EXEC AddMedicationToList {DiagnosisID}, {MedicationID}", connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            status.Text = "Успешная привязка!";
                            SystemSounds.Exclamation.Play();
                            status.ForeColor = Color.Green;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Произошла ошибка при добавлении медикамента!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            status.Text = "Привязка не удалась!";
                            status.ForeColor = Color.Red;
                        }

                    }
                    else
                    {
                        status.Text = "Некорректный выбор диагноза";
                        SystemSounds.Exclamation.Play();
                        status.ForeColor = Color.Red;
                    }
                }
                else
                {
                    status.Text = "Отменено";
                    status.ForeColor = Color.Silver;
                }
            }
        }

        private void cyberSwitch1_CheckedChanged()
        {
            if (!cyberSwitch1.Checked)
            {
                medicationDataGridView.ReadOnly = true;
            }
            else
            {
                medicationDataGridView.ReadOnly = false;
            }
        }

        private void description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                e.Handled = true;
                return;
            }
        }

        private void contraindications_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cyberSwitch1.Checked)
            {
                e.Handled = true;
                return;
            }
        }

        private void aloneComboBox1_Resize(object sender, EventArgs e)
        {
            aloneComboBox1.Invalidate();
        }
    }
}
