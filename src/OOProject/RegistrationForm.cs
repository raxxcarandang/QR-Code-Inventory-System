using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace OOProject
{
    public partial class RegistrationForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        //Registration Method
        public void register()
        {
            MailAddress to = new MailAddress("raxx109@gmail.com");
            MailAddress from = new MailAddress("raxxrcarandang@gmail.com");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "REGISTRATION FOR ADMIN ACCESS TO PROPERTY INVENTORY SYSTEM";
            email.Body = "GOOD DAY, PLEASE CONSIDER MY REGISTRATION FOR ADMIN ACCESS TO THE PROPERTY INVENTORY SYSTEM\n DETAILS BELOW: \n"
                + "First Name " + textBox1.Text + "\n"
                + "Last Name " + textBox2.Text + "\n"
                + "E-Mail " + textBox3.Text + "\n"
                + "Username " + textBox4.Text + "\n"
                + "Password " + textBox5.Text + "\n"
                + "THANK YOU FOR YOUR TIME AND CONSIDERATION";

            SmtpClient smtpClient = new SmtpClient("raxxrcarandang@gmail.com", 8080);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("raxxrcarandang@gmail.com", "systempassword123");


            try
            {
                /* Send method called below is what will send off our email 
                 * unless an exception is thrown.
                 */
                smtpClient.Send(email);
                MessageBox.Show("Registration Request Sent to Administrator \n Your Request Shall be Considered within 0 - 7 Days \n Thank You and Have a Nice Day");
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("REGISTRATION REQUEST FAILED TRY AGAIN LATER");
            }
        }
        //End Registration Method

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            register();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RegistrationForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
