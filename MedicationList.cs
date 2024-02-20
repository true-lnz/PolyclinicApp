using OfficeOpenXml;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace COMPANY_DB
{
    public partial class MedicationList : Form
    {
        int Access_level = 3;
        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;
        private DataTable medicationTable;
        public MedicationList(int Option)
        {
            InitializeComponent();
            Access_level = Option;

            medicationTable = new DataTable();
            medicationDataGridView.DataSource = medicationTable;
            medicationDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 197, 255);
            medicationListTableAdapter.Fill(polDataSet1.MedicationList);

            tempBindingSource.DataSource = medicationTable;
            medicationDataGridView.EnableHeadersVisualStyles = false;
            
            dataTable = new DataTable();

        }

        private void hopeTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hopeTextBox1.Text))
            {
                medicationTable.Clear();
                diagnoseIDTextBox.Text = string.Empty;
                diagnoseLabel.Text = "Диагноз не найден";
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = $"SELECT * FROM dbo.GetMedicationByDiagnosis(@search);";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@search", hopeTextBox1.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        medicationTable.Clear();
                        adapter.Fill(medicationTable);
                        medicationDataGridView.Columns[0].Visible = false;
                        medicationDataGridView.Columns[1].Visible = false;

                        if (medicationTable.Rows.Count > 0)
                        {
                            DataRow row = medicationTable.Rows[0];
                            diagnoseIDTextBox.Text = row["DiagnosisID"].ToString();
                            diagnoseLabel.Text = row["Диагноз"].ToString();
                        }
                        else
                        {
                            diagnoseIDTextBox.Text = string.Empty;
                            diagnoseLabel.Text = "Диагноз не найден";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
            }
        }

        object ListID = null;
        private void medicationDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ComboBoxesUpdate();

            if (medicationDataGridView.SelectedCells.Count > 0)
            {
                int rowIndex = medicationDataGridView.SelectedCells[0].RowIndex;

                ListID = medicationDataGridView[0, rowIndex].Value;
                object IDValue = medicationDataGridView[1, rowIndex].Value;
                object DiagnoseValue = medicationDataGridView[2, rowIndex].Value;
                object NameValue = medicationDataGridView[3, rowIndex].Value;
                object DosageValue = medicationDataGridView[4, rowIndex].Value;
                object Decription = medicationDataGridView[5, rowIndex].Value;
                object Contraindications = medicationDataGridView[6, rowIndex].Value;
                object AgeValue = medicationDataGridView[7, rowIndex].Value;

                diagnoseIDTextBox.Text = IDValue?.ToString();
                diagnoseLabel.Text = DiagnoseValue?.ToString();

                nameLabel.Text = NameValue?.ToString();
                dosageLabel.Text = DosageValue?.ToString();
                description.Text = Decription?.ToString();
                contraindications.Text = Contraindications?.ToString();
                ageTextBox.Text = AgeValue?.ToString();
            }
            else
            {
                nameLabel.Text = "Нет названия";
                dosageLabel.Text = "Нет данных";
                description.Text = "";
                contraindications.Text = "";
                ageTextBox.Text = "0";
                diagnoseIDTextBox.Text = string.Empty;
                diagnoseLabel.Text = "Диагноз не найден";
            }
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
                int columnIndex = medicationDataGridView.CurrentCell.ColumnIndex-1;
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

        private void medicationDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBoxesUpdate();
            isUpdated = true;

            status.Text = "Редактирование ...";
            status.ForeColor = Color.Silver;
        }

        private void medicationDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell errorCell = medicationDataGridView[e.ColumnIndex, e.RowIndex];

            // Выводим MessageBox с сообщением об исключении
            MessageBox.Show(e.Exception.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool isInputSearch = false;
        public bool isUpdated = false;
        public string searchInput = "";

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

        public void medicationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.mlBindingSource.EndEdit();
                this.tableAdapterManager1.UpdateAll(this.polDataSet1);
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
            hopeButton1.PrimaryColor = Color.FromArgb(184, 197, 255);

        }

        private void description_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void contraindications_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void diagnoseIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            int targetId = Convert.ToInt32(ListID.ToString());

            // Ищем индекс строки с указанным ListID
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["listIDDataGridViewTextBoxColumn"].Value) == targetId)
                {
                    dataGridView1.Rows.Remove(row);

                    status.Text = "Удалено";
                    status.ForeColor = Color.Green;
                    return;
                }
            }

            status.Text = "Удалено";
            status.ForeColor = Color.Green;
        }


        private void deletePatientButton_Click(object sender, EventArgs e)
        {
            bindingNavigatorDeleteItem_Click(null, new EventArgs());

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
            Color.WhiteSmoke, 1, ButtonBorderStyle.Solid,  // left
            Color.White, 1, ButtonBorderStyle.Solid, // top 
            Color.White, 1, ButtonBorderStyle.Solid,    // right
            Color.White, 1, ButtonBorderStyle.Solid);    // bottom
        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            hopeTextBox1.Text = "";
        }
        public DataTable dataTable = null;
        private void hopeButton2_Click(object sender, EventArgs e)
        {
            string diagnoseId = "0";
            try
            {
                if (medicationDataGridView.CurrentCell != null)
                {
                    int rowIndex = medicationDataGridView.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        diagnoseId = medicationDataGridView[1, rowIndex].Value.ToString();

                    }
                }

                dataTable.Clear();
                dataTable.Columns.Clear();

                string query = $"SELECT * FROM dbo.GetMedicationByDiagnosis('{diagnoseId}');";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                GenerateAndSaveDocx(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateAndSaveDocx(DataTable dataTable)
        {
            try
            {
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для создания документа.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(documentsPath, $"Рецепт_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.docx");

                using (var doc = DocX.Create(filePath))
                {
                    var titleParagraph = doc.InsertParagraph();
                    titleParagraph.AppendLine($"Рецепт № ___").Bold().FontSize(16).Font("Times New Roman").Alignment = Alignment.center;
                    titleParagraph.AppendLine().SpacingAfter(10); // Добавим отступ после надписи

                    var table = doc.AddTable(dataTable.Rows.Count + 1, dataTable.Columns.Count - 2);
                    for (int i = 2; i < dataTable.Columns.Count; i++)
                    {
                        table.Rows[0].Cells[i - 2].Paragraphs[0].Append(dataTable.Columns[i].ColumnName).Bold().Font("Times New Roman");
                    }

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 2; j < dataTable.Columns.Count; j++)
                        {
                            table.Rows[i + 1].Cells[j - 2].Paragraphs[0].Append(dataTable.Rows[i][j].ToString()).Font("Times New Roman");
                        }
                    }

                    doc.InsertTable(table);

                    // Добавляем поле для имени и подписи врача
                    var signatureParagraph = doc.InsertParagraph();
                    signatureParagraph.AppendLine().SpacingAfter(10);
                    signatureParagraph.Append("Врач _____________________________").FontSize(12).Font("Times New Roman").Bold().Alignment = Alignment.right;
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


        private void aloneComboBox1_Resize(object sender, EventArgs e)
        {
            aloneComboBox1.Invalidate();
        }
    }
}
