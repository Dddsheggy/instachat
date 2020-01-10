namespace instachat
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_log_in = new System.Windows.Forms.Button();
            this.title_label = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.id_pic = new System.Windows.Forms.PictureBox();
            this.pwd_pic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.idlabel = new System.Windows.Forms.Label();
            this.pwdlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.id_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwd_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_log_in
            // 
            this.button_log_in.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_log_in.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_log_in.ForeColor = System.Drawing.Color.Black;
            this.button_log_in.Location = new System.Drawing.Point(75, 427);
            this.button_log_in.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_log_in.Name = "button_log_in";
            this.button_log_in.Size = new System.Drawing.Size(170, 61);
            this.button_log_in.TabIndex = 0;
            this.button_log_in.Text = "Get Started";
            this.button_log_in.UseVisualStyleBackColor = false;
            this.button_log_in.Click += new System.EventHandler(this.button_log_in_Click);
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Ink Free", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(82, 21);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(201, 47);
            this.title_label.TabIndex = 1;
            this.title_label.Text = "Instachat";
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.id.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.ForeColor = System.Drawing.Color.Black;
            this.id.Location = new System.Drawing.Point(89, 304);
            this.id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(190, 41);
            this.id.TabIndex = 2;
            this.id.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.password.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Black;
            this.password.Location = new System.Drawing.Point(89, 366);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(190, 41);
            this.password.TabIndex = 3;
            this.password.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // id_pic
            // 
            this.id_pic.BackgroundImage = global::instachat.Properties.Resources.uid;
            this.id_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.id_pic.Location = new System.Drawing.Point(46, 304);
            this.id_pic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.id_pic.Name = "id_pic";
            this.id_pic.Size = new System.Drawing.Size(37, 34);
            this.id_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.id_pic.TabIndex = 4;
            this.id_pic.TabStop = false;
            // 
            // pwd_pic
            // 
            this.pwd_pic.BackgroundImage = global::instachat.Properties.Resources.pwd;
            this.pwd_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pwd_pic.Location = new System.Drawing.Point(46, 366);
            this.pwd_pic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pwd_pic.Name = "pwd_pic";
            this.pwd_pic.Size = new System.Drawing.Size(37, 34);
            this.pwd_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pwd_pic.TabIndex = 5;
            this.pwd_pic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::instachat.Properties.Resources.back1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(60, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 210);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // idlabel
            // 
            this.idlabel.AutoSize = true;
            this.idlabel.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlabel.ForeColor = System.Drawing.Color.LightGray;
            this.idlabel.Location = new System.Drawing.Point(95, 307);
            this.idlabel.Name = "idlabel";
            this.idlabel.Size = new System.Drawing.Size(232, 34);
            this.idlabel.TabIndex = 7;
            this.idlabel.Text = "username             ";
            this.idlabel.Click += new System.EventHandler(this.label_Click);
            // 
            // pwdlabel
            // 
            this.pwdlabel.AutoSize = true;
            this.pwdlabel.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdlabel.ForeColor = System.Drawing.Color.LightGray;
            this.pwdlabel.Location = new System.Drawing.Point(96, 369);
            this.pwdlabel.Name = "pwdlabel";
            this.pwdlabel.Size = new System.Drawing.Size(230, 34);
            this.pwdlabel.TabIndex = 8;
            this.pwdlabel.Text = "password             ";
            this.pwdlabel.Click += new System.EventHandler(this.label_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(324, 523);
            this.Controls.Add(this.pwdlabel);
            this.Controls.Add(this.idlabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pwd_pic);
            this.Controls.Add(this.id_pic);
            this.Controls.Add(this.password);
            this.Controls.Add(this.id);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.button_log_in);
            this.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "instachat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.id_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwd_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_log_in;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.PictureBox id_pic;
        private System.Windows.Forms.PictureBox pwd_pic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label idlabel;
        private System.Windows.Forms.Label pwdlabel;
    }
}