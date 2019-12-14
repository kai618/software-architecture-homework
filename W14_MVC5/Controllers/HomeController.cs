using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W14_MVC5.Models;

namespace W14_MVC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly VideoDAO _DAO = new VideoDAO();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllVideos()
        {
            var videos = _DAO.GetAll();
            return Json(videos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetails(int id)
        {
            var video = _DAO.GetVideo(id);
            return Json(video, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Search(string keyword)
        {
            var videos = _DAO.Search(keyword);
            return Json(videos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(Video video)
        {
            var status = _DAO.Add(video);
            return Json(status);
        }


        [HttpPost]
        public ActionResult Update(Video video)
        {
            var status = _DAO.Update(video);
            return Json(status);
        }

        public ActionResult Delete(int id)
        {
            var status = _DAO.Delete(id);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}