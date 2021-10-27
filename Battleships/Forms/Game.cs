using System;
using System.Windows.Forms;
using Battleships.Models.Facade;

namespace Battleships
{
    public partial class Game : Form
    {
        public Facade Facade;
        public Game()
        {
            InitializeComponent();
            GameObjects GameObjects = new GameObjects(player_table, enemy_table, attack_options, special_ability_label, attack_btn, special_ability_btn, score_val);
            Facade = new Facade(this, GameObjects);
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
            int index = attack_options.SelectedIndex;
            //RemoveAttackOption(FindShipByIndex(enemyPos, index).Text);//*Cia*
            Facade.position_socket.Send($"{index}:{Facade.user_id}");
            Facade.player_turn.Send($"{Facade.user_id}");
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

        public GameObjects(DataGridView player_table, DataGridView enemy_table, ComboBox attack_options,
            Label special_ability_label, Button attack_btn, Button special_ability_btn, Label score_val)
        {
            this.player_table = player_table;
            this.enemy_table = enemy_table;
            this.attack_options = attack_options;
            this.special_ability_label = special_ability_label;
            this.attack_btn = attack_btn;
            this.special_ability_btn = special_ability_btn;
            this.score_val = score_val;
        }
    }
}
