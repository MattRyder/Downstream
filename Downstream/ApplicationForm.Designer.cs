namespace Downstream
{
    partial class ApplicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolTip iconTT;
        private System.Net.WebClient downloadClient;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            this.downloadClient = new System.Net.WebClient();
            this.iconTT = new System.Windows.Forms.ToolTip(this.components);
            this.picDownloadTrack = new System.Windows.Forms.PictureBox();
            this.picFacebook = new System.Windows.Forms.PictureBox();
            this.picTwitter = new System.Windows.Forms.PictureBox();
            this.picSettings = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lst_TrackListView = new GlacialComponents.Controls.GlacialList();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDownloadText = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pnlMiscSettings = new System.Windows.Forms.Panel();
            this.tabSearchTabs = new System.Windows.Forms.TabControl();
            this.pnlTrackControl = new System.Windows.Forms.Panel();
            this.picDurationSeek = new System.Windows.Forms.PictureBox();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblNowPlayingOther = new System.Windows.Forms.Label();
            this.picDurationBar = new System.Windows.Forms.PictureBox();
            this.lblNowPlaying = new System.Windows.Forms.Label();
            this.picPlayButton = new System.Windows.Forms.PictureBox();
            this.axWMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.picDownload = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picVolumeButton = new System.Windows.Forms.PictureBox();
            this.picVolumeBar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picSearchBox = new System.Windows.Forms.PictureBox();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDownloadTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlMiscSettings.SuspendLayout();
            this.pnlTrackControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDurationSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDurationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).BeginInit();
            this.picDownload.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVolumeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVolumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchBox)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadClient
            // 
            this.downloadClient.BaseAddress = "";
            this.downloadClient.CachePolicy = null;
            this.downloadClient.Credentials = null;
            this.downloadClient.Encoding = ((System.Text.Encoding)(resources.GetObject("downloadClient.Encoding")));
            this.downloadClient.Headers = ((System.Net.WebHeaderCollection)(resources.GetObject("downloadClient.Headers")));
            this.downloadClient.QueryString = ((System.Collections.Specialized.NameValueCollection)(resources.GetObject("downloadClient.QueryString")));
            this.downloadClient.UseDefaultCredentials = false;
            this.downloadClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.downloadClient_DownloadFileCompleted);
            this.downloadClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(this.downloadClient_DownloadProgressChanged);
            // 
            // picDownloadTrack
            // 
            this.picDownloadTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDownloadTrack.BackColor = System.Drawing.Color.Transparent;
            this.picDownloadTrack.BackgroundImage = global::Downstream.Properties.Resources.download;
            this.picDownloadTrack.Location = new System.Drawing.Point(660, 6);
            this.picDownloadTrack.Name = "picDownloadTrack";
            this.picDownloadTrack.Size = new System.Drawing.Size(32, 32);
            this.picDownloadTrack.TabIndex = 10;
            this.picDownloadTrack.TabStop = false;
            this.iconTT.SetToolTip(this.picDownloadTrack, "Download Selected Track(s)");
            this.picDownloadTrack.Click += new System.EventHandler(this.picDownloadTrack_Click);
            // 
            // picFacebook
            // 
            this.picFacebook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picFacebook.BackColor = System.Drawing.Color.Transparent;
            this.picFacebook.BackgroundImage = global::Downstream.Properties.Resources.facebook;
            this.picFacebook.Location = new System.Drawing.Point(740, 6);
            this.picFacebook.Name = "picFacebook";
            this.picFacebook.Size = new System.Drawing.Size(32, 32);
            this.picFacebook.TabIndex = 3;
            this.picFacebook.TabStop = false;
            this.iconTT.SetToolTip(this.picFacebook, "Post the current track as a Facebook Status");
            this.picFacebook.Click += new System.EventHandler(this.picFacebook_Click);
            // 
            // picTwitter
            // 
            this.picTwitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picTwitter.BackColor = System.Drawing.Color.Transparent;
            this.picTwitter.BackgroundImage = global::Downstream.Properties.Resources.twitter;
            this.picTwitter.Location = new System.Drawing.Point(700, 6);
            this.picTwitter.Name = "picTwitter";
            this.picTwitter.Size = new System.Drawing.Size(32, 32);
            this.picTwitter.TabIndex = 7;
            this.picTwitter.TabStop = false;
            this.iconTT.SetToolTip(this.picTwitter, "Tweet the current track");
            this.picTwitter.Click += new System.EventHandler(this.picTwitter_Click);
            // 
            // picSettings
            // 
            this.picSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSettings.BackColor = System.Drawing.Color.Transparent;
            this.picSettings.Image = global::Downstream.Properties.Resources.SettingsImage;
            this.picSettings.Location = new System.Drawing.Point(620, 6);
            this.picSettings.Name = "picSettings";
            this.picSettings.Size = new System.Drawing.Size(32, 32);
            this.picSettings.TabIndex = 8;
            this.picSettings.TabStop = false;
            this.iconTT.SetToolTip(this.picSettings, "Downstream Preferences");
            this.picSettings.Click += new System.EventHandler(this.picSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lst_TrackListView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 287);
            this.panel1.TabIndex = 4;
            // 
            // lst_TrackListView
            // 
            this.lst_TrackListView.AllowColumnResize = true;
            this.lst_TrackListView.AllowMultiselect = true;
            this.lst_TrackListView.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lst_TrackListView.AlternatingColors = false;
            this.lst_TrackListView.AutoHeight = true;
            this.lst_TrackListView.BackColor = System.Drawing.Color.White;
            this.lst_TrackListView.BackgroundImage = global::Downstream.Properties.Resources.formbackground;
            this.lst_TrackListView.BackgroundStretchToFit = true;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "col_TrackTitle";
            glColumn4.NumericSort = false;
            glColumn4.Text = "Track Title";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 300;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "col_TrackArtist";
            glColumn5.NumericSort = false;
            glColumn5.Text = "Track Artist";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 250;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "col_TrackAlbum";
            glColumn6.NumericSort = false;
            glColumn6.Text = "Track Album";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 200;
            this.lst_TrackListView.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn4,
            glColumn5,
            glColumn6});
            this.lst_TrackListView.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lst_TrackListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_TrackListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lst_TrackListView.FullRowSelect = true;
            this.lst_TrackListView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_TrackListView.GridLines = GlacialComponents.Controls.GLGridLines.gridVertical;
            this.lst_TrackListView.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lst_TrackListView.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lst_TrackListView.HeaderHeight = 22;
            this.lst_TrackListView.HeaderVisible = true;
            this.lst_TrackListView.HeaderWordWrap = false;
            this.lst_TrackListView.HotColumnTracking = false;
            this.lst_TrackListView.HotItemTracking = false;
            this.lst_TrackListView.HotTrackingColor = System.Drawing.Color.White;
            this.lst_TrackListView.HoverEvents = false;
            this.lst_TrackListView.HoverTime = 1;
            this.lst_TrackListView.ImageList = null;
            this.lst_TrackListView.ItemHeight = 20;
            this.lst_TrackListView.ItemWordWrap = false;
            this.lst_TrackListView.Location = new System.Drawing.Point(0, 0);
            this.lst_TrackListView.Name = "lst_TrackListView";
            this.lst_TrackListView.Selectable = true;
            this.lst_TrackListView.SelectedTextColor = System.Drawing.Color.White;
            this.lst_TrackListView.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lst_TrackListView.ShowBorder = true;
            this.lst_TrackListView.ShowFocusRect = false;
            this.lst_TrackListView.Size = new System.Drawing.Size(784, 287);
            this.lst_TrackListView.SortType = GlacialComponents.Controls.SortTypes.QuickSort;
            this.lst_TrackListView.SuperFlatHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_TrackListView.TabIndex = 0;
            this.lst_TrackListView.Text = "Track List";
            this.lst_TrackListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_TrackListView_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressBar,
            this.tsStatusText,
            this.tsDownloadText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tsStatusText
            // 
            this.tsStatusText.Name = "tsStatusText";
            this.tsStatusText.Size = new System.Drawing.Size(0, 17);
            // 
            // tsDownloadText
            // 
            this.tsDownloadText.Name = "tsDownloadText";
            this.tsDownloadText.Size = new System.Drawing.Size(0, 17);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // pnlMiscSettings
            // 
            this.pnlMiscSettings.BackgroundImage = global::Downstream.Properties.Resources.SearchBarBackground;
            this.pnlMiscSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMiscSettings.Controls.Add(this.picDownloadTrack);
            this.pnlMiscSettings.Controls.Add(this.picFacebook);
            this.pnlMiscSettings.Controls.Add(this.picTwitter);
            this.pnlMiscSettings.Controls.Add(this.picSettings);
            this.pnlMiscSettings.Controls.Add(this.tabSearchTabs);
            this.pnlMiscSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiscSettings.Location = new System.Drawing.Point(0, 141);
            this.pnlMiscSettings.Name = "pnlMiscSettings";
            this.pnlMiscSettings.Size = new System.Drawing.Size(784, 47);
            this.pnlMiscSettings.TabIndex = 5;
            // 
            // tabSearchTabs
            // 
            this.tabSearchTabs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabSearchTabs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSearchTabs.Location = new System.Drawing.Point(0, 23);
            this.tabSearchTabs.Name = "tabSearchTabs";
            this.tabSearchTabs.SelectedIndex = 0;
            this.tabSearchTabs.Size = new System.Drawing.Size(784, 24);
            this.tabSearchTabs.TabIndex = 9;
            this.tabSearchTabs.Visible = false;
            this.tabSearchTabs.SelectedIndexChanged += new System.EventHandler(this.tabSearchTabs_SelectedIndexChanged);
            this.tabSearchTabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabSearchTabs_MouseClick);
            // 
            // pnlTrackControl
            // 
            this.pnlTrackControl.BackColor = System.Drawing.Color.Transparent;
            this.pnlTrackControl.BackgroundImage = global::Downstream.Properties.Resources.FormBG;
            this.pnlTrackControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTrackControl.Controls.Add(this.picDurationSeek);
            this.pnlTrackControl.Controls.Add(this.lblCurrentTime);
            this.pnlTrackControl.Controls.Add(this.lblNowPlayingOther);
            this.pnlTrackControl.Controls.Add(this.picDurationBar);
            this.pnlTrackControl.Controls.Add(this.lblNowPlaying);
            this.pnlTrackControl.Controls.Add(this.picPlayButton);
            this.pnlTrackControl.Controls.Add(this.axWMP);
            this.pnlTrackControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTrackControl.Location = new System.Drawing.Point(0, 62);
            this.pnlTrackControl.Name = "pnlTrackControl";
            this.pnlTrackControl.Size = new System.Drawing.Size(784, 79);
            this.pnlTrackControl.TabIndex = 1;
            // 
            // picDurationSeek
            // 
            this.picDurationSeek.BackColor = System.Drawing.Color.Transparent;
            this.picDurationSeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picDurationSeek.Image = ((System.Drawing.Image)(resources.GetObject("picDurationSeek.Image")));
            this.picDurationSeek.Location = new System.Drawing.Point(86, 55);
            this.picDurationSeek.Name = "picDurationSeek";
            this.picDurationSeek.Size = new System.Drawing.Size(16, 16);
            this.picDurationSeek.TabIndex = 14;
            this.picDurationSeek.TabStop = false;
            this.picDurationSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDurationSeek_MouseDown);
            this.picDurationSeek.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDurationSeek_MouseMove);
            this.picDurationSeek.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDurationSeek_MouseUp);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentTime.Location = new System.Drawing.Point(342, 55);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(34, 15);
            this.lblCurrentTime.TabIndex = 15;
            this.lblCurrentTime.Text = "00:00";
            // 
            // lblNowPlayingOther
            // 
            this.lblNowPlayingOther.AutoSize = true;
            this.lblNowPlayingOther.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblNowPlayingOther.ForeColor = System.Drawing.Color.White;
            this.lblNowPlayingOther.Location = new System.Drawing.Point(83, 35);
            this.lblNowPlayingOther.Name = "lblNowPlayingOther";
            this.lblNowPlayingOther.Size = new System.Drawing.Size(88, 17);
            this.lblNowPlayingOther.TabIndex = 13;
            this.lblNowPlayingOther.Text = "Artist - Album";
            // 
            // picDurationBar
            // 
            this.picDurationBar.Image = ((System.Drawing.Image)(resources.GetObject("picDurationBar.Image")));
            this.picDurationBar.Location = new System.Drawing.Point(86, 60);
            this.picDurationBar.Name = "picDurationBar";
            this.picDurationBar.Size = new System.Drawing.Size(250, 10);
            this.picDurationBar.TabIndex = 12;
            this.picDurationBar.TabStop = false;
            // 
            // lblNowPlaying
            // 
            this.lblNowPlaying.AutoSize = true;
            this.lblNowPlaying.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowPlaying.ForeColor = System.Drawing.Color.White;
            this.lblNowPlaying.Location = new System.Drawing.Point(82, 15);
            this.lblNowPlaying.Name = "lblNowPlaying";
            this.lblNowPlaying.Size = new System.Drawing.Size(92, 20);
            this.lblNowPlaying.TabIndex = 11;
            this.lblNowPlaying.Text = "Now Playing";
            // 
            // picPlayButton
            // 
            this.picPlayButton.Image = ((System.Drawing.Image)(resources.GetObject("picPlayButton.Image")));
            this.picPlayButton.Location = new System.Drawing.Point(12, 6);
            this.picPlayButton.Name = "picPlayButton";
            this.picPlayButton.Size = new System.Drawing.Size(64, 64);
            this.picPlayButton.TabIndex = 10;
            this.picPlayButton.TabStop = false;
            this.picPlayButton.Click += new System.EventHandler(this.picPlayButton_Click);
            // 
            // axWMP
            // 
            this.axWMP.Enabled = true;
            this.axWMP.Location = new System.Drawing.Point(553, 35);
            this.axWMP.Name = "axWMP";
            this.axWMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWMP.OcxState")));
            this.axWMP.Size = new System.Drawing.Size(219, 35);
            this.axWMP.TabIndex = 9;
            this.axWMP.TabStop = false;
            this.axWMP.Visible = false;
            // 
            // picDownload
            // 
            this.picDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.picDownload.BackgroundImage = global::Downstream.Properties.Resources.SearchBarBackground;
            this.picDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDownload.Controls.Add(this.panel3);
            this.picDownload.Controls.Add(this.label1);
            this.picDownload.Controls.Add(this.picSearchBox);
            this.picDownload.Controls.Add(this.txtSearchBox);
            this.picDownload.Dock = System.Windows.Forms.DockStyle.Top;
            this.picDownload.Location = new System.Drawing.Point(0, 0);
            this.picDownload.Name = "picDownload";
            this.picDownload.Size = new System.Drawing.Size(784, 62);
            this.picDownload.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picVolumeButton);
            this.panel3.Controls.Add(this.picVolumeBar);
            this.panel3.Location = new System.Drawing.Point(613, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(121, 22);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // picVolumeButton
            // 
            this.picVolumeButton.Image = ((System.Drawing.Image)(resources.GetObject("picVolumeButton.Image")));
            this.picVolumeButton.Location = new System.Drawing.Point(52, 3);
            this.picVolumeButton.Name = "picVolumeButton";
            this.picVolumeButton.Size = new System.Drawing.Size(16, 16);
            this.picVolumeButton.TabIndex = 5;
            this.picVolumeButton.TabStop = false;
            this.picVolumeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picVolumeButton_MouseDown);
            this.picVolumeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picVolumeButton_MouseMove);
            this.picVolumeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picVolumeButton_MouseUp);
            // 
            // picVolumeBar
            // 
            this.picVolumeBar.BackgroundImage = global::Downstream.Properties.Resources.VolumeBar;
            this.picVolumeBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picVolumeBar.Location = new System.Drawing.Point(7, 7);
            this.picVolumeBar.Name = "picVolumeBar";
            this.picVolumeBar.Size = new System.Drawing.Size(100, 8);
            this.picVolumeBar.TabIndex = 3;
            this.picVolumeBar.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "SEARCH";
            // 
            // picSearchBox
            // 
            this.picSearchBox.BackColor = System.Drawing.Color.White;
            this.picSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSearchBox.Image = global::Downstream.Properties.Resources.searchbutton;
            this.picSearchBox.Location = new System.Drawing.Point(469, 22);
            this.picSearchBox.Name = "picSearchBox";
            this.picSearchBox.Size = new System.Drawing.Size(120, 20);
            this.picSearchBox.TabIndex = 1;
            this.picSearchBox.TabStop = false;
            this.picSearchBox.Click += new System.EventHandler(this.picSearchBox_Click);
            this.picSearchBox.MouseEnter += new System.EventHandler(this.picSearchBox_MouseEnter);
            this.picSearchBox.MouseLeave += new System.EventHandler(this.picSearchBox_MouseLeave);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BackColor = System.Drawing.Color.Gray;
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtSearchBox.Location = new System.Drawing.Point(6, 20);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(457, 22);
            this.txtSearchBox.TabIndex = 0;
            this.txtSearchBox.Text = "Search by Artist, Song Name or Album";
            this.txtSearchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearchBox_MouseClick);
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyDown);
            this.txtSearchBox.Leave += new System.EventHandler(this.txtSearchBox_Leave);
            // 
            // ApplicationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMiscSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlTrackControl);
            this.Controls.Add(this.picDownload);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(770, 460);
            this.Name = "ApplicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downstream";
            ((System.ComponentModel.ISupportInitialize)(this.picDownloadTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlMiscSettings.ResumeLayout(false);
            this.pnlTrackControl.ResumeLayout(false);
            this.pnlTrackControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDurationSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDurationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).EndInit();
            this.picDownload.ResumeLayout(false);
            this.picDownload.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVolumeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVolumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMiscSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.PictureBox picSearchBox;
        private System.Windows.Forms.Panel picDownload;
        private System.Windows.Forms.Panel pnlTrackControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picSettings;
        private System.Windows.Forms.PictureBox picTwitter;
        private System.Windows.Forms.PictureBox picFacebook;
        private AxWMPLib.AxWindowsMediaPlayer axWMP;
        private System.Windows.Forms.PictureBox picPlayButton;
        private System.Windows.Forms.PictureBox picDurationBar;
        private System.Windows.Forms.Label lblNowPlaying;
        private System.Windows.Forms.TabControl tabSearchTabs;
        private System.Windows.Forms.Label lblNowPlayingOther;
        private System.Windows.Forms.PictureBox picDurationSeek;
        private System.Windows.Forms.Label lblCurrentTime;
        private GlacialComponents.Controls.GlacialList lst_TrackListView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picVolumeButton;
        private System.Windows.Forms.PictureBox picVolumeBar;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusText;
        private System.Windows.Forms.PictureBox picDownloadTrack;
        private System.Windows.Forms.ToolStripStatusLabel tsDownloadText;


    }
}

