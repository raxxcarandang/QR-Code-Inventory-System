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


namespace OOProject
{

   
    
    public partial class formDashboard : Form
    {
        SqlConnection con;
        
        public formDashboard()
        {
            InitializeComponent();

            searchcategory();
            poisonDataGridView1.ForeColor = Color.Black;
            poisonDataGridView2.ForeColor = Color.Black;
            poisonDataGridView3.ForeColor = Color.Black;
            poisonDataGridView4.ForeColor = Color.Black;
            poisonDataGridView5.ForeColor = Color.Black;
            poisonDataGridView6.ForeColor = Color.Black;
            poisonDataGridView7.ForeColor = Color.Black;
            poisonDataGridView8.ForeColor = Color.Black;
            poisonDataGridView9.ForeColor = Color.Black;
        }

        
            
        private void formDashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASEDataSet12.BorrowerTable' table. You can move, or remove it, as needed.
            this.borrowerTableTableAdapter4.Fill(this._UTILITY_INVENTORY_DATABASEDataSet12.BorrowerTable);
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASEDataSet11.PropertyTable' table. You can move, or remove it, as needed.
            this.propertyTableTableAdapter2.Fill(this._UTILITY_INVENTORY_DATABASEDataSet11.PropertyTable);
            // TODO: This line of code loads data into the '_UTILITY_INVENTORY_DATABASE_DATASET11.BorrowerTable' table. You can move, or remove it, as needed.
            this.borrowerTableTableAdapter3.Fill(this._UTILITY_INVENTORY_DATABASE_DATASET11.BorrowerTable);
            poisonDataGridView1.Refresh();
            poisonDataGridView2.Refresh();
            poisonDataGridView3.Refresh();
            poisonDataGridView4.Refresh();
            poisonDataGridView5.Refresh();
            poisonDataGridView6.Refresh();
            poisonDataGridView7.Refresh();
            poisonDataGridView8.Refresh();
            poisonDataGridView9.Refresh();

