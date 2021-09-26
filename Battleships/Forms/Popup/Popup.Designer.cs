
namespace Battleships.Forms.Popup
{
    partial class popup_message_label
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pop_up_message_value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(291, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Uždaryti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(323, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pranešimas";
            // 
            // pop_up_message_value
            // 
            this.pop_up_message_value.AutoSize = true;
            this.pop_up_message_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.pop_up_message_value.Location = new System.Drawing.Point(323, 181);
            this.pop_up_message_value.Name = "pop_up_message_value";
            this.pop_up_message_value.Size = new System.Drawing.Size(128, 26);
            this.pop_up_message_value.TabIndex = 2;
            this.pop_up_message_value.Text = "Pranešimas";
            // 
            // popup_message_label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pop_up_message_value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "popup_message_label";
            this.Text = "Popup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pop_up_message_value;
    }
}