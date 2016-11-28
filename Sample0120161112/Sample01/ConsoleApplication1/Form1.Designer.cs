namespace Score_exam
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
            this.pares_textBox = new System.Windows.Forms.TextBox();
            this.mares_textBox = new System.Windows.Forms.TextBox();
            this.pa_button = new System.Windows.Forms.Button();
            this.ma_button = new System.Windows.Forms.Button();
            this.result_button = new System.Windows.Forms.Button();
            this.result_textBox = new System.Windows.Forms.TextBox();
            this.start_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // pares_textBox
            // 
            this.pares_textBox.Location = new System.Drawing.Point(12, 35);
            this.pares_textBox.Name = "pares_textBox";
            this.pares_textBox.Size = new System.Drawing.Size(100, 19);
            this.pares_textBox.TabIndex = 0;
            // 
            // mares_textBox
            // 
            this.mares_textBox.Location = new System.Drawing.Point(12, 114);
            this.mares_textBox.Name = "mares_textBox";
            this.mares_textBox.Size = new System.Drawing.Size(100, 19);
            this.mares_textBox.TabIndex = 1;
            // 
            // pa_button
            // 
            this.pa_button.Location = new System.Drawing.Point(23, 60);
            this.pa_button.Name = "pa_button";
            this.pa_button.Size = new System.Drawing.Size(75, 23);
            this.pa_button.TabIndex = 2;
            this.pa_button.Text = "パターン";
            this.pa_button.UseVisualStyleBackColor = true;
            this.pa_button.Click += new System.EventHandler(this.pa_button_Click);
            // 
            // ma_button
            // 
            this.ma_button.Location = new System.Drawing.Point(23, 150);
            this.ma_button.Name = "ma_button";
            this.ma_button.Size = new System.Drawing.Size(75, 23);
            this.ma_button.TabIndex = 3;
            this.ma_button.Text = "マトリックス";
            this.ma_button.UseVisualStyleBackColor = true;
            this.ma_button.Click += new System.EventHandler(this.ma_button_Click);
            // 
            // result_button
            // 
            this.result_button.Location = new System.Drawing.Point(167, 88);
            this.result_button.Name = "result_button";
            this.result_button.Size = new System.Drawing.Size(75, 23);
            this.result_button.TabIndex = 4;
            this.result_button.Text = "結果ファイル";
            this.result_button.UseVisualStyleBackColor = true;
            this.result_button.Click += new System.EventHandler(this.result_button_Click);
            // 
            // result_textBox
            // 
            this.result_textBox.Location = new System.Drawing.Point(157, 60);
            this.result_textBox.Name = "result_textBox";
            this.result_textBox.Size = new System.Drawing.Size(100, 19);
            this.result_textBox.TabIndex = 5;
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(157, 196);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 6;
            this.start_button.Text = "実行";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\KUWABATA\\Documents\\Visual Studio 2015\\Projects\\Sample0120161112\\Sample01" +
    "\\ConsoleApplication1\\bin\\Release";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.InitialDirectory = "C:\\Users\\KUWABATA\\Documents\\Visual Studio 2015\\Projects\\Sample0120161112\\Sample01" +
    "\\ConsoleApplication1\\bin\\Release";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.result_textBox);
            this.Controls.Add(this.result_button);
            this.Controls.Add(this.ma_button);
            this.Controls.Add(this.pa_button);
            this.Controls.Add(this.mares_textBox);
            this.Controls.Add(this.pares_textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pares_textBox;
        private System.Windows.Forms.TextBox mares_textBox;
        private System.Windows.Forms.Button pa_button;
        private System.Windows.Forms.Button ma_button;
        private System.Windows.Forms.Button result_button;
        private System.Windows.Forms.TextBox result_textBox;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}