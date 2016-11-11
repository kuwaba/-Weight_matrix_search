namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.protein_title = new System.Windows.Forms.Label();
            this.messageQueue1 = new System.Messaging.MessageQueue();
            this.richTextBox_protein = new System.Windows.Forms.RichTextBox();
            this.listBox_score = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // protein_title
            // 
            this.protein_title.AutoSize = true;
            this.protein_title.Location = new System.Drawing.Point(27, 25);
            this.protein_title.Name = "protein_title";
            this.protein_title.Size = new System.Drawing.Size(35, 12);
            this.protein_title.TabIndex = 0;
            this.protein_title.Text = "label1";
            // 
            // messageQueue1
            // 
            this.messageQueue1.MessageReadPropertyFilter.LookupId = true;
            this.messageQueue1.SynchronizingObject = this;
            // 
            // richTextBox_protein
            // 
            this.richTextBox_protein.Location = new System.Drawing.Point(29, 55);
            this.richTextBox_protein.Name = "richTextBox_protein";
            this.richTextBox_protein.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_protein.Size = new System.Drawing.Size(472, 138);
            this.richTextBox_protein.TabIndex = 1;
            this.richTextBox_protein.Text = "";
            // 
            // listBox_score
            // 
            this.listBox_score.FormattingEnabled = true;
            this.listBox_score.HorizontalScrollbar = true;
            this.listBox_score.ItemHeight = 12;
            this.listBox_score.Location = new System.Drawing.Point(29, 228);
            this.listBox_score.Name = "listBox_score";
            this.listBox_score.Size = new System.Drawing.Size(641, 232);
            this.listBox_score.TabIndex = 2;
            this.listBox_score.SelectedIndexChanged += new System.EventHandler(this.listBox_score_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 516);
            this.Controls.Add(this.listBox_score);
            this.Controls.Add(this.richTextBox_protein);
            this.Controls.Add(this.protein_title);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label protein_title;
        private System.Messaging.MessageQueue messageQueue1;
        private System.Windows.Forms.RichTextBox richTextBox_protein;
        private System.Windows.Forms.ListBox listBox_score;
    }
}