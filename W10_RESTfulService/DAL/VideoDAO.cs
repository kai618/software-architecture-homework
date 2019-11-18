using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using W10_RESTfulService.Models;

namespace W10_RESTfulService.DAL
{
    public class VideoDAO
    {
        private readonly videoLinqDataContext _connection = new videoLinqDataContext(ConfigurationManager
            .ConnectionStrings[@"videoDb"].ConnectionString);

        public List<Video> GetAllVideos()
        {
            return _connection.Videos.ToList();
        }

        public Video GetVideo(int id)
        {
            var video = _connection.Videos.FirstOrDefault(v => v.id == id);
            return video;
        }

        public List<Video> Search(string keyword, string attribute)
        {
            List<Video> videos;

            switch (attribute)
            {
                case "id":
                    videos = _connection.Videos.Where(v => v.id.ToString().Contains(keyword)).ToList();
                    break;
                case "uploader":
                    videos = _connection.Videos.Where(v => v.uploader.Contains(keyword)).ToList();
                    break;
                case "title":
                    videos = _connection.Videos.Where(v => v.title.Contains(keyword)).ToList();
                    break;
                case "tags":
                    videos = _connection.Videos.Where(v => v.tags.Contains(keyword)).ToList();
                    break;
                case "description":
                    videos = _connection.Videos.Where(v => v.description.Contains(keyword)).ToList();
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
                _connection.Videos.InsertOnSubmit(video);
                _connection.SubmitChanges();
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
                var videoDb = _connection.Videos.SingleOrDefault(v => v.id == video.id);
                if (videoDb == null) return false;

                videoDb.uploader = video.uploader;
                videoDb.title = video.title;
                videoDb.tags = video.tags;
                videoDb.description = video.description;
                videoDb.timestamp = video.timestamp;
                videoDb.url = video.url;

                _connection.SubmitChanges();

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
                var videoDb = _connection.Videos.SingleOrDefault(v => v.id == id);
                if (videoDb == null) return false;
                _connection.Videos.DeleteOnSubmit(videoDb);
                _connection.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}