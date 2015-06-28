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
    public partial class LocaleTests : Form
    {
        private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public LocaleTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetLocales();
        }

        [Test]
        public void CanGetLocales()
        {
            var all = api.Locales.GetAllLocales();
            Assert.Greater(all.Count, 0);

            var agent = api.Locales.GetLocalesForAgents();
            Assert.Greater(agent.Count, 0);

            var specific = api.Locales.GetLocaleById(all.Locales[0].Id);
            Assert.AreEqual(specific.Locale.Id, all.Locales[0].Id);

            var current = api.Locales.GetCurrentLocale();
            Assert.Greater(current.Locale.Id, 0);
        }
    }
}
