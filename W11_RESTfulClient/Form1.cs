using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace W11_RESTfulClient
{
    public partial class VideoManagerForm : Form
    {
        private const string Uri = "http://videosa.gear.host/api/videos/";


        public VideoManagerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadTable();
        }

        private void ReloadTable()
        {
            var client = new WebClient();
            var json = client.DownloadString(Uri);
            var videos = JsonConvert.DeserializeObject<List<Video>>(json);
            Console.WriteLine();
            videoGridView.DataSource = videos;
        }

        private void VideoGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = videoGridView.SelectedRows[0];
            textBox_id.Text = row.Cells["id"].Value.ToString();
            textBox_uploader.Text = row.Cells["uploader"].Value.ToString();
            textBox_title.Text = row.Cells["title"].Value.ToString();
            textBox_description.Text = row.Cells["description"].Value.ToString();
            textBox_tags.Text = row.Cells["tags"].Value.ToString();
            textBox_url.Text = row.Cells["url"].Value.ToString();
            textBox_timestamp.Text = row.Cells["timestamp"].Value.ToString();
        }

        private void Button_search_Click(object sender, EventArgs e)
        {
            var keyword = textBox_keyword.Text.Trim();

            if (string.IsNullOrEmpty(keyword)) return;

            var attribute = GetAttribute(comboBox_Attribute.SelectedIndex);

            var client = new WebClient();
            var json = client.DownloadString(Uri + attribute + "/" + keyword);
            var videos = JsonConvert.DeserializeObject<List<Video>>(json);

            videoGridView.DataSource = videos;
        }

        private static string GetAttribute(int index)
        {
            switch (index)
            {
                case 0: return "id";
                case 1: return "uploader";
                case 2: return "title";
                case 3: return "tags";
                case 4: return "description";
                default: return "";
            }
        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            if (!CheckValidData()) return;

            Enabled = false;

            var video = new Video
            {
                uploader = textBox_uploader.Text,
                title = textBox_title.Text,
                description = textBox_description.Text,
                timestamp = int.Parse(textBox_timestamp.Text),
                tags = textBox_tags.Text,
                url = textBox_url.Text
            };

            var videoJson = JsonConvert.SerializeObject(video);
            var client = new WebClient {Headers = {[HttpRequestHeader.ContentType] = "application/json"}};
            var status = client.UploadString(Uri, "POST", videoJson);

            if (status == "true")
            {
                ReloadTable();
                MessageBox.Show(@"Added!".PadLeft(18, ' '), @"Success");
            }

            Enabled = true;
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            if (!CheckValidData()) return;

            Enabled = false;


            var video = new Video
            {
                id = int.Parse(textBox_id.Text),
                uploader = textBox_uploader.Text,
                title = textBox_title.Text,
                description = textBox_description.Text,
                timestamp = int.Parse(textBox_timestamp.Text),
                tags = textBox_tags.Text,
                url = textBox_url.Text
            };

            var videoJson = JsonConvert.SerializeObject(video);
            var client = new WebClient {Headers = {[HttpRequestHeader.ContentType] = "application/json"}};
            var status = client.UploadString(Uri, "PUT", videoJson);

            if (status == "true")
            {
                ReloadTable();
                MessageBox.Show(@"Updated!".PadLeft(18, ' '), @"Success");
            }

            Enabled = true;
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if (!CheckValidData()) return;

            Enabled = false;

            var userSelect =
                MessageBox.Show(@"Are you sure?".PadLeft(38, ' '), @"Confirmation", MessageBoxButtons.YesNo);
            if (userSelect == DialogResult.Yes)
            {
                var id = int.Parse(textBox_id.Text);

                var client = new WebClient();
                var status = client.UploadString(Uri + id, "DELETE");

                if (status == "true")
                {
                    ReloadTable();
                    MessageBox.Show(@"Deleted!".PadLeft(18, ' '), @"Success");
                }
            }

            Enabled = true;
        }

        private bool CheckValidData()
        {
            var status = !(string.IsNullOrEmpty(textBox_id.Text) || string.IsNullOrEmpty(textBox_uploader.Text) ||
                           string.IsNullOrEmpty(textBox_title.Text));
            if (!status) MessageBox.Show(@"Invalid Data!".PadLeft(20, ' '), @"Error");
            return status;
        }

        private void ShowList_Click(object sender, EventArgs e)
        {
            ReloadTable();
        }
    }
}