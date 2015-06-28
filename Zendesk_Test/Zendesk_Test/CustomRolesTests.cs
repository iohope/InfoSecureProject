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
    public partial class CustomRolesTests : Form
    {
        private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public CustomRolesTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetCustomRoles();
        }

        [Test]
        public void CanGetCustomRoles()
        {
            //var res = api.CustomAgentRoles.GetCustomRoles();

            //Apparently you have to pay more to get this feature so the test will fail
            //Assert.Greater(res.CustomRoleCollection.Count, 0);

            //So I will just throw this up instead :P
            Assert.Inconclusive();
        }
    }
}
