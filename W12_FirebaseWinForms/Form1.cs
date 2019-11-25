using System;
using System.Windows.Forms;

namespace W12_FirebaseWinForms
{
    public partial class VideoManagerForm : Form
    {
        public VideoManagerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new VideoBUS().ListenFirebase(videoGridView);
        }


        private async void VideoGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (videoGridView.SelectedRows.Count <= 0) return;

            var id = int.Parse(videoGridView.SelectedRows[0].Cells["id"].Value.ToString());
            var video = await new VideoBUS().GetDetails(id);
            if (video == null) return;

            textBox_id.Text = video.id.ToString();
            textBox_uploader.Text = video.uploader;
            textBox_title.Text = video.title;
            textBox_description.Text = video.description;
            textBox_tags.Text = video.tags;
            textBox_url.Text = video.url;
            textBox_timestamp.Text = video.timestamp.ToString();
        }

        private async void Button_search_Click(object sender, EventArgs e)
        {
            //var attribute = GetAttribute(comboBox_Attribute.SelectedIndex);

            var keyword = textBox_keyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) return;
            var books = await new VideoBUS().Search(keyword);
            videoGridView.BeginInvoke(new MethodInvoker(delegate
            {
                videoGridView.DataSource = books;
            })); // set asynchronous data source
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

        private async void Button_add_Click(object sender, EventArgs e)
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

            var status = await new VideoBUS().AddNew(video);
            if (status)
            {
                MessageBox.Show(@"Added!".PadLeft(18, ' '), @"Success");
            }else AlertFailed();

            Enabled = true;
        }

        private async void Button_update_Click(object sender, EventArgs e)
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
            var status = await new VideoBUS().Update(video);

            if (status)
            {
                MessageBox.Show(@"Updated!".PadLeft(18, ' '), @"Success");
            }else AlertFailed();

            Enabled = true;
        }

        private async void Button_delete_Click(object sender, EventArgs e)
        {
            if (!CheckValidData()) return;

            Enabled = false;

            var userSelect =
                MessageBox.Show(@"Are you sure?".PadLeft(38, ' '), @"Confirmation", MessageBoxButtons.YesNo);
            if (userSelect == DialogResult.Yes)
            {
                var id = int.Parse(textBox_id.Text);

                var status = await new VideoBUS().Delete(id);

                if (status)
                {
                    MessageBox.Show(@"Deleted!".PadLeft(18, ' '), @"Success");
                }
                else AlertFailed();
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

        private void AlertFailed()
        {
            MessageBox.Show(@"Failed!".PadLeft(25, ' '), @"Error");
        }

        private void ShowList_Click(object sender, EventArgs e)
        {
            new VideoBUS().ListenFirebase(videoGridView);
        }
    }
}