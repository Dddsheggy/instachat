namespace instachat
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.contacts_list = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Alias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ST = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_chat = new System.Windows.Forms.Button();
            this.button_group_chat = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.id_to_search = new System.Windows.Forms.TextBox();
            this.button_change_alias = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contacts";
            // 
            // contacts_list
            // 
            this.contacts_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Alias,
            this.IP,
            this.ST});
            this.contacts_list.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contacts_list.FullRowSelect = true;
            this.contacts_list.HideSelection = false;
            this.contacts_list.Location = new System.Drawing.Point(12, 91);
            this.contacts_list.Name = "contacts_list";
            this.contacts_list.Size = new System.Drawing.Size(463, 326);
            this.contacts_list.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.contacts_list.TabIndex = 1;
            this.contacts_list.UseCompatibleStateImageBehavior = false;
            this.contacts_list.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "username";
            this.ID.Width = 120;
            // 
            // Alias
            // 
            this.Alias.Text = "Alias";
            this.Alias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Alias.Width = 120;
            // 
            // IP
            // 
            this.IP.Text = "IP Address";
            this.IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IP.Width = 155;
            // 
            // ST
            // 
            this.ST.Text = "State";
            this.ST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.Color.White;
            this.button_refresh.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.Location = new System.Drawing.Point(372, 51);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(79, 34);
            this.button_refresh.TabIndex = 2;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_chat
            // 
            this.button_chat.BackColor = System.Drawing.Color.White;
            this.button_chat.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_chat.Location = new System.Drawing.Point(12, 423);
            this.button_chat.Name = "button_chat";
            this.button_chat.Size = new System.Drawing.Size(132, 34);
            this.button_chat.TabIndex = 3;
            this.button_chat.Text = "Send Message";
            this.button_chat.UseVisualStyleBackColor = false;
            this.button_chat.Click += new System.EventHandler(this.button_chat_Click);
            // 
            // button_group_chat
            // 
            this.button_group_chat.BackColor = System.Drawing.Color.White;
            this.button_group_chat.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_group_chat.Location = new System.Drawing.Point(150, 423);
            this.button_group_chat.Name = "button_group_chat";
            this.button_group_chat.Size = new System.Drawing.Size(112, 34);
            this.button_group_chat.TabIndex = 4;
            this.button_group_chat.Text = "Group Chat";
            this.button_group_chat.UseVisualStyleBackColor = false;
            this.button_group_chat.Visible = false;
            this.button_group_chat.Click += new System.EventHandler(this.button_group_chat_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.White;
            this.button_delete.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.DarkRed;
            this.button_delete.Location = new System.Drawing.Point(408, 423);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(67, 34);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_logout
            // 
            this.button_logout.BackColor = System.Drawing.Color.White;
            this.button_logout.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logout.ForeColor = System.Drawing.Color.DarkRed;
            this.button_logout.Location = new System.Drawing.Point(381, 558);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(94, 34);
            this.button_logout.TabIndex = 6;
            this.button_logout.Text = "Log out";
            this.button_logout.UseVisualStyleBackColor = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.White;
            this.button_search.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.Location = new System.Drawing.Point(170, 51);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 34);
            this.button_search.TabIndex = 7;
            this.button_search.Text = "Add";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // id_to_search
            // 
            this.id_to_search.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_to_search.Location = new System.Drawing.Point(12, 51);
            this.id_to_search.Name = "id_to_search";
            this.id_to_search.Size = new System.Drawing.Size(145, 37);
            this.id_to_search.TabIndex = 8;
            // 
            // button_change_alias
            // 
            this.button_change_alias.BackColor = System.Drawing.Color.White;
            this.button_change_alias.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_change_alias.Location = new System.Drawing.Point(283, 423);
            this.button_change_alias.Name = "button_change_alias";
            this.button_change_alias.Size = new System.Drawing.Size(119, 34);
            this.button_change_alias.TabIndex = 10;
            this.button_change_alias.Text = "Change Alias";
            this.button_change_alias.UseVisualStyleBackColor = false;
            this.button_change_alias.Click += new System.EventHandler(this.button_change_alias_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::instachat.Properties.Resources.back2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 463);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 129);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 604);
            this.Controls.Add(this.button_change_alias);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.id_to_search);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_group_chat);
            this.Controls.Add(this.button_chat);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.contacts_list);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "instachat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView contacts_list;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader ST;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_chat;
        private System.Windows.Forms.Button button_group_chat;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox id_to_search;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_change_alias;
        private System.Windows.Forms.ColumnHeader Alias;
    }
}