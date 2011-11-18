using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Downstream
{
    public partial class HelpForm : Form
    {
        int i;
        private Image[] helpImages = {
                                        Properties.Resources.HelpPage1,
                                        Properties.Resources.HelpPage2,
                                        Properties.Resources.HelpPage3,
                                        Properties.Resources.HelpPage4,
                                        Properties.Resources.HelpPage5 };

        public HelpForm()
        {
            Random random = new Random();
            i = random.Next(0, 4);

            InitializeComponent();

            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Load an initial image:

            picHelpImage.Image = helpImages[i];
        }

        private void btnNextTip_Click(object sender, EventArgs e)
        {
            if (i + 1 > 4)
                i = 0;

            Image img = helpImages[i++];
            picHelpImage.Image = img;
        }

        private void btnPrevTip_Click(object sender, EventArgs e)
        {
            if (i - 1 < 0)
                i = 4;

            Image img = helpImages[i--];
            picHelpImage.Image = img;
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            //Ternary operators are fun.
            Properties.Settings.Default.dontShowHelp = cbShow.Checked ? true : false;
            Properties.Settings.Default.Save();
        }
    }
}
