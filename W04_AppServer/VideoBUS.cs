using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared;

namespace W04_AppServer
{
    class VideoBUS : MarshalByRefObject, IVideoBUS
    {
        public List<Video> GetAll() => new VideoDAO().GetAllVideos();

        public List<Video> Search(string keyword, string attribute) => new VideoDAO().Search(keyword, attribute);

        public bool Add(Video video) => new VideoDAO().Add(video);

        public bool Update(Video video) => new VideoDAO().Update(video);

        public bool Delete(int id) => new VideoDAO().Delete(id);
    }

}