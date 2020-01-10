namespace instachat
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.TextBox_chat = new System.Windows.Forms.RichTextBox();
            this.TextBox_send = new System.Windows.Forms.RichTextBox();
            this.button_leave = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.TextBox_memebers = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_clear = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button_font = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_color = new System.Windows.Forms.Button();
            this.StickerList = new System.Windows.Forms.FlowLayoutPanel();
            this.s1 = new System.Windows.Forms.Button();
            this.s2 = new System.Windows.Forms.Button();
            this.s3 = new System.Windows.Forms.Button();
            this.s4 = new System.Windows.Forms.Button();
            this.s5 = new System.Windows.Forms.Button();
            this.s6 = new System.Windows.Forms.Button();
            this.s7 = new System.Windows.Forms.Button();
            this.s8 = new System.Windows.Forms.Button();
            this.s9 = new System.Windows.Forms.Button();
            this.s10 = new System.Windows.Forms.Button();
            this.s11 = new System.Windows.Forms.Button();
            this.s12 = new System.Windows.Forms.Button();
            this.s13 = new System.Windows.Forms.Button();
            this.s14 = new System.Windows.Forms.Button();
            this.s15 = new System.Windows.Forms.Button();
            this.s16 = new System.Windows.Forms.Button();
            this.button_B = new System.Windows.Forms.Button();
            this.button_I = new System.Windows.Forms.Button();
            this.button_U = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_shake = new System.Windows.Forms.Button();
            this.button_file = new System.Windows.Forms.Button();
            this.button_sticker = new System.Windows.Forms.Button();
            this.StickerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox_chat
            // 
            this.TextBox_chat.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_chat.Location = new System.Drawing.Point(12, 12);
            this.TextBox_chat.Name = "TextBox_chat";
            this.TextBox_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextBox_chat.Size = new System.Drawing.Size(647, 384);
            this.TextBox_chat.TabIndex = 0;
            this.TextBox_chat.Text = "";
            // 
            // TextBox_send
            // 
            this.TextBox_send.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_send.Location = new System.Drawing.Point(12, 447);
            this.TextBox_send.Name = "TextBox_send";
            this.TextBox_send.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextBox_send.Size = new System.Drawing.Size(647, 156);
            this.TextBox_send.TabIndex = 1;
            this.TextBox_send.Text = "";
            this.TextBox_send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_send_KeyPress);
            // 
            // button_leave
            // 
            this.button_leave.BackColor = System.Drawing.Color.White;
            this.button_leave.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_leave.ForeColor = System.Drawing.Color.DarkRed;
            this.button_leave.Location = new System.Drawing.Point(790, 609);
            this.button_leave.Name = "button_leave";
            this.button_leave.Size = new System.Drawing.Size(68, 41);
            this.button_leave.TabIndex = 3;
            this.button_leave.Text = "Leave";
            this.button_leave.UseVisualStyleBackColor = false;
            this.button_leave.Click += new System.EventHandler(this.button_leave_Click);
            // 
            // button_send
            // 
            this.button_send.BackColor = System.Drawing.Color.White;
            this.button_send.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_send.ForeColor = System.Drawing.Color.Lime;
            this.button_send.Location = new System.Drawing.Point(530, 609);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(59, 41);
            this.button_send.TabIndex = 4;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = false;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            this.button_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_send_KeyDown);
            this.button_send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button_send_KeyPress);
            // 
            // TextBox_memebers
            // 
            this.TextBox_memebers.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_memebers.Location = new System.Drawing.Point(665, 12);
            this.TextBox_memebers.Name = "TextBox_memebers";
            this.TextBox_memebers.Size = new System.Drawing.Size(193, 384);
            this.TextBox_memebers.TabIndex = 10;
            this.TextBox_memebers.Text = "";
            this.TextBox_memebers.WordWrap = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.White;
            this.button_clear.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.ForeColor = System.Drawing.Color.DarkRed;
            this.button_clear.Location = new System.Drawing.Point(596, 609);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(63, 41);
            this.button_clear.TabIndex = 12;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_font
            // 
            this.button_font.BackColor = System.Drawing.Color.White;
            this.button_font.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_font.ForeColor = System.Drawing.Color.Black;
            this.button_font.Location = new System.Drawing.Point(394, 400);
            this.button_font.Name = "button_font";
            this.button_font.Size = new System.Drawing.Size(59, 41);
            this.button_font.TabIndex = 16;
            this.button_font.Text = "Font";
            this.button_font.UseVisualStyleBackColor = false;
            this.button_font.Click += new System.EventHandler(this.button_font_Click);
            // 
            // button_color
            // 
            this.button_color.BackColor = System.Drawing.Color.White;
            this.button_color.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_color.ForeColor = System.Drawing.Color.Black;
            this.button_color.Location = new System.Drawing.Point(459, 400);
            this.button_color.Name = "button_color";
            this.button_color.Size = new System.Drawing.Size(59, 41);
            this.button_color.TabIndex = 17;
            this.button_color.Text = "Color";
            this.button_color.UseVisualStyleBackColor = false;
            this.button_color.Click += new System.EventHandler(this.button_color_Click);
            // 
            // StickerList
            // 
            this.StickerList.Controls.Add(this.s1);
            this.StickerList.Controls.Add(this.s2);
            this.StickerList.Controls.Add(this.s3);
            this.StickerList.Controls.Add(this.s4);
            this.StickerList.Controls.Add(this.s5);
            this.StickerList.Controls.Add(this.s6);
            this.StickerList.Controls.Add(this.s7);
            this.StickerList.Controls.Add(this.s8);
            this.StickerList.Controls.Add(this.s9);
            this.StickerList.Controls.Add(this.s10);
            this.StickerList.Controls.Add(this.s11);
            this.StickerList.Controls.Add(this.s12);
            this.StickerList.Controls.Add(this.s13);
            this.StickerList.Controls.Add(this.s14);
            this.StickerList.Controls.Add(this.s15);
            this.StickerList.Controls.Add(this.s16);
            this.StickerList.Location = new System.Drawing.Point(12, 157);
            this.StickerList.Name = "StickerList";
            this.StickerList.Size = new System.Drawing.Size(224, 239);
            this.StickerList.TabIndex = 19;
            // 
            // s1
            // 
            this.s1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s1.BackgroundImage")));
            this.s1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s1.Location = new System.Drawing.Point(3, 3);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(50, 50);
            this.s1.TabIndex = 0;
            this.s1.UseVisualStyleBackColor = true;
            this.s1.Click += new System.EventHandler(this.s1_Click);
            // 
            // s2
            // 
            this.s2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s2.BackgroundImage")));
            this.s2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s2.Location = new System.Drawing.Point(59, 3);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(50, 50);
            this.s2.TabIndex = 1;
            this.s2.UseVisualStyleBackColor = true;
            this.s2.Click += new System.EventHandler(this.s2_Click);
            // 
            // s3
            // 
            this.s3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s3.BackgroundImage")));
            this.s3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s3.Location = new System.Drawing.Point(115, 3);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(50, 50);
            this.s3.TabIndex = 2;
            this.s3.UseVisualStyleBackColor = true;
            this.s3.Click += new System.EventHandler(this.s3_Click);
            // 
            // s4
            // 
            this.s4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s4.BackgroundImage")));
            this.s4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s4.Location = new System.Drawing.Point(171, 3);
            this.s4.Name = "s4";
            this.s4.Size = new System.Drawing.Size(50, 50);
            this.s4.TabIndex = 3;
            this.s4.UseVisualStyleBackColor = true;
            this.s4.Click += new System.EventHandler(this.s4_Click);
            // 
            // s5
            // 
            this.s5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s5.BackgroundImage")));
            this.s5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s5.Location = new System.Drawing.Point(3, 59);
            this.s5.Name = "s5";
            this.s5.Size = new System.Drawing.Size(50, 50);
            this.s5.TabIndex = 4;
            this.s5.UseVisualStyleBackColor = true;
            this.s5.Click += new System.EventHandler(this.s5_Click);
            // 
            // s6
            // 
            this.s6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s6.BackgroundImage")));
            this.s6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s6.Location = new System.Drawing.Point(59, 59);
            this.s6.Name = "s6";
            this.s6.Size = new System.Drawing.Size(50, 50);
            this.s6.TabIndex = 5;
            this.s6.UseVisualStyleBackColor = true;
            this.s6.Click += new System.EventHandler(this.s6_Click);
            // 
            // s7
            // 
            this.s7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s7.BackgroundImage")));
            this.s7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s7.Location = new System.Drawing.Point(115, 59);
            this.s7.Name = "s7";
            this.s7.Size = new System.Drawing.Size(50, 50);
            this.s7.TabIndex = 6;
            this.s7.UseVisualStyleBackColor = true;
            this.s7.Click += new System.EventHandler(this.s7_Click);
            // 
            // s8
            // 
            this.s8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s8.BackgroundImage")));
            this.s8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s8.Location = new System.Drawing.Point(171, 59);
            this.s8.Name = "s8";
            this.s8.Size = new System.Drawing.Size(50, 50);
            this.s8.TabIndex = 7;
            this.s8.UseVisualStyleBackColor = true;
            this.s8.Click += new System.EventHandler(this.s8_Click);
            // 
            // s9
            // 
            this.s9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s9.BackgroundImage")));
            this.s9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s9.Location = new System.Drawing.Point(3, 115);
            this.s9.Name = "s9";
            this.s9.Size = new System.Drawing.Size(50, 50);
            this.s9.TabIndex = 8;
            this.s9.UseVisualStyleBackColor = true;
            this.s9.Click += new System.EventHandler(this.s9_Click);
            // 
            // s10
            // 
            this.s10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s10.BackgroundImage")));
            this.s10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s10.Location = new System.Drawing.Point(59, 115);
            this.s10.Name = "s10";
            this.s10.Size = new System.Drawing.Size(50, 50);
            this.s10.TabIndex = 9;
            this.s10.UseVisualStyleBackColor = true;
            this.s10.Click += new System.EventHandler(this.s10_Click);
            // 
            // s11
            // 
            this.s11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s11.BackgroundImage")));
            this.s11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s11.Location = new System.Drawing.Point(115, 115);
            this.s11.Name = "s11";
            this.s11.Size = new System.Drawing.Size(50, 50);
            this.s11.TabIndex = 10;
            this.s11.UseVisualStyleBackColor = true;
            this.s11.Click += new System.EventHandler(this.s11_Click);
            // 
            // s12
            // 
            this.s12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s12.BackgroundImage")));
            this.s12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s12.Location = new System.Drawing.Point(171, 115);
            this.s12.Name = "s12";
            this.s12.Size = new System.Drawing.Size(50, 50);
            this.s12.TabIndex = 11;
            this.s12.UseVisualStyleBackColor = true;
            this.s12.Click += new System.EventHandler(this.s12_Click);
            // 
            // s13
            // 
            this.s13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s13.BackgroundImage")));
            this.s13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s13.Location = new System.Drawing.Point(3, 171);
            this.s13.Name = "s13";
            this.s13.Size = new System.Drawing.Size(50, 50);
            this.s13.TabIndex = 12;
            this.s13.UseVisualStyleBackColor = true;
            this.s13.Click += new System.EventHandler(this.s13_Click);
            // 
            // s14
            // 
            this.s14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s14.BackgroundImage")));
            this.s14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s14.Location = new System.Drawing.Point(59, 171);
            this.s14.Name = "s14";
            this.s14.Size = new System.Drawing.Size(50, 50);
            this.s14.TabIndex = 13;
            this.s14.UseVisualStyleBackColor = true;
            this.s14.Click += new System.EventHandler(this.s14_Click);
            // 
            // s15
            // 
            this.s15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s15.BackgroundImage")));
            this.s15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s15.Location = new System.Drawing.Point(115, 171);
            this.s15.Name = "s15";
            this.s15.Size = new System.Drawing.Size(50, 50);
            this.s15.TabIndex = 14;
            this.s15.UseVisualStyleBackColor = true;
            this.s15.Click += new System.EventHandler(this.s15_Click);
            // 
            // s16
            // 
            this.s16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("s16.BackgroundImage")));
            this.s16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.s16.Location = new System.Drawing.Point(171, 171);
            this.s16.Name = "s16";
            this.s16.Size = new System.Drawing.Size(50, 50);
            this.s16.TabIndex = 15;
            this.s16.UseVisualStyleBackColor = true;
            this.s16.Click += new System.EventHandler(this.s16_Click);
            // 
            // button_B
            // 
            this.button_B.BackColor = System.Drawing.Color.White;
            this.button_B.BackgroundImage = global::instachat.Properties.Resources.B1;
            this.button_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_B.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_B.ForeColor = System.Drawing.Color.Lime;
            this.button_B.Location = new System.Drawing.Point(530, 400);
            this.button_B.Name = "button_B";
            this.button_B.Size = new System.Drawing.Size(39, 39);
            this.button_B.TabIndex = 15;
            this.button_B.UseVisualStyleBackColor = false;
            this.button_B.Click += new System.EventHandler(this.button_B_Click);
            // 
            // button_I
            // 
            this.button_I.BackColor = System.Drawing.Color.White;
            this.button_I.BackgroundImage = global::instachat.Properties.Resources.I;
            this.button_I.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_I.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_I.ForeColor = System.Drawing.Color.Lime;
            this.button_I.Location = new System.Drawing.Point(575, 400);
            this.button_I.Name = "button_I";
            this.button_I.Size = new System.Drawing.Size(39, 39);
            this.button_I.TabIndex = 14;
            this.button_I.UseVisualStyleBackColor = false;
            this.button_I.Click += new System.EventHandler(this.button_I_Click);
            // 
            // button_U
            // 
            this.button_U.BackColor = System.Drawing.Color.White;
            this.button_U.BackgroundImage = global::instachat.Properties.Resources.U;
            this.button_U.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_U.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_U.ForeColor = System.Drawing.Color.Lime;
            this.button_U.Location = new System.Drawing.Point(620, 400);
            this.button_U.Name = "button_U";
            this.button_U.Size = new System.Drawing.Size(39, 39);
            this.button_U.TabIndex = 13;
            this.button_U.UseVisualStyleBackColor = false;
            this.button_U.Click += new System.EventHandler(this.button_U_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::instachat.Properties.Resources.back3;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(665, 402);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 201);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // button_shake
            // 
            this.button_shake.BackColor = System.Drawing.Color.White;
            this.button_shake.BackgroundImage = global::instachat.Properties.Resources.shake;
            this.button_shake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_shake.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_shake.ForeColor = System.Drawing.Color.Lime;
            this.button_shake.Location = new System.Drawing.Point(102, 400);
            this.button_shake.Name = "button_shake";
            this.button_shake.Size = new System.Drawing.Size(39, 39);
            this.button_shake.TabIndex = 8;
            this.button_shake.UseVisualStyleBackColor = false;
            this.button_shake.Click += new System.EventHandler(this.button_shake_Click);
            // 
            // button_file
            // 
            this.button_file.BackColor = System.Drawing.Color.White;
            this.button_file.BackgroundImage = global::instachat.Properties.Resources.file;
            this.button_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_file.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_file.ForeColor = System.Drawing.Color.Lime;
            this.button_file.Location = new System.Drawing.Point(57, 400);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(39, 39);
            this.button_file.TabIndex = 7;
            this.button_file.UseVisualStyleBackColor = false;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // button_sticker
            // 
            this.button_sticker.BackColor = System.Drawing.Color.White;
            this.button_sticker.BackgroundImage = global::instachat.Properties.Resources.sticker;
            this.button_sticker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_sticker.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sticker.ForeColor = System.Drawing.Color.Lime;
            this.button_sticker.Location = new System.Drawing.Point(12, 400);
            this.button_sticker.Name = "button_sticker";
            this.button_sticker.Size = new System.Drawing.Size(39, 39);
            this.button_sticker.TabIndex = 5;
            this.button_sticker.UseVisualStyleBackColor = false;
            this.button_sticker.Click += new System.EventHandler(this.button_sticker_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 653);
            this.Controls.Add(this.StickerList);
            this.Controls.Add(this.button_color);
            this.Controls.Add(this.button_font);
            this.Controls.Add(this.button_B);
            this.Controls.Add(this.button_I);
            this.Controls.Add(this.button_U);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TextBox_memebers);
            this.Controls.Add(this.button_shake);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.button_sticker);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.button_leave);
            this.Controls.Add(this.TextBox_send);
            this.Controls.Add(this.TextBox_chat);
            this.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "instachat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.StickerList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox_chat;
        private System.Windows.Forms.RichTextBox TextBox_send;
        private System.Windows.Forms.Button button_leave;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_sticker;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.Button button_shake;
        private System.Windows.Forms.RichTextBox TextBox_memebers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_U;
        private System.Windows.Forms.Button button_I;
        private System.Windows.Forms.Button button_B;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button_font;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_color;
        private System.Windows.Forms.FlowLayoutPanel StickerList;
        private System.Windows.Forms.Button s1;
        private System.Windows.Forms.Button s2;
        private System.Windows.Forms.Button s3;
        private System.Windows.Forms.Button s4;
        private System.Windows.Forms.Button s5;
        private System.Windows.Forms.Button s6;
        private System.Windows.Forms.Button s7;
        private System.Windows.Forms.Button s8;
        private System.Windows.Forms.Button s9;
        private System.Windows.Forms.Button s10;
        private System.Windows.Forms.Button s11;
        private System.Windows.Forms.Button s12;
        private System.Windows.Forms.Button s13;
        private System.Windows.Forms.Button s14;
        private System.Windows.Forms.Button s15;
        private System.Windows.Forms.Button s16;
    }
}