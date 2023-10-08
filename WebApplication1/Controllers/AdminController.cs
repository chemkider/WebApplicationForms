using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class AdminController : Controller
    {

        public ActionResult ViewForms()
        {
            return View();
        }

        public JsonResult GetDataForAdmin()
        {
            using (FormDBEntities db = new FormDBEntities())
            {
                var data = db.formDatas.Select(f => new
                {
                    submissionID = f.SubmissionID,
                    formID = f.formID,
                    Name = f.Name,
                    Title = f.Title,
                    Email = f.Email,
                    MobileNumber = f.MobileNumber,
                    Subtime = f.SubTime,
                    reqStatus = f.ReqStatus,
                }).ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateStatus(int submissionID, string action)
        {
            using (FormDBEntities db = new FormDBEntities())
            {
                var formData = db.formDatas.Find(submissionID);

                if (formData != null)
                {
                    if (action == "accept")
                    {
                        formData.ReqStatus = "Accepted";
                    }
                    else if (action == "decline")
                    {
                        formData.ReqStatus = "Declined";
                    }

                    db.SaveChanges();

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "Submission not found" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}