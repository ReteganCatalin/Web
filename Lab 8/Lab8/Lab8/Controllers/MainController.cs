using Lab8.Communication_Layer;
using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View("ViewMain");
        }

        public ActionResult GetFiles()
        {
            CommunicationLayer com = new CommunicationLayer();
            List<File> fileList = com.GetFiles();
            return Json(new { files = fileList }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetFormats()
        {
            CommunicationLayer com = new CommunicationLayer();
            List<string> formatList = com.GetAllFormats();
            return Json(new { formats = formatList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGenres()
        {
            CommunicationLayer com = new CommunicationLayer();
            List<string> genreList = com.GetAllGenres();
            return Json(new { genres = genreList }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DeleteFile()
        {
            CommunicationLayer com = new CommunicationLayer();
            bool result = com.DeleteFile(int.Parse(Request.Params["id"]));
            return Json(new { success = result });
        }

        public ActionResult SaveFile()
        {
            CommunicationLayer com = new CommunicationLayer();
            File file = new File();
            file.Title= Request.Params["title"];
            file.Genre = Request.Params["genre"];
            file.Format = Request.Params["format"];
            file.Location = Request.Params["location"];

            bool result = com.AddFile(file);
            return Json(new { success = result });
        }
        public ActionResult UpdateFile()
        {
            CommunicationLayer com = new CommunicationLayer();
            File file = new File();
            file.Id = Int32.Parse(Request.Params["id"]);
            file.Title = Request.Params["title"];
            file.Genre = Request.Params["genre"];
            file.Format = Request.Params["format"];
            file.Location = Request.Params["location"];

            bool result = com.UpdateFile(file);
            return Json(new { success = result });
        }


        public ActionResult GetFilesOfGenre()
        {
            string genre = Request.Params["genre"];
            CommunicationLayer com = new CommunicationLayer();
            List<File> fileList = com.GetAllFilesWithGenre(genre);
            return Json(new { files = fileList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFilesOfFormat()
        {
            string format = Request.Params["format"];
            CommunicationLayer com = new CommunicationLayer();
            List<File> fileList = com.GetAllFilesWithFormat(format);
            return Json(new { files = fileList }, JsonRequestBehavior.AllowGet);
        }
    }
}