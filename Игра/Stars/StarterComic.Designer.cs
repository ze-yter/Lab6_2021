﻿
namespace Stars
{
    partial class StarterComic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarterComic));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button1Onwards = new System.Windows.Forms.Button();
            this.button2Onwards = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 631);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(578, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(464, 631);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1078, 49);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(464, 631);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // button1Onwards
            // 
            this.button1Onwards.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1Onwards.BackgroundImage")));
            this.button1Onwards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1Onwards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1Onwards.ForeColor = System.Drawing.Color.Black;
            this.button1Onwards.Location = new System.Drawing.Point(1275, 740);
            this.button1Onwards.Name = "button1Onwards";
            this.button1Onwards.Size = new System.Drawing.Size(238, 68);
            this.button1Onwards.TabIndex = 3;
            this.button1Onwards.UseVisualStyleBackColor = true;
            this.button1Onwards.Click += new System.EventHandler(this.Button1Onwards_Click);
            // 
            // button2Onwards
            // 
            this.button2Onwards.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2Onwards.BackgroundImage")));
            this.button2Onwards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2Onwards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2Onwards.ForeColor = System.Drawing.Color.Black;
            this.button2Onwards.Location = new System.Drawing.Point(1275, 740);
            this.button2Onwards.Name = "button2Onwards";
            this.button2Onwards.Size = new System.Drawing.Size(238, 68);
            this.button2Onwards.TabIndex = 7;
            this.button2Onwards.UseVisualStyleBackColor = true;
            this.button2Onwards.Visible = false;
            this.button2Onwards.Click += new System.EventHandler(this.Button2Onwards_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStartGame.BackgroundImage")));
            this.buttonStartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartGame.ForeColor = System.Drawing.Color.Black;
            this.buttonStartGame.Location = new System.Drawing.Point(1275, 740);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(244, 71);
            this.buttonStartGame.TabIndex = 8;
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Visible = false;
            this.buttonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Location = new System.Drawing.Point(12, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 30);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 23.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(78, 725);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1079, 66);
            this.label1.TabIndex = 10;
            this.label1.Text = "Как-то раз мои друзья-инопланетяне позвали меня в гости \r\nна Луну, и я решил слет" +
    "ать туда на выходные.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 23.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(78, 725);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1003, 99);
            this.label2.TabIndex = 11;
            this.label2.Text = "Во время посадки на Луну приборы моего космического \r\nкорабля начали издавать стр" +
    "анные звуки, а кнопка \r\nпреземления перестала работать...";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 23.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(78, 725);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1003, 99);
            this.label3.TabIndex = 12;
            this.label3.Text = "К сожалению, мою ракету разорвало на части, и теперь\r\nя не могу вернуться к себе " +
    "домой... Не могли бы вы \r\nпомочь мне собрать космический корабль заново?";
            this.label3.Visible = false;
            // 
            // StarterComic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1620, 920);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.button2Onwards);
            this.Controls.Add(this.button1Onwards);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StarterComic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StarterComic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button1Onwards;
        private System.Windows.Forms.Button button2Onwards;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}