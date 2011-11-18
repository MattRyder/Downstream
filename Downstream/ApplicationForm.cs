using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;
using DownstreamLib;
using Facebook;
using GlacialComponents.Controls;
using Twitterizer;
using Runtouch;
using System.Net;


namespace Downstream
{
    public partial class ApplicationForm : Form
    {
        //Server for sending error reports:
        Server errorServer = new Server("server.microlite7.com", "/httpdocs", new System.Net.NetworkCredential("runtouch", "password"));

        /// <summary>
        /// Current Track being played.
        /// </summary>
        private Track NowPlaying;
        System.Windows.Forms.Timer currentPositionTimer = new System.Windows.Forms.Timer();
        private String SearchTerm = "";

        private double pixelsPerSecond = 0;         //Calculated by: (tracklength - durationbarlength)
        private double timeSinceLastUpdate = 0.0;   //How much time has passed since the bar last moved?

        private static string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Downstream";
        private static string cacheDirectory = dataDirectory + "\\Cache";

        enum PlayStates
        {
            Playing,
            Paused,
            Stopped
        }

        //Manages the states that the Media Controller has.
        PlayStates MediaState = new PlayStates();

        public ApplicationForm()
        {
            InitializeComponent();
            InitalizeCache();

            //Assume "first-run", so show help, if the user doesn't want it.
            if (!Properties.Settings.Default.dontShowHelp)
            {
                HelpForm hf = new HelpForm();
                //Pop it non-modal, they might minimize and reference it occasionally.
                hf.Show();
            }

            //Create a default directory
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\Downstream Downloads\\"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\Downstream Downloads\\");
            }

