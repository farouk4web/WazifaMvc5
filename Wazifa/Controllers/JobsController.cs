using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wazifa.Models;

namespace Wazifa.Controllers
{
    [Authorize(Roles = RoleName.Admins + "," + RoleName.Publishers)]
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
 
        // GET: Jobs
        [AllowAnonymous]
        public ActionResult Index(string errMsg, string resultMsg)
        {
            if (errMsg != null)
                ViewBag.msg = errMsg;
            else
                ViewBag.msg = resultMsg;

            var jobs = db.Jobs.Include(j => j.Category);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job job = db.Jobs.Find(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        public ActionResult MyPublishedJobs()
        {
            var userId = User.Identity.GetUserId();
            var jobs = db.Jobs.Where(m => m.UserId == userId).ToList();            

            return View(jobs);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job, HttpPostedFileBase jobImage)
        {
            if (ModelState.IsValid)
            {
                if (jobImage !=null && jobImage.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Uploads"), jobImage.FileName);
                    jobImage.SaveAs(path);
                    job.ImageSrc = jobImage.FileName;
                }

                var userId = User.Identity.GetUserId();
                job.UserId = userId;

                db.Jobs.Add(job);
                db.SaveChanges();

                var msg = "تم إضافة بيانات الوظيفة بنجاح";
                return RedirectToAction("Index", new { resultMsg = msg });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", job.CategoryId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
                return HttpNotFound();

            var currentUserId = User.Identity.GetUserId();

            if (job.UserId != currentUserId)
            {
                var msg = "خطأ : هذه الوظيفة لم تقم بنشرها ولذلك لا يمكنك تعديلها";
                return RedirectToAction("Index", new { errMsg = msg });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", job.CategoryId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job, HttpPostedFileBase jobImage, string oldImage)
        {
            if (ModelState.IsValid)
            {
                if (jobImage != null && jobImage.ContentLength > 0)
                {
                    var oldImageInDb =Path.Combine(Server.MapPath("~/Uploads"), oldImage);
                    System.IO.File.Delete(oldImageInDb);

                    var path = Path.Combine(Server.MapPath("~/Uploads"), jobImage.FileName);
                    jobImage.SaveAs(path);
                    job.ImageSrc = jobImage.FileName;
                }
                else
                {
                    job.ImageSrc = oldImage;
                }

                var userId = User.Identity.GetUserId();
                job.UserId = userId;

                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();

                var msg = "تم تعديل بيانات الوظيفة بنجاح";
                return RedirectToAction("Index", new { resultMsg = msg });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", job.CategoryId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
                return HttpNotFound();

            var currentUserId = User.Identity.GetUserId();

            if (job.UserId != currentUserId)
            {
                var msg = "خطأ : هذه الوظيفة لم تقم بنشرها ولذلك لا يمكنك حذفها";
                return RedirectToAction("Index", new { errMsg = msg });
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
