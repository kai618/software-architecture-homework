using System.Windows.Forms;

namespace W07_WinFormsClient
{
    partial class VideoManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxVideo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.comboBox_Attribute = new System.Windows.Forms.ComboBox();
            this.button_search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_uploader = new System.Windows.Forms.TextBox();
            this.textBox_timestamp = new System.Windows.Forms.TextBox();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.textBox_tags = new System.Windows.Forms.TextBox();
            this.textBox_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoGridView)).BeginInit();
            this.groupBoxVideo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoGridView
            // 
            this.videoGridView.AllowUserToAddRows = false;
            this.videoGridView.AllowUserToDeleteRows = false;
            this.videoGridView.AllowUserToResizeRows = false;
            this.videoGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.videoGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.videoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.videoGridView.Location = new System.Drawing.Point(13, 26);
            this.videoGridView.MultiSelect = false;
            this.videoGridView.Name = "videoGridView";
            this.videoGridView.ReadOnly = true;
            this.videoGridView.RowHeadersVisible = false;
            this.videoGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.videoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.videoGridView.Size = new System.Drawing.Size(910, 188);
            this.videoGridView.TabIndex = 0;
            this.videoGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VideoGridView_CellClick);
            // 
            // groupBoxVideo
            // 
            this.groupBoxVideo.Controls.Add(this.label1);
            this.groupBoxVideo.Controls.Add(this.textBox_keyword);
            this.groupBoxVideo.Controls.Add(this.comboBox_Attribute);
            this.groupBoxVideo.Controls.Add(this.button_search);
            this.groupBoxVideo.Controls.Add(this.videoGridView);
            this.groupBoxVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVideo.Location = new System.Drawing.Point(19, 19);
            this.groupBoxVideo.Margin = new System.Windows.Forms.Padding(10);
            this.groupBoxVideo.Name = "groupBoxVideo";
            this.groupBoxVideo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.groupBoxVideo.Size = new System.Drawing.Size(936, 271);
            this.groupBoxVideo.TabIndex = 1;
            this.groupBoxVideo.TabStop = false;
            this.groupBoxVideo.Text = "Videos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keyword:";
            // 
            // textBox_keyword
            // 
            this.textBox_keyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_keyword.Location = new System.Drawing.Point(95, 233);
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.Size = new System.Drawing.Size(538, 24);
            this.textBox_keyword.TabIndex = 4;
            // 
            // comboBox_Attribute
            // 
            this.comboBox_Attribute.FormattingEnabled = true;
            this.comboBox_Attribute.Items.AddRange(new object[] {
            "Id",
            "Uploader",
            "Title",
            "Tag",
            "Description"});
            this.comboBox_Attribute.Location = new System.Drawing.Point(639, 233);
            this.comboBox_Attribute.Name = "comboBox_Attribute";
            this.comboBox_Attribute.Size = new System.Drawing.Size(142, 24);
            this.comboBox_Attribute.TabIndex = 3;
            this.comboBox_Attribute.SelectedIndex = 2;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(787, 232);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(136, 26);
            this.button_search.TabIndex = 5;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.Button_search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button_update);
            this.groupBox1.Controls.Add(this.button_delete);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.textBox_uploader);
            this.groupBox1.Controls.Add(this.textBox_timestamp);
            this.groupBox1.Controls.Add(this.textBox_description);
            this.groupBox1.Controls.Add(this.textBox_title);
            this.groupBox1.Controls.Add(this.textBox_url);
            this.groupBox1.Controls.Add(this.textBox_tags);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 301);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(937, 315);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tags:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Uploader:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Timestamp:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Id:";
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(787, 85);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(136, 23);
            this.button_update.TabIndex = 10;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.Button_update_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(787, 279);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(136, 23);
            this.button_delete.TabIndex = 9;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.Button_delete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Title:";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(787, 41);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(136, 23);
            this.button_add.TabIndex = 7;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.Button_add_Click);
            // 
            // textBox_uploader
            // 
            this.textBox_uploader.Location = new System.Drawing.Point(95, 84);
            this.textBox_uploader.Name = "textBox_uploader";
            this.textBox_uploader.Size = new System.Drawing.Size(326, 22);
            this.textBox_uploader.TabIndex = 6;
            // 
            // textBox_timestamp
            // 
            this.textBox_timestamp.Location = new System.Drawing.Point(535, 85);
            this.textBox_timestamp.Name = "textBox_timestamp";
            this.textBox_timestamp.Size = new System.Drawing.Size(98, 22);
            this.textBox_timestamp.TabIndex = 5;
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(95, 215);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(538, 87);
            this.textBox_description.TabIndex = 4;
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(95, 130);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(242, 22);
            this.textBox_title.TabIndex = 3;
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(95, 173);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(538, 22);
            this.textBox_url.TabIndex = 2;
            // 
            // textBox_tags
            // 
            this.textBox_tags.Location = new System.Drawing.Point(404, 130);
            this.textBox_tags.Name = "textBox_tags";
            this.textBox_tags.Size = new System.Drawing.Size(229, 22);
            this.textBox_tags.TabIndex = 1;
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(95, 38);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(87, 22);
            this.textBox_id.TabIndex = 0;
            // 
            // VideoManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(974, 635);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxVideo);
            this.Name = "VideoManagerForm";
            this.Text = "Video Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoGridView)).EndInit();
            this.groupBoxVideo.ResumeLayout(false);
            this.groupBoxVideo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView videoGridView;
        private GroupBox groupBoxVideo;
        private GroupBox groupBox1;
        private TextBox textBox_keyword;
        private ComboBox comboBox_Attribute;
        private Label label1;
        private Button button_search;
        private TextBox textBox_timestamp;
        private TextBox textBox_description;
        private TextBox textBox_title;
        private TextBox textBox_url;
        private TextBox textBox_tags;
        private TextBox textBox_id;
        private Label label2;
        private Label label3;
        private Label label7;
        private Label label5;
        private Label label6;
        private Label label8;
        private Button button_update;
        private Button button_delete;
        private Label label4;
        private Button button_add;
        private TextBox textBox_uploader;
    }
}

