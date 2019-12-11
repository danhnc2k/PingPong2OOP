using System;
using System.Windows.Forms;
using System.Drawing;

namespace Pong
{
    public class AdvancedBall
    {
        PongForm form;
        private PictureBox ballPictureBox, ballModel;
        Random rand = new Random();
        AdvancedPlayer topsidePlayer, bottomsidePlayer;
        int xSpeed, ySpeed;

        public AdvancedBall(PongForm form, PictureBox aBallModel, AdvancedPlayer topsidePlayer, AdvancedPlayer bottomsidePlayer)
        {
            this.form = form;
            ballModel = aBallModel;
            this.ballPictureBox = new PictureBox();
            this.ballPictureBox.Size = aBallModel.Size;
            this.ballPictureBox.Image = aBallModel.Image;
            form.Controls.Add(ballPictureBox);
            this.topsidePlayer = topsidePlayer;
            this.bottomsidePlayer = bottomsidePlayer;
            ResetBall();
        }

        internal bool ProcessMove()
        {
            DoMove();

            var right = PongWorldInfo.rightOfWorld - ballPictureBox.Height;
            if (ballPictureBox.Location.X >= right || ballPictureBox.Location.Y <= PongWorldInfo.topOfWorld)
            {
                xSpeed *= -1;
            }
            if (ballPictureBox.Location.X <= PongWorldInfo.leftOfWorld)
            {
                xSpeed *= -1;
            }
            if (ballPictureBox.Location.Y <= PongWorldInfo.topOfWorld)
            {
                ySpeed *= -1;
                xSpeed *= -1;
            }
            else if (ballPictureBox.Location.Y >= PongWorldInfo.bottomOfWorld)// - ballPictureBox.Width)
            {
                Score(bottomsidePlayer);
                return true;
            }

            if (topsidePlayer.paddle.Bounds.IntersectsWith(ballPictureBox.Bounds)
                || bottomsidePlayer.paddle.Bounds.IntersectsWith(ballPictureBox.Bounds))
            {
                ySpeed *= -1;

                form.ballList.Add(new AdvancedBall(form, ballModel, topsidePlayer, bottomsidePlayer));

                /*while (topsidePlayer.paddle.Bounds.IntersectsWith(ballPictureBox.Bounds)
                    || bottomsidePlayer.paddle.Bounds.IntersectsWith(ballPictureBox.Bounds))
                {
                    DoMove();
                }*/
            }

            return false;
        }

        private int DoMove()
        {
            var right = PongWorldInfo.rightOfWorld- ballPictureBox.Height;
            ballPictureBox.Location = new Point(ballPictureBox.Location.X + xSpeed,
                Math.Max(PongWorldInfo.leftOfWorld, Math.Min(right, ballPictureBox.Location.Y + ySpeed))
                );
            return right;
        }

        private void Score(AdvancedPlayer winningPlayer)
        {
            winningPlayer.score++;
            form.Controls.Remove(ballPictureBox);
        }

        private void ResetBall()
        {
            ballPictureBox.Location = new Point((PongWorldInfo.leftOfWorld + PongWorldInfo.rightOfWorld) / 2,
                            (PongWorldInfo.topOfWorld + PongWorldInfo.bottomOfWorld) / 2);
            do
            {
                xSpeed = rand.Next(-3, 3);
                ySpeed = rand.Next(-3, 3);
            } while (Math.Abs(xSpeed) + Math.Abs(ySpeed) <= 3 || Math.Abs(xSpeed) <= 1);
        }
    }
}
