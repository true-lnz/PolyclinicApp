using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace COMPANY_DB
{
    public partial class Reports : Form
    {
        public DataTable dataTable = null;
        public Reports()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        public static string connectionString = Properties.Settings.Default.KAZAKKULOV_EXP_CON;

        private void dungeonTrackBar1_ValueChanged()
        {
            if (dungeonTrackBar1.Value == 0)
                label3.Text = "3 дня";
            else if (dungeonTrackBar1.Value == 1)
                label3.Text = "Неделя";
            else if (dungeonTrackBar1.Value == 2)
                label3.Text = "Месяц";
            else if (dungeonTrackBar1.Value == 3)
                label3.Text = "Полгода";
            else if (dungeonTrackBar1.Value == 4)
                label3.Text = "Год";
            else
                label3.Text = "3 года";
        }

        private void dungeonTrackBar2_ValueChanged()
        {
            if (dungeonTrackBar2.Value == 0)
                label6.Text = "Без диагноза";
            else if (dungeonTrackBar2.Value == 1)
                label6.Text = "Последний";
            else
                label6.Text = "Все диагнозы";
        }

        private void parrotButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMode = label3.Text.ToLower();
                string selectedValue = aloneComboBox2.GetItemText(aloneComboBox2.SelectedValue);

                dataTable.Clear();
                dataTable.Columns.Clear();

                string query = $"SELECT* FROM dbo.GetPatientHistory({selectedValue}, '{selectedMode}');";


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
        private void LoadPatientsIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.GetPatientInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable patientTable = new DataTable();
                            adapter.Fill(patientTable);

                            DataRow allRow = patientTable.NewRow();
                            allRow["PatientID"] = -1;
                            allRow["PatientInfo"] = "Все";
                            patientTable.Rows.InsertAt(allRow, 0);

                            aloneComboBox1.DataSource = patientTable;
                            aloneComboBox1.DisplayMember = "PatientInfo";
                            aloneComboBox1.ValueMember = "PatientID";
                            aloneComboBox1.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке врачей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void parrotButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedValue = dungeonTrackBar2.Value;

                // Очищаем DataTable перед новым заполнением
                dataTable.Clear();
                dataTable.Columns.Clear(); // Очистка DataColumn коллекции

                string query = "";

                switch (selectedValue)
                {
                    case 0:
                        query = "SELECT * FROM PatientsWithoutDiagnosis";
                        break;
                    case 1:
                        query = "SELECT * FROM LatestDiagnosisForPatients";
                        break;
                    case 2:
                        query = "SELECT * FROM AllDiagnosesForPatients";
                        break;
                    default:
                        // Обработка значения, если оно не соответствует ни одному из ожидаемых
                        MessageBox.Show("Недопустимое значение");
                        return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Используем SqlDataAdapter для заполнения DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }

                ShowSaveDialog();
            }
            catch (Exception ex)
            {
                // Обработка ошибок, если они возникнут
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void parrotButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = label15.Text.ToLower() == "любой" ? "" : label15.Text.ToLower();
                string population = label11.Text;
                int datesCheck = aloneCheckBox1.Checked ? 1 : 0;
                int agesCheck = aloneCheckBox1.Checked ? 1 : 0;
                string mode = label21.Text.ToLower();
                string temp = aloneComboBox3.GetItemText(aloneComboBox3.SelectedValue);
                string diagnose = temp == "Все" ? "" : temp;

                dataTable.Clear();
                dataTable.Columns.Clear();

                string query = $"SELECT * FROM dbo.GetDiseaseStatistics('{diagnose}', '{gender}', " +
                                            $"'{mode}', {population}, {datesCheck}, {agesCheck});";

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

        private void ShowSaveDialog()
        {
            saveFileDialog1.Filter = "Файлы Excel|*.xlsx";
            saveFileDialog1.Title = "Сохранить отчет в Excel";

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

                if (MessageBox.Show("Отчет успешно экспортирован.\n\nОтрыть отчет в MS Excel?", "Успех", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(filePath);
                    } catch
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

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadDiagnosisIntoComboBox();
            LoadDoctorsIntoComboBox();
            LoadPatientsIntoComboBox();
        }

        private void dungeonTrackBar11_ValueChanged()
        {
            if (dungeonTrackBar11.Value == 0)
                label27.Text = "3 дня";
            else if (dungeonTrackBar11.Value == 1)
                label27.Text = "Неделя";
            else if (dungeonTrackBar11.Value == 2)
                label27.Text = "Месяц";
            else if (dungeonTrackBar11.Value == 3)
                label27.Text = "Полгода";
            else if (dungeonTrackBar11.Value == 4)
                label27.Text = "Год";
            else
                label27.Text = "3 года";
        }

        private void parrotButton5_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMode = label27.Text.ToLower();
                string selectedValue = aloneComboBox2.GetItemText(aloneComboBox2.SelectedValue);

                dataTable.Clear();
                dataTable.Columns.Clear();

                string query = $"SELECT * FROM dbo.GetDoctorDetails({selectedValue}, '{selectedMode}');";


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

        private void LoadDoctorsIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetDoctorsForComboBox", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable doctorsTable = new DataTable();
                            adapter.Fill(doctorsTable);

                            DataRow allRow = doctorsTable.NewRow();
                            allRow["DoctorID"] = -1; 
                            allRow["DoctorInfo"] = "Все";
                            doctorsTable.Rows.InsertAt(allRow, 0);

                            aloneComboBox2.DataSource = doctorsTable;
                            aloneComboBox2.DisplayMember = "DoctorInfo";
                            aloneComboBox2.ValueMember = "DoctorID";
                            aloneComboBox2.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке врачей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDiagnosisIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetUniqueDiagnosisNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable diagnosisTable = new DataTable();
                            adapter.Fill(diagnosisTable);

                            DataRow allRow = diagnosisTable.NewRow();
                            allRow["DiagnosisName"] = "Все";
                            diagnosisTable.Rows.InsertAt(allRow, 0);

                            aloneComboBox1.DataSource = diagnosisTable;
                            aloneComboBox1.DisplayMember = "DiagnosisName";
                            aloneComboBox1.ValueMember = "DiagnosisName";
                            aloneComboBox1.SelectedIndex = 0;

                            aloneComboBox3.DataSource = diagnosisTable;
                            aloneComboBox3.DisplayMember = "DiagnosisName";
                            aloneComboBox3.ValueMember = "DiagnosisName";
                            aloneComboBox3.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке диагнозов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dungeonTrackBar9_ValueChanged()
        {
            if (dungeonTrackBar9.Value == 0)
                label21.Text = "3 дня";
            else if (dungeonTrackBar9.Value == 1)
                label21.Text = "Неделя";
            else if (dungeonTrackBar9.Value == 2)
                label21.Text = "Месяц";
            else if (dungeonTrackBar9.Value == 3)
                label21.Text = "Полгода";
            else if (dungeonTrackBar9.Value == 4)
                label21.Text = "Год";
            else
                label21.Text = "3 года";
        }

        private void dungeonTrackBar3_ValueChanged()
        {
            if (dungeonTrackBar3.Value == 0)
                label11.Text = "100";
            else if (dungeonTrackBar3.Value == 1)
                label11.Text = "1000";
            else if (dungeonTrackBar3.Value == 2)
                label11.Text = "10000";
            else if (dungeonTrackBar3.Value == 3)
                label11.Text = "100000";
            else if (dungeonTrackBar3.Value == 4)
                label11.Text = "200000";
            else if (dungeonTrackBar3.Value == 5)
                label11.Text = "300000";
            else if (dungeonTrackBar3.Value == 6)
                label11.Text = "500000";
            else
                label11.Text = "1000000";
        }

        private void dungeonTrackBar6_ValueChanged()
        {
            if (dungeonTrackBar6.Value == 0)
                label15.Text = "М";
            else if (dungeonTrackBar6.Value == 1)
                label15.Text = "Любой";
            else
                label15.Text = "Ж";
        }

        private void dungeonTrackBar4_ValueChanged()
        {
            if (dungeonTrackBar6.Value == 0)
                label15.Text = "М";
            else
                label15.Text = "Ж";
        }

        private void dungeonTrackBar10_ValueChanged()
        {
            if (dungeonTrackBar10.Value == 0)
                label23.Text = "3 дня";
            else if (dungeonTrackBar10.Value == 1)
                label23.Text = "Неделя";
            else if (dungeonTrackBar10.Value == 2)
                label23.Text = "Месяц";
            else if (dungeonTrackBar10.Value == 3)
                label23.Text = "Полгода";
            else if (dungeonTrackBar10.Value == 4)
                label23.Text = "Год";
            else
                label23.Text = "3 года";
        }

        private void parrotButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMode = label23.Text.ToLower();

                dataTable.Clear();
                dataTable.Columns.Clear();

                string query = $"SELECT * FROM dbo.GetMedicationPrescriptions('{selectedMode}');";

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
    }
}
