namespace WindowsFormsApplication1
{
    partial class Form4
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_all = new System.Windows.Forms.Label();
            this.label_part = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(41, 55);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(187, 33);
            this.progressBar1.TabIndex = 0;
            // 
            // label_all
            // 
            this.label_all.AutoSize = true;
            this.label_all.Location = new System.Drawing.Point(193, 100);
            this.label_all.Name = "label_all";
            this.label_all.Size = new System.Drawing.Size(35, 12);
            this.label_all.TabIndex = 1;
            this.label_all.Text = "label1";
            // 
            // label_part
            // 
            this.label_part.AutoSize = true;
            this.label_part.Location = new System.Drawing.Point(152, 100);
            this.label_part.Name = "label_part";
            this.label_part.Size = new System.Drawing.Size(35, 12);
            this.label_part.TabIndex = 2;
            this.label_part.Text = "label2";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 165);
            this.Controls.Add(this.label_part);
            this.Controls.Add(this.label_all);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_all;
        private System.Windows.Forms.Label label_part;
    }
}