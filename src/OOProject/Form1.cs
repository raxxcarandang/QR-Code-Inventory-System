using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OOProject
{
    public partial class btnHam : Form
    {
        formDashboard dashboard;
        fromSub1 sub1;
        formSubmenu2 sub2;
        fromAbout about;
        formSettings settings;
        LoginForm login;
       
        //Movable Window From Panel Click
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public btnHam()
        {
            InitializeComponent();
            if (dashboard == null)
            {
                dashboard = new formDashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.searchcategory();
                dashboard.Show();
            }
            else
            {
                dashboard.searchcategory();
                dashboard.Activate();

            }

        }
        bool menuExpand = false;
        private void mdiProp() {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }


        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 171)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 53)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            
            if(sidebarExpand)
            {
                sidebar.Width -= 10;
                
                if (sidebar.Width <= 52)
                {
                    sidebarExpand = false;  
                    sidebarTransition.Stop();
                    
                }
            } else
            {
                sidebar.Width += 10;
                
                if (sidebar.Width >= 187)
                {
                   
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                    

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dashboard == null)
            {
                dashboard = new formDashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.searchcategory();
                dashboard.Show();
            }else
            {
                dashboard.searchcategory();
                dashboard.Activate();
                
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }

        private void submenu1_Click(object sender, EventArgs e)
        {
            if(sub1 == null)
            {
                sub1 = new fromSub1();
                sub1.FormClosed += Sub1_FormClosed;
                sub1.MdiParent = this;
                sub1.Dock = DockStyle.Fill;
                sub1.tablerefresh();
                sub1.Show();
             
            }
            else
            {
                sub1.tablerefresh();
                sub1.Activate();
               
            }
        }
        private void Sub1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sub1 = null;
        }

        private void submenu2_Click(object sender, EventArgs e)
        {
            if (sub2 == null)
            {
                sub2 = new formSubmenu2();
                sub2.FormClosed += Sub2_FormClosed;
                sub2.MdiParent = this;
                sub2.Dock = DockStyle.Fill;
                sub2.tablerefresh();
                sub2.Show();
                
            }
            else
            {
                sub2.tablerefresh();
                sub2.Activate();
                
            }
        }
        private void Sub2_FormClosed(object sender, FormClosedEventArgs e)
        {
            sub1 = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (about == null)
            {
                about = new fromAbout();
                about.FormClosed += about_FormClosed;
                about.MdiParent = this;
                about.Dock = DockStyle.Fill;
                about.Show();
            }
            else
            {
                about.Activate();
            }
        }
        private void about_FormClosed(object sender, FormClosedEventArgs e)
        {
            about = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (settings == null)
            {
                settings = new formSettings();
                settings.FormClosed += settings_FormClosed;
                settings.MdiParent = this;
                settings.Dock = DockStyle.Fill;
                settings.Show();
            }
            else
            {
                settings.Activate();
            }
        }
        private void settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            settings = null;
        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            login = new LoginForm();
            login.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHam_Load(object sender, EventArgs e)
        {

        }
    }
}

