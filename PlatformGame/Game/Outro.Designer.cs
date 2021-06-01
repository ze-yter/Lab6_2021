
using System.Windows.Forms;

namespace Game.Levels
{
    partial class Outro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Outro));
            this.outroLabel = new System.Windows.Forms.Label();
            this.vih = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outroLabel
            // 
            this.outroLabel.AutoSize = true;
            this.outroLabel.BackColor = System.Drawing.Color.Transparent;
            this.outroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outroLabel.Location = new System.Drawing.Point(12, 902);
            this.outroLabel.Name = "outroLabel";
            this.outroLabel.Size = new System.Drawing.Size(158, 68);
            this.outroLabel.TabIndex = 6;
            this.outroLabel.Text = "label1";
            this.outroLabel.UseCompatibleTextRendering = true;
            this.outroLabel.Click += new System.EventHandler(this.outroLabel_Click);
            // 
            // vih
            // 
            this.vih.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.vih.Location = new System.Drawing.Point(0, 0);
            this.vih.Margin = new System.Windows.Forms.Padding(0);
            this.vih.Name = "vih";
            this.vih.Size = new System.Drawing.Size(300, 300);
            this.vih.TabIndex = 1;
            this.vih.Text = "Для выхода нажмите Enter";
            this.vih.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 604);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(729, 150);
            this.label1.TabIndex = 7;
            this.label1.Text = "Для выхода нажмите Enter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // Outro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outroLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Outro";
            this.Text = "Outro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Outro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Outro_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label outroLabel;
        private Label vih;
        private Label label1;
    }
}