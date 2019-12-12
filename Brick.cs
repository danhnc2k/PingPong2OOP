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
        public Item It;
        
        
        public void DrawBrick(int xPos,int yPos,Color vColor)
        {
            pBrick = new PictureBox()
            {
                Width = GlobalVariable.BrickWidth,
                Height = GlobalVariable.BrickHeight,
                Location = new Point(xPos, yPos),
                BackColor = vColor
            };
            It = new Item();
            It.DrawItem(xPos+GlobalVariable.BrickWidth/2-GlobalVariable.BrickHeight/2, yPos, GlobalVariable.BrickHeight, GlobalVariable.BrickHeight);
        }
        public bool CheckCollison(Ball b)
        {
            if (pBrick.Visible == false)
                return false;
            int xStep = b.xSpeed, yStep = b.ySpeed;
            if (xStep > b.pBall.Width)
                xStep = b.pBall.Width;
            if (yStep > b.pBall.Height)
                yStep = b.pBall.Height;
            int top, bot, left, right, xBall, yBall;
            top = pBrick.Top + GlobalVariable.BrickWallyPos;
            bot = pBrick.Bottom + GlobalVariable.BrickWallyPos;
            left = pBrick.Left + GlobalVariable.BrickWallxPos;
            right = pBrick.Right + GlobalVariable.BrickWallxPos;
            xBall = b.pBall.Location.X + b.pBall.Width / 2;
            yBall = b.pBall.Location.Y + b.pBall.Height / 2;
            if (b.pBall.Left + xStep <= right && b.pBall.Left > left && yBall >= top && yBall <= bot)
            {
                b.xSpeed *= -1;
                return true;
            }
            if (b.pBall.Right + xStep >= left && b.pBall.Right < right && yBall >= top && yBall <= bot)
            {
                b.xSpeed *= -1;
                return true;
            }
            if (yStep<0 && b.pBall.Top +yStep <= bot && b.pBall.Top >= top &&xBall >= left && xBall <= right)
            {
                b.ySpeed *= -1;
                return true;
            }
                
            if (yStep>0 && b.pBall.Bottom+yStep  >= top && b.pBall.Bottom <= bot && xBall >= left && xBall <= right)
            {
                b.ySpeed *= -1;
                return true;
            }
            
            return false;
        }
       
    }
}
