using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PingPongGame
{
    public class Ball
    {
        public PictureBox ball;             //4 biến ở đây dùng để nhận các thông tin đưa vào class Ball
        private Panel playground;
        private Player Player1, Player2;
        private Timer tick;

        Random rand = new Random();
        private bool check = false;

        int xSpeed = 3;         //Mặc định tốc độ ban đầu theo phương ngang là 3 và phương dọc là 4
        int ySpeed = 4;

        private int ballx, bally;

        public Ball(PictureBox ball, Panel playground, Player play1, Player play2, int BallX, int BallY, Timer tock)        //Khi tạo new Ball thì nơi đây giống như hàm khởi tạo của nó
        {
            this.ball = ball;                                   //Gán tuần tự các biến đưa vào từ hàm gọi Ball
            this.playground = playground;
            Player1 = play1;
            Player2 = play2;
            ballx = BallX;
            bally = BallY;
            tick = tock;
            this.ball.Location = new Point(BallX, BallY);       //Cho Ball ra giữa màn hình từ các con số đã định nghĩa ở hàm SetGame()
        }

        internal void ProcessMove()
        {
            ball.Location = new Point(ball.Location.X + xSpeed, ball.Location.Y + ySpeed);          //Cho Ball di chuyển theo tốc độ(thay đổi vị trí Ball) bằng bước nhảy 

            if(ball.Left <= playground.Left || ball.Right >= playground.Right)                      //Nếu như ball chạm viền trái hoặc viền phải màn hình thì cho tốc độ theo phương ngang ngược lại
            {
                xSpeed *= -1;
            }

            if(ball.Bottom >= Player2.racket.Top && ball.Bottom <= Player2.racket.Bottom            //Nếu như ball chạm vào thanh đỡ dưới, ta cho tốc độ theo phương ngang và dọc ngược lại đồng thời tăng tốc hướng dọc thêm 1
                && ball.Left > Player2.racket.Left && ball.Right < Player2.racket.Right)    
            {
                int temp = Math.Abs(ySpeed) + 1;            //cho tốc độ dọc tăng 1 trước, sau đó chuyển tốc độ là ngược lại(nhân thêm -1)
                ySpeed = -temp;
                temp = Math.Abs(xSpeed) + 1;
                if(xSpeed < 0)
                {
                    xSpeed = -temp;
                }
                else
                {
                    xSpeed = temp;
                }
            }

            if(ball.Top <= Player1.racket.Bottom && ball.Top >= Player1.racket.Top                  //Tương tự như trên đối với TH thanh đỡ trên
                && ball.Left > Player1.racket.Left && ball.Right < Player1.racket.Right)
            {
                int temp = Math.Abs(ySpeed) + 1;
                ySpeed = temp;
                temp = Math.Abs(xSpeed) + 1;
                if (xSpeed < 0)
                {
                    xSpeed = -temp;
                }
                else
                {
                    xSpeed = temp;
                }
            }

            if(ball.Bottom >= playground.Bottom || ball.Top <= playground.Top)                      //Nếu ball chạm vào viền trên hoặc viền dưới màn hình, tức là có 1 người chơi đã ăn 1 điểm
            {
                if(ball.Bottom >= playground.Bottom)                                                //Nếu chạm dưới thì người chơi trên ăn điểm, ta set score của người chơi trên tăng thêm 1
                {
                    Player1.scored++;                                                   //score và isThePlayerWon() được định nghĩa ở class Player
                    if(Player1.isThePlayerWon())                                        //Nếu người chơi đã thắng, tức hàm isThePlayerWon() trả về true thì ta cho thời gian dừng lại, đồng thời biến Check sẽ được gọi bên Form1(HasEnded) sẽ gán true
                    {                                                                   //Tức là không thể resume được trò chơi, buộc phải thoát hoặc chơi lại
                        Check = true;
                        tick.Enabled = false;
                    }
                }
                else                                                                    //Tương tự cho trường hợp người chơi dưới ăn điểm
                {
                    Player2.scored++;
                    if (Player2.isThePlayerWon())
                    {
                        Check = true;
                        tick.Enabled = false;
                    }
                }
                ResetBall();                                                            //ResetBall() được định nghĩa ở dưới
            }
        }

        public bool HasChecked()
        {
            return Check;
        }

        public bool Check
        {
           get { return check; }
           set { check = value; }
        }                      //Khi có 1 hàm nào đó gọi hàm này, giá trị trả về chính là biến check, nếu có thay đổi thì check cũng sẽ thay đổi

        public void ResetBall()
        {                                                                               //Khi hàm này được gọi, ta sẽ random ball theo phương dọc và ngang
            do
            {
                xSpeed = rand.Next(-5, 5);
            } while (Math.Abs(xSpeed) < 2);                                             //Ta random  từ -5 dến 5 tuy nhiên không nhận nếu nó thuộc từ -2 dến 2, mục đích là để tránh trường hợp quá đạc biệt
            do
            {
                ySpeed = rand.Next(-5, 5);
            } while (Math.Abs(ySpeed) < 2);

            Player1.ResetRacket();                                                      //ResetBall thì ta cũng thực hiện reset cả 2 thanh đỡ luôn bằng hàm reset thanh đỡ đã được định nghĩa ở class Player
            Player2.ResetRacket();

            ball.Location = new Point(ballx, bally);                                    //Sau khi chọn được tốc độ di chuyển mới, ta đưa ball về vị trí ở giữa màn hình từ những dữ diện ban đầu đưa vào
        }
    }
}
