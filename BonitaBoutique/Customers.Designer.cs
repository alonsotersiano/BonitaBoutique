
namespace BonitaBoutique
{
    partial class Customers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExportCustomersBtn = new System.Windows.Forms.Button();
            this.ResearchBtn = new System.Windows.Forms.Button();
            this.CustomerDGV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.CustPhoneTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CustEmailTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CustLogoutBtn = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CustResetBtn = new System.Windows.Forms.Button();
            this.CustDeleteBtn = new System.Windows.Forms.Button();
            this.CustUpdateBtn = new System.Windows.Forms.Button();
            this.CustSaveBtn = new System.Windows.Forms.Button();
            this.CustNameTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustLogoutBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ExportCustomersBtn);
            this.panel1.Controls.Add(this.ResearchBtn);
            this.panel1.Controls.Add(this.CustomerDGV);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.CustPhoneTb);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CustEmailTb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CustLogoutBtn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CustResetBtn);
            this.panel1.Controls.Add(this.CustDeleteBtn);
            this.panel1.Controls.Add(this.CustUpdateBtn);
            this.panel1.Controls.Add(this.CustSaveBtn);
            this.panel1.Controls.Add(this.CustNameTb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(8, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 612);
            this.panel1.TabIndex = 1;
            // 
            // ExportCustomersBtn
            // 
            this.ExportCustomersBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(46)))), ((int)(((byte)(22)))));
            this.ExportCustomersBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.ExportCustomersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportCustomersBtn.Font = new System.Drawing.Font("Arial", 12.75F);
            this.ExportCustomersBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExportCustomersBtn.Location = new System.Drawing.Point(633, 242);
            this.ExportCustomersBtn.Name = "ExportCustomersBtn";
            this.ExportCustomersBtn.Size = new System.Drawing.Size(211, 27);
            this.ExportCustomersBtn.TabIndex = 40;
            this.ExportCustomersBtn.Text = "Export Customers to CSV";
            this.ExportCustomersBtn.UseVisualStyleBackColor = false;
            this.ExportCustomersBtn.Click += new System.EventHandler(this.ExportCustomersBtn_Click);
            // 
            // ResearchBtn
            // 
            this.ResearchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(46)))), ((int)(((byte)(22)))));
            this.ResearchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.ResearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResearchBtn.Font = new System.Drawing.Font("Arial", 12.75F);
            this.ResearchBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ResearchBtn.Location = new System.Drawing.Point(384, 159);
            this.ResearchBtn.Name = "ResearchBtn";
            this.ResearchBtn.Size = new System.Drawing.Size(122, 27);
            this.ResearchBtn.TabIndex = 33;
            this.ResearchBtn.Text = "Search Client";
            this.ResearchBtn.UseVisualStyleBackColor = false;
            this.ResearchBtn.Click += new System.EventHandler(this.ResearchBtn_Click);
            // 
            // CustomerDGV
            // 
            this.CustomerDGV.AllowUserToAddRows = false;
            this.CustomerDGV.AllowUserToDeleteRows = false;
            this.CustomerDGV.AllowUserToOrderColumns = true;
            this.CustomerDGV.AllowUserToResizeRows = false;
            this.CustomerDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CustomerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDGV.Location = new System.Drawing.Point(4, 275);
            this.CustomerDGV.Name = "CustomerDGV";
            this.CustomerDGV.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CustomerDGV.RowTemplate.Height = 25;
            this.CustomerDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerDGV.Size = new System.Drawing.Size(840, 334);
            this.CustomerDGV.TabIndex = 32;
            this.CustomerDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerDGV_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label6.Location = new System.Drawing.Point(623, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 22);
            this.label6.TabIndex = 31;
            this.label6.Text = "Billing";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(568, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 39);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // CustPhoneTb
            // 
            this.CustPhoneTb.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CustPhoneTb.Location = new System.Drawing.Point(565, 109);
            this.CustPhoneTb.Name = "CustPhoneTb";
            this.CustPhoneTb.Size = new System.Drawing.Size(142, 22);
            this.CustPhoneTb.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F);
            this.label5.Location = new System.Drawing.Point(565, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Phone";
            // 
            // CustEmailTb
            // 
            this.CustEmailTb.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CustEmailTb.Location = new System.Drawing.Point(382, 109);
            this.CustEmailTb.Name = "CustEmailTb";
            this.CustEmailTb.Size = new System.Drawing.Size(142, 22);
            this.CustEmailTb.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F);
            this.label4.Location = new System.Drawing.Point(382, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Email";
            // 
            // CustLogoutBtn
            // 
            this.CustLogoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustLogoutBtn.Image = ((System.Drawing.Image)(resources.GetObject("CustLogoutBtn.Image")));
            this.CustLogoutBtn.Location = new System.Drawing.Point(788, 0);
            this.CustLogoutBtn.Name = "CustLogoutBtn";
            this.CustLogoutBtn.Size = new System.Drawing.Size(54, 32);
            this.CustLogoutBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CustLogoutBtn.TabIndex = 25;
            this.CustLogoutBtn.TabStop = false;
            this.CustLogoutBtn.Click += new System.EventHandler(this.CustLogoutBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label7.Location = new System.Drawing.Point(381, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 22);
            this.label7.TabIndex = 24;
            this.label7.Text = "Customers List";
            // 
            // CustResetBtn
            // 
            this.CustResetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CustResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustResetBtn.Font = new System.Drawing.Font("Arial", 12.75F);
            this.CustResetBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustResetBtn.Location = new System.Drawing.Point(633, 159);
            this.CustResetBtn.Name = "CustResetBtn";
            this.CustResetBtn.Size = new System.Drawing.Size(140, 27);
            this.CustResetBtn.TabIndex = 22;
            this.CustResetBtn.Text = "Reset Research";
            this.CustResetBtn.UseVisualStyleBackColor = false;
            this.CustResetBtn.Click += new System.EventHandler(this.CustResetBtn_Click);
            // 
            // CustDeleteBtn
            // 
            this.CustDeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CustDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustDeleteBtn.Font = new System.Drawing.Font("Arial", 12.75F);
            this.CustDeleteBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustDeleteBtn.Location = new System.Drawing.Point(524, 159);
            this.CustDeleteBtn.Name = "CustDeleteBtn";
            this.CustDeleteBtn.Size = new System.Drawing.Size(92, 27);
            this.CustDeleteBtn.TabIndex = 21;
            this.CustDeleteBtn.Text = "Delete";
            this.CustDeleteBtn.UseVisualStyleBackColor = false;
            this.CustDeleteBtn.Click += new System.EventHandler(this.CustDeleteBtn_Click);
            // 
            // CustUpdateBtn
            // 
            this.CustUpdateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(46)))), ((int)(((byte)(22)))));
            this.CustUpdateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.CustUpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustUpdateBtn.Font = new System.Drawing.Font("Arial", 12.75F);
            this.CustUpdateBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustUpdateBtn.Location = new System.Drawing.Point(274, 159);
            this.CustUpdateBtn.Name = "CustUpdateBtn";
            this.CustUpdateBtn.Size = new System.Drawing.Size(92, 27);
            this.CustUpdateBtn.TabIndex = 20;
            this.CustUpdateBtn.Text = "Update";
            this.CustUpdateBtn.UseVisualStyleBackColor = false;
            this.CustUpdateBtn.Click += new System.EventHandler(this.CustUpdateBtn_Click);
            // 
            // CustSaveBtn
            // 
            this.CustSaveBtn.BackColor = System.Drawing.Color.Green;
            this.CustSaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustSaveBtn.Font = new System.Drawing.Font("Arial", 12.75F);
            this.CustSaveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustSaveBtn.Location = new System.Drawing.Point(118, 159);
            this.CustSaveBtn.Name = "CustSaveBtn";
            this.CustSaveBtn.Size = new System.Drawing.Size(138, 27);
            this.CustSaveBtn.TabIndex = 19;
            this.CustSaveBtn.Text = "Add New Client";
            this.CustSaveBtn.UseVisualStyleBackColor = false;
            this.CustSaveBtn.Click += new System.EventHandler(this.CustSaveBtn_Click);
            // 
            // CustNameTb
            // 
            this.CustNameTb.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CustNameTb.Location = new System.Drawing.Point(199, 109);
            this.CustNameTb.Name = "CustNameTb";
            this.CustNameTb.Size = new System.Drawing.Size(142, 22);
            this.CustNameTb.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F);
            this.label3.Location = new System.Drawing.Point(199, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(437, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Customers";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(382, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label2.Location = new System.Drawing.Point(263, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Products";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(208, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 632);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustLogoutBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox CustPhoneTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CustEmailTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox CustLogoutBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CustResetBtn;
        private System.Windows.Forms.Button CustDeleteBtn;
        private System.Windows.Forms.Button CustUpdateBtn;
        private System.Windows.Forms.Button CustSaveBtn;
        private System.Windows.Forms.TextBox CustNameTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView CustomerDGV;
        private System.Windows.Forms.Button ResearchBtn;
        private System.Windows.Forms.Button ExportCustomersBtn;
    }
}