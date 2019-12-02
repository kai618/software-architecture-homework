using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace W12_FirebaseWinForms
{
    class VideoBUS
    {
        private const string FbRoot = "https://sprout-sa.firebaseio.com/";
        private readonly FirebaseClient _fb = new FirebaseClient(FbRoot);

        public void ListenFirebase(DataGridView gridVideo)
        {
            _fb.Child("videos").AsObservable<Video>().Subscribe(async _ =>
            {
                List<Video> videos = await GetAll();
                gridVideo.BeginInvoke(new MethodInvoker(delegate { gridVideo.DataSource = videos; }));
            });
        }

        public async Task<List<Video>> GetAll()
        {
            var videos = new List<Video>();
            var fbVideos = await _fb.Child("videos").OnceAsync<Video>();
            foreach (var video in fbVideos)
            {
                videos.Add(video.Object);
                Debug.WriteLine(video.Object.id);
            }

            return videos;
        }

        public async Task<Video> GetDetails(string id)
        {
            var fbVideos = await _fb.Child("videos").OnceAsync<Video>();
            foreach (var item in fbVideos)
                if (item.Object.id == id)
                    return item.Object;
            return
                null;
        }

        public async Task<List<Video>> Search(string keyword)
        {
            var videos = new List<Video>();
            var fbVideos = await _fb.Child("videos").OnceAsync<Video>();
            foreach (var item in fbVideos)
                if (item.Object.title.ToLower().Contains(keyword.ToLower()))
                    videos.Add(item.Object);
            return videos;
        }

        public async Task<bool> AddNew(Video video)
        {
            try
            {
                //await _fb.Child("videos").PostAsync(video); // auto-generated key
                await _fb.Child("videos").Child(video.id).PutAsync(video); // custom key
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Video video)
        {
            try
            {
                var exist = await CheckId(video.id);
                if (string.IsNullOrEmpty(video.id.ToString()) && !exist) return false;
                await _fb.Child("videos").Child(video.id.ToString()).PutAsync(video);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var exist = await CheckId(id);
                if (string.IsNullOrEmpty(id) && !exist) return false;
                await _fb.Child("videos").Child(id).DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> CheckId(string id)
        {
            var fbVideos = await _fb.Child("videos").OnceAsync<Video>();
            foreach (var item in fbVideos)
                if (item.Object.id == id)
                    return true;
            return false;
        }
    }
}