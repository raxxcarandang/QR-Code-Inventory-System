using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
using System.Text.RegularExpressions;
using System.Threading;

namespace OOProject
{

    public partial class fromSub1 : Form
    {
        public fromSub1()
        {
            InitializeComponent();
            poisonDataGridView1.ForeColor = Color.Black;
        }

        private void fromSub1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable' table. You can move, or remove it, as needed.
            this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);

            this.ControlBox = false;

            //Default Item in comboBoxes:
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            poisonDateTime1.Value = DateTime.Today;

            //ID Count from DataGridView:
            string utilid = "";

            int cptcount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count() + 1;
            int miscount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count() + 1;
            int ctecount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count() + 1;
            int rowcount = poisonDataGridView1.RowCount + 1;
            if (cptcount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count())
            {
                cptcount++;
            }
            if (miscount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count())
            {
                miscount++;
            }
            if (ctecount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count())
            {
                ctecount++;
            }
            if (rowcount == poisonDataGridView1.RowCount)
            {
                rowcount++;
            }

            if (comboBox4.SelectedIndex == 0)
            {
                if (cptcount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + cptcount;
                }
                else if (cptcount >= 10 && cptcount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + cptcount;


                }
                else if (cptcount >= 100 && cptcount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + cptcount;


                }
                else if (cptcount >= 1000 && cptcount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + cptcount;


                }
                else if (cptcount >= 10000 && cptcount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + cptcount;


                }

                else if (cptcount >= 100000 && cptcount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + cptcount;


                }
                else if (cptcount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + cptcount;
                }
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                if (miscount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + miscount;
                }
                else if (miscount >= 10 && miscount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + miscount;


                }
                else if (miscount >= 100 && miscount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + miscount;


                }
                else if (miscount >= 1000 && miscount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + miscount;


                }
                else if (miscount >= 10000 && miscount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + miscount;


                }

                else if (miscount >= 100000 && miscount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + miscount;


                }
                else if (miscount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + miscount;
                }
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                if (ctecount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + ctecount;
                }
                else if (ctecount >= 10 && ctecount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + ctecount;


                }
                else if (ctecount >= 100 && ctecount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + ctecount;


                }
                else if (ctecount >= 1000 && ctecount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + ctecount;


                }
                else if (ctecount >= 10000 && ctecount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + ctecount;


                }

                else if (ctecount >= 100000 && ctecount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + ctecount;


                }
                else if (ctecount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + ctecount;
                }
            }
            else
            {
                if (rowcount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + rowcount;
                }
                else if (rowcount >= 10 && rowcount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + rowcount;


                }
                else if (rowcount >= 100 && rowcount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + rowcount;


                }
                else if (rowcount >= 1000 && rowcount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + rowcount;


                }
                else if (rowcount >= 10000 && rowcount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + rowcount;


                }

                else if (rowcount >= 100000 && rowcount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + rowcount;


                }
                else if (rowcount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + rowcount;
                }
            }


