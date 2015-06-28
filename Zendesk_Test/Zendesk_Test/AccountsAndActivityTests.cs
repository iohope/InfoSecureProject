using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NUnit.Framework;
using ZendeskApi_v2;


namespace Zendesk_Test
{
    public partial class AccountsAndActivityTests : Form
    {
        ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public AccountsAndActivityTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetSettings();
        }

        [Test]
        public void CanGetSettings()
        {
            var res = api.AccountsAndActivity.GetSettings();
            Assert.IsNotEmpty(res.Settings.Branding.HeaderColor);
        }

        [Test]
        public void CanGetActivities()
        {
            //the api returns empty objects and I'm not sure how to get it to populate
            var res = api.AccountsAndActivity.GetActivities();

            //var res1 = api.AccountsAndActivity.GetActivityById()

        }
    }
}
