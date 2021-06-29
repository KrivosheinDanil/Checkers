namespace Kursach
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CountKillBlue = new System.Windows.Forms.Label();
            this.CountKillRed = new System.Windows.Forms.Label();
            this.CurrentTurn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // CountKillBlue
            // 
            this.CountKillBlue.AutoSize = true;
            this.CountKillBlue.Font = new System.Drawing.Font("Algerian", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountKillBlue.Location = new System.Drawing.Point(676, 54);
            this.CountKillBlue.Name = "CountKillBlue";
            this.CountKillBlue.Size = new System.Drawing.Size(83, 21);
            this.CountKillBlue.TabIndex = 0;
            this.CountKillBlue.Text = "0 убитых";
            // 
            // CountKillRed
            // 
            this.CountKillRed.AutoSize = true;
            this.CountKillRed.Font = new System.Drawing.Font("Algerian", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountKillRed.Location = new System.Drawing.Point(676, 470);
            this.CountKillRed.Name = "CountKillRed";
            this.CountKillRed.Size = new System.Drawing.Size(83, 21);
            this.CountKillRed.TabIndex = 2;
            this.CountKillRed.Text = "0 убитых";
            // 
            // CurrentTurn
            // 
            this.CurrentTurn.AutoSize = true;
            this.CurrentTurn.BackColor = System.Drawing.Color.Red;
            this.CurrentTurn.Font = new System.Drawing.Font("Algerian", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTurn.Location = new System.Drawing.Point(598, 244);
            this.CurrentTurn.Name = "CurrentTurn";
            this.CurrentTurn.Size = new System.Drawing.Size(172, 31);
            this.CurrentTurn.TabIndex = 4;
            this.CurrentTurn.Text = "Ход Красных";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(597, 444);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(597, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 548);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CurrentTurn);
            this.Controls.Add(this.CountKillRed);
            this.Controls.Add(this.CountKillBlue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Шашки";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CountKillBlue;
        private System.Windows.Forms.Label CountKillRed;
        private System.Windows.Forms.Label CurrentTurn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