            poisonTextBox2.Text = utilid;

        }


        //Global Variables:
        SqlConnection con;
        int parrotButton1click = 0;
        int reset7 = 0;
        int night = 0;

        Property utility = new Property();
        Bitmap sun = Properties.Resources.sun;
        Bitmap moon = Properties.Resources.moon;
        Bitmap lightning = Properties.Resources.lightning;
        Bitmap water = Properties.Resources.waterdrop;
        Bitmap fart = Properties.Resources.gas;
        Bitmap other = Properties.Resources.other;
        Bitmap all = Properties.Resources.all;

        // Table Refresh Method
        public void tablerefresh()
        {
            this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);
            poisonDataGridView1.Refresh();
        }

        // Sql Search Method:
        public void search()
        {
            string query = poisonTextBox1.Text;
            string condition =  comboBox1.Text;
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string search = "SELECT * FROM PropertyTable WHERE [" + condition + "] LIKE " + "'%" + query + "%'";
            con = new SqlConnection(constring);
            int num = 0;

            //ID Count from DataGridView:
            int rowcount = poisonDataGridView1.RowCount + 1;
            string utilid = "UTILITY#" + rowcount;
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
                MessageBox.Show("SEARCH CONNECTION ERROR!");
            }

        }


        // Sql Insertion Method:

        public void insert()
        {
           
                //Initialization of Connections and Sql Strings:
                string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                string create = "INSERT INTO PropertyTable VALUES (@id, @department, @itemdesc, @type, @date, @person, @amount, @status)";

                string count = "Select * From PropertyTable";
                con = new SqlConnection(constring);
                int num = 0;

                //ID Count from DataGridView:
                
                int cptcount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count() + 1;
                int miscount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count() + 1;
                int ctecount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count() + 1;
            int rowcount = poisonDataGridView1.RowCount + 1;
            if (cptcount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count())
            {
                cptcount++;
            }
            if (miscount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count())
            {
                miscount++;
            }
            if (ctecount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count())
            {
                ctecount++;
            }
            if (rowcount == poisonDataGridView1.RowCount)
            {
                rowcount++;
            }
            string utilid = "";
          
            if (comboBox4.SelectedIndex == 0)
                {
                    if (cptcount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + cptcount;
                    }
                    else if (cptcount >= 10 && cptcount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + cptcount;


                    }
                    else if (cptcount >= 100 && cptcount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + cptcount;


                    }
                    else if (cptcount >= 1000 && cptcount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + cptcount;


                    }
                    else if (cptcount >= 10000 && cptcount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + cptcount;


                    }

                    else if (cptcount >= 100000 && cptcount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + cptcount;


                    }
                    else if (cptcount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + cptcount;
                    }
                }
                else if (comboBox4.SelectedIndex == 1)
                {
                    if (miscount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + miscount;
                    }
                    else if (miscount >= 10 && miscount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + miscount;


                    }
                    else if (miscount >= 100 && miscount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + miscount;


                    }
                    else if (miscount >= 1000 && miscount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + miscount;


                    }
                    else if (miscount >= 10000 && miscount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + miscount;


                    }

                    else if (miscount >= 100000 && miscount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + miscount;


                    }
                    else if (miscount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + miscount;
                    }
                }
                else if (comboBox4.SelectedIndex == 2)
                {
                    if (ctecount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + ctecount;
                    }
                    else if (ctecount >= 10 && ctecount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + ctecount;


                    }
                    else if (ctecount >= 100 && ctecount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + ctecount;


                    }
                    else if (ctecount >= 1000 && ctecount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + ctecount;


                    }
                    else if (ctecount >= 10000 && ctecount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + ctecount;


                    }

                    else if (ctecount >= 100000 && ctecount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + ctecount;


                    }
                    else if (ctecount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + ctecount;
                    }
                }
                else
                {
                    if (rowcount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + rowcount;
                    }
                    else if (rowcount >= 10 && rowcount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + rowcount;


                    }
                    else if (rowcount >= 100 && rowcount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + rowcount;


                    }
                    else if (rowcount >= 1000 && rowcount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + rowcount;


                    }
                    else if (rowcount >= 10000 && rowcount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + rowcount;


                    }

                    else if (rowcount >= 100000 && rowcount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + rowcount;


                    }
                    else if (rowcount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + rowcount;
                    }
                }

                //Initialization of Object in Insert Context:
                utility.ID = poisonTextBox2.Text;
                utility.itemdesc = poisonTextBox3.Text;
                utility.type = comboBox2.Text;
                utility.dateacquired = poisonDateTime1.Value;
                utility.person = poisonTextBox4.Text;
                utility.amount = poisonTextBox5.Text;
                utility.department = comboBox4.Text;
                utility.status = comboBox3.Text;

                // Try-Catch of Sql Insertion:
                try
                {
                    using (SqlCommand ins = new SqlCommand(create, con))
                    {
                        con.Open();
                        ins.Parameters.Add("@id", SqlDbType.VarChar).Value = utility.ID;
                        ins.Parameters.Add("@department", SqlDbType.VarChar).Value = utility.department;
                        ins.Parameters.Add("@itemdesc", SqlDbType.VarChar).Value = utility.itemdesc;
                        ins.Parameters.Add("@type", SqlDbType.VarChar).Value = utility.type;
                        ins.Parameters.Add("@date", SqlDbType.DateTime).Value = utility.dateacquired;
                        ins.Parameters.Add("@person", SqlDbType.VarChar).Value = utility.person;
                        ins.Parameters.Add("@amount", SqlDbType.VarChar).Value = utility.amount;
                        ins.Parameters.Add("@status", SqlDbType.VarChar).Value = utility.status;
                        ins.ExecuteNonQuery();
                        this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);
                        poisonDataGridView1.Refresh();
                        con.Close();
                    }
                }
                catch (Exception conerr)
                {
                    MessageBox.Show("INSERT CONNECTION ERROR!");
                }
                clearboxnodialog();
        }

        // Sql Updation Method:
        public void update()
        {
            try
            {
                utility.ID = poisonDataGridView1.SelectedRows[0].Cells[0].Value + string.Empty; ;
            }
            catch (Exception iderr)
            {
                MessageBox.Show("ID out of range");
            }
            DialogResult confirmupd = MessageBox.Show("UPDATE PROPERTY " + utility.ID + "?", "UPDATE PROPERTY", MessageBoxButtons.YesNo);
            if (confirmupd == DialogResult.Yes)
            {
                //Initialization of Connections and Sql Strings:
                string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                string update = "UPDATE PropertyTable SET DEPARTMENT = @department, [ITEM DESCRIPTION] = @itemdesc, TYPE = @type, [DATE ACQUIRED] = @date, [PERSON ISSUED] = @person, AMOUNT = @amount, STATUS = @status WHERE [PROPERTY ID] = @id";
                string count = "Select * From PropertyTable";
                con = new SqlConnection(constring);
                int num = 0;

                //Initialization of Object in Update Context:
                utility.itemdesc = poisonTextBox3.Text;
                utility.type = comboBox2.Text;
                utility.dateacquired = poisonDateTime1.Value;
                utility.person = poisonTextBox4.Text;
                utility.amount = poisonTextBox5.Text;
                utility.department = comboBox4.Text;
                utility.status = comboBox3.Text;


                // Try-Catch of Sql Update:
                try
                {
                    using (SqlCommand upd = new SqlCommand(update, con))
                    {
                        con.Open();
                        upd.Parameters.Add("@itemdesc", SqlDbType.VarChar).Value = utility.itemdesc;
                        upd.Parameters.Add("@department", SqlDbType.VarChar).Value = utility.department;
                        upd.Parameters.Add("@type", SqlDbType.VarChar).Value = utility.type;
                        upd.Parameters.Add("@date", SqlDbType.DateTime).Value = utility.dateacquired;
                        upd.Parameters.Add("@person", SqlDbType.VarChar).Value = utility.person;
                        upd.Parameters.Add("@amount", SqlDbType.VarChar).Value = utility.amount;
                        upd.Parameters.Add("@status", SqlDbType.VarChar).Value = utility.status;
                        upd.Parameters.Add("@id", SqlDbType.VarChar).Value = utility.ID;
                        upd.ExecuteNonQuery();
                        this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);
                        poisonDataGridView1.Refresh();
                        con.Close();
                    }
                }
                catch (Exception conerr)
                {
                    MessageBox.Show("UPDATE CONNECTION ERROR!");
                }
            }
            else if (confirmupd == DialogResult.No) { }
        }

        public void updatecon()
        {
           
                // Utility Object Initialization in Select Method:
                try { 
                utility.ID = poisonDataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                utility.department = poisonDataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                utility.itemdesc = poisonDataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                utility.type = poisonDataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                utility.dateacquired = Convert.ToDateTime(poisonDataGridView1.SelectedRows[0].Cells[4].Value);
                utility.person = poisonDataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                utility.amount = poisonDataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                utility.status = poisonDataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
            } catch (Exception inerr)
            {
                MessageBox.Show("Input Out of Range");
            }

                // Laying all the values into the poisonTextBoxes
            poisonTextBox2.Text = utility.ID;
                poisonTextBox3.Text = utility.itemdesc;
                poisonTextBox4.Text = utility.person;
                poisonTextBox5.Text = utility.amount;
                comboBox4.Text = utility.department;
                poisonDateTime1.Value = utility.dateacquired;
                //comboBox3.Text = utility.status;

                // Laying all the values into the ComboBox2
                if (utility.type.Equals("ELECTRIC"))
                {
                    comboBox2.SelectedIndex = 0;
                }
                else if (utility.type.Equals("WATER"))
                {
                    comboBox2.SelectedIndex = 1;
                }
                else if (utility.type.Equals("GAS"))
                {
                    comboBox2.SelectedIndex = 2;
                }
                else if (utility.type.Equals("OTHER"))
                {
                    comboBox2.SelectedIndex = 3;
                }

                // Laying all the values into the ComboBox3
                if (utility.status.Equals("NORMAL"))
                {
                    comboBox3.SelectedIndex = 0;
                }
                else if (utility.status.Equals("BORROWED"))
                {
                    comboBox3.SelectedIndex = 1;
                }
                else if (utility.status.Equals("DEFECTIVE"))
                {
                    comboBox3.SelectedIndex = 2;
                }
                else if (utility.status.Equals("MISSING"))
                {
                    comboBox3.SelectedIndex = 3;
                }
                else if (utility.status.Equals("INACTIVE"))
                {
                    comboBox3.SelectedIndex = 4;
                }
                else if (utility.status.Equals("ACTIVE"))
                {
                    comboBox3.SelectedIndex = 5;
                }
                else if (utility.status.Equals("MAINTENANCE"))
                {
                    comboBox3.SelectedIndex = 6;
                }

                // Initialization of Qr Coder:
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("Property ID: " + utility.ID + "\n" + "Department: " + utility.department + "\n" + "Item-Description: " + utility.itemdesc + "\n" + "Type: " + utility.type + "\n" + "Date Acquired: " + utility.dateacquired + "\n" + "Person-Issued: " + utility.person + "\n" + "Amount: " + utility.amount + "\n" + "Status: " + utility.status + "\n" + "Saved On: " + DateTime.Now + "\n" + "Please Visit the Link Below for Updated Info:" + "\n" + "localhost:80/" + utility.ID, QRCodeGenerator.ECCLevel.Q))
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    hopePictureBox1.Image = qrCodeImage;
                }
            
        }
        // Sql Deletion Method:
        public void delete()
        {
            try
            {
                utility.ID = poisonDataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
            }
            catch (Exception iderr)
            {
                MessageBox.Show("ID out of Range");
            }
            DialogResult confirmdel = MessageBox.Show("DELETE PROPERTY " + utility.ID +"?", "DELETE PROPERTY", MessageBoxButtons.YesNo);
            if (confirmdel == DialogResult.Yes)
            {
                //Initialization of Connections and Sql Strings:
                string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                string delete = "DELETE FROM PropertyTable WHERE [Property ID] = @id ";
                string count = "Select * From PropertyTable";
                con = new SqlConnection(constring);
                int num = 0;

                //ID Count from DataGridView:
                int rowcount = poisonDataGridView1.RowCount + 1;
               
                string utilid = "UTILITY#" + rowcount;

                // Try-Catch of Sql Deletion:
                try
                {
                    using (SqlCommand del = new SqlCommand(delete, con))
                    {
                        con.Open();
                        del.Parameters.Add("@id", SqlDbType.VarChar).Value = utility.ID;
                        del.ExecuteNonQuery();
                        this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);
                        poisonDataGridView1.Refresh();
                        con.Close();
                    }
                }
                catch (Exception conerr)
                {
                    MessageBox.Show("DELETE CONNECTION ERROR!");
                }
                clearboxnodialog();
            }
            else if (confirmdel == DialogResult.No) { }
        }

        //Reset Method:
        public void clearboxnodialog()
        {
          
                //ID Count from DataGridView to reset for latest ID:
                
                int cptcount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count() + 1;
                int miscount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count() + 1;
                int ctecount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count() + 1;
            int rowcount = poisonDataGridView1.RowCount + 1;
            if (cptcount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count())
            {
                cptcount++;
            }
            if (miscount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count())
            {
                miscount++;
            }
            if (ctecount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count())
            {
                ctecount++;
            }
            if (rowcount == poisonDataGridView1.RowCount)
            {
                rowcount++;
            }
            string utilid = "";

                if (comboBox4.SelectedIndex == 0)
                {
                    if (cptcount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + cptcount;
                    }
                    else if (cptcount >= 10 && cptcount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + cptcount;


                    }
                    else if (cptcount >= 100 && cptcount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + cptcount;


                    }
                    else if (cptcount >= 1000 && cptcount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + cptcount;


                    }
                    else if (cptcount >= 10000 && cptcount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + cptcount;


                    }

                    else if (cptcount >= 100000 && cptcount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + cptcount;


                    }
                    else if (cptcount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + cptcount;
                    }
                }
                else if (comboBox4.SelectedIndex == 1)
                {
                    if (miscount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + miscount;
                    }
                    else if (miscount >= 10 && miscount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + miscount;


                    }
                    else if (miscount >= 100 && miscount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + miscount;


                    }
                    else if (miscount >= 1000 && miscount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + miscount;


                    }
                    else if (miscount >= 10000 && miscount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + miscount;


                    }

                    else if (miscount >= 100000 && miscount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + miscount;


                    }
                    else if (miscount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + miscount;
                    }
                }
                else if (comboBox4.SelectedIndex == 2)
                {
                    if (ctecount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + ctecount;
                    }
                    else if (ctecount >= 10 && ctecount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + ctecount;


                    }
                    else if (ctecount >= 100 && ctecount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + ctecount;


                    }
                    else if (ctecount >= 1000 && ctecount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + ctecount;


                    }
                    else if (ctecount >= 10000 && ctecount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + ctecount;


                    }

                    else if (ctecount >= 100000 && ctecount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + ctecount;


                    }
                    else if (ctecount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + ctecount;
                    }
                }
                else
                {
                    if (rowcount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + rowcount;
                    }
                    else if (rowcount >= 10 && rowcount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + rowcount;


                    }
                    else if (rowcount >= 100 && rowcount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + rowcount;


                    }
                    else if (rowcount >= 1000 && rowcount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + rowcount;


                    }
                    else if (rowcount >= 10000 && rowcount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + rowcount;


                    }

                    else if (rowcount >= 100000 && rowcount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + rowcount;


                    }
                    else if (rowcount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + rowcount;
                    }
                }

                // Clear all poisonTextBoxes and Etc.:
                poisonTextBox1.Text = "";
                poisonTextBox2.Text = utilid;
                poisonTextBox3.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                //comboBox4.SelectedIndex = 0;
                poisonTextBox4.Text = "";
                poisonTextBox5.Text = "PHP";
                hopePictureBox1.Image = null;
                parrotButton1.ButtonText = "ALL";
                parrotButton1.ButtonImage = all;
                this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);
                poisonDataGridView1.DataSource = this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable;
                poisonDataGridView1.Refresh();
                poisonDateTime1.Value = DateTime.Today;

        }
        //End of Reset Method 

        //Reset Method:
        public void clearbox()
        {
            DialogResult confirmreset = MessageBox.Show("RESET ALL PROPERTY FORMS?", "RESET WINDOW FORM", MessageBoxButtons.YesNo);
            if (confirmreset == DialogResult.Yes)
            {
                //ID Count from DataGridView to reset for latest ID:
                
                int cptcount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count() + 1;
                int miscount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count() + 1;
                int ctecount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count() + 1;
                int rowcount = poisonDataGridView1.RowCount + 1;
                if (cptcount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count())
                {
                    cptcount++;
                }
                if (miscount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count())
                {
                    miscount++;
                }
                if (ctecount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count())
                {
                    ctecount++;
                }
                if (rowcount == poisonDataGridView1.RowCount)
                {
                    rowcount++;
                }
                string utilid = "";

                if (comboBox4.SelectedIndex == 0)
                {
                    if (cptcount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + cptcount;
                    }
                    else if (cptcount >= 10 && cptcount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + cptcount;


                    }
                    else if (cptcount >= 100 && cptcount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + cptcount;


                    }
                    else if (cptcount >= 1000 && cptcount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + cptcount;


                    }
                    else if (cptcount >= 10000 && cptcount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + cptcount;


                    }

                    else if (cptcount >= 100000 && cptcount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + cptcount;


                    }
                    else if (cptcount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + cptcount;
                    }
                }
                else if (comboBox4.SelectedIndex == 1)
                {
                    if (miscount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + miscount;
                    }
                    else if (miscount >= 10 && miscount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + miscount;


                    }
                    else if (miscount >= 100 && miscount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + miscount;


                    }
                    else if (miscount >= 1000 && miscount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + miscount;


                    }
                    else if (miscount >= 10000 && miscount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + miscount;


                    }

                    else if (miscount >= 100000 && miscount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + miscount;


                    }
                    else if (miscount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + miscount;
                    }
                }
                else if (comboBox4.SelectedIndex == 2)
                {
                    if (ctecount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + ctecount;
                    }
                    else if (ctecount >= 10 && ctecount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + ctecount;


                    }
                    else if (ctecount >= 100 && ctecount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + ctecount;


                    }
                    else if (ctecount >= 1000 && ctecount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + ctecount;


                    }
                    else if (ctecount >= 10000 && ctecount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + ctecount;


                    }

                    else if (ctecount >= 100000 && ctecount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + ctecount;


                    }
                    else if (ctecount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + ctecount;
                    }
                }
                else
                {
                    if (rowcount < 10)
                    {
                        utilid = comboBox4.Text + "-000000" + rowcount;
                    }
                    else if (rowcount >= 10 && rowcount < 100)
                    {

                        utilid = comboBox4.Text + "-00000" + rowcount;


                    }
                    else if (rowcount >= 100 && rowcount < 1000)
                    {

                        utilid = comboBox4.Text + "-0000" + rowcount;


                    }
                    else if (rowcount >= 1000 && rowcount < 10000)
                    {

                        utilid = comboBox4.Text + "-000" + rowcount;


                    }
                    else if (rowcount >= 10000 && rowcount < 100000)
                    {

                        utilid = comboBox4.Text + "-00" + rowcount;


                    }

                    else if (rowcount >= 100000 && rowcount < 1000000)
                    {

                        utilid = comboBox4.Text + "-0" + rowcount;


                    }
                    else if (rowcount >= 1000000)
                    {

                        utilid = comboBox4.Text + "-" + rowcount;
                    }
                }

                // Clear all poisonTextBoxes and Etc.:
                poisonTextBox1.Text = "";
                poisonTextBox2.Text = utilid;
                poisonTextBox3.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                //comboBox4.SelectedIndex = 0;
                poisonTextBox4.Text = "";
                poisonTextBox5.Text = "PHP";
                hopePictureBox1.Image = null;
                parrotButton1.ButtonText = "ALL";
                parrotButton1.ButtonImage = all;
                this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);
                poisonDataGridView1.DataSource = this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable;
                poisonDataGridView1.Refresh();
                poisonDateTime1.Value = DateTime.Today;
            }
            else if (confirmreset == DialogResult.No) { }
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
                poisonDataGridView1.DataSource = _UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable;
                poisonDataGridView1.Refresh();
                reset7 = 0;
            }
            else
            {
                string query = parrotButton1.ButtonText;
                string condition = "Type";
                string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
                string search = "SELECT * FROM PropertyTable WHERE " + condition + " LIKE " + "'%" + query + "%'";
                con = new SqlConnection(constring);
                int num = 0;

                //ID Count from DataGridView:
                int rowcount = poisonDataGridView1.RowCount + 1;
             
                if (rowcount == poisonDataGridView1.RowCount)
                {
                    rowcount++;
                }
                string utilid = "UTILITY#" + rowcount;
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
                    MessageBox.Show("SEARCH CATEGORY CONNECTION ERROR!");
                }
            }
        }

        //QRCode Save Method:
        public void saveimg()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                saveFileDialog.FileName = utility.itemdesc;
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

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void parrotButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            this.propertyTableTableAdapter1.Fill(this._UTILITY_INVENTORY_DATABASEDataSet13.PropertyTable);
            DataView dv = new DataView(this._UTILITY_INVENTORY_DATABASEDataSet4.PropertyTable);
            dv.RowFilter = "'" + comboBox1.Text + "'" + " LIKE " + "'" + poisonTextBox1.Text + "'";
            poisonDataGridView1.DataSource = dv;
            */
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void poisonLabel1_Click(object sender, EventArgs e)
        {

        }

        private void poisonLabel4_Click(object sender, EventArgs e)
        {

        }

        private void poisonLabel5_Click(object sender, EventArgs e)
        {

        }

        private void poisonLabel6_Click(object sender, EventArgs e)
        {

        }

        private void poisonLabel7_Click(object sender, EventArgs e)
        {

        }

        private void poisonButton2_Click(object sender, EventArgs e)
        {
            insert();
        }

        private void poisonButton3_Click(object sender, EventArgs e)
        {
            update();
            updatecon();
        }

        private void poisonButton4_Click(object sender, EventArgs e)
        {
            clearbox();
        }

        private void poisonButton5_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void poisonButton6_Click(object sender, EventArgs e)
        {
            saveimg();
        }

        private void poisonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try { 
                DataGridViewRow row = this.poisonDataGridView1.Rows[e.RowIndex];
                }
                catch (Exception celerror)
                {

                }

                try
                {
                    // Utility Object Initialization in Select Method:
                    utility.ID = poisonDataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                    utility.department = poisonDataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                    utility.itemdesc = poisonDataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                    utility.type = poisonDataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                    utility.dateacquired = Convert.ToDateTime(poisonDataGridView1.SelectedRows[0].Cells[4].Value);
                    utility.person = poisonDataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                    utility.amount = poisonDataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                    utility.status = poisonDataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
                }
                catch (Exception inerr)
                {
                    MessageBox.Show("Input Out of Range");
                }
                // Laying all the values into the poisonTextBoxes
                poisonTextBox2.Text = utility.ID;
                poisonTextBox3.Text = utility.itemdesc;
                poisonTextBox4.Text = utility.person;
                poisonTextBox5.Text = utility.amount;
                comboBox4.Text = utility.department;
                poisonDateTime1.Value = utility.dateacquired;
                //comboBox3.Text = utility.status;

                // Laying all the values into the ComboBox2
                if (utility.type.Equals("ELECTRIC"))
                {
                    comboBox2.SelectedIndex = 0;
                }
                else if (utility.type.Equals("WATER"))
                {
                    comboBox2.SelectedIndex = 1;
                }
                else if (utility.type.Equals("GAS"))
                {
                    comboBox2.SelectedIndex = 2;
                }
                else if (utility.type.Equals("OTHER"))
                {
                    comboBox2.SelectedIndex = 3;
                }

                // Laying all the values into the ComboBox3
                if (utility.status.Equals("NORMAL"))
                {
                    comboBox3.SelectedIndex = 0;
                }
                else if (utility.status.Equals("BORROWED"))
                {
                    comboBox3.SelectedIndex = 1;
                }
                else if (utility.status.Equals("DEFECTIVE"))
                {
                    comboBox3.SelectedIndex = 2;
                }
                else if (utility.status.Equals("MISSING"))
                {
                    comboBox3.SelectedIndex = 3;
                }
                else if (utility.status.Equals("INACTIVE"))
                {
                    comboBox3.SelectedIndex = 4;
                }
                else if (utility.status.Equals("ACTIVE"))
                {
                    comboBox3.SelectedIndex = 5;
                }
                else if (utility.status.Equals("MAINTENANCE"))
                {
                    comboBox3.SelectedIndex = 6;
                }

                // Initialization of Qr Coder:
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("|Property ID|" + utility.ID + "\n" + "|Department|" + utility.department + "\n" + "|Item-Description|" + utility.itemdesc + "\n" + "|Type|" + utility.type + "\n" + "|Date Acquired|" + utility.dateacquired + "\n" + "|Person-Issued|" + utility.person + "\n" + "|Amount|" + utility.amount + "\n" + "|Status|" + utility.status + "\n" + "|Saved On|" + DateTime.Now + "\n" + "|Please Visit the Link Below for Updated Info|" + "\n" + "localhost:80/" + utility.ID, QRCodeGenerator.ECCLevel.Q))
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    hopePictureBox1.Image = qrCodeImage;
                }
            }
        }

        private void poisonButton1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void parrotButton1_Click_1(object sender, EventArgs e)
        {
            categorize();
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
                poisonTextBox1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonTextBox5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                comboBox1.BackColor = Color.Black;
                comboBox1.ForeColor = Color.White;
                comboBox2.BackColor = Color.Black;
                comboBox2.ForeColor = Color.White;
                comboBox3.BackColor = Color.Black;
                comboBox3.ForeColor = Color.White;
                comboBox4.BackColor = Color.Black;
                comboBox4.ForeColor = Color.White;
                poisonDateTime1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView1.ForeColor = Color.White;
                panel1.BackColor = Color.Black;
                panel2.BackColor = Color.Black;
                panel3.BackColor = Color.Black;
                poisonLabel1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel9.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                hopePictureBox1.BackColor = Color.Black;
                parrotButton1.BackgroundColor = Color.Black;
                parrotButton1.TextColor = Color.White;
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
                poisonTextBox1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonTextBox5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                comboBox1.BackColor = Color.White;
                comboBox1.ForeColor = Color.Black;
                comboBox2.BackColor = Color.White;
                comboBox2.ForeColor = Color.Black;
                comboBox3.BackColor = Color.White;
                comboBox3.ForeColor = Color.Black;
                comboBox4.BackColor = Color.White;
                comboBox4.ForeColor = Color.Black;
                poisonDateTime1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView1.ForeColor = Color.Black;
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                panel3.BackColor = Color.White;
                poisonLabel1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel9.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                hopePictureBox1.BackColor = Color.White;
                parrotButton1.BackgroundColor = Color.White;
                parrotButton1.TextColor = Color.Black;
            }
        }

        private void poisonTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void poisonTextBox5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int cptcount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count() + 1;
            int miscount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count() + 1;
            int ctecount = poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count() + 1;
            int rowcount = poisonDataGridView1.RowCount + 1;
            if (cptcount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CPT").Count())
            {
                cptcount++;
            }
            if (miscount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "MIS").Count())
            {
                miscount++;
            }
            if (ctecount == poisonDataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == "CTE").Count())
            {
                ctecount++;
            }
            if (rowcount == poisonDataGridView1.RowCount)
            {
                rowcount++;
            }
            string utilid = "";
            if (comboBox4.SelectedIndex == 0)
            {
                if (cptcount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + cptcount;
                }
                else if (cptcount >= 10 && cptcount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + cptcount;


                }
                else if (cptcount >= 100 && cptcount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + cptcount;


                }
                else if (cptcount >= 1000 && cptcount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + cptcount;


                }
                else if (cptcount >= 10000 && cptcount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + cptcount;


                }

                else if (cptcount >= 100000 && cptcount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + cptcount;


                }
                else if (cptcount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + cptcount;
                }
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                if (miscount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + miscount;
                }
                else if (miscount >= 10 && miscount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + miscount;


                }
                else if (miscount >= 100 && miscount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + miscount;


                }
                else if (miscount >= 1000 && miscount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + miscount;


                }
                else if (miscount >= 10000 && miscount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + miscount;


                }

                else if (miscount >= 100000 && miscount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + miscount;


                }
                else if (miscount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + miscount;
                }
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                if (ctecount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + ctecount;
                }
                else if (ctecount >= 10 && ctecount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + ctecount;


                }
                else if (ctecount >= 100 && ctecount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + ctecount;


                }
                else if (ctecount >= 1000 && ctecount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + ctecount;


                }
                else if (ctecount >= 10000 && ctecount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + ctecount;


                }

                else if (ctecount >= 100000 && ctecount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + ctecount;


                }
                else if (ctecount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + ctecount;
                }
            }
            else
            {
                if (rowcount < 10)
                {
                    utilid = comboBox4.Text + "-000000" + rowcount;
                }
                else if (rowcount >= 10 && rowcount < 100)
                {

                    utilid = comboBox4.Text + "-00000" + rowcount;


                }
                else if (rowcount >= 100 && rowcount < 1000)
                {

                    utilid = comboBox4.Text + "-0000" + rowcount;


                }
                else if (rowcount >= 1000 && rowcount < 10000)
                {

                    utilid = comboBox4.Text + "-000" + rowcount;


                }
                else if (rowcount >= 10000 && rowcount < 100000)
                {

                    utilid = comboBox4.Text + "-00" + rowcount;


                }

                else if (rowcount >= 100000 && rowcount < 1000000)
                {

                    utilid = comboBox4.Text + "-0" + rowcount;


                }
                else if (rowcount >= 1000000)
                {

                    utilid = comboBox4.Text + "-" + rowcount;
                }
            }
            poisonTextBox2.Text = utilid;
        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}



