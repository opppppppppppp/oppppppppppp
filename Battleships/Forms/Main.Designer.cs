
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
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // create_room_btn
            // 
            this.create_room_btn.FlatAppearance.BorderSize = 0;
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
            this.exit_btn.FlatAppearance.BorderSize = 0;
            this.exit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.exit_btn.Location = new System.Drawing.Point(437, 525);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(463, 82);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // join_room_btn
            // 
            this.join_room_btn.FlatAppearance.BorderSize = 0;
            this.join_room_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.join_room_btn.Location = new System.Drawing.Point(437, 319);
            this.join_room_btn.Name = "join_room_btn";
            this.join_room_btn.Size = new System.Drawing.Size(463, 82);
            this.join_room_btn.TabIndex = 4;
            this.join_room_btn.Text = "Prisijungti prie Kambario";
            this.join_room_btn.UseVisualStyleBackColor = true;
            this.join_room_btn.Click += new System.EventHandler(this.join_room_btn_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button4.Location = new System.Drawing.Point(437, 423);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(463, 82);
            this.button4.TabIndex = 5;
            this.button4.Text = "Nustatymai";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.join_room_btn);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.create_room_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button create_room_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button join_room_btn;
        private System.Windows.Forms.Button button4;
    }
}