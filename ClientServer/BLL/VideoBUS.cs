using System.Collections.Generic;
using ClientServer.DAL;
using ClientServer.DTO;

namespace ClientServer.BLL
{
    class VideoBUS
    {
        public List<Video> GetAllVideos() => VideoDAO.Instance.GetAllVideos();

        public List<Video> Search(string keyword) => VideoDAO.Instance.Search(keyword);

        public bool Add(Video video) => VideoDAO.Instance.Add(video);

        public bool Update(Video video) => VideoDAO.Instance.Update(video);

        public bool Delete(int id) => VideoDAO.Instance.Delete(id);
    }
}