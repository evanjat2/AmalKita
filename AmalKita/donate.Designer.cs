
namespace AmalKita2
{
    partial class donate
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTujuan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbJumlah = new System.Windows.Forms.TextBox();
            this.lblClose = new System.Windows.Forms.Label();
            this.btnDonate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Donate Untuk Siapa?";
            // 
            // tbTujuan
            // 
            this.tbTujuan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTujuan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbTujuan.Location = new System.Drawing.Point(27, 63);
            this.tbTujuan.Name = "tbTujuan";
            this.tbTujuan.Size = new System.Drawing.Size(152, 20);
            this.tbTujuan.TabIndex = 1;
            this.tbTujuan.TextChanged += new System.EventHandler(this.tbTujuan_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Donate berapa Item?";
            // 
            // tbJumlah
            // 
            this.tbJumlah.Location = new System.Drawing.Point(27, 118);
            this.tbJumlah.Name = "tbJumlah";
            this.tbJumlah.Size = new System.Drawing.Size(152, 20);
            this.tbJumlah.TabIndex = 3;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.Location = new System.Drawing.Point(175, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(26, 25);
            this.lblClose.TabIndex = 14;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // btnDonate
            // 
            this.btnDonate.Location = new System.Drawing.Point(27, 170);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(152, 23);
            this.btnDonate.TabIndex = 15;
            this.btnDonate.Text = "Donate";
            this.btnDonate.UseVisualStyleBackColor = true;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // donate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 265);
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.tbJumlah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTujuan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "donate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "donate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTujuan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbJumlah;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button btnDonate;
    }
}