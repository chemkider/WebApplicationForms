using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class FormController : Controller
    {
        
        public ActionResult form1()
        {
            return View();
        }
        public ActionResult form2()
        {
            return View();
        }
        public ActionResult form3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitForm(formData model, int formType)
        {
            //Define SubTime through Time.Now() and add it to the Model Input
            //Define FormID (Foreign Key) based on what option was chosen in the previous page and add it to the Model Input
            if (ModelState.IsValid)
            {
                model.SubTime = DateTime.Now;
                model.formID=formType;
                using (FormDBEntities db = new FormDBEntities())
                {
                    db.formDatas.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View(model);
        }

       /* [HttpPost]
        public ActionResult Form2(formData model)
        {
            //Define SubTime through Time.Now() and add it to the Model Input
            //Define FormID (Foreign Key) based on what option was chosen in the previous page and add it to the Model Input
            if (ModelState.IsValid)
            {
                model.SubTime = DateTime.Now;
                model.formID = 2;
                using (FormDBEntities db = new FormDBEntities())
                {
                    db.formDatas.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Form3(formData model)
        {
            //Define SubTime through Time.Now() and add it to the Model Input
            //Define FormID (Foreign Key) based on what option was chosen in the previous page and add it to the Model Input
            if (ModelState.IsValid)
            {
                model.SubTime = DateTime.Now;
                model.formID = 3;
                using (FormDBEntities db = new FormDBEntities())
                {
                    db.formDatas.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(model);
        }*/
    }
}