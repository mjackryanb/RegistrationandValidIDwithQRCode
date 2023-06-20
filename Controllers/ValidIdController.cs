using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using ValidIdv3.Models;

namespace ValidIdv3.Controllers
{
    public class ValidIdController : Controller
    {
        // GET: ValidId
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ValidIdClass vc, HttpPostedFileBase file)//gumagana
        {
            using (var dbContext = new RegistrationEntities()) // Replace ValidIDModel with your generated model's name
            {
                var validId = new Registration()
                {
                    FullName = vc.FullName,
                    MobileNumber = vc.MobileNumber,
                    DateofVisit = vc.DateofVisit,
                    Department = vc.Department,
                    PurposeofVisit = vc.PurposeofVisit
                };

                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetExtension(file.FileName);
                    string uniqueFileName = vc.FullName + filename;
                    string imgpath = Path.Combine(Server.MapPath("~/Visitor-ValidID/"), uniqueFileName);
                    string selfiepath = Path.Combine(Server.MapPath("~/Visitor-Selfie/"), uniqueFileName);
                    file.SaveAs(imgpath);
                    file.SaveAs(selfiepath);

                    validId.ValidID = "~/Visitor-ValidID/" + uniqueFileName;
                    validId.Selfie = "~/Visitor-Selfie/" + uniqueFileName;
                    validId.QRCode = "~/QRCode/" + uniqueFileName;
                }

                dbContext.Registration.Add(validId);
                dbContext.SaveChanges();
            }

            ViewData["Message"] = "Visitor Images are saved successfully!";
            return RedirectToAction("Generate", "QRCode", new
            {
                fullName = vc.FullName,
                dateOfVisit = vc.DateofVisit.ToString("yyyy-MM-dd"),
                department = vc.Department
            });
        }


    }
}