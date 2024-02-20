using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace COMPANY_DB
{
    public partial class UsersTable : Form
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

        public UsersTable()
        {
            m_aeroEnabled = false;
            InitializeComponent();
            usersDataGridView.EnableHeadersVisualStyles = false;

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
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        private SqlConnection connection = new SqlConnection(Properties.Settings.Default.PolyclinicConnectionString1);
        private SqlDataAdapter adapter = null;
        static DataTable dataSet = new DataTable();
        private void LoadData()
        {
            string query = $"EXEC GetDecryptedUserPasswords;";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.KAZAKKULOV_EXP_CON))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet);
                }
            }

            bindingSource1.DataSource = dataSet;
            usersDataGridView.DataSource = bindingSource1;
            // Обновление данных в DataGridView
            usersDataGridView.Refresh();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
/*            usersBindingSource.EndEdit();
            adapter.Update(polyclinicDataSet.Users);*/
        }


        //public static string connectionString = @"Data Source=DESKTOP-MK9RMFI\KAZAKKULOV_URAL;Initial Catalog=Polyclinic;Integrated Security=True";

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Drag = true;
                MouseX = e.X;
                MouseY = e.Y;
            }
        }
        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.WindowState = FormWindowState.Normal;
                int newX = this.Left + e.X - MouseX;
                int newY = this.Top + e.Y - MouseY;
                this.Location = new Point(newX, newY);
            }
        }
        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Drag = false;
            }
        }

        private void usersDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            usersDataGridView.Columns[0].Width = 35;
            usersDataGridView.Columns[1].Width = 120;
            usersDataGridView.Columns[2].Width = 120;
            usersDataGridView.Columns[3].Width = 95;
        }

        private bool newUser = false;
        private void newButton_Click(object sender, EventArgs e)
        {
/*            if (newUser)
            {
                PolyclinicDataSet.UsersRow usersRow = polyclinicDataSet.Users.NewUsersRow();

                usersRow.login = loginTextBox.Text;
                usersRow.password = passwordTextBox.Text;
                usersRow.Access_Level = byte.Parse(textBox1.Text);
                usersBindingSource.EndEdit();
                newUser = false;
                usersDataGridView.ReadOnly = false;

                return;
            }

            loginTextBox.Text = "Введите логин ...";
            passwordTextBox.Text = "Пароль";
            usersDataGridView.ReadOnly = true;
            newUser = true;*/
        }
        public double temp { get; set; }
        private void deleteButton_Click(object sender, EventArgs e)
        {
/*            if (MessageBox.Show("Пользователь будет удален безвозвратно! Вы уверены?",
                                "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                usersBindingSource.RemoveCurrent();
            }*/
        }

        private void usersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                AccessLevelNumeric.ValueNumber = 0;
            else if (textBox1.Text == "1")
                AccessLevelNumeric.ValueNumber = 1;
            else if (textBox1.Text == "2")
                AccessLevelNumeric.ValueNumber = 2;

        }

        private void AccessLevelNumeric_MouseClick(object sender, MouseEventArgs e)
        {
            if (AccessLevelNumeric.ValueNumber == 0)
                textBox1.Text = "0";
            else if (AccessLevelNumeric.ValueNumber == 1)
                textBox1.Text = "1";
            else if (AccessLevelNumeric.ValueNumber == 2)
                textBox1.Text = "2";
            //usersBindingSource.EndEdit();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            newButton_Click(null, new EventArgs());
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            deleteButton_Click(null, new EventArgs());
        }

        private void UsersTable_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void parrotButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
