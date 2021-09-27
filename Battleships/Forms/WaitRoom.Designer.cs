
namespace Battleships.Forms
{
    partial class WaitRoom
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
            this.waiting_label = new System.Windows.Forms.Label();
            this.server_ip_address = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // waiting_label
            // 
            this.waiting_label.AutoSize = true;
            this.waiting_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.waiting_label.Location = new System.Drawing.Point(265, 191);
            this.waiting_label.Name = "waiting_label";
            this.waiting_label.Size = new System.Drawing.Size(258, 26);
            this.waiting_label.TabIndex = 0;
            this.waiting_label.Text = "Waiting For The Enemy...";
            // 
            // server_ip_address
            // 
            this.server_ip_address.AutoSize = true;
            this.server_ip_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.server_ip_address.Location = new System.Drawing.Point(368, 165);
            this.server_ip_address.Name = "server_ip_address";
            this.server_ip_address.Size = new System.Drawing.Size(258, 26);
            this.server_ip_address.TabIndex = 1;
            this.server_ip_address.Text = "Waiting For The Enemy...";
            this.server_ip_address.Click += new System.EventHandler(this.server_ip_address_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(280, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server:";
            // 
            // WaitRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.server_ip_address);
            this.Controls.Add(this.waiting_label);
            this.Name = "WaitRoom";
            this.Text = "WaitRoom";
            this.Load += new System.EventHandler(this.WaitRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label waiting_label;
        private System.Windows.Forms.Label server_ip_address;
        private System.Windows.Forms.Label label1;
    }
}