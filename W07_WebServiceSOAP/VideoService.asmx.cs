using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace W07_WebServiceSOAP
{
    /// <summary>
    /// Summary description for VideoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VideoService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Video> GetAll() => new VideoDAO().GetAllVideos();

        [WebMethod]
        public List<Video> Search(string keyword, string attribute) => new VideoDAO().Search(keyword, attribute);

        [WebMethod]
        public bool Add(Video video) => new VideoDAO().Add(video);

        [WebMethod]
        public bool Update(Video video) => new VideoDAO().Update(video);

        [WebMethod]
        public bool Delete(int id) => new VideoDAO().Delete(id);
    }
}
