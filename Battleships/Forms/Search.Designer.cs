
namespace Battleships.Forms
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.create_server_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ip_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_servers_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // create_server_btn
            // 
            this.create_server_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.create_server_btn.Location = new System.Drawing.Point(431, 512);
            this.create_server_btn.Name = "create_server_btn";
            this.create_server_btn.Size = new System.Drawing.Size(463, 82);
            this.create_server_btn.TabIndex = 2;
            this.create_server_btn.Text = "Sukurti Žaidimų Kambarį";
            this.create_server_btn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip_address});
            this.dataGridView1.Location = new System.Drawing.Point(272, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(689, 155);
            this.dataGridView1.TabIndex = 3;
            // 
            // ip_address
            // 
            this.ip_address.HeaderText = "IP Address";
            this.ip_address.Name = "ip_address";
            // 
            // current_servers_label
            // 
            this.current_servers_label.AutoSize = true;
            this.current_servers_label.BackColor = System.Drawing.Color.Transparent;
            this.current_servers_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.current_servers_label.ForeColor = System.Drawing.Color.White;
            this.current_servers_label.Location = new System.Drawing.Point(272, 180);
            this.current_servers_label.Name = "current_servers_label";
            this.current_servers_label.Size = new System.Drawing.Size(263, 26);
            this.current_servers_label.TabIndex = 4;
            this.current_servers_label.Text = "Esami žaidimų kambariai:";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.current_servers_label);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.create_server_btn);
            this.Name = "Search";
            this.Text = "Start";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_server_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip_address;
        private System.Windows.Forms.Label current_servers_label;
    }
}