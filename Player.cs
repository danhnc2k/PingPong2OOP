using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PingPongGame
{
    public class Player
    {
        const int racket_speed = 10;                                    //biến này là tốc độ di chuyển mặc định của thanh đỡ
        const int PointNeedToWin = 5;                                   //biến này là điểm cần có để quyết thịnh thắng

        private int RacketX, RacketY;                                   //2 biến phụ để lưu vị trí(đầu tiên) của thanh đỡ

        public bool isLeftPress, isRightPress;                          //2 biến kiểm tra nút bấm
        public PictureBox racket;                                       //racket, playground và Scored lần lượt nhận Racket, PlayGround và scoredLabel từ hàm gọi
        Panel playground;
        Label Scored;

        int _scored;                                                    //biến scored này có giá trị = 0(để lưu điểm đã đạt được của Player)
        public int scored                                               //hàm scored khi gọi sẽ trả về _scored và đặt giá trị mới nếu thay đổi từ ngoài
        {
            get
            {
                return _scored;
            }
            set
            {
                _scored = value;                                        //value là kết quả của sự thay đổi khi gọi _scored và nó sẽ lưu kết quả thay đổi mới đó vào đây
                Scored.Text = scored.ToString();                        // Chuyển số thành chuỗi rồi in ra bảng kế bên bảng Score của Player
            }
        }

        public Player(PictureBox racket, Label Scored, int XPos, int YPos)      //Nơi nhận các biến đưa vào
        {
            this.racket = racket;
            this.Scored = Scored;
            this.RacketX = XPos;
            this.RacketY = YPos;
            racket.Location = new Point(RacketX, RacketY);
        }

        internal void ProcessMove(Panel PlayGround)
        {
            playground = PlayGround;

            if(isLeftPress && isLeftPress != isRightPress && racket.Left >= playground.Left)                //Di chuyển thanh đỡ sang trái nếu nút trái được ấn(A hoặc mũi tên trái) và nút phải(D hoặc mũi tên phải)
            {                                                                                               //và chỉ di chuyển cho đến khi thanh dỡ chạm viền trái của khung
                racket.Location = new Point(racket.Location.X - racket_speed, racket.Location.Y);           
            }
            else if (isRightPress && isLeftPress != isRightPress && racket.Right <= playground.Right)       //Tương tự như trên
            {
                racket.Location = new Point(racket.Location.X + racket_speed, racket.Location.Y);
            }
        }

        public bool isThePlayerWon()                                    //Khi gọi hàm này sẽ kiểm tra điểm người chơi đạt được có thỏa điểm cần để thắng hay chưa
        {
            if (_scored == PointNeedToWin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetRacket()                                       //Hàm này giúp thanh đỡ trở về vị trí ban đầu nhờ các tham số lần đầu đưa vào
        {
            racket.Location = new Point(RacketX, RacketY);
        }

    }


}
