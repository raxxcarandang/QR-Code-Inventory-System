namespace OOProject
{
    partial class btnHam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnHam));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDashboard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.submenu1 = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.submenu2 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.pnAbout = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.sidebar.SuspendLayout();
            this.pnDashboard.SuspendLayout();
            this.menuContainer.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnAbout.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.nightControlBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 39);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(1118, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 1;
            this.nightControlBox1.Click += new System.EventHandler(this.nightControlBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "PROPERTY | MONITORING";
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.sidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidebar.Controls.Add(this.pnDashboard);
            this.sidebar.Controls.Add(this.menuContainer);
            this.sidebar.Controls.Add(this.pnAbout);
            this.sidebar.Controls.Add(this.pnLogout);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 39);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.sidebar.Size = new System.Drawing.Size(187, 618);
            this.sidebar.TabIndex = 1;
            // 
            // pnDashboard
            // 
            this.pnDashboard.Controls.Add(this.button1);
            this.pnDashboard.Location = new System.Drawing.Point(3, 33);
            this.pnDashboard.Name = "pnDashboard";
            this.pnDashboard.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.pnDashboard.Size = new System.Drawing.Size(193, 53);
            this.pnDashboard.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-19, -19);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(227, 91);
            this.button1.TabIndex = 4;
            this.button1.Text = "                  Dashboard";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuContainer
            // 
            this.menuContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menuContainer.Controls.Add(this.panel7);
            this.menuContainer.Controls.Add(this.panel3);
            this.menuContainer.Controls.Add(this.panel8);
            this.menuContainer.Location = new System.Drawing.Point(0, 89);
            this.menuContainer.Margin = new System.Windows.Forms.Padding(0);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(193, 53);
            this.menuContainer.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button7);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.panel7.Size = new System.Drawing.Size(193, 53);
            this.panel7.TabIndex = 7;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(-19, -19);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(227, 91);
            this.button7.TabIndex = 4;
            this.button7.Text = "                  Menu";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Controls.Add(this.submenu1);
            this.panel3.Controls.Add(this.menu);
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.panel3.Size = new System.Drawing.Size(193, 53);
            this.panel3.TabIndex = 6;
            // 
            // submenu1
            // 
            this.submenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.submenu1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submenu1.ForeColor = System.Drawing.Color.Transparent;
            this.submenu1.Image = ((System.Drawing.Image)(resources.GetObject("submenu1.Image")));
            this.submenu1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu1.Location = new System.Drawing.Point(-17, -19);
            this.submenu1.Name = "submenu1";
            this.submenu1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.submenu1.Size = new System.Drawing.Size(227, 91);
            this.submenu1.TabIndex = 5;
            this.submenu1.Text = "                  Properties";
            this.submenu1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu1.UseVisualStyleBackColor = false;
            this.submenu1.Click += new System.EventHandler(this.submenu1_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.ForeColor = System.Drawing.Color.Transparent;
            this.menu.Image = ((System.Drawing.Image)(resources.GetObject("menu.Image")));
            this.menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu.Location = new System.Drawing.Point(-19, -19);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.menu.Size = new System.Drawing.Size(227, 91);
            this.menu.TabIndex = 4;
            this.menu.Text = "                  Menu";
            this.menu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel8.Controls.Add(this.submenu2);
            this.panel8.Controls.Add(this.button9);
            this.panel8.Location = new System.Drawing.Point(0, 106);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.panel8.Size = new System.Drawing.Size(193, 53);
            this.panel8.TabIndex = 7;
            // 
            // submenu2
            // 
            this.submenu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.submenu2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submenu2.ForeColor = System.Drawing.Color.Transparent;
            this.submenu2.Image = ((System.Drawing.Image)(resources.GetObject("submenu2.Image")));
            this.submenu2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu2.Location = new System.Drawing.Point(-17, -19);
            this.submenu2.Name = "submenu2";
            this.submenu2.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.submenu2.Size = new System.Drawing.Size(227, 91);
            this.submenu2.TabIndex = 5;
            this.submenu2.Text = "                  Borrowers";
            this.submenu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu2.UseVisualStyleBackColor = false;
            this.submenu2.Click += new System.EventHandler(this.submenu2_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Transparent;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(-19, -19);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button9.Size = new System.Drawing.Size(227, 91);
            this.button9.TabIndex = 4;
            this.button9.Text = "                  Menu";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // pnAbout
            // 
            this.pnAbout.Controls.Add(this.button3);
            this.pnAbout.Location = new System.Drawing.Point(3, 145);
            this.pnAbout.Name = "pnAbout";
            this.pnAbout.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.pnAbout.Size = new System.Drawing.Size(193, 53);
            this.pnAbout.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-19, -19);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(227, 91);
            this.button3.TabIndex = 4;
            this.button3.Text = "                  About";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.button4);
            this.pnLogout.Location = new System.Drawing.Point(3, 204);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.pnLogout.Size = new System.Drawing.Size(193, 53);
            this.pnLogout.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-19, -19);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(227, 91);
            this.button4.TabIndex = 4;
            this.button4.Text = "                  Logout";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuTransition
            // 
            this.menuTransition.Interval = 10;
            this.menuTransition.Tick += new System.EventHandler(this.menuTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // btnHam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1257, 657);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "btnHam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTILITY | MONITORING";
            this.Load += new System.EventHandler(this.btnHam_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.pnDashboard.ResumeLayout(false);
            this.menuContainer.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.pnAbout.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnDashboard;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.FlowLayoutPanel menuContainer;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Button submenu1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button submenu2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnAbout;
        private System.Windows.Forms.Button button3;
    }
}