            axWMP.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWMP_PlayStateChange);
        }
            
        #region Cache Init, Loading, Saving
        private void InitalizeCache()
        {
            try
            {
                if (!Directory.Exists(cacheDirectory))
                    Directory.CreateDirectory(cacheDirectory);
            }
            catch (Exception e) { new ErrorReport(e).Upload(errorServer); }
        }

        /// <summary>
        /// Loads a file containing Track data from a local file on cache.
        /// </summary>
        /// <param name="strSearchTerm"></param>
        /// <returns></returns>
        private List<Track> LoadCachedResult(string strSearchTerm)
        {
            strSearchTerm = strSearchTerm.Replace("/", "±");
            string cachedResult = cacheDirectory + "\\" + strSearchTerm;

            //If there's a cached result, and the Search Term isn't nothing:
            if (File.Exists(cachedResult) && !String.IsNullOrEmpty(strSearchTerm))
            {
                try
                {
                    List<Track> TrackList = new List<Track>();

                    //Load the cached Results from local disk:
                    using (StreamReader reader = new StreamReader(cachedResult, System.Text.Encoding.UTF8, false))
                    {
                        String trackline = reader.ReadLine();

                        while (trackline != null)
                        {
                            String[] trackitems = trackline.Split(';');
                            Track track = new Track(trackitems[0], trackitems[1], trackitems[2], trackitems[3]);
                            TrackList.Add(track);
                            trackline = reader.ReadLine();
                        }
                        return TrackList; //Got the cached result in a usable form!
                    }
                }
                catch (Exception) { return null; /*It wasn't formatted right? Get new.*/ }
            }
            else return null; //File either doesn't exist or has a blank search (so obviously non-existant)
        }

        private void SaveCachedResult(string filename, List<Track> result)
        {
            filename = filename.Replace("\\", "±");
            filename = filename.Replace("/", "±");
            string cachedResult = cacheDirectory + "\\" + filename;

            try
            {
                if (!Directory.Exists(cacheDirectory))
                    Directory.CreateDirectory(cacheDirectory);

                if (!File.Exists(cachedResult))
                {
                    //No precached result, so save this:
                    using (StreamWriter writer = new StreamWriter(cachedResult))
                    {
                        foreach (Track track in result)
                        {
                            writer.WriteLine(track.Title + ";" + track.Artist + ";" + track.Album + ";" + track.Link);
                        }
                    }
                }
            }
            catch (Exception e) { new ErrorReport(e).Upload(errorServer); }
        }
        #endregion

        #region Search Input Code
        private void picSearchBox_Click(object sender, EventArgs e)
        {
            string strSearchString = txtSearchBox.Text;
            createSearch(strSearchString);
        }
        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strSearchString = txtSearchBox.Text;
                createSearch(strSearchString);
            }
        }

        private void createSearch(string strSearchString)
        {
            try
            {
                List<Track> trackData;

                //Check if the tab's already open!
                foreach (TabPage t in tabSearchTabs.TabPages)
                { if (t.Text == txtSearchBox.Text) { tabSearchTabs.SelectedTab = t; return; } }


                //Bypass Asyncronous Working if possible by using the cache:
                if ((trackData = LoadCachedResult(strSearchString)) != null)
                { 
                    listTracksInTable(trackData); 
                } //Load it and return, we're done!
                else
                {
                    //No cache available, let's load it from the Web:
                    //Put a check on the BGWorker. Is the user trying to do two searches?
                    if (bgWorker.IsBusy)
                    {
                        MessageBox.Show("DownstreamSearch is currently working.\nTry again in a moment.");
                        return;
                    }

                    //Start the ProgressBar so the user know's "something's happening".
                    tsProgressBar.Style = ProgressBarStyle.Marquee;
                    tsProgressBar.MarqueeAnimationSpeed = 30;
                    tsStatusText.Text = "Now Searching: " + strSearchString;

                    bgWorker.RunWorkerAsync(strSearchString);
                }

                //Give this new search it's own tab:
                tabSearchTabs.TabPages.Add(strSearchString);

                //Show the Tab bar if it's not shown yet:
                if (tabSearchTabs.Visible == false) { tabSearchTabs.Visible = true; }

                //Flick to the selected tab:
                foreach (TabPage t in tabSearchTabs.TabPages)
                { if (t.Text == txtSearchBox.Text) { tabSearchTabs.SelectedTab = t; return; } }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("DownstreamSearch is currently working.\nTry again in a moment.");
                tabSearchTabs.TabPages.Remove(tabSearchTabs.TabPages[strSearchString]);
            }
            finally
            {
                txtSearchBox.Clear();
            }
        }
        #endregion

        #region BackgroundWorker Code
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //We get the Search Term from the BackgroundWorker Args:
            string strSearchString = (string)e.Argument;
            SearchTerm = strSearchString; //Set it as Global for saving cache.

            //No cache available, generate web results from DownstreamLib.
            List<Track> trackData = DownstreamLib.Downstream.GenerateTrackList(
                                                    strSearchString,
                        Properties.Settings.Default.int_SearchLimit,
                        Properties.Settings.Default.bool_Duplicates,
                        Properties.Settings.Default.bool_Relevence);

            //Whereever we've the data from, return it.
            e.Result = trackData;
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                List<Track> trackListing = e.Result as List<Track>;

                //Fill in the ListView with the data.
                if (e.Result != null)
                {
                    listTracksInTable(trackListing);
                    SaveCachedResult(SearchTerm, trackListing);
                }
            }
            catch (Exception ex) { new ErrorReport(ex).Upload(errorServer); }
            finally
            {
                //Finally, reset the isSearching bool, we've finished this search.
                tsStatusText.Text = "";
                tsProgressBar.MarqueeAnimationSpeed = 0;
                tsProgressBar.Style = ProgressBarStyle.Continuous;
            }
        }
        #endregion

        #region Track Selection and Load Code
        /// <summary>
        /// Gets the selected row's MP3 Link and uses the WindowsMediaPlayer to play it.
        /// </summary>
        private void lst_TrackListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_TrackListView.FocusedItem != null)
            {
                //Set the Now Playing Track to the current selected.
                NowPlaying = new Track(lst_TrackListView.FocusedItem.SubItems[0].Text,
                                       lst_TrackListView.FocusedItem.SubItems[1].Text,
                                       lst_TrackListView.FocusedItem.SubItems[2].Text,
                                       lst_TrackListView.FocusedItem.Tag.ToString());

                LoadMedia(NowPlaying);
            }
        }
       
        private void LoadMedia(Track newTrack)
        {
            //Load the track:
            axWMP.currentMedia = axWMP.newMedia(newTrack.Link);
            MediaState = PlayStates.Playing;

            //Sort out any GUI settings required:
            picPlayButton.Image = Properties.Resources.PauseButton;
            lblNowPlaying.Text = NowPlaying.Title;
            lblNowPlayingOther.Text = NowPlaying.Artist + " - " + NowPlaying.Album;

            axWMP.Ctlcontrols.play();
        }
        private void PauseMedia()
        {
            if (axWMP.currentMedia != null)
            {
                axWMP.Ctlcontrols.pause();
                MediaState = PlayStates.Paused;
                picPlayButton.Image = Properties.Resources.PlayButton;
            }
        }
        private void PlayMedia()
        {
            if (axWMP.currentMedia != null)
            {
                axWMP.Ctlcontrols.play();
                MediaState = PlayStates.Playing;
                picPlayButton.Image = Properties.Resources.PauseButton;
            }
        }

        #endregion

        #region Other Changes related to the TrackPlaying

        private void changeMediaAfterLastOneFinishes()
        {
            //Long method name or longest method name?

            //Either get the current Track if it's not the same (selected index changed)
            //or get next(;;) next != current Track.

            if (lst_TrackListView.FocusedItem != null)
            {
                Track lastTrack = NowPlaying;
                int si = (int)lst_TrackListView.SelectedIndicies[0];
                while (lst_TrackListView.Items[si].SubItems[0].Text == lastTrack.Title)
                {
                    lst_TrackListView.Items[si].Selected = false;
                    si++;
                    lst_TrackListView.Items[si].Selected = true;

                    //Have we hit the last one? Should we go to the top?
                    if (si >= lst_TrackListView.Items.Count)
                        si = 0;
                }

                //Set the Now Playing Track to the current selected.
                NowPlaying = new Track(lst_TrackListView.Items[si].SubItems[0].Text,
                                       lst_TrackListView.Items[si].SubItems[1].Text,
                                       lst_TrackListView.Items[si].SubItems[2].Text,
                                       lst_TrackListView.Items[si].Tag.ToString());


                LoadMedia(NowPlaying);
            }
        }

        private void axWMP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWMP.playState == WMPLib.WMPPlayState.wmppsBuffering && (axWMP.currentMedia.duration != 0))
            {
                //picDurationSeek.Location = new Point(picDurationBar.Location.X, picDurationSeek.Location.Y);
                currentPositionTimer.Stop();

                double duration = axWMP.currentMedia.duration;
                pixelsPerSecond = duration / picDurationBar.Width;

                currentPositionTimer.Interval = 100;
                currentPositionTimer.Tick += new EventHandler(currentPositionTimer_Tick);
                currentPositionTimer.Start();
            }
            else if (axWMP.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                MediaState = PlayStates.Stopped;
                lblNowPlaying.Text = "";
                lblNowPlayingOther.Text = "";
                lblCurrentTime.Text = "";
                picPlayButton.Image = Properties.Resources.PlayButton;
                picDurationSeek.Location = new Point(picDurationBar.Location.X, picDurationSeek.Location.Y-8);
                currentPositionTimer.Stop();

                changeMediaAfterLastOneFinishes(); //...and the beat goes on!
            }
            else if (axWMP.playState == WMPLib.WMPPlayState.wmppsReady && axWMP.currentMedia != null)
            {
                axWMP.Ctlcontrols.play();
            }
            else if (axWMP.playState == WMPLib.WMPPlayState.wmppsPaused && axWMP.currentMedia != null)
            {
                currentPositionTimer.Stop();
            }
            else if (axWMP.playState == WMPLib.WMPPlayState.wmppsPlaying && axWMP.currentMedia != null)
            {
                currentPositionTimer.Start();
            }
            else if (axWMP.playState == WMPLib.WMPPlayState.wmppsTransitioning && axWMP.currentMedia != null)
            {
                picDurationSeek.Location = new Point(picDurationBar.Location.X, picDurationBar.Location.Y-4);
            }

        }

        //Updates the current position label on the Form.
        void currentPositionTimer_Tick(object sender, EventArgs e)
        {
            String currentMin = String.Format("{0:00}", ((int)(axWMP.Ctlcontrols.currentPosition)) / 60);
            String currentSec = String.Format("{0:00}", ((int)(axWMP.Ctlcontrols.currentPosition)) % 60);

            lblCurrentTime.Text = currentMin + ":" + currentSec;
            updateSeekerDuration();
          
        }

        private delegate void listTracksInTableDelegate(List<Track> results);
        private void listTracksInTable(List<Track> results)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new listTracksInTableDelegate(listTracksInTable), new object[] { results });
                return;
            }
            else
            {
                lst_TrackListView.Items.Clear();
                //foreach (Track trk in results)
                for(int i=results.Count-1; i>=0; i--)
                {
                    Track trk = results[i];
                    string[] lvi_TrackStrings = { trk.Title, trk.Artist, trk.Album, trk.Link };

                    GLItem item = lst_TrackListView.Items.Add(lvi_TrackStrings[0]);
                    item.ForeColor = Color.White;
                    item.SubItems[1].Text = trk.Artist;
                    item.SubItems[2].Text = trk.Album;
                    item.Tag = trk.Link;
                }

                //Switch to the new tab:
                foreach (TabPage t in tabSearchTabs.TabPages)
                { if (t.Text == SearchTerm) { tabSearchTabs.SelectedTab = t; } }
            }
        }

        private void picPlayButton_Click(object sender, EventArgs e)
        {
            if ((MediaState == PlayStates.Playing) && (axWMP.currentMedia != null))
            {
                PauseMedia();
            }
            else if ((MediaState == PlayStates.Paused) && (axWMP.currentMedia != null))
            {
                PlayMedia();
            }
        }

        #endregion

        #region Slider Code

        void updateSeekerDuration()
        {
            if(timeSinceLastUpdate >= pixelsPerSecond)
            {
                //Move the seeker to the current position:
                Point p = new Point();
                p.X = picDurationSeek.Location.X + 1;
                if (p.X >= picDurationBar.Location.X + picDurationBar.Width - 16) { p.X = picDurationBar.Location.X + picDurationBar.Width - 16; }

                p.Y = picDurationSeek.Location.Y;
                picDurationSeek.Location = p;
                timeSinceLastUpdate = 0;
            }
            else 
            {
                timeSinceLastUpdate += (float)(currentPositionTimer.Interval / 1000.0f); //Get into Miliseconds.
            }
        }

        private Boolean dragInProgress = false;
        int MouseDownX = 0;

        private void picDurationSeek_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.dragInProgress)
            {
                this.dragInProgress = true;
                this.MouseDownX = e.X;
            }
            return;
        }
        private void picDurationSeek_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.dragInProgress = false;
            }
            return;
        }
        private void picDurationSeek_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.dragInProgress && (axWMP.currentMedia != null))
            {
                Point p = new Point();

                p.X = this.picDurationSeek.Location.X + (e.X - MouseDownX);
                p.Y = this.picDurationSeek.Location.Y;

                if (p.X < picDurationBar.Location.X) { p.X = picDurationBar.Location.X; }
                if (p.X > picDurationBar.Location.X + picDurationBar.Width-16) { p.X = picDurationBar.Location.X + picDurationBar.Width-16; }
                this.picDurationSeek.Location = p;

                //And change the current media position based on the new location:
                //TODO: ADD NEW POSITION ALGORITHM
                //axWMP.Ctlcontrols.currentPosition = newMediaPosition;
            }
        }
        #endregion

        #region Volume Code

        private Boolean vDragInProgress = false;
        int vMouseDownX = 0;

        private void picVolumeButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.vDragInProgress)
            {
                this.vDragInProgress = true;
                this.vMouseDownX = e.X;
            }
            return;
        }
        private void picVolumeButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.vDragInProgress = false;
            }
            return;
        }
        private void picVolumeButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.vDragInProgress)
            {
                Point p = new Point();

                p.X = this.picVolumeButton.Location.X + (e.X - vMouseDownX);
                p.Y = this.picVolumeButton.Location.Y;

                if (p.X < picVolumeBar.Location.X) { p.X = picVolumeBar.Location.X; }
                if (p.X > picVolumeBar.Location.X + picVolumeBar.Width - 16) { p.X = picVolumeBar.Location.X + picVolumeBar.Width - 16; }
                this.picVolumeButton.Location = p;

                //Update Volume:
                //TODO:s
            }
        }
        #endregion

        #region Miscellanious Code (ControlEvents etc)
        private void txtSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchBox.Clear();
        }
        private void txtSearchBox_Leave(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == String.Empty)
                txtSearchBox.Text = "Search by Artist, Song Name or Album";
        }
        private void picSearchBox_MouseEnter(object sender, EventArgs e)
        {
            picSearchBox.BackgroundImage = Properties.Resources.searchbutton_hover;
        }
        private void picSearchBox_MouseLeave(object sender, EventArgs e)
        {
            picSearchBox.BackgroundImage = Properties.Resources.searchbutton;
        }
        private void picSettings_Click(object sender, EventArgs e)
        {
            PreferenceForm p = new PreferenceForm(bgWorker.IsBusy);
            p.ShowDialog();
        }

        private void tabSearchTabs_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                tabSearchTabs.TabPages.Remove(tabSearchTabs.SelectedTab);

                if (tabSearchTabs.TabCount == 0)
                {
                    lst_TrackListView.Items.Clear();
                }
            }
        }
        private void tabSearchTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSearchTabs.TabCount > 0)
            {
                //Changed tab, so we'll load using the new tabs title:
                string tabName = tabSearchTabs.SelectedTab.Text;
                List<Track> cachedResults = LoadCachedResult(tabName);
                if (cachedResults != null) { listTracksInTable(cachedResults); }
                else { lst_TrackListView.Items.Clear(); }

                //Switch to the selected tab:
                foreach (TabPage t in tabSearchTabs.TabPages)
                { if (t.Text == tabName) { tabSearchTabs.SelectedTab = t; } }
            }
            else
            {
                lst_TrackListView.Items.Clear();
                tabSearchTabs.Hide();
            }
        }

        /// <summary>
        /// Twitter processing: 
        /// </summary>
        private void picTwitter_Click(object sender, EventArgs e)
        {
            Properties.Settings set = Properties.Settings.Default;
            string str_Tweet = null;

            try
            {
                if (set.TwitterOAuthToken == null)
                {
                    MessageBox.Show(
                        "You have not signed into Twitter.\n Please access Preferences to set Twitter Access",
                        "Downstream",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }


                if (axWMP.currentMedia != null)
                {
                    //What preference have they got stored?
                    string ps = set.str_PostStyle;

                    if (ps.Equals("Simple"))
                    {
                        str_Tweet = "I'm listening to " + NowPlaying.Title + " - " + NowPlaying.Artist;
                        if (str_Tweet.Length < 140 - " #downstream".Length - 19)
                        {
                            str_Tweet += " #downstream http://goo.gl/nz1iQ";
                        }
                    }
                    else if (ps.Equals("SimpleAlt"))
                    {
                        str_Tweet = "I'm listening to " + NowPlaying.Title + " by " + NowPlaying.Artist;
                        if (str_Tweet.Length < 140 - " #downstream".Length - 19)
                        {
                            str_Tweet += " #downstream http://goo.gl/nz1iQ";
                        }
                    }
                    else if (ps.Equals("NowPlaying"))
                    {
                        str_Tweet = NowPlaying.Title + " - " + NowPlaying.Artist;
                        if (str_Tweet.Length < (140 - " #nowplaying".Length - " #downstream".Length - 19))
                        {
                            //Tweet is <140 and has enough room for both tags!
                            str_Tweet += " #nowplaying #downstream http://goo.gl/nz1iQ";
                        }
                        else if (str_Tweet.Length < (140 - " #nowplaying".Length))
                        {
                            //Tweet is <140 and has enough for nowplaying tag!
                            str_Tweet += " #nowplaying";
                        }

                        else if (str_Tweet.Length > (140 - " #nowplaying".Length - 19))
                        {
                            str_Tweet = NowPlaying.Title + "#nowplaying http://goo.gl/nz1iQ";
                        }

                        else if (str_Tweet.Length > (140 - " #nowplaying".Length))
                        {
                            str_Tweet = NowPlaying.Title + "#nowplaying";
                        }
                    }

                    OAuthTokens TwitterAuthTokens = set.TwitterOAuthToken;


                    if (!String.IsNullOrEmpty(str_Tweet) && TwitterAuthTokens != null)
                    {
                        //Tweet set, update it!
                        TwitterStatus.Update(TwitterAuthTokens, str_Tweet);
                        string bar = tsStatusText.Text;
                        tsStatusText.Text = "Successfully Posted to Twitter!";
                        System.Threading.Thread.Sleep(3000);
                        tsStatusText.Text = bar;
                    }
                }
            }
            catch (Exception ex) { new ErrorReport(ex).Upload(errorServer); }
        }

        /// <summary>
        /// Facebook processing: 
        /// </summary>
        private void picFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings set = Properties.Settings.Default;
                if (set.fb_AccToken == null)
                {
                    MessageBox.Show(
                        "You have not signed into Facebook.\n Please access Preferences to set Facebook Access",
                        "Downstream",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                string str_Status = null;
                if (axWMP.currentMedia != null && set.fb_AccToken != null)
                {
                    //What preference have they got stored?
                    string ps = Properties.Settings.Default.str_PostStyle;

                    if (ps.Equals("Simple"))
                    {
                        str_Status = "I'm listening to " + NowPlaying.Title + " - " + NowPlaying.Artist;
                    }
                    else if (ps.Equals("SimpleAlt"))
                    {
                        str_Status = "I'm listening to " + NowPlaying.Title + " by " + NowPlaying.Artist;
                    }
                    else if (ps.Equals("NowPlaying"))
                    {
                        str_Status = NowPlaying.Title + " - " + NowPlaying.Artist + " #nowplaying";
                    }

                    FacebookClient fbc = new FacebookClient(Properties.Settings.Default.fb_AccToken);

                    dynamic parameters = new ExpandoObject();
                    parameters.message = str_Status;
                    parameters.picture = "http://mattryder.co.uk/image/downstreamicon.png";
                    parameters.link = "http://mattryder.co.uk/project/downstream";
                    parameters.picture = "http://mattryder.co.uk/image/downstreamicon.png";
                    parameters.name = "Downstream Media Player";
                    parameters.caption = "Downstream Download";
                    parameters.description = "Downstream is a free application that plays the music you want to listen to, and allows you to share your musical tastes through Facebook and Twitter.";
                    parameters.action = new
                    {
                        name = "Download Downstream",
                        link = "http://mattryder.co.uk/project/downstream"
                    };

                    parameters.privacy = new
                    {
                        value = "ALL_FRIENDS",
                    };

                    parameters.targeting = new
                    {
                        countries = "UK",
                        regions = "6,53",
                        locales = "6",
                    };

                    dynamic result = fbc.Post("me/feed", parameters);
                    string bar = tsStatusText.Text;
                    tsStatusText.Text = "Successfully Posted to Facebook!";
                    System.Threading.Thread.Sleep(10000);
                    tsStatusText.Text = bar;
                }
                else { tsStatusText.Text = "No media is playing!"; }
            }
            catch (Exception ex) { new ErrorReport(ex).Upload(errorServer); }

        }
        #endregion

        #region Download Track Code

        private System.Collections.ArrayList itemList;
        private int currentDownloadCount = 0;
        private int downloadListCount = 0;
        private string currentDownloadName = "";
        private bool isBusy = false;
        private void downloadClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            tsDownloadText.Text = "["+currentDownloadCount+"/"+downloadListCount+"] Download Progress for "+currentDownloadName+": " + e.ProgressPercentage+"%";

            if (e.ProgressPercentage == 100 && currentDownloadCount == downloadListCount)
            {
                tsDownloadText.Text = currentDownloadCount + " tracks downloaded successfully.";
            }
        }

        private void downloadClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //This file has completed, is there any more track to download?
            if (currentDownloadCount != downloadListCount)
            {
                //Yes, there's more to download!
                downloadItem((GLItem)itemList[currentDownloadCount]);
            }
            else
            {
                //We're done here. Clean up the counters.
                currentDownloadCount = 0;
                downloadListCount = 0;
                currentDownloadName = "";
                isBusy = false;
            }
        }

        private void picDownloadTrack_Click(object sender, EventArgs e)
        {
            string dslocation = Properties.Settings.Default.defaultSaveLocation;
            if (isBusy)
                return;

            try
            {
                //Fixed not having the right directory messing everything up.
                if (!Directory.Exists(dslocation) && !String.IsNullOrEmpty(dslocation))
                    Directory.CreateDirectory(dslocation);
                else if(String.IsNullOrEmpty(dslocation)) //Default to the... default save directory.
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\Downstream Downloads\\");

                //Create the directory to save to, you peti
                //Check if any tracks are selected:
                if (lst_TrackListView.SelectedIndicies.Count == 0)
                {
                    tsDownloadText.Text = "No tracks to download.";
                }
                else
                {
                    //Get the selected items
                    itemList = lst_TrackListView.SelectedItems;
                    downloadListCount = itemList.Count;
                    isBusy = true;
                    downloadItem((GLItem)itemList[0]); //Kick off the downloading list 
                }
            }
            catch (System.Exception ex)
            { new ErrorReport(ex).Upload(errorServer); }
        }

        private void downloadItem(GLItem item)
        {
            try
            {
                string dlFolder = Properties.Settings.Default.defaultSaveLocation;
                currentDownloadCount++;
                currentDownloadName = item.SubItems[0].Text;

                downloadClient.DownloadFileAsync(new Uri(item.Tag.ToString()), dlFolder +"\\"+ currentDownloadName + ".mp3");
            }
            catch (System.Exception ex)
            { new ErrorReport(ex).Upload(errorServer); }
        }

        #endregion

    }
}
