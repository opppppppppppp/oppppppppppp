using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
namespace Battleships
{
    public partial class Game : Form
    {
        List<Button> playerPos;
        List<Button> enemyPos;

        int totalShips = 4;
        int playerScore = 0;
        int enemyScore = 0;
        public Game(WebSocket ws)
        {
            InitializeComponent();
            RestartGame();
        }

        private void user_b_Click(object sender, EventArgs e)
        {

        }

        private void generateRandomPos()
        {

        }

        public void RestartGame()
        {
            playerPos = new List<Button> { w1, w2, w3, w4, w5, x1, x2, x3, x4,x5, y1, y2, y3, y4,y5, z1, z2, z3, z4,z5, f1, f2, f3, f4,f5 };
            enemyPos = new List<Button> { a1, a2, a3, a4, a5, b1, b2, b3, b4,b5, c1, c2, c3, c4,c5, d1, d2, d3, d4,d5, e1, e2, e3, e4, e5 };

            for(int i = 0;i<playerPos.Count;i++)
            {
                playerPos[i].BackColor = Color.White;
                enemyPos[i].BackColor = Color.White;

                playerPos[i].Tag = null;
                enemyPos[i].Tag = null;

                playerScore = 0;
                enemyScore = 0;
            }
        }

        private void timer_label_Click(object sender, EventArgs e)
        {

        }
    }
}
