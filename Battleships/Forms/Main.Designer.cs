
namespace Battleships.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.create_room_btn = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.join_room_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // create_room_btn
            // 
            this.create_room_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.create_room_btn.Location = new System.Drawing.Point(437, 231);
            this.create_room_btn.Name = "create_room_btn";
            this.create_room_btn.Size = new System.Drawing.Size(463, 82);
            this.create_room_btn.TabIndex = 1;
            this.create_room_btn.Text = "Sukurti Kambarį";
            this.create_room_btn.UseVisualStyleBackColor = true;
            this.create_room_btn.Click += new System.EventHandler(this.create_room_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.exit_btn.Location = new System.Drawing.Point(437, 422);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(463, 82);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // join_room_btn
            // 
            this.join_room_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.join_room_btn.Location = new System.Drawing.Point(437, 319);
            this.join_room_btn.Name = "join_room_btn";
            this.join_room_btn.Size = new System.Drawing.Size(463, 82);
            this.join_room_btn.TabIndex = 4;
            this.join_room_btn.Text = "Prisijungti prie Kambario";
            this.join_room_btn.UseVisualStyleBackColor = true;
            this.join_room_btn.Click += new System.EventHandler(this.join_room_btn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.join_room_btn);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.create_room_btn);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button create_room_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button join_room_btn;
    }
}