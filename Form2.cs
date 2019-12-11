using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class PongForm : Form
    {
        AdvancedPlayer player1, player2;
        public List<AdvancedBall> ballList;

        public PongForm()
        {
            InitializeComponent();

            player1 = new AdvancedPlayer(aPaddle4, aLabelPlayer1);
            player2 = new AdvancedPlayer(aPaddle3, aLabelPlayer2);
            ballList = new List<AdvancedBall>();
            StartNewGame();
        }

        private void StartNewGame()
        {
            ballList.Add(new AdvancedBall(this, aBall, player1, player2));
        }
        private void aTimer_Tick(object sender, EventArgs e)
        {
            player1.ProcessMove();
            player2.ProcessMove();

            for (int i = ballList.Count - 1; i >= 0; i--)
            {
                if (ballList[i].ProcessMove())
                {
                    ballList.RemoveAt(i);
                }
            }

            if (ballList.Count == 0)
            {
                StartNewGame();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeys(e, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            CheckKeys(e, false);
        }

        private void aBall_Click(object sender, EventArgs e)
        {

        }

        private void PongForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckKeys(KeyEventArgs e, bool isDown)
        {
            switch (e.KeyCode)
            {
                case Keys.Oemcomma:
                case Keys.A:
                    player1.isUpPressed = isDown;
                    break;
                case Keys.O:
                case Keys.D:
                    player1.isDownPressed = isDown;
                    break;

                case Keys.Left:
                    player2.isUpPressed = isDown;
                    break;
                case Keys.Right:
                    player2.isDownPressed = isDown;
                    break;
            }
        }
    }
}