            comboBox1.SelectedIndex = 0;
            
        }

        
        public void search()
        {
            string query = textBox1.Text;
            string condition = comboBox1.Text;
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string search = "SELECT * FROM [PropertyTable] WHERE [" + condition + "] LIKE " + "'%" + query + "%'";
            string elecsearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%ELECTRIC%' AND [" + condition + "] LIKE " + "'%" + query + "%'";
            string watersearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%WATER%' AND [" + condition + "] LIKE " + "'%" + query + "%'";
            string gassearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%GAS%' AND [" + condition + "] LIKE " + "'%" + query + "%'";
            string othersearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%OTHER%' AND [" + condition + "] LIKE " + "'%" + query + "%'";
            con = new SqlConnection(constring);

            DataSet result = new DataSet();
            DataSet resultelec = new DataSet();
            DataSet resultwater = new DataSet();
            DataSet resultgas = new DataSet();
            DataSet resultother = new DataSet();
            // Try-Catch of Sql Search:
            try
            {
                using (SqlCommand srch = new SqlCommand(search, con))
                {
                    con.Open();
                    SqlDataAdapter look = new SqlDataAdapter(search, con);
                    SqlDataAdapter lookelec = new SqlDataAdapter(elecsearch, con);
                    SqlDataAdapter lookwater = new SqlDataAdapter(watersearch, con);
                    SqlDataAdapter lookgas = new SqlDataAdapter(gassearch, con);
                    SqlDataAdapter lookother = new SqlDataAdapter(othersearch, con);
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(look);
                    SqlCommandBuilder cmdbelec = new SqlCommandBuilder(lookelec);
                    SqlCommandBuilder cmdbwater = new SqlCommandBuilder(lookwater);
                    SqlCommandBuilder cmdbgas = new SqlCommandBuilder(lookgas);
                    SqlCommandBuilder cmdbother = new SqlCommandBuilder(lookother);
                    look.Fill(result);
                    lookelec.Fill(resultelec);
                    lookwater.Fill(resultwater);
                    lookgas.Fill(resultgas);
                    lookother.Fill(resultother);
                    poisonDataGridView1.DataSource = resultelec.Tables[0];
                    poisonDataGridView1.Refresh();
                    poisonDataGridView2.DataSource = resultwater.Tables[0];
                    poisonDataGridView2.Refresh();
                    poisonDataGridView3.DataSource = resultgas.Tables[0];
                    poisonDataGridView3.Refresh();
                    poisonDataGridView4.DataSource = resultother.Tables[0];
                    poisonDataGridView4.Refresh();
                    srch.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception srcherr)
            {
                MessageBox.Show("CONNECTION ERROR!");
            }

        }

        public void searchcategory()
        {
            string constring = "Data Source = SLAPTOP\\SQLEXPRESS; Initial Catalog = UTILITY-INVENTORY-DATABASE; Trusted_Connection = True";
            string elecsearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%ELECTRIC%'";
            string watersearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%WATER%'";
            string gassearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%GAS%'";
            string othersearch = "SELECT * FROM [PropertyTable] WHERE [TYPE] LIKE '%OTHER%'";
            string elecbrwsearch = "SELECT * FROM [BorrowerTable] WHERE EXISTS (SELECT * FROM [PropertyTable] WHERE [PropertyTable].[PROPERTY ID] = [BorrowerTable].[PROPERTY ID] AND [PropertyTable].[TYPE] LIKE '%ELECTRIC%')";
            string waterbrwsearch = "SELECT * FROM [BorrowerTable] WHERE EXISTS (SELECT * FROM [PropertyTable] WHERE [PropertyTable].[PROPERTY ID] = [BorrowerTable].[PROPERTY ID] AND [PropertyTable].[TYPE] LIKE '%WATER%')";
            string gasbrwsearch = "SELECT * FROM [BorrowerTable] WHERE EXISTS (SELECT * FROM [PropertyTable] WHERE [PropertyTable].[PROPERTY ID] = [BorrowerTable].[PROPERTY ID] AND [PropertyTable].[TYPE] LIKE '%GAS%')";
            string otherbrwsearch = "SELECT * FROM [BorrowerTable] WHERE EXISTS (SELECT * FROM [PropertyTable] WHERE [PropertyTable].[PROPERTY ID] = [BorrowerTable].[PROPERTY ID] AND [PropertyTable].[TYPE] LIKE '%OTHER%')";
            con = new SqlConnection(constring);

            DataSet result = new DataSet();
            DataSet resultelec = new DataSet();
            DataSet resultwater = new DataSet();
            DataSet resultgas = new DataSet();
            DataSet resultother = new DataSet();
            DataSet resultelecbrw = new DataSet();
            DataSet resultwaterbrw = new DataSet();
            DataSet resultgasbrw = new DataSet();
            DataSet resultotherbrw = new DataSet();
            // Try-Catch of Sql Search:
            try
            {
                using (SqlCommand srch = new SqlCommand(elecsearch, con))
                {
                    con.Open();
                    SqlDataAdapter lookelec = new SqlDataAdapter(elecsearch, con);
                    SqlDataAdapter lookwater = new SqlDataAdapter(watersearch, con);
                    SqlDataAdapter lookgas = new SqlDataAdapter(gassearch, con);
                    SqlDataAdapter lookother = new SqlDataAdapter(othersearch, con);
                    SqlDataAdapter lookelecbrw = new SqlDataAdapter(elecbrwsearch, con);
                    SqlDataAdapter lookwaterbrw = new SqlDataAdapter(waterbrwsearch, con);
                    SqlDataAdapter lookgasbrw = new SqlDataAdapter(gasbrwsearch, con);
                    SqlDataAdapter lookotherbrw = new SqlDataAdapter(otherbrwsearch, con);
                    SqlCommandBuilder cmdbelec = new SqlCommandBuilder(lookelec);
                    SqlCommandBuilder cmdbwater = new SqlCommandBuilder(lookwater);
                    SqlCommandBuilder cmdbgas = new SqlCommandBuilder(lookgas);
                    SqlCommandBuilder cmdbother = new SqlCommandBuilder(lookother);
                    SqlCommandBuilder cmdbelecbrw = new SqlCommandBuilder(lookelecbrw);
                    SqlCommandBuilder cmdbwaterbrw = new SqlCommandBuilder(lookwaterbrw);
                    SqlCommandBuilder cmdbgasbrw = new SqlCommandBuilder(lookgasbrw);
                    SqlCommandBuilder cmdbotherbrw = new SqlCommandBuilder(lookotherbrw);
                    lookelec.Fill(resultelec);
                    lookwater.Fill(resultwater);
                    lookgas.Fill(resultgas);
                    lookother.Fill(resultother);
                    lookelecbrw.Fill(resultelecbrw);
                    lookwaterbrw.Fill(resultwaterbrw);
                    lookgasbrw.Fill(resultgasbrw);
                    lookotherbrw.Fill(resultotherbrw);
                    poisonDataGridView1.DataSource = resultelec.Tables[0];
                    poisonDataGridView1.Refresh();
                    poisonDataGridView2.DataSource = resultwater.Tables[0];
                    poisonDataGridView2.Refresh();
                    poisonDataGridView3.DataSource = resultgas.Tables[0];
                    poisonDataGridView3.Refresh();
                    poisonDataGridView4.DataSource = resultother.Tables[0];
                    poisonDataGridView4.Refresh();
                    poisonDataGridView5.DataSource = resultelecbrw.Tables[0];
                    poisonDataGridView5.Refresh();
                    poisonDataGridView6.DataSource = resultwaterbrw.Tables[0];
                    poisonDataGridView6.Refresh();
                    poisonDataGridView7.DataSource = resultgasbrw.Tables[0];
                    poisonDataGridView7.Refresh();
                    poisonDataGridView8.DataSource = resultotherbrw.Tables[0];
                    poisonDataGridView8.Refresh();
                    poisonDataGridView9.DataSource = _UTILITY_INVENTORY_DATABASE_DATASET11.BorrowerTable;
                    this.borrowerTableTableAdapter3.Fill(this._UTILITY_INVENTORY_DATABASE_DATASET11.BorrowerTable);
                    poisonDataGridView9.Refresh();
                    srch.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception srcherr)
            {
                MessageBox.Show("CONNECTION ERROR!");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void button7_Click(object sender, EventArgs e)
            {

            }

            private void button8_Click(object sender, EventArgs e)
            {

            }

            private void button9_Click(object sender, EventArgs e)
            {

            }

            private void button10_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {




            }

            private void button11_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click_1(object sender, EventArgs e)
            {


            }

            private void button5_Click(object sender, EventArgs e)
            {

            }

            private void button4_Click_1(object sender, EventArgs e)
            {


            }

            private void button3_Click(object sender, EventArgs e)
            {

            }

            private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void button2_Click_1(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void textBox6_TextChanged(object sender, EventArgs e)
            {

            }

            private void panel3_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel4_Paint(object sender, PaintEventArgs e)
            {

            }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        int night = 0;
        Bitmap sun = Properties.Resources.sun;
        Bitmap moon = Properties.Resources.moon;

        private void hopePictureBox2_Click(object sender, EventArgs e)
        { 

            // Night Theme:
            if (night == 0)
            {
                hopePictureBox2.Image = sun;
                night += 1;
                tableLayoutPanel1.BackColor = Color.Black;
                comboBox1.BackColor = Color.Black;
                comboBox1.ForeColor = Color.White;
                textBox1.BackColor = Color.Black;
                textBox1.ForeColor = Color.White;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;
                poisonDataGridView1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView9.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                panel1.BackColor = Color.Black;
                panel2.BackColor = Color.Black;
                panel3.BackColor = Color.Black;
                poisonLabel1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonLabel4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
                poisonDataGridView1.ForeColor = Color.White;
                poisonDataGridView2.ForeColor = Color.White;
                poisonDataGridView3.ForeColor = Color.White;
                poisonDataGridView4.ForeColor = Color.White;
                poisonDataGridView5.ForeColor = Color.White;
                poisonDataGridView6.ForeColor = Color.White;
                poisonDataGridView7.ForeColor = Color.White;
                poisonDataGridView8.ForeColor = Color.White;
                poisonDataGridView9.ForeColor = Color.White;

            }
            else if (night == 1)
            {
                hopePictureBox2.Image = moon;
                night = 0;
                tableLayoutPanel1.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                button1.BackColor = Color.White;
                button1.ForeColor = Color.Black;
                button2.BackColor = Color.White;
                button2.ForeColor = Color.Black;
                comboBox1.BackColor = Color.White;
                comboBox1.ForeColor = Color.Black;
                poisonDataGridView1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                panel3.BackColor = Color.White;
                poisonLabel1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonLabel4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView2.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView3.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView4.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView5.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView6.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView7.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView8.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView9.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
                poisonDataGridView1.ForeColor = Color.Black;
                poisonDataGridView2.ForeColor = Color.Black;
                poisonDataGridView3.ForeColor = Color.Black;
                poisonDataGridView4.ForeColor = Color.Black;
                poisonDataGridView5.ForeColor = Color.Black;
                poisonDataGridView6.ForeColor = Color.Black;
                poisonDataGridView7.ForeColor = Color.Black;
                poisonDataGridView8.ForeColor = Color.Black;
                poisonDataGridView9.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchcategory();
            comboBox1.SelectedIndex = 0;
        }

        private void poisonDataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row0 = this.poisonDataGridView9.Rows[e.RowIndex];
                // Utility Object Initialization in Select Method:

                int rowIndex = -1;
                int rowIndex2 = -1;
                int rowIndex3 = -1;
                int rowIndex4 = -1;
                int rowIndex5 = -1;
                int rowIndex6 = -1;
                int rowIndex7 = -1;
                int rowIndex8 = -1;

                string id = poisonDataGridView9.SelectedRows[0].Cells[0].Value + string.Empty;

                try { 
                DataGridViewRow row1 = poisonDataGridView1.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                rowIndex = row1.Index;

                poisonDataGridView1.Rows[rowIndex].Selected = true;
                } catch (Exception celerror)
                {

                }

                try { 
                    DataGridViewRow row2 = poisonDataGridView2.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                    rowIndex2 = row2.Index;

                    poisonDataGridView2.Rows[rowIndex2].Selected = true;
                } catch (Exception celerror)
            {

            }

           try { 
                    DataGridViewRow row3 = poisonDataGridView3.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                    rowIndex3 = row3.Index;
                    poisonDataGridView3.Rows[rowIndex3].Selected = true;
                } catch (Exception celerror)
            {

            }
           try { 
                    DataGridViewRow row4 = poisonDataGridView4.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                    rowIndex4 = row4.Index;
                    poisonDataGridView4.Rows[rowIndex4].Selected = true;
                }
                catch (Exception celerror)
                {

                }
                try { 
                    DataGridViewRow row5 = poisonDataGridView5.Rows
                   .Cast<DataGridViewRow>()
                   .Where(r => r.Cells[0].Value.ToString().Equals(id))
                   .First();

                    rowIndex5 = row5.Index;
                    poisonDataGridView5.Rows[rowIndex5].Selected = true;
                }
                catch (Exception celerror)
                {

                }
                try { 
                    DataGridViewRow row6 = poisonDataGridView6.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                    rowIndex6 = row6.Index;
                    poisonDataGridView6.Rows[rowIndex6].Selected = true;
                }
                catch (Exception celerror)
                {

                }
                try { 
                    DataGridViewRow row7 = poisonDataGridView7.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                    rowIndex7 = row7.Index;
                    poisonDataGridView7.Rows[rowIndex7].Selected = true;
                }
                catch (Exception celerror)
                {

                }
                try { 
                    DataGridViewRow row8 = poisonDataGridView4.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                    rowIndex8 = row8.Index;
                    poisonDataGridView8.Rows[rowIndex8].Selected = true;
                }
                catch (Exception celerror)
                {

                }

            }
            
        }

        private void poisonDataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try {
                DataGridViewRow row = this.poisonDataGridView5.Rows[e.RowIndex];
                // Utility Object Initialization in Select Method:

                int rowIndex = -1;
                string id = poisonDataGridView5.SelectedRows[0].Cells[0].Value + string.Empty;
                DataGridViewRow row2 = poisonDataGridView1.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                rowIndex = row2.Index;

                poisonDataGridView1.Rows[rowIndex].Selected = true;
                }
                catch (Exception celerror)
                {

                }
            }
        }

        private void poisonDataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try { 
                DataGridViewRow row = this.poisonDataGridView6.Rows[e.RowIndex];
                // Utility Object Initialization in Select Method:

                int rowIndex = -1;
                string id = poisonDataGridView6.SelectedRows[0].Cells[0].Value + string.Empty;
                DataGridViewRow row2 = poisonDataGridView2.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                rowIndex = row2.Index;

                poisonDataGridView2.Rows[rowIndex].Selected = true;
            }
                catch (Exception celerror)
            {

            }
        }
        }

