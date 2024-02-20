using COMPANY_DB.polDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static COMPANY_DB.Patient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COMPANY_DB
{
    public partial class MainPolyclinicForm : Form
    {
        private bool Drag;
        private int MouseX;
        private int MouseY;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
         );
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        static int Access_level = 3;
        static int DoctorIdentifier = 0;
        UsersTable us;
        Questionnaire q;
        NewPatientQues newP;
        public static Patient p;
        Diagnosis di;
        MedicationList ml;
        Medication md;
        Doctor dr;
        Department dp;
        Reports rp;

        public MainPolyclinicForm(int Option, int DoctorID)
        {
            m_aeroEnabled = false;
            InitializeComponent();
            Access_level = Option;
            DoctorIdentifier = DoctorID;
            us = new UsersTable();
            q = new Questionnaire(Access_level, DoctorID);
            newP = new NewPatientQues(DoctorID);
            p = new Patient(Access_level, DoctorID);
            di = new Diagnosis(Access_level, DoctorID);
            ml = new MedicationList(Access_level);
            md = new Medication(Access_level);
            dr = new Doctor(Access_level);
            dp = new Department(Access_level);
            rp = new Reports();
            getDoctorData();
         }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 0,
                            leftWidth = 0,
                            rightWidth = 1,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        private void getDoctorData()
        {
            string query = "SELECT Surname, FirstName, MiddleName, Specialization " +
                            $"FROM Doctor WHERE DoctorID = {DoctorIdentifier};";

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

                        label2.Text = $"Текущий пользователь:\n\n{surname} {firstName} {middleName}\nСпециализация: {spec}";

                    }
                }
            }
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

        private void Tables_Load(object sender, EventArgs e)
        {
            di.PatientSearchRequested += HandlePatientSearchRequested;
            q.PatientSearchRequested += HandlePatientSearchRequested;
            q.NewQues += HandleNewQuestionnaire;
            newP.QuesSearchRequested += HandleBackRequested;

            md.MedicationSearchRequested += HandleMedicationSearchRequested;
            di.MedicationSearchRequested += HandleMedicationSearchRequested;
            p.DataUpdated += DataUpdatedHandler;
            if (Access_level == 0)
            {
                label1.Text += "Админ";
                пользователиToolStripMenuItem.Visible = true;
            }
            else if (Access_level == 1)
            {
                label1.Text += "Врач";

            }
            else
            {
                label1.Text += "Регистратура";
            }
        }

        private void HandleNewQuestionnaire()
        {
            formToggle(newP, 0);
        }

        private void HandleBackRequested(int ID)
        {
            formToggle(q, 0);
            q.Questionnaire_Load(null, new EventArgs());
            q.questionnaireBindingSource.MoveLast();
        }

        private void Tables_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!p.isUpdated || !dp.isUpdated || !dr.isUpdated || !md.isUpdated || !di.isUpdated || !q.isUpdated) return;

            if (MessageBox.Show("Вы действительно уверены?\nНе сохраненные изменения будут утеряны.", 
                "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Auth.DecrementUserCount();
                Application.Exit();
            }
        }

        Form currentForm = null;
        Form previousForm = null;
        int toggleCount = 0;

        private void HandlePatientSearchRequested(int patientID)
        {
            buttonToggle(hopeButton2);
            formToggle(p, Access_level);
            p.SearchByID(patientID);
        }

        private void HandleMedicationSearchRequested(string searchterm)
        {
            cancelMedicationList.Visible = true;
            previousForm = currentForm;
            formToggle(ml, Access_level);
            ml.hopeTextBox1.Text = searchterm;
        }

        private void DataUpdatedHandler(object sender, DataUpdatedEventArgs e)
        {
            string tableName = e.TableName;
        }

        private void formToggle(Form F, int flag)
        {
            previousForm = currentForm;

            if (toggleCount!=0)
                currentForm.Hide();

            F.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(F);
            F.Dock = DockStyle.Fill;
            F.Show();

            if (flag==0)
                currentForm = F;

            toggleCount++;
        }

        List<ReaLTaiizor.Controls.HopeButton> buttons = new List<ReaLTaiizor.Controls.HopeButton>();
        
        private void buttonToggle(ReaLTaiizor.Controls.HopeButton btn)
        {
            buttons.Add(hopeButton1); buttons.Add(hopeButton2); buttons.Add(hopeButton3);
            buttons.Add(hopeButton4); buttons.Add(hopeButton5); buttons.Add(hopeButton7);
            foreach (ReaLTaiizor.Controls.HopeButton button in buttons)
            {
                button.TextColor = Color.FromArgb(184, 197, 255);
                button.HoverTextColor = Color.FromArgb(99, 124, 234);
                button.PrimaryColor = Color.White;
                button.Invalidate();
            }

            btn.TextColor = Color.White;
            btn.HoverTextColor = Color.White;
            btn.PrimaryColor = Color.FromArgb(99, 124, 234);
        }
        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (getAccess(2))
            {
                formToggle(q, 0);
                hopeButton8.Visible = true;
                cancelMedicationList.Visible = false;
                buttonToggle((ReaLTaiizor.Controls.HopeButton)sender);
            }

        }
        private void hopeButton2_Click(object sender, EventArgs e)
        {
            if (!getAccess(2)) return;
            formToggle(p, 0);
            hopeButton8.Visible = true;
            cancelMedicationList.Visible = false;
            buttonToggle((ReaLTaiizor.Controls.HopeButton)sender);
        }
        private void hopeButton3_Click(object sender, EventArgs e)
        {
            if (!getAccess(1)) return;
            formToggle(di, 0);
            hopeButton8.Visible = true;
            cancelMedicationList.Visible = false;
            buttonToggle((ReaLTaiizor.Controls.HopeButton)sender);
        }
        private void hopeButton7_Click(object sender, EventArgs e)
        {
            if (!getAccess(1)) return;
            formToggle(md, 0);
            hopeButton8.Visible = true;
            buttonToggle((ReaLTaiizor.Controls.HopeButton)sender);
        }
        private void hopeButton4_Click(object sender, EventArgs e)
        {
            if (!getAccess(1)) return;
            formToggle(dr, 0);
            hopeButton8.Visible = true;
            cancelMedicationList.Visible = false;
            buttonToggle((ReaLTaiizor.Controls.HopeButton)sender);
        }
        private void hopeButton5_Click(object sender, EventArgs e)
        {
            if (!getAccess(1)) return;
            formToggle(dp, 0);
            hopeButton8.Visible = true;
            cancelMedicationList.Visible = false;
            buttonToggle((ReaLTaiizor.Controls.HopeButton)sender);
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Drag = true;
                MouseX = e.X;
                MouseY = e.Y;
            }
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.WindowState = FormWindowState.Normal;
                int newX = this.Left + e.X - MouseX;
                int newY = this.Top + e.Y - MouseY;
                this.Location = new Point(newX, newY);
            }
        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Drag = false;
            }
        }
        private void MainPolyclinicForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                настройкиToolStripMenuItem.Padding = new Padding(0, 25, 0, 25);
                календарьToolStripMenuItem.Padding = new Padding(0, 25, 0, 25);
                уведомленияToolStripMenuItem2.Padding = new Padding(0, 25, 0, 25);
                таблицыToolStripMenuItem3.Padding = new Padding(0, 25, 0, 25);
                отчетыToolStripMenuItem.Padding = new Padding(0, 25, 0, 25);
                panel2.MaximumSize = new Size(1447, 833);
            }
            else
            {
                настройкиToolStripMenuItem.Padding = new Padding(0, 10, 0, 10);
                календарьToolStripMenuItem.Padding = new Padding(0, 10, 0, 10);
                уведомленияToolStripMenuItem2.Padding = new Padding(0, 10, 0, 10);
                таблицыToolStripMenuItem3.Padding = new Padding(0, 10, 0, 10);
                отчетыToolStripMenuItem.Padding = new Padding(0, 10, 0, 10);
                //panel2.MaximumSize = new Size(725, 469);
            }
        }
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        private void saveAllTables()
        {
            try
            {
                q.questionnaireBindingNavigatorSaveItem_Click(null, new EventArgs());
                p.patientBindingNavigatorSaveItem_Click(null, new EventArgs());
                di.diagnosisBindingNavigatorSaveItem_Click(null, new EventArgs());
                //ml.medicationListBindingNavigatorSaveItem_Click(null, new EventArgs());
                md.medicationBindingNavigatorSaveItem_Click(null, new EventArgs());
                dp.departmentBindingNavigatorSaveItem_Click(null, new EventArgs());
                dr.doctorBindingNavigatorSaveItem_Click(null, new EventArgs());
            } catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении одной из таблиц!" +
                    "\nПопробуйте сохранить таблицы по отдельности.\n\n"+ex.Message,
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hopeButton8.Visible = false;

        }
        private void hopeButton8_Click(object sender, EventArgs e)
        {
            saveAllTables();
        }
        private void hopeButton8_MouseEnter(object sender, EventArgs e)
        {
            hopeButton8.PrimaryColor = Color.FromArgb(99, 124, 234);
        }
        private void hopeButton8_MouseDown(object sender, MouseEventArgs e)
        {
            hopeButton8.PrimaryColor = Color.FromArgb(184, 197, 255);
        }
        private void hopeButton8_MouseLeave(object sender, EventArgs e)
        {
            hopeButton8.PrimaryColor = Color.FromArgb(184, 197, 255);
        }

        private void таблицыToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!getAccess(2)) return;
            if (panel1.Visible)
            {
                panel1.Visible = false;
                panel2.Size = new Size(916, 469);
            }
            else
            {
                panel1.Visible = true;
                panel2.Location = new Point(275, 31);
                panel2.Size = new Size(725, 469);
            }
            if (toggleCount > 0)
            {
                formToggle(previousForm, 0);
                return;
            }
            formToggle(q, 0);
        }
        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!getAccess(1)) return;
            panel1.Visible = false;
            panel2.Size = new Size(758, 449);
            hopeButton8.Visible = false;
            cancelMedicationList.Visible = false;
            formToggle(rp, 0);
        }
        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!getAccess(0)) return;
            if (us.ShowDialog() == DialogResult.OK) return;
        }

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void cancelMedicationList_Click(object sender, EventArgs e)
        {
            cancelMedicationList.Visible = false;
            formToggle(previousForm, Access_level);
        }

        private void cancelMedicationList_MouseDown(object sender, MouseEventArgs e)
        {
            cancelMedicationList.PrimaryColor = Color.FromArgb(184, 197, 255);
        }

        private void cancelMedicationList_MouseEnter(object sender, EventArgs e)
        {
            cancelMedicationList.PrimaryColor = Color.FromArgb(99, 124, 234);
        }

        private void cancelMedicationList_MouseLeave(object sender, EventArgs e)
        {
            cancelMedicationList.PrimaryColor = Color.FromArgb(184, 197, 255);
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!getAccess(1)) return;
            using (ParametrInput F = new ParametrInput())
            {
                F.parametrLabel.Text = "Отображать все поля?";
                F.aloneComboBox1.Items.Add("Да");
                F.aloneComboBox1.Items.Add("Нет");
                F.aloneComboBox1.SelectedIndex = 0;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    string selectedDeptText = F.aloneComboBox1.SelectedItem.ToString();

                    if (selectedDeptText == "Да")
                    {
                        p.query = "SELECT * FROM Patient_new";
                        di.query = "SELECT * FROM Diagnosis";
                        q.query = "SELECT * FROM Questionnaire";

                        p.LoadData();
                        di.LoadData();
                        q.LoadData();
                    }
                    else
                    {
                        p.query = $"SELECT DISTINCT Patient_new.* FROM Patient_new JOIN Questionnaire ON Patient_new.PatientID = Questionnaire.PatientID " +
                $"WHERE Questionnaire.DoctorID_A = {DoctorIdentifier} OR Questionnaire.DoctorID_D = {DoctorIdentifier};";
                        di.query = $"SELECT Diagnosis.* FROM Patient_new JOIN Questionnaire ON " +
                  $"Patient_new.PatientID = Questionnaire.PatientID " +
                  $"JOIN Diagnosis ON Questionnaire.DiagnosisID = Diagnosis.DiagnosisID " +
                  $"WHERE Questionnaire.DoctorID_A = {DoctorIdentifier}   OR Questionnaire.DoctorID_D = {DoctorIdentifier};";
                        q.query = $"SELECT * FROM dbo.Questionnaire WHERE Questionnaire.DoctorID_A = {DoctorIdentifier} OR Questionnaire.DoctorID_D = {DoctorIdentifier};"; ;

                        p.LoadData();
                        di.LoadData();
                        q.LoadData();
                    }
                }
            }
        }
    }
}
