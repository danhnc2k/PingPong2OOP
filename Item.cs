using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PingPongGame
{
    class Item
    {
        public PictureBox pItem;
        public int Type;//0: No item
                        //1:x0.5, 2: x2, 3: x2 length, 4: x0.5 length
        int Speed = 3;
        public void DrawItem(int xPos, int yPos, int w, int h)
        {
            pItem = new PictureBox()
            {
                Image = System.Drawing.Image.FromFile("2.png"),
                BackColor = Color.Transparent,
                SizeMode=PictureBoxSizeMode.StretchImage,
                Location = new Point(xPos, yPos),
                Size = new Size(w, h)
                
            };
        }
        public void Move()
        {
            pItem.Location = new Point(pItem.Location.X, pItem.Location.Y + Speed);
        }
        public bool CheckCollison(Racket r)
        {
            if (pItem.Bottom < r.racket.Bottom && pItem.Bottom - Speed > r.racket.Top
                && pItem.Location.X + pItem.Width / 2 > r.racket.Left && pItem.Location.X + pItem.Width / 2 < r.racket.Right)
            {
                return true;
            }
            return false;
        }
    }
}
