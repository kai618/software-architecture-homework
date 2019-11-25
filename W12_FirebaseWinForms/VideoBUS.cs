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
            //var fbVideos = await _fb.Child("videos").OnceAsync<Video>();
            var fbVideos = await _fb.Child("videos").OnceSingleAsync<List<Video>>();
            foreach (var video in fbVideos)
            {
                videos.Add(video);
                Debug.WriteLine(video.id);
            }

            return videos;
        }

        public async Task<Video> GetDetails(int id)
        {
            var fbVideos = await _fb.Child("videos").OnceSingleAsync<List<Video>>();
            foreach (var item in fbVideos)
                if (item.id == id)
                    return item;
            return
                null;
        }

        public async Task<List<Video>> Search(string keyword)
        {
            var videos = new List<Video>();
            var fbVideos = await _fb.Child("videos").OnceSingleAsync<List<Video>>();
            foreach (var item in fbVideos)
                if (item.title.Contains(keyword))
                    videos.Add(item);
            return videos;
        }

        public async Task<bool> AddNew(Video video)
        {
            try
            {
                await _fb.Child("videos").PostAsync(video); // auto-generated key
                //await _fb.Child("videos").Child("B" + video.id).PutAsync(video); // custom key
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
                var key = await GetKeyByCode(video.id);
                if (string.IsNullOrEmpty(key)) return false;
                await _fb.Child("videos").Child(key).PutAsync(video);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var key = await GetKeyByCode(id);
                if (string.IsNullOrEmpty(key)) return false;
                await _fb.Child("videos").Child(key).DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<string> GetKeyByCode(int id)
        {
            var fbVideos = await _fb.Child("videos").OnceAsync<Video>();
            foreach (var item in fbVideos)
                if (item.Object.id == id)
                    return item.Key;
            return null;
        }
    }
}