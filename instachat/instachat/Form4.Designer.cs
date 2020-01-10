namespace instachat
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label_no_use = new System.Windows.Forms.Label();
            this.label_of_use = new System.Windows.Forms.Label();
            this.changed_alias = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_no_use
            // 
            this.label_no_use.AutoSize = true;
            this.label_no_use.Font = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_no_use.Location = new System.Drawing.Point(12, 18);
            this.label_no_use.Name = "label_no_use";
            this.label_no_use.Size = new System.Drawing.Size(69, 31);
            this.label_no_use.TabIndex = 0;
            this.label_no_use.Text = "Alias";
            // 
            // label_of_use
            // 
            this.label_of_use.AutoSize = true;
            this.label_of_use.BackColor = System.Drawing.Color.White;
            this.label_of_use.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_of_use.ForeColor = System.Drawing.Color.LightGray;
            this.label_of_use.Location = new System.Drawing.Point(90, 19);
            this.label_of_use.Name = "label_of_use";
            this.label_of_use.Size = new System.Drawing.Size(265, 30);
            this.label_of_use.TabIndex = 1;
            this.label_of_use.Text = "                                    ";
            this.label_of_use.Click += new System.EventHandler(this.label_Click);
            // 
            // changed_alias
            // 
            this.changed_alias.BackColor = System.Drawing.Color.White;
            this.changed_alias.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changed_alias.Location = new System.Drawing.Point(85, 18);
            this.changed_alias.Name = "changed_alias";
            this.changed_alias.Size = new System.Drawing.Size(201, 32);
            this.changed_alias.TabIndex = 2;
            this.changed_alias.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // button_OK
            // 
            this.button_OK.BackColor = System.Drawing.Color.White;
            this.button_OK.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(62, 64);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 29);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.White;
            this.button_cancel.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(193, 64);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 29);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(309, 105);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_of_use);
            this.Controls.Add(this.changed_alias);
            this.Controls.Add(this.label_no_use);
            this.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "instachat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_no_use;
        private System.Windows.Forms.Label label_of_use;
        private System.Windows.Forms.TextBox changed_alias;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_cancel;
    }
}