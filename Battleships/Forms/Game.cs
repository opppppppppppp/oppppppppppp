using System;
using System.Diagnostics;
using System.Windows.Forms;
using Battleships.Models;
using Battleships.Models.Composite;
using System.IO;
using Battleships.Models.Facade;

namespace Battleships
{
    public partial class Game : Form
    {
        public Facade Facade;
        public Game(Player player)
        {
            InitializeComponent();
            GameObjects GameObjects = new GameObjects(player_table, enemy_table, attack_options, special_ability_label, attack_btn, special_ability_btn, score_val, send_btn, chatbox, chat_message_box);
            Facade = new Facade(this, GameObjects, player);
            Facade.InitializeGameLogic();
            Facade.RestartGame();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void special_ability_btn_Click(object sender, EventArgs e)
        {
            Facade.SpecialAttack();
            special_ability_btn.Hide();
            special_ability_label.Hide();
           
        }
        public void Attack_btn_Click(object sender, EventArgs e)
        {
            int index = Facade.EnemyPos.GetShipIndex(attack_options.SelectedItem.ToString());
            Facade.positionsConnector.GetSocket().Send($"{index}:{Facade.player.getUID()}");
            Facade.turnConnector.GetSocket().Send($"{Facade.player.getUID()}");
            RemoveAttackOption(attack_options.SelectedIndex);
   
        }

        private void RemoveAttackOption(int index)
        {
            attack_options.Items.RemoveAt(index);
        }

        private void score_val_Click(object sender, EventArgs e)
        {

        }

        private void score_label_Click(object sender, EventArgs e)
        {

        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            Facade.chatConnector.GetSocket().Send($"{Facade.player.getUID()}:{chat_message_box.Text}");
        }
    }

    public class GameObjects
    {
        public DataGridView player_table;
        public DataGridView enemy_table;
        public ComboBox attack_options;
        public Label special_ability_label;
        public Button attack_btn;
        public Button special_ability_btn;
        public Label score_val;
        public Button send_btn;
        public RichTextBox chatbox;
        public TextBox chat_box_message;

        public GameObjects(DataGridView player_table, DataGridView enemy_table, ComboBox attack_options,
            Label special_ability_label, Button attack_btn, Button special_ability_btn, Label score_val, Button send_button, RichTextBox richchatbox, TextBox chatb_message)
        {
            this.player_table = player_table;
            this.enemy_table = enemy_table;
            this.attack_options = attack_options;
            this.special_ability_label = special_ability_label;
            this.attack_btn = attack_btn;
            this.special_ability_btn = special_ability_btn;
            this.score_val = score_val;
            this.send_btn = send_button;
            this.chatbox = richchatbox;
            this.chat_box_message = chatb_message;
        }
    }
}
