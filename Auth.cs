using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace COMPANY_DB
{
    public partial class Auth : Form
    {
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
        public Auth()
        {
            m_aeroEnabled = false;
            InitializeComponent();
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
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }

        void toggleElements()
        {
            hopeRoundButton1.Enabled = hopeRoundButton1.Enabled ? false : true;
            user.Enabled = user.Enabled ? false : true;
            password.Enabled = password.Enabled ? false : true;
        }

        bool userActive = false;
        bool passwordActive = false;
        private void user_Click(object sender, EventArgs e)
        {
            if (!userActive)
            {
                userActive = true;
                user.ForeColor = Color.Gray;
                user.Text = "";
            }
        }

        private void Auth_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private const string EnvironmentVariableName = "ACTIVE_USER_COUNT";
        public static int GetActiveUserCount()
        {
            string countString = Environment.GetEnvironmentVariable(EnvironmentVariableName);
            if (int.TryParse(countString, out int count))
            {
                return count;
            }

            return 0;
        }

        public static void IncrementUserCount()
        {
            int count = GetActiveUserCount();
            count++;
            UpdateUserCount(count);
        }

        public static void DecrementUserCount()
        {
            int count = GetActiveUserCount();
            if (count > 0)
            {
                count--;
                UpdateUserCount(count);
            }
        }

        private static void UpdateUserCount(int count)
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableName, count.ToString());
        }
        private async void hopeRoundButton1_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;
                toggleElements();

                string checkcmd = "EXEC LoginIn @user, @password;";

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.KAZAKKULOV_EXP_CON))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("LoginIn", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Login", user.Text);
                        command.Parameters.AddWithValue("@Password", password.Text);

                        // Выполняем процедуру
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Проверяем, что значения не являются null
                                int? accessLevel = reader["Access_Level"] as int?;
                                int? doctorId = reader["DoctorID"] as int?;

                                if (accessLevel.HasValue)
                                {
                                    ShowSuccessNotification("Успешный вход!");                                   
                                    await Task.Delay(2000);
                                    MainPolyclinicForm f1;
                                    if (doctorId.HasValue)
                                        f1 = new MainPolyclinicForm(accessLevel.Value, doctorId.Value);
                                    else
                                        f1 = new MainPolyclinicForm(accessLevel.Value, -1);
                                    f1.Show();
                                    Hide();
                                }
                                else
                                {
                                    ShowErrorNotification("Неверные данные!");
                                }
                            }
                            else
                            {
                                ShowErrorNotification("Неверные данные!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка интернет соединения. Или возможно база данных повреждена. Или другая ошибка:" +
                    $"\n\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                IncrementUserCount();
                toggleElements();
                UseWaitCursor = false;
            }
        }


        private void ShowErrorNotification(string message)
        {
            hopeNotify1.Visible = true;
            hopeNotify1.Type = ReaLTaiizor.Controls.HopeNotify.AlertType.Error;
            hopeNotify1.Text = message;
        }

        private void ShowSuccessNotification(string message)
        {
            hopeNotify1.Visible = true;
            hopeNotify1.Type = ReaLTaiizor.Controls.HopeNotify.AlertType.Success;
            hopeNotify1.Text = message;
        }


        private void user_Enter(object sender, EventArgs e)
        {
            if (password.Text == "" || password.Text == " ")
            {
                password.Text = "1234";
                passwordActive = false;
            }
            if (!userActive)
            {
                userActive = true;
                user.ForeColor = Color.Gray;
                user.Text = "";
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (user.Text == "" || user.Text == " ")
            {
                user.Text = "Логин";
                userActive = false;
            }
            if (!passwordActive)
            {
                passwordActive = true;
                password.Text = "";

            }
        }
    }
}