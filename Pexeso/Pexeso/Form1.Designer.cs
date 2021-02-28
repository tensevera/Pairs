
namespace Pexeso
{
    partial class Form1
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
            this.btStart = new System.Windows.Forms.Button();
            this.dupSize = new System.Windows.Forms.DomainUpDown();
            this.lbTurn = new System.Windows.Forms.Label();
            this.lbCurScore = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(156, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(122, 24);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // dupSize
            // 
            this.dupSize.Items.Add("8x8");
            this.dupSize.Items.Add("6x6");
            this.dupSize.Items.Add("4x4");
            this.dupSize.Location = new System.Drawing.Point(30, 12);
            this.dupSize.Name = "dupSize";
            this.dupSize.Size = new System.Drawing.Size(120, 24);
            this.dupSize.TabIndex = 2;
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.Location = new System.Drawing.Point(27, 39);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(62, 17);
            this.lbTurn.TabIndex = 3;
            this.lbTurn.Text = "Turn: P1";
            // 
            // lbCurScore
            // 
            this.lbCurScore.AutoSize = true;
            this.lbCurScore.Location = new System.Drawing.Point(153, 39);
            this.lbCurScore.Name = "lbCurScore";
            this.lbCurScore.Size = new System.Drawing.Size(122, 17);
            this.lbCurScore.TabIndex = 4;
            this.lbCurScore.Text = "Current score: 0:0";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(301, 39);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(68, 17);
            this.lbScore.TabIndex = 5;
            this.lbScore.Text = "Score 0:0";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.lbCurScore);
            this.Controls.Add(this.lbTurn);
            this.Controls.Add(this.dupSize);
            this.Controls.Add(this.btStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.DomainUpDown dupSize;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.Label lbCurScore;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

