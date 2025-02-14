using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Timers;
using System.Diagnostics;
using System.Drawing.Imaging;
using QRCoder;
using System.Threading;
using ReaLTaiizor.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Media;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace OOProject
{
    public partial class formSubmenu2 : Form
    {

        //Camera Variables
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice CaptureDevice;

        public formSubmenu2()
        {
            InitializeComponent();

            // DEFAULT ITEM FOR SEARCH COMBOBOX
            comboBox1.SelectedIndex = 0;

            //Default Table ForeColor
            poisonDataGridView1.ForeColor = Color.Black;
            poisonDataGridView2.ForeColor = Color.Black;

            //WebCam Identify inside FormLoad()
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboBox3.Items.Add(filterInfo);
            comboBox3.SelectedIndex = 0;
        }

        public static int rowcount = 0;
        public static int generateId()
        {
            return Interlocked.Increment(ref rowcount);
        }

        private void formSubmenu2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASEDataSet15.PropertyTable' table. You can move, or remove it, as needed.
            this.propertyTableTableAdapter3.Fill(this._UTILITY_INVENTORY_DATABASEDataSet15.PropertyTable);
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable' table. You can move, or remove it, as needed.
            this.borrowerTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable);
            poisonDataGridView1.Refresh();
            poisonDataGridView2.Refresh();
            this.ControlBox = false;

            //Default Item in comboBoxes:
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            poisonDateTime1.Value = DateTime.Today;
            poisonDateTime2.Value = DateTime.Today;

            //ID Count from DataGridView:

            string brwid = "";
            int rowcount = poisonDataGridView2.RowCount + 1;
            if (rowcount == poisonDataGridView2.RowCount)
            {
                rowcount++;
            }
            if (rowcount < 10)
            {
                brwid = "BRW-000000" + rowcount;
            }
            else if (rowcount >= 10 && rowcount < 100)
            {

                brwid = "BRW-00000" + rowcount;


            }
            else if (rowcount >= 100 && rowcount < 1000)
            {

                brwid = "BRW-0000" + rowcount;


            }
            else if (rowcount >= 1000 && rowcount < 10000)
            {

                brwid = "BRW-000" + rowcount;


            }
            else if (rowcount >= 10000 && rowcount < 100000)
            {

                brwid = "BRW-00" + rowcount;


            }

            else if (rowcount >= 100000 && rowcount < 1000000)
            {

                brwid = "BRW-0" + rowcount;


            }
            else if (rowcount >= 1000000)
            {

                brwid = "BRW-" + rowcount;
            }

            poisonTextBox3.Text = brwid;

        }

        //Global Variables:
        SqlConnection con;
        int parrotButton1click = 0;
        int reset7 = 0;
        int night = 0;
        DateTime empty = Convert.ToDateTime("07/07/7777");

        //Main Borrower & Property Objects Initialization
        Borrower borrower = new Borrower();
        Property utility = new Property();

        Bitmap sun = Properties.Resources.sun;
        Bitmap moon = Properties.Resources.moon;
        Bitmap lightning = Properties.Resources.lightning;
        Bitmap water = Properties.Resources.waterdrop;
        Bitmap fart = Properties.Resources.gas;
        Bitmap other = Properties.Resources.other;
        Bitmap all = Properties.Resources.all;

        //Camera Start Method
        public void scancamera()
        {
          
            hopePictureBox1.Image = null;
            poisonTextBox1.Text = "";
            poisonTextBox3.Text = "";
            poisonTextBox4.Text = "";
            poisonTextBox5.Text = "";
            poisonTextBox6.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            CaptureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox3.SelectedIndex].MonikerString);
            CaptureDevice.NewFrame += CaptureDevice_NewFrame;
            CaptureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            hopePictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        //Table Refresh Method
        public void tablerefresh()
        {
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASEDataSet5.PropertyTable' table. You can move, or remove it, as needed.
            this.propertyTableTableAdapter3.Fill(this._UTILITY_INVENTORY_DATABASEDataSet15.PropertyTable);
            poisonDataGridView1.Refresh();
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASEBorrowDataSet.BorrowerTable' table. You can move, or remove it, as needed.
            this.borrowerTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable);
            poisonDataGridView2.Refresh();
        }
        // Sql Search Method:
        public void searchprop()
        {
            string query = poisonTextBox1.Text;
            string condition = comboBox1.Text;
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string search = "SELECT * FROM PropertyTable WHERE [" + condition + "] LIKE " + "'%" + query + "%'";
            con = new SqlConnection(constring);
            int num = 0;

            DataSet result = new DataSet();
            // Try-Catch of Sql Search:
            try
            {
                using (SqlCommand srch = new SqlCommand(search, con))
                {
                    con.Open();
                    SqlDataAdapter look = new SqlDataAdapter(search, con);
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(look);
                    look.Fill(result);
                    poisonDataGridView1.DataSource = result.Tables[0];
                    poisonDataGridView1.Refresh();
                    srch.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception srcherr)
            {
                MessageBox.Show("SEARCH CONNECTION ERROR!");
            }

        }

        public void searchbrow()
        {
            string query = poisonTextBox1.Text;
            string condition = comboBox1.Text;
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string search = "SELECT * FROM BorrowerTable WHERE [" + condition + "] LIKE " + "'%" + query + "%'";
            con = new SqlConnection(constring);
            int num = 0;

            DataSet result = new DataSet();
            // Try-Catch of Sql Search:
            try
            {
                using (SqlCommand srch = new SqlCommand(search, con))
                {
                    con.Open();
                    SqlDataAdapter look = new SqlDataAdapter(search, con);
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(look);
                    look.Fill(result);
                    poisonDataGridView2.DataSource = result.Tables[0];
                    poisonDataGridView2.Refresh();
                    srch.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception srcherr)
            {
                MessageBox.Show("SEARCH BORROWER TABLE CONNECTION ERROR!");
            }

        }

        // Sql Insertion Method:

        public void insert()
        {

            //Initialization of Connections and Sql Strings:
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string create = "INSERT INTO BorrowerTable VALUES (@propid, @brwid, @name, @position, @purpose, @offense, @brwdate, @retdate)";

            string count = "Select * From BorrowerTable";
            int rowcount = poisonDataGridView2.RowCount + 1;
            if (rowcount == poisonDataGridView2.RowCount)
            {
                rowcount++;
            }
            con = new SqlConnection(constring);
            int num = 0;

            //ID Count from DataGridView:
            string brwid = "";

            if (rowcount < 10)
            {
                brwid = "BRW-000000" + rowcount;
            }
            else if (rowcount >= 10 && rowcount < 100)
            {

                brwid = "BRW-00000" + rowcount;


            }
            else if (rowcount >= 100 && rowcount < 1000)
            {

                brwid = "BRW-0000" + rowcount;


            }
            else if (rowcount >= 1000 && rowcount < 10000)
            {

                brwid = "BRW-000" + rowcount;


            }
            else if (rowcount >= 10000 && rowcount < 100000)
            {

                brwid = "BRW-00" + rowcount;


            }

            else if (rowcount >= 100000 && rowcount < 1000000)
            {

                brwid = "BRW-0" + rowcount;


            }
            else if (rowcount >= 1000000)
            {

                brwid = "BRW-" + rowcount;
            }


            //Initialization of Object in Insert Context:
            borrower.pID = poisonTextBox2.Text;
            borrower.bID = poisonTextBox3.Text;
            borrower.name = poisonTextBox4.Text;
            borrower.position = poisonTextBox5.Text;
            borrower.purpose = poisonTextBox6.Text;
            borrower.offense = comboBox2.Text;
            borrower.brwdate = empty;
            borrower.retdate = empty;
            if (checkBox1.Checked)
            {
                borrower.brwdate = Convert.ToDateTime(poisonDateTime1.Value);
            }
            else
            {
                borrower.brwdate = empty;
            }
            if (checkBox2.Checked)
            {
                borrower.retdate = Convert.ToDateTime(poisonDateTime2.Value);
            }
            else
            {
                borrower.retdate = empty;
            }

            // Try-Catch of Sql Insertion:
            try
            {
                using (SqlCommand ins = new SqlCommand(create, con))
                {
                    con.Open();
                    ins.Parameters.Add("@propid", SqlDbType.VarChar).Value = borrower.pID;
                    ins.Parameters.Add("@brwid", SqlDbType.VarChar).Value = borrower.bID;
                    ins.Parameters.Add("@name", SqlDbType.VarChar).Value = borrower.name;
                    ins.Parameters.Add("@position", SqlDbType.VarChar).Value = borrower.position;
                    ins.Parameters.Add("@purpose", SqlDbType.VarChar).Value = borrower.purpose;
                    ins.Parameters.Add("@offense", SqlDbType.VarChar).Value = borrower.offense;
                    ins.Parameters.Add("@brwdate", SqlDbType.DateTime).Value = borrower.brwdate;
                    ins.Parameters.Add("@retdate", SqlDbType.DateTime).Value = borrower.retdate;
                    ins.ExecuteNonQuery();
                    this.borrowerTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable);
                    poisonDataGridView2.Refresh();
                    con.Close();
                }
            }
            catch (Exception conerr)
            {

                MessageBox.Show("INSERT CONNECTION ERROR!");
            }
            clearbox();
        }


        // Sql Updation Method:
        public void update()
        {
            try
            {
                borrower.bID = poisonDataGridView2.SelectedRows[0].Cells[1].Value + string.Empty; ;
            }
            catch (Exception iderr)
            {
                MessageBox.Show("ID out of range");
            }

                //Initialization of Connections and Sql Strings:
                string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                string update = "UPDATE [BorrowerTable] SET [PROPERTY ID] = @propid, [NAME] = @name, [POSITION] = @position, [PURPOSE] = @purpose, [OFFENSE] = @offense, [BORROW DATE] = @brwdate, [RETURN DATE] = @retdate WHERE [BORROW ID] = @brwid";

                con = new SqlConnection(constring);

                //Initialization of Object in Update Context:

                borrower.pID = poisonTextBox2.Text;
                borrower.bID = poisonTextBox3.Text;
                borrower.name = poisonTextBox4.Text;
                borrower.position = poisonTextBox5.Text;
                borrower.purpose = poisonTextBox6.Text;
                borrower.offense = comboBox2.Text;
                borrower.brwdate = poisonDateTime1.Value;
                borrower.retdate = poisonDateTime2.Value;


                // Try-Catch of Sql Update:
                try
                {
                    using (SqlCommand upd = new SqlCommand(update, con))
                    {
                        con.Open();
                        upd.Parameters.Add("@propid", SqlDbType.VarChar).Value = borrower.pID;
                        upd.Parameters.Add("@name", SqlDbType.VarChar).Value = borrower.name;
                        upd.Parameters.Add("@position", SqlDbType.VarChar).Value = borrower.position;
                        upd.Parameters.Add("@purpose", SqlDbType.VarChar).Value = borrower.purpose;
                        upd.Parameters.Add("@offense", SqlDbType.VarChar).Value = borrower.offense;
                        upd.Parameters.Add("@brwdate", SqlDbType.DateTime).Value = borrower.brwdate;
                        upd.Parameters.Add("@retdate", SqlDbType.DateTime).Value = borrower.retdate;
                        upd.Parameters.Add("@brwid", SqlDbType.VarChar).Value = borrower.bID;
                        upd.ExecuteNonQuery();
                        this.borrowerTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable);
                        poisonDataGridView2.Refresh();
                        con.Close();
                    }
                }
                catch (Exception conerr)
                {
                    MessageBox.Show("UPDATE CONNECTION ERROR!");
                }
          
        }

        public void updatecon()
        {
            // Utility Object Initialization in Select Method:
            try
            {
                borrower.pID = poisonDataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                borrower.bID = poisonDataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                borrower.name = poisonDataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                borrower.position = poisonDataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                borrower.purpose = poisonDataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                borrower.offense = poisonDataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                borrower.brwdate = Convert.ToDateTime(poisonDataGridView1.SelectedRows[0].Cells[6].Value + string.Empty);
                borrower.retdate = Convert.ToDateTime(poisonDataGridView1.SelectedRows[0].Cells[7].Value + string.Empty);
            }
            catch (Exception uperr)
            {
                MessageBox.Show("Input Out of Range");
            }

            // Laying all the values into the poisonTextBoxes
            poisonTextBox2.Text = borrower.pID;
            poisonTextBox3.Text = borrower.bID;
            poisonTextBox4.Text = borrower.name;
            poisonTextBox5.Text = borrower.position;
            poisonTextBox6.Text = borrower.purpose;
            comboBox2.Text = borrower.offense;
            poisonDateTime1.Value = borrower.brwdate;
            poisonDateTime2.Value = borrower.retdate;


            // Laying all the values into the comboBox2
            if (borrower.offense.Equals("N/A"))
            {
                comboBox2.SelectedIndex = 0;
            }
            else if (borrower.offense.Equals("1ST OFFENSE"))
            {
                comboBox2.SelectedIndex = 1;
            }
            else if (borrower.offense.Equals("2ND OFFENSE"))
            {
                comboBox2.SelectedIndex = 2;
            }
            else if (borrower.offense.Equals("3RD OFFENSE"))
            {
                comboBox2.SelectedIndex = 3;
            }
            else if (borrower.offense.Equals("COMPENSATION"))
            {
                comboBox2.SelectedIndex = 4;
            }
            else if (borrower.offense.Equals("DISCIPLINARY ACTION"))
            {
                comboBox2.SelectedIndex = 5;
            }
            else if (borrower.offense.Equals("EXPULSION"))
            {
                comboBox2.SelectedIndex = 6;
            }
        }

        // Sql Deletion Method:
        public void delete()
        {
            try
            {
                borrower.bID = poisonDataGridView2.SelectedRows[0].Cells[1].Value + string.Empty;
            }
            catch (Exception iderr)
            {
                MessageBox.Show("ID out of Range");
            }

            DialogResult confirmdel = MessageBox.Show("DELETE BORROWER " + borrower.bID + "?", "DELETE BORROWER", MessageBoxButtons.YesNo);
            if (confirmdel == DialogResult.Yes)
            {
                //Initialization of Connections and Sql Strings:
                string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                string delete = "DELETE FROM [BorrowerTable] WHERE [BORROW ID] = @brwid ";
                con = new SqlConnection(constring);


                // Try-Catch of Sql Deletion:
                try
                {
                    using (SqlCommand del = new SqlCommand(delete, con))
                    {
                        con.Open();
                        del.Parameters.Add("@brwid", SqlDbType.VarChar).Value = borrower.bID;
                        del.ExecuteNonQuery();
                        this.borrowerTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable);
                        poisonDataGridView2.Refresh();
                        con.Close();
                    }
                }
                catch (Exception conerr)
                {
                    MessageBox.Show("DELETE CONNECTION ERROR!");
                }
                clearbox();
            }
            else if (confirmdel == DialogResult.No) { };
        }

        //Reset Method:
  
        //Reset Method:
        public void clearbox()
        {
          
            {
                //ID Count from DataGridView to reset for latest ID:

                string brwid = "";
                int rowcount = poisonDataGridView2.RowCount + 1;
                if (rowcount == poisonDataGridView2.RowCount)
                {
                    rowcount++;
                }
                if (rowcount < 10)
                {
                    brwid = "BRW-000000" + rowcount;
                }
                else if (rowcount >= 10 && rowcount < 100)
                {

                    brwid = "BRW-00000" + rowcount;


                }
                else if (rowcount >= 100 && rowcount < 1000)
                {

                    brwid = "BRW-0000" + rowcount;


                }
                else if (rowcount >= 1000 && rowcount < 10000)
                {

                    brwid = "BRW-000" + rowcount;


                }
                else if (rowcount >= 10000 && rowcount < 100000)
                {

                    brwid = "BRW-00" + rowcount;


                }

                else if (rowcount >= 100000 && rowcount < 1000000)
                {

                    brwid = "BRW-0" + rowcount;


                }
                else if (rowcount >= 1000000)
                {

                    brwid = "BRW-" + rowcount;
                }

                poisonTextBox3.Text = brwid;

                // Clear all poisonTextBoxes and Etc.:
                poisonTextBox1.Text = "";
                poisonTextBox2.Text = "";
                poisonTextBox3.Text = brwid;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                poisonTextBox4.Text = "";
                poisonTextBox5.Text = "";
                poisonTextBox6.Text = "";
                hopePictureBox1.Image = null;
                parrotButton1.ButtonText = "ALL";
                parrotButton1.ButtonImage = all;
                this.propertyTableTableAdapter3.Fill(this._UTILITY_INVENTORY_DATABASEDataSet15.PropertyTable);
                poisonDataGridView1.DataSource = this._UTILITY_INVENTORY_DATABASEDataSet15.PropertyTable;
                poisonDataGridView1.Refresh();
                this.borrowerTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable);
                poisonDataGridView2.DataSource = this._UTILITY_INVENTORY_DATABASEDataSet14.BorrowerTable;
                poisonDataGridView2.Refresh();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                poisonRadioButton1.Checked = false;
                poisonRadioButton2.Checked = false;
                poisonRadioButton3.Checked = false;
            }
          

        }
        //End of Reset Method 

        //parrotButton1 categorize method:
        public void categorize()
        {

            if (parrotButton1click == 0)
            {
                parrotButton1click += 1;
                parrotButton1.ButtonText = "ELECTRIC";
                parrotButton1.ButtonImage = lightning;
            }
            else if (parrotButton1click == 1)
            {
                parrotButton1click += 1;
                parrotButton1.ButtonText = "WATER";
                parrotButton1.ButtonImage = water;
            }
            else if (parrotButton1click == 2)
            {
                parrotButton1click += 1;
                parrotButton1.ButtonText = "GAS";
                parrotButton1.ButtonImage = fart;
            }
            else if (parrotButton1click == 3)
            {
                parrotButton1click += 1;
                parrotButton1.ButtonText = "OTHER";
                parrotButton1.ButtonImage = other;
            }
            else
            {
                reset7 = 1;
                parrotButton1click = 0;
                parrotButton1.ButtonText = "ALL";
                parrotButton1.ButtonImage = all;
            }
            if (reset7 == 1)
            {
                poisonDataGridView1.DataSource = _UTILITY_INVENTORY_DATABASEDataSet15.PropertyTable;
                poisonDataGridView1.Refresh();
                reset7 = 0;
            }
            else
            {
                string query = parrotButton1.ButtonText;
                string condition = "Type";
                string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                string search = "SELECT * FROM [PropertyTable] WHERE " + condition + " LIKE " + "'%" + query + "%'";
                con = new SqlConnection(constring);
                int num = 0;

                DataSet result = new DataSet();
                // Try-Catch of Sql Search:
                try
                {
                    using (SqlCommand srch = new SqlCommand(search, con))
                    {
                        con.Open();
                        SqlDataAdapter look = new SqlDataAdapter(search, con);
                        SqlCommandBuilder cmdb = new SqlCommandBuilder(look);
                        look.Fill(result);
                        poisonDataGridView1.DataSource = result.Tables[0];
                        poisonDataGridView1.Refresh();
                        srch.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception inserr)
                {
                    MessageBox.Show("SEARCH RESET CONNECTION ERROR!");
                }
            }
        }

        //QRCode Save Method:
        public void saveimg()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                saveFileDialog.FileName = borrower.name;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    hopePictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void utilityTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender)
        {
            //TOGGLE CONDITION FOR BORROW DATETIMEPICKER
            if (checkBox1.Checked)
            {
                poisonDateTime1.Enabled = true;
                poisonDateTime1.Value = DateTime.Today;
            }
            else
            {
                poisonDateTime1.Value = Convert.ToDateTime(empty);
                poisonDateTime1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender)
        {
            //TOGGLE CONIDTION FOR RETURN DATETIMEPICKER
            if (checkBox2.Checked)
            {
                poisonDateTime2.Value = DateTime.Today;
                poisonDateTime2.Enabled = true;
            }
            else
            {
                poisonDateTime2.Value = Convert.ToDateTime(empty);
                poisonDateTime2.Enabled = false;
            }
        }

        private void poisonButton2_Click(object sender, EventArgs e)
        {
            string query = poisonTextBox2.Text;
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string search = "SELECT * FROM PropertyTable WHERE [PROPERTY ID] = " + "'" + query + "'";
            con = new SqlConnection(constring);

            DataSet result = new DataSet();
            // Try-Catch of Sql Search:
            try
            {
                using (SqlCommand srch = new SqlCommand(search, con))
                {
                    con.Open();
                    SqlDataAdapter look = new SqlDataAdapter(search, con);
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(look);
                    look.Fill(result);
                    /* if (result.Tables[0].Rows.Count == 0) {

                             MessageBox.Show("Property does not exist.");


                     } else{
                         insert();
                     }
                    */
                    insert();
                    srch.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception srcherr)
            {
                MessageBox.Show("SEARCH CONNECTION ERROR!");
            }


        }

        private void poisonButton3_Click(object sender, EventArgs e)
        {
        DialogResult confirmupd = MessageBox.Show("UPDATE BORROWER " + borrower.bID + "?", "UPDATE PROPERTY", MessageBoxButtons.YesNo);
        if (confirmupd == DialogResult.Yes)
        {
            update();
            }
            else if (confirmupd == DialogResult.No) { }
        }

        private void poisonButton4_Click(object sender, EventArgs e)
        {
            DialogResult confirmreset = MessageBox.Show("RESET ALL BORROWER FORMS?", "RESET WINDOW FORM", MessageBoxButtons.YesNo);
            if (confirmreset == DialogResult.Yes)
                clearbox();
            else if (confirmreset == DialogResult.No) { };
        }

        private void poisonButton5_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void poisonButton1_Click(object sender, EventArgs e)
        {
            searchprop();
            searchbrow();
        }

        private void parrotButton1_Click(object sender, EventArgs e)
        {
            categorize();
        }

        private void poisonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.poisonDataGridView1.Rows[e.RowIndex];
                // Utility Object Initialization in Select Method:
                utility.ID = poisonDataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;

                // Laying all the values into the poisonTextBoxes
                poisonTextBox2.Text = utility.ID;

            }
        }

        private void poisonDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.poisonDataGridView1.Rows[e.RowIndex];
                }
                catch (Exception celerror)
                {

                }
                // Utility Object Initialization in Select Method:

                try
                {
                    borrower.pID = poisonDataGridView2.SelectedRows[0].Cells[0].Value + string.Empty;
                    borrower.bID = poisonDataGridView2.SelectedRows[0].Cells[1].Value + string.Empty;
                    borrower.name = poisonDataGridView2.SelectedRows[0].Cells[2].Value + string.Empty;
                    borrower.position = poisonDataGridView2.SelectedRows[0].Cells[3].Value + string.Empty;
                    borrower.purpose = poisonDataGridView2.SelectedRows[0].Cells[4].Value + string.Empty;
                    borrower.offense = poisonDataGridView2.SelectedRows[0].Cells[5].Value + string.Empty;
                    borrower.brwdate = Convert.ToDateTime(poisonDataGridView2.SelectedRows[0].Cells[6].Value + string.Empty);
                    borrower.retdate = Convert.ToDateTime(poisonDataGridView2.SelectedRows[0].Cells[7].Value + string.Empty);
                }
                catch (Exception uperr)
                {
                    MessageBox.Show("Input Out of Range");
                }

                // Laying all the values into the poisonTextBoxes
                poisonTextBox2.Text = borrower.pID;
                poisonTextBox3.Text = borrower.bID;
                poisonTextBox4.Text = borrower.name;
                poisonTextBox5.Text = borrower.position;
                poisonTextBox6.Text = borrower.purpose;
                comboBox2.Text = borrower.offense;
                if (borrower.brwdate == Convert.ToDateTime("07/07/7777"))
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Checked = true;
                }
                if (borrower.retdate == Convert.ToDateTime("07/07/7777"))
                {
                    checkBox2.Checked = false;
                }
                else
                {
                    checkBox2.Checked = true;
                }
                //DateTime Check
                if (checkBox1.Checked)
                {
                    poisonDateTime1.Value = borrower.brwdate;
                }
                else
                {
                    poisonDateTime1.Value = Convert.ToDateTime(empty);
                }
                if (checkBox2.Checked)
                {
                    poisonDateTime2.Value = borrower.retdate;
                }
                else
                {
                    poisonDateTime2.Value = Convert.ToDateTime(empty);
                }



                // Laying all the values into the comboBox2
                if (borrower.offense.Equals("N/A"))
                {
                    comboBox2.SelectedIndex = 0;
                }
                else if (borrower.offense.Equals("1ST OFFENSE"))
                {
                    comboBox2.SelectedIndex = 1;
                }
                else if (borrower.offense.Equals("2ND OFFENSE"))
                {
                    comboBox2.SelectedIndex = 2;
                }
                else if (borrower.offense.Equals("3RD OFFENSE"))
                {
                    comboBox2.SelectedIndex = 3;
                }
                else if (borrower.offense.Equals("COMPENSATION"))
                {
                    comboBox2.SelectedIndex = 4;
                }
                else if (borrower.offense.Equals("DISCIPLINARY ACTION"))
                {
                    comboBox2.SelectedIndex = 5;
                }
                else if (borrower.offense.Equals("EXPULSION"))
                {
                    comboBox2.SelectedIndex = 6;
                }

            }

            int rowIndex = -1;
            try
            {
                DataGridViewRow row2 = poisonDataGridView1.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(borrower.pID))
                    .First();

                rowIndex = row2.Index;

                poisonDataGridView1.Rows[rowIndex].Selected = true;
            }
            catch (Exception celerror)
            {

            }

            // Initialization of Qr Coder:
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("|PROPERTY ID|" + borrower.pID + "\n" + "|BORROWER ID|" + borrower.bID + "\n" + "|NAME|" + borrower.name + "\n" + "|POSITION|" + borrower.position + "\n" + "|PURPOSE|" + borrower.purpose + "\n" + "|OFFENSE|" + borrower.offense + "\n" + "|BORROW DATE|" + borrower.brwdate + "\n" + "|RETURN DATE|" + borrower.retdate + "\n" + "|SAVED ON|" + DateTime.Now + "\n" + "|Please Visit the Link Below for Updated Info:" + "\n" + "localhost:80/" + borrower.bID + "|", QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                hopePictureBox1.Image = qrCodeImage;
            }
        }

        private void hopePictureBox2_Click(object sender, EventArgs e)
        {
            // Night Theme:
            if (night == 0)
            {
                hopePictureBox2.Image = sun;
                night += 1;
                tableLayoutPanel1.BackColor = Color.Black;
                poisonButton1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonButton2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonButton3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonButton4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonButton5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonButton6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonButton7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonButton8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonRadioButton1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonRadioButton2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonRadioButton3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                comboBox1.BackColor = Color.Black;
                comboBox1.ForeColor = Color.White;
                comboBox2.BackColor = Color.Black;
                comboBox2.ForeColor = Color.White;
                checkBox1.BackColor = Color.Black;
                checkBox1.ForeColor = Color.White;
                checkBox2.BackColor = Color.Black;
                checkBox2.ForeColor = Color.White;
                poisonDataGridView1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDateTime1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDateTime2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                panel1.BackColor = Color.Black;
                panel2.BackColor = Color.Black;
                panel3.BackColor = Color.Black;
                poisonLabel1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                //poisonLabel8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                hopePictureBox1.BackColor = Color.Black;
                parrotButton1.BackgroundColor = Color.Black;
                parrotButton1.TextColor = Color.White;
                poisonDataGridView1.ForeColor = Color.White;
                poisonDataGridView2.ForeColor = Color.White;
            }
            else if (night == 1)
            {
                hopePictureBox2.Image = moon;
                night = 0;
                tableLayoutPanel1.BackColor = Color.White;
                poisonButton1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonButton2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonButton3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonButton4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonButton5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonButton6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonButton7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonButton8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonRadioButton1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonRadioButton2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonRadioButton3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                comboBox1.BackColor = Color.White;
                comboBox1.ForeColor = Color.Black;
                comboBox2.BackColor = Color.White;
                comboBox2.ForeColor = Color.Black;
                checkBox1.BackColor = Color.White;
                checkBox1.ForeColor = Color.Black;
                checkBox2.BackColor = Color.White;
                checkBox2.ForeColor = Color.Black;
                poisonDataGridView1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDateTime1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDateTime2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                panel3.BackColor = Color.White;
                poisonLabel1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                //poisonLabel8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                hopePictureBox1.BackColor = Color.White;
                parrotButton1.BackgroundColor = Color.White;
                parrotButton1.TextColor = Color.Black;
                poisonDataGridView1.ForeColor = Color.Black;
                poisonDataGridView2.ForeColor = Color.Black;
            }
        }

        private void poisonButton6_Click(object sender, EventArgs e)
        {
            saveimg();
        }

        private void hopePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hopePictureBox1.Image != null)
            {
                //QRDecoder
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)hopePictureBox1.Image);
                if (result != null)
                {
                    if(poisonRadioButton3.Checked)
                    {
                        
                        try
                        {
                            string[] lines = result.ToString().Split(
                            new string[] { "|" },
                            StringSplitOptions.None);
                            poisonTextBox2.Text = lines[2];
                            MessageBox.Show(lines[2] + " SELECTED\n \n" + result.ToString());

                           /*
                                int rowIndex = -1;
                            var searchValue = poisonTextBox2.Text;
                            var row = poisonDataGridView1.Rows.Cast<DataGridViewRow>()
                                .Where(x => !x.IsNewRow)
                                .Where(x => ((DataRowView)x.DataBoundItem)["PROPERTY ID"].ToString().Equals(searchValue))
                                .FirstOrDefault();
                            this.poisonDataGridView1.CurrentCell = row.Cells[0];
                           */
                      
                        }
                        catch (Exception properror)
                        {
                            MessageBox.Show("Property Selection Error");                        
                        }
                        } else if (poisonRadioButton1.Checked) {

                        int rowcount = poisonDataGridView2.Rows.Count + 1;
               
                    string brwid = "";

                    if (rowcount < 10)
                    {
                        brwid = "BRW-000000" + rowcount;
                    }
                    else if (rowcount >= 10 && rowcount < 100)
                    {

                        brwid = "BRW-00000" + rowcount;


                    }
                    else if (rowcount >= 100 && rowcount < 1000)
                    {

                        brwid = "BRW-0000" + rowcount;


                    }
                    else if (rowcount >= 1000 && rowcount < 10000)
                    {

                        brwid = "BRW-000" + rowcount;


                    }
                    else if (rowcount >= 10000 && rowcount < 100000)
                    {

                        brwid = "BRW-00" + rowcount;


                    }

                    else if (rowcount >= 100000 && rowcount < 1000000)
                    {

                        brwid = "BRW-0" + rowcount;


                    }
                    else if (rowcount >= 1000000)
                    {

                        brwid = "BRW-" + rowcount;
                    }


                    try { 
                    string[] lines = result.ToString().Split(
                    new string[] { "|" },
                    StringSplitOptions.None);
                    poisonTextBox3.Text = lines[4];
                    poisonTextBox4.Text = lines[6];
                    poisonTextBox5.Text = lines[8];
                    poisonTextBox6.Text = lines[10];
                    
                    if (lines[12].Equals("N/A"))
                    {
                        comboBox3.SelectedIndex = 0;
                    }
                    else if (lines[12].Equals("1ST OFFENSE"))
                    {
                        comboBox3.SelectedIndex = 1;
                    }
                    else if (lines[12].Equals("2ND OFFENSE"))
                    {
                        comboBox3.SelectedIndex = 2;
                    }
                    else if (lines[12].Equals("3RD OFFENSE"))
                    {
                        comboBox3.SelectedIndex = 3;
                    }
                    else if (lines[12].Equals("COMPENSATION"))
                    {
                        comboBox3.SelectedIndex = 4;
                    }
                    else if (lines[12].Equals("DISCIPLINARY ACTION"))
                    {
                        comboBox3.SelectedIndex = 5;
                    }
                    else if (lines[12].Equals("EXPULSION"))
                    {
                        comboBox3.SelectedIndex = 6;
                    }
                            checkBox1.Checked = true;
                            checkBox2.Checked = false;
                        poisonDateTime1.Value = DateTime.Today;
                        poisonDateTime2.Value = Convert.ToDateTime(empty);
                    
                             string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                        string search = "SELECT * FROM BorrowerTable WHERE [PROPERTY ID] LIKE '@propid'";
                        con = new SqlConnection(constring);
                        int switcher = 0;

                        DataTable result2 = new DataTable();
                        // Try-Catch of Sql Search:
                        try
                        {
                            using (SqlCommand srch = new SqlCommand(search, con))
                            {
                                con.Open();
                                    srch.Parameters.Add("@propid", SqlDbType.VarChar).Value = lines[2];
                                    SqlDataAdapter look = new SqlDataAdapter(search, con);
                                    SqlCommandBuilder cmdb = new SqlCommandBuilder(look);
                                    look.Fill(result2);
                                    if(result2.Rows.Count > 0)
                                    {
                                        switcher = 1;
                                    } else
                                    {
                                        switcher = 0;
                                    }
                                srch.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        catch (Exception srcherr)
                        {
                            MessageBox.Show("SEARCH CONNECTION ERROR!");
                        }
                            if (poisonTextBox2.Text == "")
                            {
                                MessageBox.Show("NO PROPERTY SELECTED");
                            }
                            else
                            {
                                string item = poisonTextBox2.Text;
                             
                                    insert();
                                MessageBox.Show(item + " BORROWED");
                            }
                                
                    }
                    catch (Exception indexerror)
                    {
                            MessageBox.Show("Scan Borrow Failed");
                    }
                } else if (poisonRadioButton2.Checked)
                    {
                     
                        try
                        {
                            string[] lines = result.ToString().Split(
                            new string[] { "|" },
                            StringSplitOptions.None);

                            poisonTextBox2.Text = lines[2];
                            string item = poisonTextBox2.Text;
                            poisonTextBox3.Text = lines[4];
                            poisonTextBox4.Text = lines[6];
                            poisonTextBox5.Text = lines[8];
                            poisonTextBox6.Text = lines[10];

                            if (lines[12].Equals("N/A"))
                            {
                                comboBox3.SelectedIndex = 0;
                            }
                            else if (lines[12].Equals("1ST OFFENSE"))
                            {
                                comboBox3.SelectedIndex = 1;
                            }
                            else if (lines[12].Equals("2ND OFFENSE"))
                            {
                                comboBox3.SelectedIndex = 2;
                            }
                            else if (lines[12].Equals("3RD OFFENSE"))
                            {
                                comboBox3.SelectedIndex = 3;
                            }
                            else if (lines[12].Equals("COMPENSATION"))
                            {
                                comboBox3.SelectedIndex = 4;
                            }
                            else if (lines[12].Equals("DISCIPLINARY ACTION"))
                            {
                                comboBox3.SelectedIndex = 5;
                            }
                            else if (lines[12].Equals("EXPULSION"))
                            {
                                comboBox3.SelectedIndex = 6;
                            }

                            poisonDateTime1.Value = Convert.ToDateTime(lines[14]);
                            poisonDateTime2.Value = Convert.ToDateTime(lines[16]);
                            if (poisonDateTime1.Value == Convert.ToDateTime(empty))
                            {
                                checkBox1.Checked = true;
                            }
                            else
                            {
                                checkBox1.Checked = true;
                            }
                            if (poisonDateTime2.Value == Convert.ToDateTime(empty))
                            {
                                checkBox2.Checked = true;
                                poisonDateTime2.Value = DateTime.Today;
                            }
                            else
                            {
                                checkBox2.Checked = true;
                                poisonDateTime2.Value = DateTime.Today;
                            }
                            
                            update();
                            MessageBox.Show(item + " RETURNED");
                        }
                        catch (Exception indexerror)
                        {

                        }
                    } else
                    {
                        MessageBox.Show("NO QR SCAN MODE SELECTED");
                        clearbox();
                    }
                    timer1.Stop();
                    if (CaptureDevice.IsRunning)
                    {
                        CaptureDevice.Stop();
                    }
                }

            }
        }

        private void poisonButton8_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            try { 
            if (CaptureDevice.IsRunning)
            {
                CaptureDevice.Stop();
                hopePictureBox1.Image = null;
            }
            } catch (Exception deviceerror)
            {
                MessageBox.Show("No Capture Device Running");
            }
            hopePictureBox1.Image = null;
        }

        private void formSubmenu2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CaptureDevice.IsRunning)
                {
                    CaptureDevice.Stop();
                }
                else
                {

                }
            }
            catch (Exception deviceerror)
            {

            }
        }

        private void poisonButton7_Click(object sender, EventArgs e)
        {
            scancamera();
        }

        private void poisonTextBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
