using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ClientServer.DTO;

namespace ClientServer.DAL
{
    class VideoDAO
    {
        private static VideoDAO _instance;
        public static VideoDAO Instance => _instance ?? (_instance = new VideoDAO());

        private VideoDAO()
        { }



        private readonly LinqDbDataContext connection = new LinqDbDataContext(ConfigurationManager
            .ConnectionStrings[@"videodbConnectionString"].ConnectionString);

        public List<Video> GetAllVideos() => connection.Videos.ToList();

        public List<Video> Search(string keyword)
        {
            var videos = connection.Videos.Where(v => v.title.Contains(keyword)).ToList();
            return videos;
        }

        public bool Add(Video video)
        {
            try
            {
                connection.Videos.InsertOnSubmit(video);
                connection.SubmitChanges();
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
                var videoDb = connection.Videos.SingleOrDefault(v => v.id == video.id);
                if (videoDb == null) return false;

                videoDb.uploader = video.uploader;
                videoDb.title = video.title;
                videoDb.tags = video.tags;
                videoDb.description = video.description;
                videoDb.timestamp = video.timestamp;
                videoDb.url = video.url;

                connection.SubmitChanges();

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
                var videoDb = connection.Videos.SingleOrDefault(v => v.id == id);
                if (videoDb == null) return false;

                connection.Videos.DeleteOnSubmit(videoDb);
                connection.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}