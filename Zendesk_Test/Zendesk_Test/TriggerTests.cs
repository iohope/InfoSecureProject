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
    public partial class TriggerTests : Form
    {
        private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public TriggerTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetTriggers();
        }

        [Test]
        public void CanGetTriggers()
        {
            var res = api.Triggers.GetTriggers();
            Assert.Greater(res.Count, 0);

            var ind = api.Triggers.GetTriggerById(res.Triggers[0].Id);
            Assert.AreEqual(ind.Trigger.Id, res.Triggers[0].Id);
        }
    }
}