        private void poisonDataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try { 
                DataGridViewRow row = this.poisonDataGridView7.Rows[e.RowIndex];
                // Utility Object Initialization in Select Method:

                int rowIndex = -1;
                string id = poisonDataGridView7.SelectedRows[0].Cells[0].Value + string.Empty;
                DataGridViewRow row2 = poisonDataGridView3.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                rowIndex = row2.Index;

                poisonDataGridView3.Rows[rowIndex].Selected = true;
            }
                catch (Exception celerror)
            {

            }
        }
        }

        private void poisonDataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try { 
                DataGridViewRow row = this.poisonDataGridView8.Rows[e.RowIndex];
                // Utility Object Initialization in Select Method:

                int rowIndex = -1;
                string id = poisonDataGridView8.SelectedRows[0].Cells[0].Value + string.Empty;
                DataGridViewRow row2 = poisonDataGridView4.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(id))
                    .First();

                rowIndex = row2.Index;

                poisonDataGridView4.Rows[rowIndex].Selected = true;
            }
                catch (Exception celerror)
            {

            }
        }
        }

        private void borrowerTableBindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void propertyTableBindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void borrowerTableBindingSource3_CurrentChanged(object sender, EventArgs e)
        {
           
        }

        private void poisonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.poisonDataGridView1.Rows[e.RowIndex];
                    // Utility Object Initialization in Select Method:

                    int rowIndex = -1;
                    string id = poisonDataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                    DataGridViewRow row2 = poisonDataGridView5.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[0].Value.ToString().Equals(id))
                        .First();

                    rowIndex = row2.Index;

                    poisonDataGridView5.Rows[rowIndex].Selected = true;
                }
                catch (Exception celerror)
                {

                }
            }
        }

        private void poisonDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.poisonDataGridView2.Rows[e.RowIndex];
                    // Utility Object Initialization in Select Method:

                    int rowIndex = -1;
                    string id = poisonDataGridView2.SelectedRows[0].Cells[0].Value + string.Empty;
                    DataGridViewRow row2 = poisonDataGridView6.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[0].Value.ToString().Equals(id))
                        .First();

                    rowIndex = row2.Index;

                    poisonDataGridView6.Rows[rowIndex].Selected = true;
                }
                catch (Exception celerror)
                {

                }
            }
        }

        private void poisonDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.poisonDataGridView3.Rows[e.RowIndex];
                    // Utility Object Initialization in Select Method:

                    int rowIndex = -1;
                    string id = poisonDataGridView3.SelectedRows[0].Cells[0].Value + string.Empty;
                    DataGridViewRow row2 = poisonDataGridView7.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[0].Value.ToString().Equals(id))
                        .First();

                    rowIndex = row2.Index;

                    poisonDataGridView7.Rows[rowIndex].Selected = true;
                }
                catch (Exception celerror)
                {

                }
            }
        }

        private void poisonDataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.poisonDataGridView4.Rows[e.RowIndex];
                    // Utility Object Initialization in Select Method:

                    int rowIndex = -1;
                    string id = poisonDataGridView4.SelectedRows[0].Cells[0].Value + string.Empty;
                    DataGridViewRow row2 = poisonDataGridView8.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[0].Value.ToString().Equals(id))
                        .First();

                    rowIndex = row2.Index;

                    poisonDataGridView8.Rows[rowIndex].Selected = true;
                }
                catch (Exception celerror)
                {

                }
            }
        }
    }
}
