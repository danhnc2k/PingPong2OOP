namespace Pong
{
    partial class PongForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PongForm));
            this.aBall = new System.Windows.Forms.PictureBox();
            this.aTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.aLabelPlayer2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aLabelPlayer1 = new System.Windows.Forms.Label();
            this.aPaddle3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aPaddle4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.aBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPaddle3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPaddle4)).BeginInit();
            this.SuspendLayout();
            // 
            // aBall
            // 
            this.aBall.BackColor = System.Drawing.Color.Transparent;
            this.aBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.aBall.Image = ((System.Drawing.Image)(resources.GetObject("aBall.Image")));
            this.aBall.InitialImage = ((System.Drawing.Image)(resources.GetObject("aBall.InitialImage")));
            this.aBall.Location = new System.Drawing.Point(631, 250);
            this.aBall.Name = "aBall";
            this.aBall.Size = new System.Drawing.Size(36, 37);
            this.aBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aBall.TabIndex = 2;
            this.aBall.TabStop = false;
            this.aBall.Visible = false;
            this.aBall.Click += new System.EventHandler(this.aBall_Click);
            // 
            // aTimer
            // 
            this.aTimer.Enabled = true;
            this.aTimer.Interval = 1;
            this.aTimer.Tick += new System.EventHandler(this.aTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Score";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // aLabelPlayer2
            // 
            this.aLabelPlayer2.AutoSize = true;
            this.aLabelPlayer2.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aLabelPlayer2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aLabelPlayer2.Location = new System.Drawing.Point(12, 39);
            this.aLabelPlayer2.Name = "aLabelPlayer2";
            this.aLabelPlayer2.Size = new System.Drawing.Size(23, 24);
            this.aLabelPlayer2.TabIndex = 4;
            this.aLabelPlayer2.Text = "0";
            this.aLabelPlayer2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(41, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "|";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // aLabelPlayer1
            // 
            this.aLabelPlayer1.AutoSize = true;
            this.aLabelPlayer1.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aLabelPlayer1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aLabelPlayer1.Location = new System.Drawing.Point(69, 41);
            this.aLabelPlayer1.Name = "aLabelPlayer1";
            this.aLabelPlayer1.Size = new System.Drawing.Size(23, 24);
            this.aLabelPlayer1.TabIndex = 6;
            this.aLabelPlayer1.Text = "0";
            // 
            // aPaddle3
            // 
            this.aPaddle3.Image = ((System.Drawing.Image)(resources.GetObject("aPaddle3.Image")));
            this.aPaddle3.Location = new System.Drawing.Point(1489, 237);
            this.aPaddle3.Name = "aPaddle3";
            this.aPaddle3.Size = new System.Drawing.Size(23, 200);
            this.aPaddle3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aPaddle3.TabIndex = 7;
            this.aPaddle3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("VNI-Whimsy", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(528, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 52);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ping Pong";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // aPaddle4
            // 
            this.aPaddle4.Image = ((System.Drawing.Image)(resources.GetObject("aPaddle4.Image")));
            this.aPaddle4.Location = new System.Drawing.Point(509, 792);
            this.aPaddle4.Name = "aPaddle4";
            this.aPaddle4.Size = new System.Drawing.Size(258, 21);
            this.aPaddle4.TabIndex = 9;
            this.aPaddle4.TabStop = false;
            // 
            // PongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1321, 812);
            this.Controls.Add(this.aPaddle4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aPaddle3);
            this.Controls.Add(this.aLabelPlayer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aLabelPlayer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aBall);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PongForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.PongForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.aBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPaddle3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPaddle4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox aBall;
        private System.Windows.Forms.Timer aTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label aLabelPlayer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label aLabelPlayer1;
        private System.Windows.Forms.PictureBox aPaddle3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox aPaddle4;
    }
}
