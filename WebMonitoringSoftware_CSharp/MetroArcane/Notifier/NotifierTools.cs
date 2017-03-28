using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notifier
{
    public partial class NotifierTools : Form
    {
        public NotifierTools()
        {
            InitializeComponent();
        }

        private void NotifierTools_Load(object sender, EventArgs e)
        {

        }

        public void SystemTrayNotification(string title, string text)
        {

            notifyIconUniversal.BalloonTipTitle = title;
            notifyIconUniversal.BalloonTipText = text;
            notifyIconUniversal.Visible = true;
            notifyIconUniversal.ShowBalloonTip(1000);
        }


    }
}
