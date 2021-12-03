
namespace Battleships.Forms
{
    partial class JoinRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinRoom));
            this.go_back_btn = new System.Windows.Forms.Button();
            this.ip_address_label = new System.Windows.Forms.Label();
            this.ip_address_textbox = new System.Windows.Forms.TextBox();
            this.login_server_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // go_back_btn
            // 
            this.go_back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.go_back_btn.Location = new System.Drawing.Point(419, 446);
            this.go_back_btn.Name = "go_back_btn";
            this.go_back_btn.Size = new System.Drawing.Size(463, 82);
            this.go_back_btn.TabIndex = 11;
            this.go_back_btn.Text = "Grįžti";
            this.go_back_btn.UseVisualStyleBackColor = true;
            this.go_back_btn.Click += new System.EventHandler(this.go_back_btn_Click);
            // 
            // ip_address_label
            // 
            this.ip_address_label.AutoSize = true;
            this.ip_address_label.BackColor = System.Drawing.Color.Transparent;
            this.ip_address_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ip_address_label.ForeColor = System.Drawing.Color.White;
            this.ip_address_label.Location = new System.Drawing.Point(579, 227);
            this.ip_address_label.Name = "ip_address_label";
            this.ip_address_label.Size = new System.Drawing.Size(102, 26);
            this.ip_address_label.TabIndex = 9;
            this.ip_address_label.Text = "Įvesti IP :";
            this.ip_address_label.Visible = false;
            // 
            // ip_address_textbox
            // 
            this.ip_address_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ip_address_textbox.Location = new System.Drawing.Point(474, 268);
            this.ip_address_textbox.Name = "ip_address_textbox";
            this.ip_address_textbox.Size = new System.Drawing.Size(317, 32);
            this.ip_address_textbox.TabIndex = 8;
            this.ip_address_textbox.Visible = false;
            // 
            // login_server_btn
            // 
            this.login_server_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.login_server_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login_server_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.login_server_btn.Location = new System.Drawing.Point(419, 347);
            this.login_server_btn.Name = "login_server_btn";
            this.login_server_btn.Size = new System.Drawing.Size(463, 82);
            this.login_server_btn.TabIndex = 10;
            this.login_server_btn.Text = "Prisijungti";
            this.login_server_btn.UseVisualStyleBackColor = true;
            this.login_server_btn.Click += new System.EventHandler(this.login_server_btn_Click);
            // 
            // JoinRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.go_back_btn);
            this.Controls.Add(this.login_server_btn);
            this.Controls.Add(this.ip_address_label);
            this.Controls.Add(this.ip_address_textbox);
            this.Name = "JoinRoom";
            this.Text = "JoinRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button go_back_btn;
        private System.Windows.Forms.Label ip_address_label;
        private System.Windows.Forms.TextBox ip_address_textbox;
        private System.Windows.Forms.Button login_server_btn;
    }
}