using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W14_MVC5.Models
{
    public class VideoDAO
    {
        private readonly VideoLinqDataContext _db = new VideoLinqDataContext();

        public List<Video> GetAll()
        {
            return _db.Videos.ToList();
        }

         public Video GetVideo(int id)
        {
            var video = _db.Videos.FirstOrDefault(v => v.id == id);
            return video;
        }

        public List<Video> Search(string keyword, string attribute = "title")
        {
            List<Video> videos;

            switch (attribute)
            {
                case "id":
                    videos = _db.Videos.Where(v => v.id.ToString().Contains(keyword)).ToList();
                    break;
                case "uploader":
                    videos = _db.Videos.Where(v => v.uploader.Contains(keyword)).ToList();
                    break;
                case "title":
                    videos = _db.Videos.Where(v => v.title.Contains(keyword)).ToList();
                    break;
                case "tags":
                    videos = _db.Videos.Where(v => v.tags.Contains(keyword)).ToList();
                    break;
                case "description":
                    videos = _db.Videos.Where(v => v.description.Contains(keyword)).ToList();
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
            catch (Exception e)
            {
                Console.WriteLine(e);
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