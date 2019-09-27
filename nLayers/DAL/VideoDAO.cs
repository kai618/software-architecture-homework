using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using nLayers.DTO.TSQL;

namespace nLayers.DAL
{
    class VideoDAO
    {
        private static VideoDAO _instance;
        public static VideoDAO Instance => _instance ?? (_instance = new VideoDAO());

        private VideoDAO()
        {
        }

        public List<Video> GetAllVideos()
        {
            var strCon = ConfigurationManager.ConnectionStrings[@"nLayers.Properties.Settings.videodbConnectionString"]
                .ConnectionString;
            var connection = new SqlConnection(strCon);
            connection.Open();

            var videos = new List<Video>();

            const string cmdText =
                "SELECT * FROM Video";

            var cmd = new SqlCommand(cmdText, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                videos.Add(new Video
                {
                    id = (int) reader["id"],
                    title = (string) reader["title"],
                    uploader = (string) reader["uploader"],
                    tags = (string) reader["tags"],
                    description = (string) reader["description"],
                    url = (string) reader["url"],
                    timestamp = (int) reader["timestamp"]
                });
            }

            connection.Close();
            return videos;
        }

        public List<Video> Search(string keyword, string attribute)
        {
            var strCon = ConfigurationManager.ConnectionStrings[@"nLayers.Properties.Settings.videodbConnectionString"]
                .ConnectionString;
            var connection = new SqlConnection(strCon);
            connection.Open();

            var videos = new List<Video>();
            var cmdText = $"SELECT * FROM Video WHERE {attribute} LIKE '%{keyword}%'";

            var cmd = new SqlCommand(cmdText, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                videos.Add(new Video
                {
                    id = (int) reader["id"],
                    title = (string) reader["title"],
                    uploader = (string) reader["uploader"],
                    tags = (string) reader["tags"],
                    description = (string) reader["description"],
                    url = (string) reader["url"],
                    timestamp = (int) reader["timestamp"]
                });
            }

            connection.Close();
            return videos;
        }

        public bool Add(Video video)
        {
            var strCon = ConfigurationManager.ConnectionStrings[@"nLayers.Properties.Settings.videodbConnectionString"]
                .ConnectionString;
            var connection = new SqlConnection(strCon);
            connection.Open();

            const string cmdText =
                "INSERT INTO Video VALUES(@uploader, @title, @description, @tags, @url, @timestamp)";

            var cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add(new SqlParameter("@uploader", video.uploader));
            cmd.Parameters.Add(new SqlParameter("@title", video.title));
            cmd.Parameters.Add(new SqlParameter("@description", video.description));
            cmd.Parameters.Add(new SqlParameter("@tags", video.tags));
            cmd.Parameters.Add(new SqlParameter("@url", video.url));
            cmd.Parameters.Add(new SqlParameter("@timestamp", video.timestamp));

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Video video)
        {
            var strCon = ConfigurationManager.ConnectionStrings[@"nLayers.Properties.Settings.videodbConnectionString"]
                .ConnectionString;
            var connection = new SqlConnection(strCon);
            connection.Open();

            const string cmdText =
                "UPDATE Video SET uploader=@uploader, title=@title, description=@description, tags=@tags, url=@url, timestamp=@timestamp WHERE id=@id";

            var cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add(new SqlParameter("@id", video.id));
            cmd.Parameters.Add(new SqlParameter("@uploader", video.uploader));
            cmd.Parameters.Add(new SqlParameter("@title", video.title));
            cmd.Parameters.Add(new SqlParameter("@description", video.description));
            cmd.Parameters.Add(new SqlParameter("@tags", video.tags));
            cmd.Parameters.Add(new SqlParameter("@url", video.url));
            cmd.Parameters.Add(new SqlParameter("@timestamp", video.timestamp));

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            var strCon = ConfigurationManager.ConnectionStrings[@"nLayers.Properties.Settings.videodbConnectionString"]
                .ConnectionString;
            var connection = new SqlConnection(strCon);
            connection.Open();

            const string cmdText = "DELETE FROM Video WHERE id=@id";
            var cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            return cmd.ExecuteNonQuery() > 0;
        }

        #region LINQ Code

        //private readonly VideoManagerLINQDataContext connection = new VideoManagerLINQDataContext(ConfigurationManager
        //    .ConnectionStrings[@"nLayers.Properties.Settings.videodbConnectionString"].ConnectionString);

        //public List<Video> GetAllVideos() => connection.Videos.ToList();

        //public List<Video> Search(string keyword, string attribute)
        //{
        //    var videos = new List<Video>();
        //    switch (attribute)
        //    {
        //        case "id":
        //            videos = connection.Videos.Where(v => v.id.ToString().Contains(keyword)).ToList();
        //            break;
        //        case "uploader":
        //            videos = connection.Videos.Where(v => v.uploader.Contains(keyword)).ToList();
        //            break;
        //        case "title":
        //            videos = connection.Videos.Where(v => v.title.Contains(keyword)).ToList();
        //            break;
        //        case "tags":
        //            videos = connection.Videos.Where(v => v.tags.Contains(keyword)).ToList();
        //            break;
        //        case "description":
        //            videos = connection.Videos.Where(v => v.description.Contains(keyword)).ToList();
        //            break;
        //        default:
        //            videos = null;
        //            break;
        //    }

        //    return videos;
        //}

        //public bool Add(Video video)
        //{
        //    try
        //    {
        //        connection.Videos.InsertOnSubmit(video);
        //        connection.SubmitChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool Update(Video video)
        //{
        //    try
        //    {
        //        var videoDb = connection.Videos.SingleOrDefault(v => v.id == video.id);
        //        if (videoDb == null) return false;

        //        videoDb.uploader = video.uploader;
        //        videoDb.title = video.title;
        //        videoDb.tags = video.tags;
        //        videoDb.description = video.description;
        //        videoDb.timestamp = video.timestamp;
        //        videoDb.url = video.url;

        //        connection.SubmitChanges();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var videoDb = connection.Videos.SingleOrDefault(v => v.id == id);
        //        if (videoDb == null) return false;

        //        connection.Videos.DeleteOnSubmit(videoDb);
        //        connection.SubmitChanges();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        #endregion
    }
}