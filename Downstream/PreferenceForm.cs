using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Twitterizer;
using System.Text.RegularExpressions;
using Facebook;

namespace Downstream
{
    public partial class PreferenceForm : Form
    {
        bool searchRunning = false;
        private bool auth_user = false;
        private bool auth_code = false;
        WebBrowser tw; // Twitter login 'hidden' Web Browser.
        OAuthTokenResponse oa_TokenResponse;
        Properties.Settings settings = Properties.Settings.Default;

        public PreferenceForm(bool isSearchRunning)
        {
            //Noshow in the taskbar:
            this.ShowInTaskbar = false;

            InitializeComponent();
            initializeProperties();

            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
            this.lblLogieWebsite.LinkClicked += new LinkLabelLinkClickedEventHandler(lblLogieWebsite_LinkClicked);

            if (isSearchRunning)
                btnClearData.Enabled = false;
        }

        /// <summary>
        /// Any and all initalizing Settings 
        /// </summary>
        private void initializeProperties()
        {
            //Add version:
            lblAbout.Text = "Downstream - v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //Load Settings from Settings.cs
            chkDuplicates.Checked = Properties.Settings.Default.bool_Duplicates;
            chkRelevence.Checked = Properties.Settings.Default.bool_Relevence;
            chkLimitedResults.Checked = (Properties.Settings.Default.int_SearchLimit != -1) ? true : false;

            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.defaultSaveLocation))
            {
                Properties.Settings.Default.defaultSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\Downstream Downloads\\";
                txtSaveLocation.Text = Properties.Settings.Default.defaultSaveLocation;
            }
            else
            {
                txtSaveLocation.Text = Properties.Settings.Default.defaultSaveLocation;
            }

            txtSaveLocation.Text = Properties.Settings.Default.defaultSaveLocation;

            if (settings.tw_sn != null)
            {
                lblTwitterOutput.Text = "Currently authenticated as: " + settings.tw_sn;
            }
            if (settings.fb_sn != null)
            {
                lblFacebookOutput.Text = "Currently authenticated as: " + settings.fb_sn;
            }

