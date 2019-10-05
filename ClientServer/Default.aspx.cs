using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientServer.BLL;
using ClientServer.DTO;

namespace ClientServer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = new VideoBUS().GetAllVideos();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = new VideoBUS().Search(TextBox1.Text);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = GridView1.SelectedRow;
            TextBox_Id.Text = row.Cells[1].Text;
            TextBox_Uploader.Text = row.Cells[2].Text;
            TextBox_Title.Text = row.Cells[3].Text;
            TextBox_Description.Text = row.Cells[4].Text;
            TextBox_Tags.Text = row.Cells[5].Text;
            TextBox_Url.Text = row.Cells[6].Text;
            TextBox_Timestamp.Text = row.Cells[7].Text;
        }

        protected void Button_add_Click(object sender, EventArgs e)
        {
            var video = new Video
            {
                uploader = TextBox_Uploader.Text,
                title = TextBox_Title.Text,
                description = TextBox_Description.Text,
                tags = TextBox_Tags.Text,
                url = TextBox_Url.Text,
                timestamp = int.Parse(TextBox_Timestamp.Text)
            };
            new VideoBUS().Add(video);

            GridView1.DataSource = new VideoBUS().GetAllVideos();
            GridView1.DataBind();
        }

        protected void Button_update_Click(object sender, EventArgs e)
        {
            var video = new Video
            {
                id = int.Parse(TextBox_Id.Text),
                uploader = TextBox_Uploader.Text,
                title = TextBox_Title.Text,
                description = TextBox_Description.Text,
                tags = TextBox_Tags.Text,
                url = TextBox_Url.Text,
                timestamp = int.Parse(TextBox_Timestamp.Text)
            };
            new VideoBUS().Update(video);
            GridView1.DataSource = new VideoBUS().GetAllVideos();
            GridView1.DataBind();
        }

        protected void Button_delete_Click(object sender, EventArgs e)
        {
            new VideoBUS().Delete(int.Parse(TextBox_Id.Text));
            GridView1.DataSource = new VideoBUS().GetAllVideos();
            GridView1.DataBind();
        }
    }
}