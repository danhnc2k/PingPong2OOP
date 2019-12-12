using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PingPongGame
{
    class Wall
    {
        public List<Brick> LBricks;
        Panel BrickWall;
        public Wall(Panel p)
        {
            BrickWall = p;
        }
        public bool CheckCollisonBrick(Ball b)
        {
           
            for (int i = 0; i < LBricks.Count; i++) 
            {
               
                if (LBricks[i].CheckCollison(b) == true)
                {
                    LBricks[i].pBrick.Visible = false;
                    return true;
                }
                
            }
            return false;
        }
        public void MoveItem()
        {
            for (int i = 0; i < LBricks.Count; i++)
            {

                if (LBricks[i].pBrick.Visible == false)
                {
                    LBricks[i].It.Move();
                }
            }
            
        }
        public bool CheckCollisonItem(Racket r)
        {
            for (int i = 0; i < LBricks.Count; i++)
            {
                
                if (LBricks[i].It.CheckCollison(r) == true)
                {
                    
                    return true;
                }
            }
            return false;
        }
        public void DrawWall()
        {
            
            LBricks = new List<Brick>();
            int Num = GlobalVariable.BrickColumn;
            int x = 0, y = 0;
            for (int i = 0; i < GlobalVariable.BrickRow; i++)
            {
               
                for (int j = 0; j < Num; j++)
                {
                    Brick temp = new Brick();
                    if (j==0)
                    {
                        temp.DrawBrick(x , y, System.Drawing.Color.Red);
                    }
                    else
                    {
                        temp.DrawBrick(x + GlobalVariable.BrickWidth + GlobalVariable.BrickSpace, y, System.Drawing.Color.Red);
                    }

                    LBricks.Add(temp);
                    BrickWall.Controls.Add(temp.pBrick);
                    BrickWall.Controls.Add(temp.It.pItem);
                    x = temp.pBrick.Location.X;
                    y = temp.pBrick.Location.Y;
                   
                    
                }
                if (i % 2 == 0)
                {
                    Num = GlobalVariable.BrickColumn - 1;
                    
                    x = GlobalVariable.BrickWidth / 2;
                    y += GlobalVariable.BrickHeight + GlobalVariable.BrickSpace;
                }
                else
                {
                    Num = GlobalVariable.BrickColumn;

                    x = 0;
                    y += GlobalVariable.BrickHeight + GlobalVariable.BrickSpace;
                    
                }
                

            }
            BrickWall.SendToBack();
        }
    }
}
