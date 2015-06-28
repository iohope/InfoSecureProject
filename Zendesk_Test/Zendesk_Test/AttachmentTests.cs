using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using NUnit.Framework;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Shared;

namespace Zendesk_Test
{
    public partial class AttachmentTests : Form
    {
        ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public AttachmentTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanUploadAttachments();
        }

        [Test]
        public void CanUploadAttachments()
        {
            var res = api.Attachments.UploadAttachment(new ZenFile()
            {
                ContentType = "text/plain",
                FileName = "testupload.txt",
                FileData =
                    File.ReadAllBytes(Environment.CurrentDirectory +
                                      "\\testupload.txt")
            });
            Assert.True(!string.IsNullOrEmpty(res.Token));
        }
    }
}
