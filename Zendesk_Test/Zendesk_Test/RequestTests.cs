﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NUnit.Framework;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Requests;
using ZendeskApi_v2.Models.Tickets;

namespace Zendesk_Test
{
    public partial class RequestTests : Form
    {
        private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        public RequestTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanGetRequests();
        }

        [Test]
        public void CanGetRequests()
        {
            var res = api.Requests.GetAllRequests();
            Assert.True(res.Count > 0);
        }

        [Test]
        public void CanCreateAndUpdateRequests()
        {
            var req = new Request()
            {
                Subject = "end user request test",
                Comment = new Comment() { Body = "end user test" }
            };


            var res = api.Requests.CreateRequest(req);
            Assert.True(res.Request.Id > 0);

            var res1 = api.Requests.GetRequestById(res.Request.Id.Value);
            Assert.AreEqual(res1.Request.Id, res.Request.Id);

            res1.Request.Subject = "new subject";
            res1.Request.Comment = new Comment()
            {
                Body = "something more to say"
            };

            var res2 = api.Requests.UpdateRequest(res1.Request);
            //var res2 = api.Requests.UpdateRequest(res.Request.Id.Value, new Comment() {Body = "something more to say"});
            var res3 = api.Requests.GetRequestCommentsById(res.Request.Id.Value);

            Assert.AreEqual(res3.Comments.Last().Body.Replace("\n", ""), "something more to say");

            var res4 = api.Requests.GetSpecificRequestComment(res.Request.Id.Value, res3.Comments.Last().Id.Value);

            res1.Request.RequesterId = 56766413L;
            var res5 = api.Requests.UpdateRequest(res1.Request);
            var res6 = api.Requests.GetRequestById(res.Request.Id.Value);

            Assert.AreEqual(res5.Request.RequesterId, res6.Request.RequesterId);
            Assert.AreEqual(res4.Comment.Id, res3.Comments.Last().Id);

            Assert.True(api.Tickets.Delete(res1.Request.Id.Value));
        }
    }
}
