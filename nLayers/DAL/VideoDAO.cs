using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using nLayers.DTO;

namespace nLayers.DAL
{
    class VideoDAO
    {
        private static VideoDAO _instance;
        public static VideoDAO Instance => _instance ?? (_instance = new VideoDAO());

        private VideoDAO() {}

        private readonly VideoManagerLINQDataContext _db = new VideoManagerLINQDataContext(ConfigurationManager
            .ConnectionStrings[@"nLayers.Properties.Settings.videodbConnectionString"].ConnectionString);

        public List<Video> GetAllVideos() => _db.Videos.ToList();

        public List<Video> Search(string keyword, string attribute)
        {
            var videos = new List<Video>();
            switch (attribute)
            {
                case "id":
                    videos =
                        (from video in _db.Videos where video.id.ToString().Contains(keyword) select video).ToList();
                    break;
                case "uploader":
                    videos = (from video in _db.Videos where video.uploader.Contains(keyword) select video).ToList();
                    break;
                case "title":
                    videos = (from video in _db.Videos where video.title.Contains(keyword) select video).ToList();
                    break;
                case "tags":
                    videos = (from video in _db.Videos where video.tags.Contains(keyword) select video).ToList();
                    break;
                case "description":
                    videos = (from video in _db.Videos where video.description.Contains(keyword) select video).ToList();
                    break;
                default:
                    videos = null;
                    break;
            }

            return videos;
        }

        public bool Add(Video video)
        {
            try
            {
                _db.Videos.InsertOnSubmit(video);
                _db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Video video)
        {
            try
            {
                var videoDb = _db.Videos.SingleOrDefault(v => v.id == video.id);
                if (videoDb == null) return false;

                videoDb.uploader = video.uploader;
                videoDb.title = video.title;
                videoDb.tags = video.tags;
                videoDb.description = video.description;
                videoDb.timestamp = video.timestamp;
                videoDb.url = video.url;

                _db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var videoDb = _db.Videos.SingleOrDefault(v => v.id == id);
                if (videoDb == null) return false;

                _db.Videos.DeleteOnSubmit(videoDb);
                _db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}