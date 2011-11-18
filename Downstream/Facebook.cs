using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using System.IO;
using System.Dynamic;

namespace Downstream
{
    public partial class FacebookForm : Form
    {
        private string _output = "";
        public string FacebookForm_Output
        {
            get { return _output; }
            set { _output = value; }
        }

        public FacebookForm()
        {
            InitializeComponent();

            string _appID = Properties.Settings.Default.fb_AppKey;
            string _appSec = Properties.Settings.Default.fb_AppSec;
            string[] extendedPermissions = new[] { "publish_stream", "offline_access" };

            var oauth = new FacebookOAuthClient { AppId = _appID, AppSecret = _appSec };

            var parameters = new Dictionary<string, object>
                    {
                        { "response_type", "token" },
                        { "display", "popup" }
                    };

            if (extendedPermissions != null && extendedPermissions.Length > 0)
            {
                var scope = new StringBuilder();
                scope.Append(string.Join(",", extendedPermissions));
                parameters["scope"] = scope.ToString();
            }

            var loginUrl = oauth.GetLoginUrl(parameters);
            webBrowser1.Navigate(loginUrl);

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            FacebookOAuthResult result;

            if (FacebookOAuthResult.TryParse(e.Url, out result))
            {
                if (result.IsSuccess)
                {
                    var accesstoken = result.AccessToken;
                    //Store Access Token!
                    Properties.Settings.Default.fb_AccToken = accesstoken;

                    facebookWhois(result);
                }
                else
                {
                    var errorDescription = result.ErrorDescription;
                    var errorReason = result.ErrorReason;
                    FacebookForm_Output = "Failed to authenticate!";
                }
            }
        }

        private void facebookWhois(FacebookOAuthResult fboa)
        {
            var fba = new FacebookClient(fboa.AccessToken);

            var resultWhois = (IDictionary<string, object>)fba.Get("/me");
            var name = (string)resultWhois["name"];
            Properties.Settings.Default.fb_sn = name; //Store Facebook Profile Name!
            FacebookForm_Output = "Currently logged in as: " + name; //Output Success message.
            Properties.Settings.Default.Save();

            //Ask the user if they'll help spread the word about Downstream:
            DialogResult d = MessageBox.Show(
                "If you're happy with Downstream, could I have your permission\n" +
                "to post a status about Downstream?\n\nIt costs nothing to you but means a lot to the developer!",
                "Downstream Appreciation Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.Yes)
            {
                //Use fba FacebookClient object (Code reuse!)
                dynamic parameters = new ExpandoObject();
                parameters.message = "I'm using Downstream to listen to music! Get it free!";
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

                parameters.privacy = new {
	                    value = "ALL_FRIENDS",
                };

                parameters.targeting = new {
	                    countries = "UK",
	                    regions = "6,53",
	                    locales = "6",
                };

                dynamic result = fba.Post("me/feed", parameters);
                FacebookForm_Output = "Thanks for supporting Downstream!";
         
            }
            this.Close();

        }
    }
}
