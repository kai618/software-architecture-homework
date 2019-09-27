using System.Collections.Generic;
using nLayers.DAL;
using nLayers.DTO.TSQL;

namespace nLayers.BLL
{
    class VideoBUS
    {
        public List<Video> GetAllVideos() => VideoDAO.Instance.GetAllVideos();

        public List<Video> Search(string keyword, string attribute) => VideoDAO.Instance.Search(keyword, attribute);

        public bool Add(Video video) => VideoDAO.Instance.Add(video);

        public bool Update(Video video) => VideoDAO.Instance.Update(video);

        public bool Delete(int id) => VideoDAO.Instance.Delete(id);
    }
}