using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PingPongGame
{
    public partial class Form1 : Form
    {
        public bool HasEnded = false;//biến kiểm tra xem game đã kết thúc chưa
        public int BallXPos = 0, BallYPos=0;

        Player player1, player2;//class Player tượng trưng cho thanh đỡ
        Ball CircleThing,CircleThing2,PicturBox1;//class Ball tượng trưng cho quả bóng
        public Form1()
        {
            InitializeComponent();

            TopMost = true;                                //Đưa form ra đằng trước
            Bounds = Screen.PrimaryScreen.Bounds;          //Chế độ toàn màn hình

            timer1.Enabled = false;     //1 biến timer có nhiệm vụ bắt đầu cho chương trình hoạt động theo thời gian biến chạy

            Rules.Location = new Point(this.ClientSize.Width / 2 - Rules.Size.Width / 2, this.ClientSize.Height / 2 - this.ClientSize.Height / 8);      //Khung luật chơi cũng như các thao tác sẽ in ra trước khi bắt đầu 
                                                                                                                                                        //trò chơi cũng như khi timer1.Enalble = false(ngưng chưng trình không cho các biến chạy)

            PlayerTopAnouncement.Location = new Point(this.ClientSize.Width / 2 - PlayerTopAnouncement.Size.Width / 2, this.ClientSize.Height / 2 - this.ClientSize.Height / 8);        //2 khung thông báo có người chơi thắng
            PlayerBotAnouncement.Location = new Point(this.ClientSize.Width / 2 - PlayerBotAnouncement.Size.Width / 2, this.ClientSize.Height / 2 - this.ClientSize.Height / 8);        //
                                                                                                                                                                                        //và trước khi điều đó xảy ra thì ta ẩn 2 khung này đi
            PlayerTopAnouncement.Visible = false;                                                                                                                                       //bằng lệnh Visible = false
            PlayerBotAnouncement.Visible = false;                                                                                                                                       //

            SetGame();          //Hàm này có chức năng khởi tạo các biến cần thiết cho trò chơi(ở dưới cùng của trang code này)

        }

        private void timer1_Tick(object sender, EventArgs e)        //Biến timer1 sẽ hoạt động ở đây(tức là các phần tử hoạt động theo thời gian thì ta tạo chúng trong đây như việc cho di chuyển của banh hay thanh đỡ(1 tick =  1 mili giây)
        {
            
            player1.ProcessMove(PlayGround);        //ProcessMove là hàm làm cho thanh đỡ di chuyển khi nhận các lệnh cần thiết
            player2.ProcessMove(PlayGround);        //

            CircleThing.ProcessMove(BallXPos,BallYPos); //Tương tự như đối với đối tượng(class) Player
            if (Ball.Location.X == 382 && Ball.Location.Y == 281)
            {
                CircleThing2.ProcessMove(BallXPos, BallYPos);
            }

            HasEnded = CircleThing.HasChecked();    //các hàm trên hoạt động ứng với mỗi 1 tick(thời gian chạy chương trình) cho nên khi chạy các hàm xem game đã kết thúc chưa
            
            
            if (HasEnded == true)                            //Nếu game kết thúc thì biến timer1 sẽ dừng hoạt động các biến này(bên hàm Ball.PocessMove() sẽ kiểm tra
            {
                if (player1.isThePlayerWon())//Kiểm tra xem người chơi 1 có thỏa điều kiện thắng hay ko
                {
                    PlayerTopAnouncement.Visible = true;//Nếu có thì ta cho hiện bảng thông báo người chơi 1 thắng(ở phía trên)
                }
                else
                {
                    PlayerBotAnouncement.Visible = true;//nếu không phải thì mặc định là người chơi 2 thắng(ở dưới)
                }
            }
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)//Key_Down là 1 Even(sự kiện) trên Form, tức là nó sẽ nhận dữ kiệu từ việc ấn bàn phím
        {
            Check_Keys(e, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)//Tương tự Key_Down nhưng Key_Up là nhận dữ liệu khi ta thả tay ra sau khi ấn nút, tức là khi ấn thì hàm trên thực hiện, khi buông ra thì hàm này thực hiện
        {
            Check_Keys(e, false);
        }

        private void Check_Keys(KeyEventArgs e, bool checker)//hàm kiểm tra thao tác các nút khi ta ấn, checker = true là khi ta ấn nút, còn checker = false là khi ta thả nút đó ra
        {
            switch (e.KeyCode)
            {
                case Keys.F2:                                                                       //F2 là cho biến timer1 ngưng hoặc chạy tiếp sau khi ngưng hay nói cách khác là Pause hoặc Resume
                    if (timer1.Enabled == true && checker == true)                                           //nếu timer1 không dừng thì ta cho nó dừng và cho hiện bảng lệnh ban đầu
                    {
                        timer1.Enabled = false;                                                     //dừng hoạt động các biến
                        Rules.Visible = true;                                                       //hiên bảng lệnh
                    }
                    else if (timer1.Enabled == false && checker == true && HasEnded == false)        //nếu đã dừng thì cho chạy tiếp và ẩn bảng lệnh đi
                    {
                        timer1.Enabled = true;                                                      // cho các biến hoạt động tiếp
                        Rules.Visible = false;                                                      //Ẩn bảng lệnh đi
                    }
                    break;
                case Keys.F1:
                    //F1 là cho chương trình chạy giống như lúc bắt đầu chương trình hay nói cách khác là Restart
                    if (checker == true && HasEnded == true)
                    {

                        if (timer1.Enabled == false)                                                 //Tương tự như hàm trên, ta tắt bảng lệnh và cho game chạy
                        {
                            timer1.Enabled = true;
                            Rules.Visible = false;

                        }
                        player1.scored = 0;                                                         //score là 1 hàm ở trong class player có tác dụng xem player đang trỏ tới có điểm là bao nhiêu và thay đổi điểm đó bằng thao tác toán tử bình thường
                        player2.scored = 0;

                        PlayerTopAnouncement.Visible = PlayerBotAnouncement.Visible = false;        //Giả sử game đã kết thúc thì ta cho 2 bảng thông báo này ẩn đi
                        CircleThing.ResetBall();                                                    //hàm ResetBall() nằm ở trong class Ball có công việc cho vị trí của ball về lại vị trí ở giữa với các biến chạy mới
                        HasEnded = false;                                                          //Đương nhiên là phải cho biến kiểm tra game kết thúc chưa về lại false(kể cả khi nó đang false, để tránh xảy ra lỗi)
                        CircleThing.Check = false;
                    }
                    break;
                case Keys.Escape://nút Esc là để thoát chương trình khi ta gán nút này thực hiện lệnh Close()
                    if (HasEnded == true)
                    {
                        Close();
                    }

                    break;
                case Keys.A:                                                                        //isPressLeft và isRightPress nằm ở trong hàm Player, A và D dành cho người chơi 1, mũi tên qua trái và mũi tên qua phải dành cho người chơi 2
                    player1.isLeftPress = checker;
                    break;
                case Keys.D:
                    player1.isRightPress = checker;
                    break;
                case Keys.Left:
                    player2.isLeftPress = checker;
                    break;
                case Keys.Right:
                    player2.isRightPress = checker;
                    break;
                default:
                    break;
            }
        }

        public void SetGame()
        {
            int RacketXPos = this.ClientSize.Width / 2 - Racket1.Size.Width / 2;                                                                       //5 biến int này lần lượt lưu vị trí ban đầu theo X của thanh đỡ,
            int Racket1YPos = this.ClientSize.Height / 2 - Racket1.Size.Height / 2 - this.ClientSize.Height * 17 / 40;                                 //vị trí theo Y(ngang) của thanh đỡ của người chơi 1,
            int Racket2YPos = this.ClientSize.Height / 2 - Racket2.Size.Height / 2 + this.ClientSize.Height * 17 / 40;                                 //vị trí theo Y của thanh đỡ của người chơi 2
            int BallXPos = this.ClientSize.Width / 2 - Ball.Size.Width / 2;                                                                            //vị trí theo X của banh,
            int BallYPos = this.ClientSize.Height / 2 - Ball.Size.Height / 2;                                                                          //vị trí theo Y của banh.

            player1 = new Player(Racket1, Player1Scored, RacketXPos, Racket1YPos);                                                                      //Tạo player mới với các tham số đưa vào bao gôm Racket, bảng điểm, và vị trí gồm X và Y
            player2 = new Player(Racket2, Player2Scored, RacketXPos, Racket2YPos);

            CircleThing = new Ball(this, Ball, PlayGround, player1, player2, BallXPos, BallYPos, timer1);                                                     //Đối với biến Ball thì khi di chuyển cần biết vị trí của thanh đờ từ 2 người chơi và biến timer1 cho việc nếu game kết thúc thì pause game

            Player1Label.Location = new Point(this.ClientSize.Width / 2 - Player1Label.Size.Width / 2 - this.ClientSize.Width * 17 / 40,                //Chữ Score hiên trên màn hình chính là đây, đây là 1 label, ta set vị trí cho chúng lần lượt ở góc trái trên và dưới
                                                this.ClientSize.Height / 2 - Player1Label.Size.Height / 2 - this.ClientSize.Height * 19 / 40);
            Player2label.Location = new Point(this.ClientSize.Width / 2 - Player1Label.Size.Width / 2 - this.ClientSize.Width * 17 / 40,
                                                this.ClientSize.Height / 2 - Player1Label.Size.Height / 2 + this.ClientSize.Height * 19 / 40);

            Player1Scored.Location = new Point(Player1Label.Location.X + Player1Label.Width, Player1Label.Location.Y);                                  //Tương tự cho bảng điểm của 2 người chơi, ta đặt cạnh bên 2 label Score
            Player2Scored.Location = new Point(Player2label.Location.X + Player2label.Width, Player2label.Location.Y);

            CircleThing2 = new Ball(this, BallModel, PlayGround, player1, player2, 200, 300, timer1);
            PicturBox1 = new Ball(this, pictureBox1, PlayGround, player1, player2, 200, 300, timer1);


            /*Player1Label.Location = new Point(this.ClientSize.Width / 2 - Player1Label.Size.Width / 2 - this.ClientSize.Width * 17 / 40,                //Chữ Score hiên trên màn hình chính là đây, đây là 1 label, ta set vị trí cho chúng lần lượt ở góc trái trên và dưới
                                               this.ClientSize.Height / 2 - Player1Label.Size.Height / 2 - this.ClientSize.Height * 19 / 40);
            Player2label.Location = new Point(this.ClientSize.Width / 2 - Player1Label.Size.Width / 2 - this.ClientSize.Width * 17 / 40,
                                                this.ClientSize.Height / 2 - Player1Label.Size.Height / 2 + this.ClientSize.Height * 19 / 40);

            Player1Scored.Location = new Point(Player1Label.Location.X + Player1Label.Width, Player1Label.Location.Y);                                  //Tương tự cho bảng điểm của 2 người chơi, ta đặt cạnh bên 2 label Score
            Player2Scored.Location = new Point(Player2label.Location.X + Player2label.Width, Player2label.Location.Y);*/
        }
    }
}