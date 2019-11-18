using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W11_RESTfulClient
{
    class Video
    {
        public int id { get; set; }

        public string uploader { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string tags { get; set; }

        public string url { get; set; }

        public int timestamp { get; set; }
    }
}