            if (settings.str_PostStyle == "Simple")
            {
                cboPostStyle.SelectedIndex = 0;
                lblFormatTitle.Text = "Simple";
                lblFormatEx.Text = "I'm listening to [Track Title] - [Track Artist] #downstream";
            }
            else if (settings.str_PostStyle == "SimpleAlt")
            {
                cboPostStyle.SelectedIndex = 1;
                lblFormatTitle.Text = "SimpleAlt";
                lblFormatEx.Text = "I'm listening to [Track Title] by [Track Artist] #downstream";
            }
            else if (settings.str_PostStyle == "NowPlaying")
            {
                cboPostStyle.SelectedIndex = 2;
                lblFormatTitle.Text = "NowPlaying";
                lblFormatEx.Text = "[Track Title] - [Track Artist] #nowplaying #downstream";
            }
        }

        private void chkRelevence_CheckedChanged(object sender, EventArgs e)
        {
           settings.bool_Relevence = chkRelevence.Checked;
        }

        private void chkDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            settings.bool_Duplicates = chkDuplicates.Checked;
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Downstream";
            string cacheDirectory = dataDirectory + "\\Cache";

            if (Directory.Exists(cacheDirectory) && !searchRunning)
            {
                Directory.Delete(cacheDirectory, true);
                lblOutput.Text = "Cleared Cached Data!";
                System.Threading.Thread.Sleep(1000);
                lblOutput.Text = "";
            }
        }

        private void chkLimitedResults_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLimitedResults.Checked)
                settings.int_SearchLimit = 20;
            else
                settings.int_SearchLimit = -1;
        }

        private void PreferenceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Save();
        }

        /// <summary>
        /// TWITTER AUTHENTICATION
        /// </summary>
        private void btnTwitterAuth_Click(object sender, EventArgs e)
        {
            oa_TokenResponse = OAuthUtility.GetRequestToken(
                settings.tw_cKey,
                settings.tw_cSec, "oob");

            tw = new WebBrowser();
            tw.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(tw_DocumentCompleted);
            tw.Navigate(OAuthUtility.BuildAuthorizationUri(oa_TokenResponse.Token, true));
        }
        private void tw_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!auth_user)
            {
                tw.Document.All["session[username_or_email]"].InnerText = txtTwitterUser.Text;
                tw.Document.All["session[password]"].InnerText = txtTwitterPass.Text;
                HtmlElement submit = tw.Document.GetElementById("allow");
                submit.InvokeMember("click");
                auth_user = true;
            }

            else if (!auth_code)
            {
                int c = tw.Document.GetElementsByTagName("code").Count; 
                if (tw.Document.GetElementsByTagName("code").Count < 1)
                {
                    lblTwitterOutput.Text = "Error authenticating with Twitter\nPlease check your credentials and try again.";
                    return;
                }

                string pc = tw.Document.GetElementsByTagName("code")[0].InnerText;

                Match match = Regex.Match(pc, @"([0-9]+)");
                if (!match.Success)
                {
                    lblTwitterOutput.Text = "Error authenticating with Twitter\nPlease check your credentials and try again.";
                    return;
                }
                else
                {
                    OAuthTokenResponse accessToken = OAuthUtility.GetAccessToken(
                        settings.tw_cKey,
                        settings.tw_cSec,
                        oa_TokenResponse.Token,
                        pc);

                    //Add the shorthand OAuthTokens
                    OAuthTokens oaTokens = new OAuthTokens() {
                        AccessToken = accessToken.Token,
                        AccessTokenSecret = accessToken.TokenSecret,
                        ConsumerKey = settings.tw_cKey,
                        ConsumerSecret = settings.tw_cSec
                    };

                    settings.TwitterOAuthToken = oaTokens;
                    settings.tw_sn = accessToken.ScreenName;
                    settings.Save();

                    lblTwitterOutput.Text = "Currently authenticated as: " + settings.tw_sn;

                    //Ask the user if they'll help spread the word about Downstream:
                    DialogResult d = MessageBox.Show(
                        "If you're happy with Downstream, could I have your permission\n" +
                        "to post a tweet about Downstream?\n\nIt costs nothing but means a lot to the developer!",
                        "Downstream Appreciation Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == System.Windows.Forms.DialogResult.Yes)
                    {
                        TwitterStatus.Update(settings.TwitterOAuthToken, "I'm using Downstream to listen to music! Get it here: http://mattryder.co.uk/project/downstream");
                        lblTwitterOutput.Text = "Thanks for supporting Downstream!";
                    }
                }
            }
        }

        /// <summary>
        /// FACEBOOK AUTHENTICATION
        /// </summary>
        private void btnFBAuth_Click(object sender, EventArgs e)
        {
            FacebookForm fbf = new FacebookForm();
            fbf.ShowDialog();
            lblFacebookOutput.Text = fbf.FacebookForm_Output; //Output either success or fail message.
        }

        /// <summary>
        /// DATA CLEARANCE [TWITTER/FACEBOOK]
        /// </summary>
        private void btnClearTwitterData_Click(object sender, EventArgs e)
        {
            Properties.Settings s = Properties.Settings.Default;
            s.TwitterOAuthToken = new OAuthTokens();
            s.tw_sn = null;
            lblTwitterOutput.Text = "Cleared all Twitter Data";
            s.Save();
        }
        private void btnRemoveFBData_Click(object sender, EventArgs e)
        {
            Properties.Settings s = Properties.Settings.Default;
            s.fb_AccToken = null;
            s.fb_sn = null;
            lblFacebookOutput.Text = "Cleared all Facebook data";
            s.Save();
        }

        private void cboPostStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings s = Properties.Settings.Default;
            switch (cboPostStyle.SelectedIndex)
            {
                case 0:
                    s.str_PostStyle = "Simple";
                    lblFormatEx.Text = "I'm listening to [Track Title] - [Track Artist] #downstream";
                    break;
                case 1:
                    s.str_PostStyle = "SimpleAlt";
                    lblFormatEx.Text = "I'm listening to [Track Title] by [Track Artist] #downstream";
                    break;
                case 2:
                    s.str_PostStyle = "NowPlaying";
                    lblFormatEx.Text = "[Track Title] - [Track Artist] #nowplaying #downstream";
                    break;
            }
            s.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mattryder.co.uk");
        }

        private void lblLogieWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.eeyum.net");
        }

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.defaultSaveLocation = fbd.SelectedPath;
                txtSaveLocation.Text = Properties.Settings.Default.defaultSaveLocation;

                if (!Directory.Exists(fbd.SelectedPath))
                    Directory.CreateDirectory(fbd.SelectedPath);
            }
        }

    }
}