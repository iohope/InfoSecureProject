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
    public partial class TagTests : Form
    {
        private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public TagTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetTags();
        }

        [Test]
        public void CanGetTags()
        {
            var res = api.Tags.GetTags();

            Assert.Greater(res.Tags.Count, 0);
        }

        [Test]
        public void CanAutocompleteTags()
        {
            var res = api.Tags.GetTags();
            var auto = api.Tags.AutocompleteTags(res.Tags[0].Name.Substring(0, 3));

            Assert.Greater(auto.Tags.Count, 0);
        }
    }
}
