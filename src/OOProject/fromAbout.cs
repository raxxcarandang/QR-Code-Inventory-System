using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOProject
{
    public partial class fromAbout : Form
    {
        public fromAbout()
        {
            InitializeComponent();
            poisonDataGridView1.ForeColor = Color.Black;
            this.poisonDataGridView1.Rows.Insert(0, "ABRIGO, LEIRA");
            this.poisonDataGridView1.Rows.Insert(1, "CARANDANG, RAXX MORENZ");
            this.poisonDataGridView1.Rows.Insert(2, "DATOR, JONNEL");

        }

        //Global Variables 
        Bitmap leira = Properties.Resources.leira;
        Bitmap raxx = Properties.Resources.raxx;
        Bitmap jonnel = Properties.Resources.joninosins;

        private void fromAbout_Load(object sender, EventArgs e)
        {
            hopePictureBox1.Image = leira;
            bigLabel1.Text = "DOCUMENT HUSTLER";
            this.ControlBox = false;

        }

        private void poisonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (poisonDataGridView1.Rows[0].Selected == true)
            {
                hopePictureBox1.Image = leira;
                bigLabel1.Text = "DOCUMENT HUSTLER";
            } else if (poisonDataGridView1.Rows[1].Selected == true)
            {
                hopePictureBox1.Image = raxx;
                bigLabel1.Text = "BACKEND HACKER";
            }
            else if (poisonDataGridView1.Rows[2].Selected == true)
            {
                hopePictureBox1.Image = jonnel;
                bigLabel1.Text = "FRONTEND HIPSTER";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
