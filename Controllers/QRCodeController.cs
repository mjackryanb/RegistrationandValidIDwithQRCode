using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using QRCoder;
using System.IO;
using System.Web.Mvc;

namespace ValidIdv3.Controllers
{
    public class QRCodeController : Controller
    {
        // GET: QRCode
       //public ActionResult Index()
        //{
            //return View();
        //}

        public ActionResult Generate(string fullName, string dateOfVisit, string department)
        {
            // Generate the QR code using the provided data
            string qrCodeText = $"{fullName} - {dateOfVisit} - {department}";
            Bitmap qrCodeImage = GenerateQRCodeImage(qrCodeText);

            // Save the QR code image to a file
            string qrCodeFileName = SaveQRCodeImage(qrCodeImage, fullName);

            // Pass the file name to the view using ViewBag
            ViewBag.QRCodeFileName = qrCodeFileName;

            return View();
        }
        private Bitmap GenerateQRCodeImage(string qrCodeText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }

        private string SaveQRCodeImage(Bitmap qrCodeImage, string fullname)
        {
            //string qrCodeFileName = $"{Guid.NewGuid()}.png";
            string FullNameFileName = $"{fullname}_QRCode.png";
            string qrCodeFilePath = Path.Combine(Server.MapPath("~/QRCode/"), FullNameFileName);
            qrCodeImage.Save(qrCodeFilePath, ImageFormat.Png);


            return FullNameFileName;
        }
    }
}