using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PingPongGame
{
    class Brick
    {
        public PictureBox pBrick;
        
        
        
        public void DrawBrick(int xPos,int yPos,Color vColor)
        {
            pBrick = new PictureBox()
            {
                Width = GlobalVariable.BrickWidth,
                Height = GlobalVariable.BrickHeight,
                Location = new Point(xPos, yPos),
                BackColor = vColor
            };
            //pBrick.Visible = true;
        }
        public bool CheckCollison(Ball b)
        {
            
            int xStep = b.xSpeed, yStep = b.ySpeed;
            if (xStep > b.pBall.Width)
                xStep = b.pBall.Width;
            if (yStep > b.pBall.Height)
                yStep = b.pBall.Height;
            int top, bot, left, right;
            top = pBrick.Top + GlobalVariable.BrickWallyPos;
            bot = pBrick.Bottom + GlobalVariable.BrickWallyPos;
            left = pBrick.Left + GlobalVariable.BrickWallxPos;
            right = pBrick.Right + GlobalVariable.BrickWallxPos;
            if (b.pBall.Top +yStep < bot && b.pBall.Top > top && b.pBall.Location.X >= left && b.pBall.Location.X <= right)
            {
                b.ySpeed *= -1;
                return true;
            }
                
            if (b.pBall.Bottom+yStep  > top && b.pBall.Bottom < bot && b.pBall.Location.X >= left && b.pBall.Location.X <= right)
            {
                b.ySpeed *= -1;
                return true;
            }
            if (b.pBall.Left + xStep < right && b.pBall.Left > left && b.pBall.Location.Y > top && b.pBall.Location.Y < bot)
            {
                b.xSpeed *= -1;
                return true;
            }
            if (b.pBall.Right + xStep > left && b.pBall.Right < right && b.pBall.Location.Y > top && b.pBall.Location.Y < bot)
            {
                b.xSpeed *= -1;
                return true;
            }
            return false;
        }
    }
}
