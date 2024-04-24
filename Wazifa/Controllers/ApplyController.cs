using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wazifa.Models;

namespace Wazifa.Controllers
{
    [Authorize(Roles = RoleName.Admins + "," + RoleName.Researchers)]
    public class ApplyController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // apply to job
        public ActionResult ApplyToJob(int id)
        {
            ViewBag.jobId = id;

            var job = context.Jobs.Single(m => m.Id == id);

            var jobPublisherId = job.UserId;
            var currentUserId = User.Identity.GetUserId();

            if (jobPublisherId == currentUserId)
                return RedirectToAction("Details", "Jobs", new { id = job.Id });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyToJob(ApplyForJob apply)
        {
            var currentUserId = User.Identity.GetUserId();
            var applyResult = "نتيجة التقديم";

            var checkResult = context.ApplyForJobs.Where(m => m.UserId == currentUserId && m.JobId == apply.JobId).ToList();
            if (checkResult.Count < 1)
            {
                apply.ApplyDate = DateTime.Now;
                apply.UserId = currentUserId;

                context.ApplyForJobs.Add(apply);
                context.SaveChanges();

                applyResult = "تم التقديم للوظيفة بنجاح";
                return RedirectToAction("ApplyDetails", new { id = apply.Id, msg = applyResult });
            }

            applyResult = "للأسف عميلنا العزيز لا تستطيع التقديم لنفس الوظيفة اكثر من مرة";
            return RedirectToAction("ApplyDetails", new { id = apply.Id, msg = applyResult });
        }

        // GET: Applies
        public ActionResult MyAppliesJobs()
        {
            var userId = User.Identity.GetUserId();

            var applyJobs = context.ApplyForJobs.Where(m => m.UserId == userId).ToList();

            return View(applyJobs);
        }

        //Get: Apply Details
        public ActionResult ApplyDetails(int id, string msg)
        {
            var apply = context.ApplyForJobs.Find(id);
            if (apply == null)
                return HttpNotFound();

            if (msg != null)
                ViewBag.applyResult = msg;

            return View(apply);
        }

        // Edit get
        public ActionResult EditApply(int id)
        {
            var apply = context.ApplyForJobs.Find(id);
            if (apply == null)
                return HttpNotFound();

            return View(apply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditApply(ApplyForJob apply)
        {
            var applyInDb = context.ApplyForJobs.Find(apply.Id);
            applyInDb.Message = apply.Message;
            applyInDb.ApplyDate = DateTime.Now;
            context.SaveChanges();

            return RedirectToAction("MyAppliesJobs");
        }

        // get: Delete
        public ActionResult DeleteApply(int id)
        {
            var apply = context.ApplyForJobs.Find(id);
            if (apply == null)
                return HttpNotFound();
            return View(apply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteApply(ApplyForJob apply)
        {
            var applyInDb = context.ApplyForJobs.Find(apply.Id);
            context.ApplyForJobs.Remove(applyInDb);
            context.SaveChanges();

            return RedirectToAction("MyAppliesJobs");
        }

        // GET: Applies
        [Authorize(Roles = RoleName.Admins + "," + RoleName.Publishers)]
        public ActionResult AllJobApplers(int id)
        {
            var job = context.Jobs.Single(m => m.Id == id);

            return View(job);
        }

    }
}