using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOProject
{
    public partial class LoginForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public LoginForm()
        {

            InitializeComponent();
        
        }


        //Global Variables
        SqlConnection con;
        btnHam system;
        RegistrationForm regform;
        

        // Login Method
        public void login()
        {
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string search = "SELECT * FROM LoginTable WHERE USERNAME = '" + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "'";
            con = new SqlConnection(constring);
            int num = 0;

            DataTable result = new DataTable();
            // Try-Catch of Sql Search:
            try
            {
                using (SqlCommand srch = new SqlCommand(search, con))
                {
                    con.Open();
                    SqlDataAdapter look = new SqlDataAdapter(search, con);
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(look);
                    look.Fill(result);
                    srch.ExecuteNonQuery();
                    con.Close();
                    if (result.Rows.Count > 0)
                    {
                        this.Hide();
                        system = new btnHam();
                        system.Show();
                    }
                    else if (textBox1.Text == "" && textBox2.Text == "")
                    {
                        MessageBox.Show("Please Enter your Username and Password");
                    }
                    else if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please Enter your Username");
                    }
                    else if (textBox2.Text == "")
                    {
                        MessageBox.Show("Please Enter your Password");
                    }
                    else
                    {
                        MessageBox.Show("LOGIN FAILED");
                    }
                }
            }
            catch (Exception inserr)
            {
                MessageBox.Show("LOGIN CONNECTION ERROR!");
            }
        }
     

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login();
            
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                regform = new RegistrationForm();
                regform.Show();
            }
            catch (Exception idk)
            {
                MessageBox.Show("Registration Form Load Error");
            }
        }
    }
}
