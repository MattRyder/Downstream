namespace Downstream
{
    partial class PreferenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferenceForm));
            this.tabPrefPages = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLimitedResults = new System.Windows.Forms.CheckBox();
            this.chkDuplicates = new System.Windows.Forms.CheckBox();
            this.chkRelevence = new System.Windows.Forms.CheckBox();
            this.tabPostStyle = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblFormatEx = new System.Windows.Forms.Label();
            this.lblFormatTitle = new System.Windows.Forms.Label();
            this.cboPostStyle = new System.Windows.Forms.ComboBox();
            this.tabTwitter = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClearTwitterData = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTwitterPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTwitterUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTwitterOutput = new System.Windows.Forms.Label();
            this.btnTwitterAuth = new System.Windows.Forms.Button();
            this.tabFacebook = new System.Windows.Forms.TabPage();
            this.lblFacebookOutput = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRemoveFBData = new System.Windows.Forms.Button();
            this.btnFBAuth = new System.Windows.Forms.Button();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblAbout = new System.Windows.Forms.Label();
            this.picDownstream = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFlamestart = new System.Windows.Forms.Label();
            this.lblLogieWebsite = new System.Windows.Forms.LinkLabel();
            this.lblLogie = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSaveLocation = new System.Windows.Forms.Button();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.tabPrefPages.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPostStyle.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabTwitter.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabFacebook.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDownstream)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrefPages
            // 
            this.tabPrefPages.Controls.Add(this.tabGeneral);
            this.tabPrefPages.Controls.Add(this.tabPostStyle);
            this.tabPrefPages.Controls.Add(this.tabTwitter);
            this.tabPrefPages.Controls.Add(this.tabFacebook);
            this.tabPrefPages.Controls.Add(this.tabAbout);
            this.tabPrefPages.Location = new System.Drawing.Point(10, 12);
            this.tabPrefPages.Name = "tabPrefPages";
            this.tabPrefPages.SelectedIndex = 0;
            this.tabPrefPages.Size = new System.Drawing.Size(321, 349);
            this.tabPrefPages.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBox8);
            this.tabGeneral.Controls.Add(this.groupBox2);
            this.tabGeneral.Controls.Add(this.groupBox1);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(313, 323);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOutput);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnClearData);
            this.groupBox2.Location = new System.Drawing.Point(6, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 83);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced Options";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(6, 66);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 13);
            this.lblOutput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clear Cached Data";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(109, 30);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(77, 23);
            this.btnClearData.TabIndex = 1;
            this.btnClearData.Text = "Clear";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLimitedResults);
            this.groupBox1.Controls.Add(this.chkDuplicates);
            this.groupBox1.Controls.Add(this.chkRelevence);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(301, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Optimization";
            // 
            // chkLimitedResults
            // 
            this.chkLimitedResults.AutoSize = true;
            this.chkLimitedResults.Location = new System.Drawing.Point(6, 77);
            this.chkLimitedResults.Name = "chkLimitedResults";
            this.chkLimitedResults.Size = new System.Drawing.Size(121, 17);
            this.chkLimitedResults.TabIndex = 2;
            this.chkLimitedResults.Text = "Return Less Results";
            this.chkLimitedResults.UseVisualStyleBackColor = true;
            this.chkLimitedResults.CheckedChanged += new System.EventHandler(this.chkLimitedResults_CheckedChanged);
            // 
            // chkDuplicates
            // 
            this.chkDuplicates.AutoSize = true;
            this.chkDuplicates.Location = new System.Drawing.Point(6, 54);
            this.chkDuplicates.Name = "chkDuplicates";
            this.chkDuplicates.Size = new System.Drawing.Size(119, 17);
            this.chkDuplicates.TabIndex = 1;
            this.chkDuplicates.Text = "Remove Duplicates";
            this.chkDuplicates.UseVisualStyleBackColor = true;
            this.chkDuplicates.CheckedChanged += new System.EventHandler(this.chkDuplicates_CheckedChanged);
            // 
            // chkRelevence
            // 
            this.chkRelevence.AutoSize = true;
            this.chkRelevence.Location = new System.Drawing.Point(6, 31);
            this.chkRelevence.Name = "chkRelevence";
            this.chkRelevence.Size = new System.Drawing.Size(170, 17);
            this.chkRelevence.TabIndex = 0;
            this.chkRelevence.Text = "Arrange Results by Relevence";
            this.chkRelevence.UseVisualStyleBackColor = true;
            this.chkRelevence.CheckedChanged += new System.EventHandler(this.chkRelevence_CheckedChanged);
            // 
            // tabPostStyle
            // 
            this.tabPostStyle.Controls.Add(this.groupBox5);
            this.tabPostStyle.Location = new System.Drawing.Point(4, 22);
            this.tabPostStyle.Name = "tabPostStyle";
            this.tabPostStyle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPostStyle.Size = new System.Drawing.Size(313, 323);
            this.tabPostStyle.TabIndex = 3;
            this.tabPostStyle.Text = "Post Style";
            this.tabPostStyle.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblFormatEx);
            this.groupBox5.Controls.Add(this.lblFormatTitle);
            this.groupBox5.Controls.Add(this.cboPostStyle);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(301, 138);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Twitter / Facebook Style";
            // 
            // lblFormatEx
            // 
            this.lblFormatEx.AutoSize = true;
            this.lblFormatEx.Location = new System.Drawing.Point(6, 86);
            this.lblFormatEx.Name = "lblFormatEx";
            this.lblFormatEx.Size = new System.Drawing.Size(0, 13);
            this.lblFormatEx.TabIndex = 2;
            // 
            // lblFormatTitle
            // 
            this.lblFormatTitle.AutoSize = true;
            this.lblFormatTitle.Location = new System.Drawing.Point(3, 64);
            this.lblFormatTitle.Name = "lblFormatTitle";
            this.lblFormatTitle.Size = new System.Drawing.Size(42, 13);
            this.lblFormatTitle.TabIndex = 1;
            this.lblFormatTitle.Text = "Format:";
            // 
            // cboPostStyle
            // 
            this.cboPostStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPostStyle.FormattingEnabled = true;
            this.cboPostStyle.Items.AddRange(new object[] {
            "Simple Style",
            "Attribution Style",
            "Now-Playing Style"});
            this.cboPostStyle.Location = new System.Drawing.Point(6, 30);
            this.cboPostStyle.Name = "cboPostStyle";
            this.cboPostStyle.Size = new System.Drawing.Size(289, 21);
            this.cboPostStyle.TabIndex = 0;
            this.cboPostStyle.SelectedIndexChanged += new System.EventHandler(this.cboPostStyle_SelectedIndexChanged);
            // 
            // tabTwitter
            // 
            this.tabTwitter.Controls.Add(this.label4);
            this.tabTwitter.Controls.Add(this.groupBox4);
            this.tabTwitter.Controls.Add(this.groupBox3);
            this.tabTwitter.Controls.Add(this.lblTwitterOutput);
            this.tabTwitter.Controls.Add(this.btnTwitterAuth);
            this.tabTwitter.Location = new System.Drawing.Point(4, 22);
            this.tabTwitter.Name = "tabTwitter";
            this.tabTwitter.Padding = new System.Windows.Forms.Padding(3);
            this.tabTwitter.Size = new System.Drawing.Size(313, 323);
            this.tabTwitter.TabIndex = 1;
            this.tabTwitter.Text = "Twitter";
            this.tabTwitter.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 26);
            this.label4.TabIndex = 15;
            this.label4.Text = "Clicking this button will sign you out of Downstream,\r\nand remove all details all" +
                "owing authentication to Twitter.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnClearTwitterData);
            this.groupBox4.Location = new System.Drawing.Point(6, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 71);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // btnClearTwitterData
            // 
            this.btnClearTwitterData.Location = new System.Drawing.Point(11, 19);
            this.btnClearTwitterData.Name = "btnClearTwitterData";
            this.btnClearTwitterData.Size = new System.Drawing.Size(280, 40);
            this.btnClearTwitterData.TabIndex = 0;
            this.btnClearTwitterData.Text = "Remove All Twitter Data";
            this.btnClearTwitterData.UseVisualStyleBackColor = true;
            this.btnClearTwitterData.Click += new System.EventHandler(this.btnClearTwitterData_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTwitterPass);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtTwitterUser);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(9, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 90);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 1 -Twitter Login Credentials";
            // 
            // txtTwitterPass
            // 
            this.txtTwitterPass.Location = new System.Drawing.Point(69, 49);
            this.txtTwitterPass.Name = "txtTwitterPass";
            this.txtTwitterPass.PasswordChar = '●';
            this.txtTwitterPass.Size = new System.Drawing.Size(182, 20);
            this.txtTwitterPass.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // txtTwitterUser
            // 
            this.txtTwitterUser.Location = new System.Drawing.Point(69, 25);
            this.txtTwitterUser.Name = "txtTwitterUser";
            this.txtTwitterUser.Size = new System.Drawing.Size(182, 20);
            this.txtTwitterUser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // lblTwitterOutput
            // 
            this.lblTwitterOutput.AutoSize = true;
            this.lblTwitterOutput.Location = new System.Drawing.Point(13, 179);
            this.lblTwitterOutput.Name = "lblTwitterOutput";
            this.lblTwitterOutput.Size = new System.Drawing.Size(0, 13);
            this.lblTwitterOutput.TabIndex = 2;
            // 
            // btnTwitterAuth
            // 
            this.btnTwitterAuth.Location = new System.Drawing.Point(16, 115);
            this.btnTwitterAuth.Name = "btnTwitterAuth";
            this.btnTwitterAuth.Size = new System.Drawing.Size(280, 40);
            this.btnTwitterAuth.TabIndex = 1;
            this.btnTwitterAuth.Text = "Step 2 - Twitter Authorization";
            this.btnTwitterAuth.UseVisualStyleBackColor = true;
            this.btnTwitterAuth.Click += new System.EventHandler(this.btnTwitterAuth_Click);
            // 
            // tabFacebook
            // 
            this.tabFacebook.Controls.Add(this.lblFacebookOutput);
            this.tabFacebook.Controls.Add(this.label6);
            this.tabFacebook.Controls.Add(this.label5);
            this.tabFacebook.Controls.Add(this.groupBox6);
            this.tabFacebook.Controls.Add(this.btnFBAuth);
            this.tabFacebook.Location = new System.Drawing.Point(4, 22);
            this.tabFacebook.Name = "tabFacebook";
            this.tabFacebook.Size = new System.Drawing.Size(313, 323);
            this.tabFacebook.TabIndex = 2;
            this.tabFacebook.Text = "Facebook";
            this.tabFacebook.UseVisualStyleBackColor = true;
            // 
            // lblFacebookOutput
            // 
            this.lblFacebookOutput.AutoSize = true;
            this.lblFacebookOutput.Location = new System.Drawing.Point(13, 179);
            this.lblFacebookOutput.Name = "lblFacebookOutput";
            this.lblFacebookOutput.Size = new System.Drawing.Size(0, 13);
            this.lblFacebookOutput.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 26);
            this.label6.TabIndex = 14;
            this.label6.Text = "Clicking this button will sign you out of Downstream,\r\nand remove all details all" +
                "owing authentication to Facebook.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 39);
            this.label5.TabIndex = 13;
            this.label5.Text = "Click the button below to start the authentication proceedure.\r\nEnter your Facebo" +
                "ok login email and password, and click \r\n\"Remember Downstream\" to keep the app a" +
                "uthenticated.";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnRemoveFBData);
            this.groupBox6.Location = new System.Drawing.Point(6, 246);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(301, 71);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            // 
            // btnRemoveFBData
            // 
            this.btnRemoveFBData.Location = new System.Drawing.Point(11, 19);
            this.btnRemoveFBData.Name = "btnRemoveFBData";
            this.btnRemoveFBData.Size = new System.Drawing.Size(280, 40);
            this.btnRemoveFBData.TabIndex = 0;
            this.btnRemoveFBData.Text = "Remove All Facebook Data";
            this.btnRemoveFBData.UseVisualStyleBackColor = true;
            this.btnRemoveFBData.Click += new System.EventHandler(this.btnRemoveFBData_Click);
            // 
            // btnFBAuth
            // 
            this.btnFBAuth.Location = new System.Drawing.Point(16, 115);
            this.btnFBAuth.Name = "btnFBAuth";
            this.btnFBAuth.Size = new System.Drawing.Size(280, 40);
            this.btnFBAuth.TabIndex = 9;
            this.btnFBAuth.Text = "Facebook Authorization";
            this.btnFBAuth.UseVisualStyleBackColor = true;
            this.btnFBAuth.Click += new System.EventHandler(this.btnFBAuth_Click);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.linkLabel1);
            this.tabAbout.Controls.Add(this.lblAbout);
            this.tabAbout.Controls.Add(this.picDownstream);
            this.tabAbout.Controls.Add(this.groupBox7);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(313, 323);
            this.tabAbout.TabIndex = 4;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(89, 137);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(135, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "© Matt Ryder 2011";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.Location = new System.Drawing.Point(73, 116);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(0, 21);
            this.lblAbout.TabIndex = 2;
            // 
            // picDownstream
            // 
            this.picDownstream.BackgroundImage = global::Downstream.Properties.Resources.downstreamicon;
            this.picDownstream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDownstream.Location = new System.Drawing.Point(108, 17);
            this.picDownstream.Name = "picDownstream";
            this.picDownstream.Size = new System.Drawing.Size(96, 96);
            this.picDownstream.TabIndex = 1;
            this.picDownstream.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.lblFlamestart);
            this.groupBox7.Controls.Add(this.lblLogieWebsite);
            this.groupBox7.Controls.Add(this.lblLogie);
            this.groupBox7.Location = new System.Drawing.Point(4, 185);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(303, 132);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Special Thanks";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 26);
            this.label8.TabIndex = 3;
            this.label8.Text = "Izzie Ryder - Creating the download icon with better\r\n Photoshop skills than myse" +
                "lf.\r\n";
            // 
            // lblFlamestart
            // 
            this.lblFlamestart.AutoSize = true;
            this.lblFlamestart.Location = new System.Drawing.Point(6, 69);
            this.lblFlamestart.Name = "lblFlamestart";
            this.lblFlamestart.Size = new System.Drawing.Size(223, 13);
            this.lblFlamestart.TabIndex = 2;
            this.lblFlamestart.Text = "Flamestart - For Downstream\'s awesome Icon!";
            // 
            // lblLogieWebsite
            // 
            this.lblLogieWebsite.AutoSize = true;
            this.lblLogieWebsite.Location = new System.Drawing.Point(204, 43);
            this.lblLogieWebsite.Name = "lblLogieWebsite";
            this.lblLogieWebsite.Size = new System.Drawing.Size(46, 13);
            this.lblLogieWebsite.TabIndex = 1;
            this.lblLogieWebsite.TabStop = true;
            this.lblLogieWebsite.Text = "Website";
            // 
            // lblLogie
            // 
            this.lblLogie.AutoSize = true;
            this.lblLogie.Location = new System.Drawing.Point(6, 30);
            this.lblLogie.Name = "lblLogie";
            this.lblLogie.Size = new System.Drawing.Size(283, 26);
            this.lblLogie.TabIndex = 0;
            this.lblLogie.Text = "Liam Logue - Downstream\'s Design, and the helpful tweets\r\n making me get on and f" +
                "inish the project!";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtSaveLocation);
            this.groupBox8.Controls.Add(this.btnSaveLocation);
            this.groupBox8.Location = new System.Drawing.Point(6, 142);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(301, 76);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Downloads Folder";
            // 
            // btnSaveLocation
            // 
            this.btnSaveLocation.Location = new System.Drawing.Point(206, 45);
            this.btnSaveLocation.Name = "btnSaveLocation";
            this.btnSaveLocation.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLocation.TabIndex = 0;
            this.btnSaveLocation.Text = "Choose...";
            this.btnSaveLocation.UseVisualStyleBackColor = true;
            this.btnSaveLocation.Click += new System.EventHandler(this.btnSaveLocation_Click);
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Enabled = false;
            this.txtSaveLocation.Location = new System.Drawing.Point(9, 19);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.Size = new System.Drawing.Size(272, 20);
            this.txtSaveLocation.TabIndex = 4;
            // 
            // PreferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(340, 370);
            this.Controls.Add(this.tabPrefPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreferenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downstream Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferenceForm_FormClosing);
            this.tabPrefPages.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPostStyle.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabTwitter.ResumeLayout(false);
            this.tabTwitter.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabFacebook.ResumeLayout(false);
            this.tabFacebook.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDownstream)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrefPages;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabTwitter;
        private System.Windows.Forms.TabPage tabFacebook;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.CheckBox chkDuplicates;
        private System.Windows.Forms.CheckBox chkRelevence;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.CheckBox chkLimitedResults;
        private System.Windows.Forms.Button btnTwitterAuth;
        private System.Windows.Forms.Label lblTwitterOutput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTwitterPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTwitterUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClearTwitterData;
        private System.Windows.Forms.TabPage tabPostStyle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblFormatEx;
        private System.Windows.Forms.Label lblFormatTitle;
        private System.Windows.Forms.ComboBox cboPostStyle;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnRemoveFBData;
        private System.Windows.Forms.Button btnFBAuth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFacebookOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.PictureBox picDownstream;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFlamestart;
        private System.Windows.Forms.LinkLabel lblLogieWebsite;
        private System.Windows.Forms.Label lblLogie;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtSaveLocation;
        private System.Windows.Forms.Button btnSaveLocation;
    }
}