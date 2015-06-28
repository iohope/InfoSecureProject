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
    public partial class SatisfactionRatingTests : Form
    {
        private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public SatisfactionRatingTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetSatisfactionRatings();
        }

        [Test]
        public void CanGetSatisfactionRatings()
        {
            //there is no way to create satisfaction ratings through the api so they can't be tested
        }
    }
}
