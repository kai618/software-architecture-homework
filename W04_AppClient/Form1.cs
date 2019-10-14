using AppShared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace W04_AppClient
{
    public partial class VideoManagerForm : Form
    {
        private const string Uri = "tcp://192.168.1.35:6969/xxx";

        public VideoManagerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var videos = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).GetAll();
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
            if (!string.IsNullOrEmpty(textBox_keyword.Text))
            {
                var videos = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).Search(
                    textBox_keyword.Text.Trim(),
                    GetAttribute(comboBox_Attribute.SelectedIndex));

                videoGridView.DataSource = videos;
            }
        }

        private string GetAttribute(int index)
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

            var status = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).Add(new Video
            {
                uploader = textBox_uploader.Text,
                title = textBox_title.Text,
                description = textBox_description.Text,
                timestamp = int.Parse(textBox_timestamp.Text),
                tags = textBox_tags.Text,
                url = textBox_url.Text
            });

            if (status)
            {
                videoGridView.DataSource = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).GetAll();
                MessageBox.Show(@"Added!".PadLeft(18, ' '), @"Success");
            }

            Enabled = true;
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            if (!CheckValidData()) return;

            Enabled = false;
            var status = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).Update(new Video
            {
                id = int.Parse(textBox_id.Text),
                uploader = textBox_uploader.Text,
                title = textBox_title.Text,
                description = textBox_description.Text,
                timestamp = int.Parse(textBox_timestamp.Text),
                tags = textBox_tags.Text,
                url = textBox_url.Text
            });

            if (status)
            {
                videoGridView.DataSource = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).GetAll();
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
                var status = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).Delete(int.Parse(textBox_id.Text));

                if (status)
                {
                    videoGridView.DataSource = ((IVideoBUS) Activator.GetObject(typeof(IVideoBUS), Uri)).GetAll();
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
    }
}