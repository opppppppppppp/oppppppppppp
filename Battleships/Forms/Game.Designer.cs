
namespace Battleships
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.user_a = new System.Windows.Forms.Label();
            this.user_b = new System.Windows.Forms.Label();
            this.Attack = new System.Windows.Forms.Label();
            this.attack_options = new System.Windows.Forms.ComboBox();
            this.attack_btn = new System.Windows.Forms.Button();
            this.surrender_btn = new System.Windows.Forms.Label();
            this.level_label = new System.Windows.Forms.Label();
            this.level_value = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.score_value = new System.Windows.Forms.Label();
            this.score_val = new System.Windows.Forms.Label();
            this.special_ability_label = new System.Windows.Forms.Label();
            this.special_ability_btn = new System.Windows.Forms.Button();
            this.player_table = new System.Windows.Forms.DataGridView();
            this.enemy_table = new System.Windows.Forms.DataGridView();
            this.chatbox = new System.Windows.Forms.RichTextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.chat_label = new System.Windows.Forms.Label();
            this.chat_message_box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.player_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_table)).BeginInit();
            this.SuspendLayout();
            // 
            // user_a
            // 
            this.user_a.AutoSize = true;
            this.user_a.BackColor = System.Drawing.Color.Transparent;
            this.user_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.user_a.ForeColor = System.Drawing.Color.GreenYellow;
            this.user_a.Location = new System.Drawing.Point(505, 175);
            this.user_a.Name = "user_a";
            this.user_a.Size = new System.Drawing.Size(163, 36);
            this.user_a.TabIndex = 33;
            this.user_a.Text = "Your Ships";
            // 
            // user_b
            // 
            this.user_b.AutoSize = true;
            this.user_b.BackColor = System.Drawing.Color.Transparent;
            this.user_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.user_b.ForeColor = System.Drawing.Color.White;
            this.user_b.Location = new System.Drawing.Point(1062, 170);
            this.user_b.Name = "user_b";
            this.user_b.Size = new System.Drawing.Size(190, 36);
            this.user_b.TabIndex = 34;
            this.user_b.Text = "Enemy Ships";
            // 
            // Attack
            // 
            this.Attack.AutoSize = true;
            this.Attack.BackColor = System.Drawing.Color.Transparent;
            this.Attack.ForeColor = System.Drawing.Color.White;
            this.Attack.Location = new System.Drawing.Point(10, 141);
            this.Attack.Name = "Attack";
            this.Attack.Size = new System.Drawing.Size(143, 26);
            this.Attack.TabIndex = 37;
            this.Attack.Text = "Choose Ship:";
            // 
            // attack_options
            // 
            this.attack_options.FormattingEnabled = true;
            this.attack_options.Location = new System.Drawing.Point(23, 175);
            this.attack_options.Name = "attack_options";
            this.attack_options.Size = new System.Drawing.Size(121, 33);
            this.attack_options.TabIndex = 38;
            // 
            // attack_btn
            // 
            this.attack_btn.BackColor = System.Drawing.Color.Maroon;
            this.attack_btn.ForeColor = System.Drawing.Color.White;
            this.attack_btn.Location = new System.Drawing.Point(150, 170);
            this.attack_btn.Name = "attack_btn";
            this.attack_btn.Size = new System.Drawing.Size(98, 40);
            this.attack_btn.TabIndex = 39;
            this.attack_btn.Text = "Attack";
            this.attack_btn.UseVisualStyleBackColor = false;
            this.attack_btn.Click += new System.EventHandler(this.Attack_btn_Click);
            // 
            // surrender_btn
            // 
            this.surrender_btn.AutoSize = true;
            this.surrender_btn.BackColor = System.Drawing.Color.GreenYellow;
            this.surrender_btn.Location = new System.Drawing.Point(1082, 25);
            this.surrender_btn.Name = "surrender_btn";
            this.surrender_btn.Size = new System.Drawing.Size(153, 26);
            this.surrender_btn.TabIndex = 40;
            this.surrender_btn.Text = "SURRENDER";
            // 
            // level_label
            // 
            this.level_label.AutoSize = true;
            this.level_label.BackColor = System.Drawing.Color.Transparent;
            this.level_label.ForeColor = System.Drawing.Color.White;
            this.level_label.Location = new System.Drawing.Point(702, 312);
            this.level_label.Name = "level_label";
            this.level_label.Size = new System.Drawing.Size(76, 26);
            this.level_label.TabIndex = 80;
            this.level_label.Text = "Level :";
            // 
            // level_value
            // 
            this.level_value.AutoSize = true;
            this.level_value.BackColor = System.Drawing.Color.Transparent;
            this.level_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.level_value.ForeColor = System.Drawing.Color.White;
            this.level_value.Location = new System.Drawing.Point(784, 308);
            this.level_value.Name = "level_value";
            this.level_value.Size = new System.Drawing.Size(32, 36);
            this.level_value.TabIndex = 81;
            this.level_value.Text = "1";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.BackColor = System.Drawing.Color.Transparent;
            this.score_label.ForeColor = System.Drawing.Color.White;
            this.score_label.Location = new System.Drawing.Point(702, 279);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(69, 26);
            this.score_label.TabIndex = 82;
            this.score_label.Text = "Score";
            this.score_label.Click += new System.EventHandler(this.score_label_Click);
            // 
            // score_value
            // 
            this.score_value.AutoSize = true;
            this.score_value.BackColor = System.Drawing.Color.Transparent;
            this.score_value.ForeColor = System.Drawing.Color.White;
            this.score_value.Location = new System.Drawing.Point(1340, 635);
            this.score_value.Name = "score_value";
            this.score_value.Size = new System.Drawing.Size(36, 26);
            this.score_value.TabIndex = 83;
            this.score_value.Text = "20";
            // 
            // score_val
            // 
            this.score_val.AutoSize = true;
            this.score_val.BackColor = System.Drawing.Color.Transparent;
            this.score_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.score_val.ForeColor = System.Drawing.Color.Lime;
            this.score_val.Location = new System.Drawing.Point(777, 272);
            this.score_val.Name = "score_val";
            this.score_val.Size = new System.Drawing.Size(49, 36);
            this.score_val.TabIndex = 84;
            this.score_val.Text = "20";
            this.score_val.Click += new System.EventHandler(this.score_val_Click);
            // 
            // special_ability_label
            // 
            this.special_ability_label.AutoSize = true;
            this.special_ability_label.BackColor = System.Drawing.Color.Transparent;
            this.special_ability_label.ForeColor = System.Drawing.Color.White;
            this.special_ability_label.Location = new System.Drawing.Point(10, 60);
            this.special_ability_label.Name = "special_ability_label";
            this.special_ability_label.Size = new System.Drawing.Size(155, 26);
            this.special_ability_label.TabIndex = 85;
            this.special_ability_label.Text = "Special Ability:";
            this.special_ability_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // special_ability_btn
            // 
            this.special_ability_btn.BackColor = System.Drawing.Color.Coral;
            this.special_ability_btn.Enabled = false;
            this.special_ability_btn.ForeColor = System.Drawing.Color.White;
            this.special_ability_btn.Location = new System.Drawing.Point(15, 89);
            this.special_ability_btn.Name = "special_ability_btn";
            this.special_ability_btn.Size = new System.Drawing.Size(98, 40);
            this.special_ability_btn.TabIndex = 86;
            this.special_ability_btn.Text = "USE";
            this.special_ability_btn.UseVisualStyleBackColor = false;
            this.special_ability_btn.Click += new System.EventHandler(this.special_ability_btn_Click);
            // 
            // player_table
            // 
            this.player_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.player_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.player_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.player_table.Location = new System.Drawing.Point(280, 216);
            this.player_table.Name = "player_table";
            this.player_table.Size = new System.Drawing.Size(407, 351);
            this.player_table.TabIndex = 87;
            // 
            // enemy_table
            // 
            this.enemy_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.enemy_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.enemy_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.enemy_table.Location = new System.Drawing.Point(845, 216);
            this.enemy_table.Name = "enemy_table";
            this.enemy_table.Size = new System.Drawing.Size(407, 351);
            this.enemy_table.TabIndex = 88;
            // 
            // chatbox
            // 
            this.chatbox.Enabled = false;
            this.chatbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbox.Location = new System.Drawing.Point(15, 272);
            this.chatbox.Name = "chatbox";
            this.chatbox.Size = new System.Drawing.Size(250, 278);
            this.chatbox.TabIndex = 89;
            this.chatbox.Text = "";
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(15, 634);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(116, 35);
            this.send_btn.TabIndex = 90;
            this.send_btn.Text = "Send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // chat_label
            // 
            this.chat_label.AutoSize = true;
            this.chat_label.BackColor = System.Drawing.Color.Transparent;
            this.chat_label.ForeColor = System.Drawing.Color.White;
            this.chat_label.Location = new System.Drawing.Point(12, 243);
            this.chat_label.Name = "chat_label";
            this.chat_label.Size = new System.Drawing.Size(58, 26);
            this.chat_label.TabIndex = 91;
            this.chat_label.Text = "Chat";
            // 
            // chat_message_box
            // 
            this.chat_message_box.Location = new System.Drawing.Point(13, 561);
            this.chat_message_box.Multiline = true;
            this.chat_message_box.Name = "chat_message_box";
            this.chat_message_box.Size = new System.Drawing.Size(218, 64);
            this.chat_message_box.TabIndex = 92;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.chat_message_box);
            this.Controls.Add(this.chat_label);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.chatbox);
            this.Controls.Add(this.enemy_table);
            this.Controls.Add(this.player_table);
            this.Controls.Add(this.special_ability_btn);
            this.Controls.Add(this.special_ability_label);
            this.Controls.Add(this.score_val);
            this.Controls.Add(this.score_value);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.level_value);
            this.Controls.Add(this.level_label);
            this.Controls.Add(this.surrender_btn);
            this.Controls.Add(this.attack_btn);
            this.Controls.Add(this.attack_options);
            this.Controls.Add(this.Attack);
            this.Controls.Add(this.user_b);
            this.Controls.Add(this.user_a);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.player_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label user_a;
        private System.Windows.Forms.Label user_b;
        private System.Windows.Forms.Label Attack;
        private System.Windows.Forms.ComboBox attack_options;
        private System.Windows.Forms.Button attack_btn;
        private System.Windows.Forms.Label surrender_btn;
        private System.Windows.Forms.Label level_label;
        private System.Windows.Forms.Label level_value;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Label score_value;
        private System.Windows.Forms.Label score_val;
        private System.Windows.Forms.Label special_ability_label;
        private System.Windows.Forms.Button special_ability_btn;
        private System.Windows.Forms.DataGridView player_table;
        private System.Windows.Forms.DataGridView enemy_table;
        private System.Windows.Forms.RichTextBox chatbox;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Label chat_label;
        private System.Windows.Forms.TextBox chat_message_box;
    }
}