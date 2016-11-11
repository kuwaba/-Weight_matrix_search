namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.botten_protein = new System.Windows.Forms.Button();
            this.label_protein = new System.Windows.Forms.Label();
            this.textbox_protein = new System.Windows.Forms.TextBox();
            this.label_motif = new System.Windows.Forms.Label();
            this.text_motif = new System.Windows.Forms.TextBox();
            this.button_motif = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog_protein = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.serche = new System.Windows.Forms.Button();
            this.label_time = new System.Windows.Forms.Label();
            this.listBox_protein = new System.Windows.Forms.ListBox();
            this.button_List_protein = new System.Windows.Forms.Button();
            this.listBox_motif = new System.Windows.Forms.ListBox();
            this.button_List_motif = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Score_textbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.score_radioButton = new System.Windows.Forms.RadioButton();
            this.level_radioButton = new System.Windows.Forms.RadioButton();
            this.level_comboBox = new System.Windows.Forms.ComboBox();
            this.result_label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.well_radioButton = new System.Windows.Forms.RadioButton();
            this.best_radioButton = new System.Windows.Forms.RadioButton();
            this.protein_dataGridView = new System.Windows.Forms.DataGridView();
            this.protein_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protein_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.motif_dataGridView = new System.Windows.Forms.DataGridView();
            this.motif_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motif_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.protein_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motif_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // botten_protein
            // 
            this.botten_protein.Location = new System.Drawing.Point(76, 88);
            this.botten_protein.Name = "botten_protein";
            this.botten_protein.Size = new System.Drawing.Size(75, 23);
            this.botten_protein.TabIndex = 0;
            this.botten_protein.Text = "ファイル選択";
            this.botten_protein.UseVisualStyleBackColor = true;
            this.botten_protein.Click += new System.EventHandler(this.botten_protein_Click);
            // 
            // label_protein
            // 
            this.label_protein.AutoSize = true;
            this.label_protein.Location = new System.Drawing.Point(89, 48);
            this.label_protein.Name = "label_protein";
            this.label_protein.Size = new System.Drawing.Size(52, 12);
            this.label_protein.TabIndex = 1;
            this.label_protein.Text = "タンパク質";
            this.label_protein.Click += new System.EventHandler(this.label1_Click);
            // 
            // textbox_protein
            // 
            this.textbox_protein.Location = new System.Drawing.Point(30, 63);
            this.textbox_protein.Name = "textbox_protein";
            this.textbox_protein.Size = new System.Drawing.Size(169, 19);
            this.textbox_protein.TabIndex = 2;
            // 
            // label_motif
            // 
            this.label_motif.AutoSize = true;
            this.label_motif.Location = new System.Drawing.Point(546, 48);
            this.label_motif.Name = "label_motif";
            this.label_motif.Size = new System.Drawing.Size(41, 12);
            this.label_motif.TabIndex = 4;
            this.label_motif.Text = "モチーフ";
            // 
            // text_motif
            // 
            this.text_motif.Location = new System.Drawing.Point(484, 63);
            this.text_motif.Name = "text_motif";
            this.text_motif.Size = new System.Drawing.Size(169, 19);
            this.text_motif.TabIndex = 5;
            // 
            // button_motif
            // 
            this.button_motif.Location = new System.Drawing.Point(534, 88);
            this.button_motif.Name = "button_motif";
            this.button_motif.Size = new System.Drawing.Size(75, 23);
            this.button_motif.TabIndex = 6;
            this.button_motif.Text = "ファイル選択";
            this.button_motif.UseVisualStyleBackColor = true;
            this.button_motif.Click += new System.EventHandler(this.button_motif_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 282);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(718, 217);
            this.textBox1.TabIndex = 7;
            this.textBox1.WordWrap = false;
            // 
            // openFileDialog_protein
            // 
            this.openFileDialog_protein.FileName = "openFileDialog_protein";
            this.openFileDialog_protein.Multiselect = true;
            // 
            // serche
            // 
            this.serche.Location = new System.Drawing.Point(338, 211);
            this.serche.Name = "serche";
            this.serche.Size = new System.Drawing.Size(75, 23);
            this.serche.TabIndex = 10;
            this.serche.Text = "検索";
            this.serche.UseVisualStyleBackColor = true;
            this.serche.Click += new System.EventHandler(this.serche_Click);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(346, 237);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(53, 12);
            this.label_time.TabIndex = 11;
            this.label_time.Text = "検索時間";
            // 
            // listBox_protein
            // 
            this.listBox_protein.FormattingEnabled = true;
            this.listBox_protein.HorizontalScrollbar = true;
            this.listBox_protein.ItemHeight = 12;
            this.listBox_protein.Location = new System.Drawing.Point(768, 63);
            this.listBox_protein.Name = "listBox_protein";
            this.listBox_protein.Size = new System.Drawing.Size(238, 124);
            this.listBox_protein.TabIndex = 12;
            // 
            // button_List_protein
            // 
            this.button_List_protein.Location = new System.Drawing.Point(824, 211);
            this.button_List_protein.Name = "button_List_protein";
            this.button_List_protein.Size = new System.Drawing.Size(75, 23);
            this.button_List_protein.TabIndex = 13;
            this.button_List_protein.Text = "詳細";
            this.button_List_protein.UseVisualStyleBackColor = true;
            this.button_List_protein.Click += new System.EventHandler(this.button_List_protein_Click);
            // 
            // listBox_motif
            // 
            this.listBox_motif.FormattingEnabled = true;
            this.listBox_motif.ItemHeight = 12;
            this.listBox_motif.Location = new System.Drawing.Point(1038, 63);
            this.listBox_motif.Name = "listBox_motif";
            this.listBox_motif.Size = new System.Drawing.Size(241, 124);
            this.listBox_motif.TabIndex = 14;
            // 
            // button_List_motif
            // 
            this.button_List_motif.Location = new System.Drawing.Point(1123, 211);
            this.button_List_motif.Name = "button_List_motif";
            this.button_List_motif.Size = new System.Drawing.Size(75, 23);
            this.button_List_motif.TabIndex = 15;
            this.button_List_motif.Text = "詳細";
            this.button_List_motif.UseVisualStyleBackColor = true;
            this.button_List_motif.Click += new System.EventHandler(this.button_List_motif_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(303, 224);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(10, 10);
            this.progressBar1.TabIndex = 16;
            // 
            // Score_textbox
            // 
            this.Score_textbox.Location = new System.Drawing.Point(367, 140);
            this.Score_textbox.Name = "Score_textbox";
            this.Score_textbox.Size = new System.Drawing.Size(100, 19);
            this.Score_textbox.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.score_radioButton);
            this.groupBox1.Controls.Add(this.level_radioButton);
            this.groupBox1.Location = new System.Drawing.Point(297, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(64, 87);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // score_radioButton
            // 
            this.score_radioButton.AutoSize = true;
            this.score_radioButton.Location = new System.Drawing.Point(6, 60);
            this.score_radioButton.Name = "score_radioButton";
            this.score_radioButton.Size = new System.Drawing.Size(49, 16);
            this.score_radioButton.TabIndex = 1;
            this.score_radioButton.TabStop = true;
            this.score_radioButton.Text = "スコア";
            this.score_radioButton.UseVisualStyleBackColor = true;
            // 
            // level_radioButton
            // 
            this.level_radioButton.AutoSize = true;
            this.level_radioButton.Checked = true;
            this.level_radioButton.Location = new System.Drawing.Point(6, 18);
            this.level_radioButton.Name = "level_radioButton";
            this.level_radioButton.Size = new System.Drawing.Size(52, 16);
            this.level_radioButton.TabIndex = 0;
            this.level_radioButton.TabStop = true;
            this.level_radioButton.Text = "レベル";
            this.level_radioButton.UseVisualStyleBackColor = true;
            this.level_radioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // level_comboBox
            // 
            this.level_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level_comboBox.FormattingEnabled = true;
            this.level_comboBox.Location = new System.Drawing.Point(367, 100);
            this.level_comboBox.Name = "level_comboBox";
            this.level_comboBox.Size = new System.Drawing.Size(100, 20);
            this.level_comboBox.TabIndex = 20;
            // 
            // result_label
            // 
            this.result_label.AutoSize = true;
            this.result_label.Location = new System.Drawing.Point(30, 264);
            this.result_label.Name = "result_label";
            this.result_label.Size = new System.Drawing.Size(0, 12);
            this.result_label.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.well_radioButton);
            this.groupBox2.Controls.Add(this.best_radioButton);
            this.groupBox2.Location = new System.Drawing.Point(305, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 29);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // well_radioButton
            // 
            this.well_radioButton.AutoSize = true;
            this.well_radioButton.Location = new System.Drawing.Point(76, 7);
            this.well_radioButton.Name = "well_radioButton";
            this.well_radioButton.Size = new System.Drawing.Size(70, 16);
            this.well_radioButton.TabIndex = 1;
            this.well_radioButton.TabStop = true;
            this.well_radioButton.Text = "周辺含み";
            this.well_radioButton.UseVisualStyleBackColor = true;
            // 
            // best_radioButton
            // 
            this.best_radioButton.AutoSize = true;
            this.best_radioButton.Checked = true;
            this.best_radioButton.Location = new System.Drawing.Point(6, 7);
            this.best_radioButton.Name = "best_radioButton";
            this.best_radioButton.Size = new System.Drawing.Size(50, 16);
            this.best_radioButton.TabIndex = 0;
            this.best_radioButton.TabStop = true;
            this.best_radioButton.Text = "ベスト";
            this.best_radioButton.UseVisualStyleBackColor = true;
            // 
            // protein_dataGridView
            // 
            this.protein_dataGridView.AllowUserToAddRows = false;
            this.protein_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.protein_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.protein_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.protein_id,
            this.protein_name,
            this.delete});
            this.protein_dataGridView.Location = new System.Drawing.Point(30, 117);
            this.protein_dataGridView.Name = "protein_dataGridView";
            this.protein_dataGridView.ReadOnly = true;
            this.protein_dataGridView.RowTemplate.Height = 21;
            this.protein_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.protein_dataGridView.Size = new System.Drawing.Size(248, 132);
            this.protein_dataGridView.TabIndex = 23;
            // 
            // protein_id
            // 
            this.protein_id.HeaderText = "ID";
            this.protein_id.Name = "protein_id";
            this.protein_id.ReadOnly = true;
            this.protein_id.Width = 41;
            // 
            // protein_name
            // 
            this.protein_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.protein_name.HeaderText = "タンパク質名";
            this.protein_name.Name = "protein_name";
            this.protein_name.ReadOnly = true;
            this.protein_name.Width = 89;
            // 
            // delete
            // 
            this.delete.HeaderText = "削除";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "削除";
            this.delete.Width = 35;
            // 
            // motif_dataGridView
            // 
            this.motif_dataGridView.AllowUserToAddRows = false;
            this.motif_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.motif_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.motif_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.motif_id,
            this.motif_name});
            this.motif_dataGridView.Location = new System.Drawing.Point(484, 117);
            this.motif_dataGridView.Name = "motif_dataGridView";
            this.motif_dataGridView.ReadOnly = true;
            this.motif_dataGridView.RowTemplate.Height = 21;
            this.motif_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.motif_dataGridView.Size = new System.Drawing.Size(255, 132);
            this.motif_dataGridView.TabIndex = 24;
            // 
            // motif_id
            // 
            this.motif_id.HeaderText = "ID";
            this.motif_id.Name = "motif_id";
            this.motif_id.ReadOnly = true;
            this.motif_id.Width = 41;
            // 
            // motif_name
            // 
            this.motif_name.HeaderText = "モチーフ名";
            this.motif_name.Name = "motif_name";
            this.motif_name.ReadOnly = true;
            this.motif_name.Width = 78;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 520);
            this.Controls.Add(this.motif_dataGridView);
            this.Controls.Add(this.protein_dataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.result_label);
            this.Controls.Add(this.level_comboBox);
            this.Controls.Add(this.Score_textbox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_List_motif);
            this.Controls.Add(this.listBox_motif);
            this.Controls.Add(this.button_List_protein);
            this.Controls.Add(this.listBox_protein);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.serche);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_motif);
            this.Controls.Add(this.text_motif);
            this.Controls.Add(this.label_motif);
            this.Controls.Add(this.textbox_protein);
            this.Controls.Add(this.label_protein);
            this.Controls.Add(this.botten_protein);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.protein_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motif_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botten_protein;
        private System.Windows.Forms.Label label_protein;
        private System.Windows.Forms.TextBox textbox_protein;
        private System.Windows.Forms.Label label_motif;
        private System.Windows.Forms.TextBox text_motif;
        private System.Windows.Forms.Button button_motif;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_protein;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button serche;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.ListBox listBox_protein;
        private System.Windows.Forms.Button button_List_protein;
        private System.Windows.Forms.ListBox listBox_motif;
        private System.Windows.Forms.Button button_List_motif;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox Score_textbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton level_radioButton;
        private System.Windows.Forms.RadioButton score_radioButton;
        private System.Windows.Forms.ComboBox level_comboBox;
        private System.Windows.Forms.Label result_label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton well_radioButton;
        private System.Windows.Forms.RadioButton best_radioButton;
        private System.Windows.Forms.DataGridView protein_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn protein_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn protein_name;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridView motif_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn motif_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn motif_name;
    }
}

