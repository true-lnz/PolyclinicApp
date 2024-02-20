using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COMPANY_DB.NewPatientQues;
using static COMPANY_DB.Questionnaire;

namespace COMPANY_DB
{
    public partial class NewPatientQues : Form
    {
        int DoctorId;
        public NewPatientQues(int DoctorID)
        {
            InitializeComponent();
            this.DoctorId = DoctorID;
        }
        public delegate void QuestionnaireSearchEventHandler(int ID);
        public event QuestionnaireSearchEventHandler QuesSearchRequested;
        private void newQuesButton_Click(object sender, EventArgs e)
        {
            CreatePatientAndQuestionnaire();
            QuesSearchRequested?.Invoke(-1);
        }
        private int InsertPatient(PatientData patientData)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.KAZAKKULOV_EXP_CON))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("InsertPatientAndGetID", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 250).Value = patientData.Surname;
                        cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 250).Value = patientData.FirstName;
                        cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar, 250).Value = patientData.MiddleName;
                        cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = patientData.BirthDate;

                        SqlParameter outputParameter = new SqlParameter("@NewPatientID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParameter);

                        cmd.ExecuteNonQuery();

                        int newPatientID = (int)outputParameter.Value;
                        return newPatientID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании пациента: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }

        private void InsertQuestionnaire(QuestionnaireData questionnaireData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertQuestionnaire", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = questionnaireData.PatientID;
                    cmd.Parameters.Add("@DoctorID_A", SqlDbType.Int).Value = questionnaireData.DoctorID_A;
                    cmd.Parameters.Add("@AppointmentDate", SqlDbType.Date).Value = questionnaireData.AppointmentDate;

                    cmd.ExecuteNonQuery();
                }
            }
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании приема: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CreatePatientAndQuestionnaire()
        {
            int patientID;

            if (!aloneCheckBox1.Checked && aloneComboBox2.SelectedValue != null)
            {
                patientID = (int)aloneComboBox2.SelectedValue;
            }
            else
            {
                PatientData patientData = new PatientData
                {
                    Surname = hopeTextBox0.Text,
                    FirstName = hopeTextBox1.Text,
                    MiddleName = hopeTextBox2.Text,
                    BirthDate = DateTime.Parse(hopeTextBox3.Text)
                };

                patientID = InsertPatient(patientData);
            }

            QuestionnaireData questionnaireData = new QuestionnaireData
            {
                PatientID = patientID,
                DoctorID_A = Convert.ToInt32(aloneComboBox1.SelectedValue),
                AppointmentDate = DateTime.Now
            };

            InsertQuestionnaire(questionnaireData);
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

                            aloneComboBox2.DataSource = patientTable;
                            aloneComboBox2.DisplayMember = "PatientInfo";
                            aloneComboBox2.ValueMember = "PatientID";
                            aloneComboBox2.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке пациентов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDoctorsIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT DoctorID, Specialization + ' ' + Surname + ' ' + FirstName + ' ' + ISNULL(MiddleName, '') AS DoctorName FROM Doctor", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable patientTable = new DataTable();
                            adapter.Fill(patientTable);

                            aloneComboBox1.DataSource = patientTable;
                            aloneComboBox1.DisplayMember = "DoctorName";
                            aloneComboBox1.ValueMember = "DoctorID";
                            aloneComboBox1.SelectedValue = DoctorId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке врачей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class PatientData
        {
            public string Surname { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Allergies { get; set; }
            public string ChronicDiseases { get; set; }
            public DateTime BirthDate { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class QuestionnaireData
        {
            public int PatientID { get; set; }
            public int DoctorID_A { get; set; }
            public string Complaints { get; set; }
            public DateTime AppointmentDate { get; set; }
            public DateTime? NextAppointmentDate { get; set; }
            public int? DaysUntilNextAppointment { get; set; }
            public int DiagnosisID { get; set; }
            public int? DoctorID_D { get; set; }
        }

        private void date1_TextChanged(object sender, EventArgs e)
        {
            aloneCheckBox1.Checked = true;
        }

        private void hopeTextBox1_TextChanged(object sender, EventArgs e)
        {
            aloneCheckBox1.Checked = true;

        }

        private void hopeTextBox2_TextChanged(object sender, EventArgs e)
        {
            aloneCheckBox1.Checked = true;

        }

        private void hopeTextBox3_TextChanged(object sender, EventArgs e)
        {
            aloneCheckBox1.Checked = true;

        }

        private void NewPatientQues_Load(object sender, EventArgs e)
        {
            LoadDoctorsIntoComboBox();
            LoadPatientsIntoComboBox();
        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            QuesSearchRequested?.Invoke(-2);
            Close();
        }
    }

   

}
