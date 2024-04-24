using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Wazifa.Models;

namespace Wazifa.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchQuery)
        {
            var searchResult = context.Jobs.Where(m => m.Title.Contains(SearchQuery)
            || m.Description.Contains(SearchQuery)
            || m.Category.Name.Contains(SearchQuery)
            || m.Category.Description.Contains(SearchQuery)).ToList();

            return View(searchResult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {

                var siteMail = "faroukok2000@gmail.com";
                var mail = new MailMessage();

                mail.From = new MailAddress(contact.Email); // sender
                mail.Subject = contact.Subject;
                mail.IsBodyHtml = true;

                mail.Body = "<h3>Email From: " + contact.Name + "</h3>" +
                    "<h5>Email : " + contact.Email + "</h5>" +
                    "<h6>Message Content : </h6>" + contact.Message;

                mail.To.Add(new MailAddress(siteMail)); // to

                var SiteCredentials = new NetworkCredential(siteMail, "googleOk5050");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = SiteCredentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                ViewBag.msg = "تم ارسال الرسالة رجاءآ انتظر الرد علي  نفس البريد الذي وضعته في محتوي نموذج الارسال.";
                return View();
            }
            return View(contact);

        }
    }
}