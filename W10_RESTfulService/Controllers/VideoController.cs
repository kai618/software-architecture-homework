using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using W10_RESTfulService.DAL;
using W10_RESTfulService.Models;

namespace W10_RESTfulService.Controllers
{
    public class VideoController : ApiController
    {
        [Route("api/videos")]
        [HttpGet]
        public List<Video> GetAll()
        {
            return new VideoDAO().GetAllVideos();
        }

        [Route("api/videos/{id}")]
        [HttpGet]
        public Video GetVideo(int id)
        {
            return new VideoDAO().GetVideo(id);
        }
        
        [Route("api/videos/{attribute}/{keyword}")]
        [HttpGet]
        public List<Video> Search(string attribute, string keyword)
        {
            return new VideoDAO().Search(keyword, attribute);
        }

        [Route("api/videos")]
        [HttpPost]
        public bool Add(Video video)
        {
            return new VideoDAO().Add(video);
        }

        [Route("api/videos")]
        [HttpPut]
        public bool Update(Video video)
        {
            return new VideoDAO().Update(video);
        }

        [Route("api/videos/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return new VideoDAO().Delete(id);
        }
    }
}