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
using ZendeskApi_v2.Models.Articles;
using ZendeskApi_v2.Requests.HelpCenter;

namespace Zendesk_Test
{
    public partial class VoteTests : Form
    {
        private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);
        private long _articleIdWithVotes = 204838115; //https://csharpapi.zendesk.com/hc/en-us/articles/204838115-Thing-4?page=1#comment_200486479

        public VoteTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetArticleVotes();
        }

        [Test]
        public void CanGetArticleVotes()
        {
            var votes = api.HelpCenter.Votes.GetVotesForArticle(_articleIdWithVotes);

            Assert.IsTrue(votes.Count > 0);
        }
    }
}
