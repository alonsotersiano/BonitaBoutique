
namespace BonitaBoutique
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Myprogress = new System.Windows.Forms.ProgressBar();
            this.Label2 = new System.Windows.Forms.Label();
            this.PercentageLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(200, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.SystemColors.Control;
            this.Label1.Location = new System.Drawing.Point(159, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(258, 37);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Bonita Boutique";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Myprogress
            // 
            this.Myprogress.Location = new System.Drawing.Point(10, 281);
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.Size = new System.Drawing.Size(515, 20);
            this.Myprogress.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.SystemColors.Control;
            this.Label2.Location = new System.Drawing.Point(11, 260);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(160, 20);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Loading Modules...";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PercentageLbl
            // 
            this.PercentageLbl.AutoSize = true;
            this.PercentageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.PercentageLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.PercentageLbl.Location = new System.Drawing.Point(176, 259);
            this.PercentageLbl.Name = "PercentageLbl";
            this.PercentageLbl.Size = new System.Drawing.Size(24, 20);
            this.PercentageLbl.TabIndex = 4;
            this.PercentageLbl.Text = "%";
            this.PercentageLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(46)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(536, 311);
            this.Controls.Add(this.PercentageLbl);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Myprogress);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ProgressBar Myprogress;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label PercentageLbl;
        private System.Windows.Forms.Timer timer1;
    }
}

