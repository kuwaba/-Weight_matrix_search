using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<LinkLabel> labellist_protein = new List<LinkLabel>();
        string[] fasta;
        string[] motif;
        IO io = new IO();
        Dictionary<string, Dictionary<string, Dictionary<int, Score>>> score;
        Dictionary<string, Dictionary<string, Dictionary<int, Score>>> res_score;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            io.get_result_protein();
            //checkedListBox_protein.Items.Clear();
            //checkedListBox_protein.Items.Add("all");
            //checkedListBox_protein.Items.AddRange(io.get_protein_titles());
            protein_dataGridView.Rows.Clear();
            List<DataGridViewRow> rows = new List<DataGridViewRow>(); 
            foreach (KeyValuePair<string,Entry> ent in io.entrys)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(protein_dataGridView);
                row.SetValues(ent.Value.id, ent.Value.title);
                //protein_dataGridView.Rows.Add(ent.Value.id, ent.Value.title);
                rows.Add(row);
            }
            protein_dataGridView.Rows.AddRange(rows.ToArray());
            io.get_result_motif();
            //checkedListBox_motif.Items.Clear();
            //checkedListBox_motif.Items.Add("all");
            //checkedListBox_motif.Items.AddRange(io.get_motif_titles());
            rows.Clear();
            foreach(KeyValuePair<string,Motif> mot in io.motifs)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(motif_dataGridView);
                row.SetValues(mot.Value.ac, mot.Value.title);
                //motif_dataGridView.Rows.Add(mot.Value.ac, mot.Value.title);
                rows.Add(row);
            }
            motif_dataGridView.Rows.AddRange(rows.ToArray());
            level_comboBox.Items.Clear();
            string[] levels = io.get_motif_level(io.get_motif_keys()).ToArray();
            foreach (string a in levels)
            {
                textBox1.AppendText(a + System.Environment.NewLine);
            }
            level_comboBox.Items.AddRange(levels);
            level_comboBox.SelectedIndex = 0;
            level_comboBox.Update();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botten_protein_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog_protein.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string l_protein = "";
                fasta = openFileDialog_protein.FileNames;
                for (int i = 0; i < openFileDialog_protein.FileNames.Length; i++)
                {
                    textBox1.Text += openFileDialog_protein.FileNames[i] + "\r\n";
                    Label buflabel = new Label();
                    buflabel.Text = openFileDialog_protein.FileNames[i];
                    ////checkedListBox_protein.Items.Add(openFileDialog_protein.FileNames[i]);
                    l_protein = l_protein + openFileDialog_protein.FileNames[i];


                }
                textbox_protein.Text = l_protein;
                io.read_fasta(openFileDialog_protein.FileNames);
                //checkedListBox_protein.Items.Clear();
                //checkedListBox_protein.Items.Add("all");
                //checkedListBox_protein.Items.AddRange(io.get_protein_titles());

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_motif_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog_protein.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string l_motif = "";
                motif = openFileDialog_protein.FileNames;
                for (int i = 0; i < openFileDialog_protein.FileNames.Length; i++)
                {
                    //textBox1.Text += openFileDialog_protein.FileNames[i] + "\r\n";
                    Label buflabel = new Label();
                    buflabel.Text = openFileDialog_protein.FileNames[i];
                    //checkedListBox_protein.Items.Add(openFileDialog_protein.FileNames[i]);
                    l_motif = l_motif + openFileDialog_protein.FileNames[i];


                }
                text_motif.Text = l_motif;
                io.read_motif(openFileDialog_protein.FileNames);
                //checkedListBox_motif.Items.Clear();
                //checkedListBox_motif.Items.Add("all");
                //checkedListBox_motif.Items.AddRange(io.get_motif_titles());

            }
        }

        private async void serche_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch alltime = System.Diagnostics.Stopwatch.StartNew();
            //if (checkedListBox_protein.CheckedItems.Count != 0 & checkedListBox_motif.CheckedItems.Count != 0)
            if(protein_dataGridView.SelectedRows.Count > 0 && motif_dataGridView.SelectedRows.Count > 0)
            {
                // If so, loop through all checked items and print results.
                //string[] select_protein;
                //if (!checkedListBox_protein.CheckedItems[0].ToString().Equals("all"))
                //{
                //    select_protein = new string[checkedListBox_protein.CheckedItems.Count];
                //    for (int x = 0; x <= checkedListBox_protein.CheckedItems.Count - 1; x++)
                //    {

                //        select_protein[x] = checkedListBox_protein.CheckedItems[x].ToString();

                //    }
                //}
                //else
                //{
                //    select_protein = new string[checkedListBox_protein.CheckedItems.Count - 1];
                //    for (int x = 0; x <= checkedListBox_protein.CheckedItems.Count - 2; x++)
                //    {

                //        select_protein[x] = checkedListBox_protein.CheckedItems[x + 1].ToString();

                //    }
                //}
                List<String> select_protein = new List<string>();
                StringBuilder sb = new StringBuilder();
                if(protein_dataGridView.SelectedRows.Count> 0)
                {
                    for(int i= protein_dataGridView.SelectedRows.Count-1; i >=0 ; i--)
                    {
                        select_protein.Add(protein_dataGridView.SelectedRows[i].Cells[0].Value.ToString());
                    }

                    //foreach (DataGridViewRow sele_pro in protein_dataGridView.SelectedRows)
                    //{
                    //    select_protein.Add(sele_pro.Cells[0].Value.ToString());
                    //    //sb.Append(sele_pro.Cells[0].Value.ToString() + "\n");
                    //}
                }
                //foreach(string sss in select_protein.ToArray())
                //{
                //    sb.Append(sss + ",");
                //}
                //MessageBox.Show(sb.ToString());



                // If so, loop through all checked items and print results.
                //string[] select_motif;
                //string[] select_motif_tmp;
                //if (!checkedListBox_motif.CheckedItems[0].ToString().Equals("all"))
                //{
                //    select_motif_tmp = new string[checkedListBox_motif.CheckedItems.Count];

                //    select_motif = new string[checkedListBox_motif.CheckedItems.Count];
                //    for (int x = 0; x <= checkedListBox_motif.CheckedItems.Count - 1; x++)
                //    {

                //        select_motif[x] = checkedListBox_motif.CheckedItems[x].ToString().Split(',')[0];

                //    }
                //}
                //else
                //{
                //    select_motif = new string[checkedListBox_motif.CheckedItems.Count - 1];
                //    for (int x = 0; x <= checkedListBox_motif.CheckedItems.Count - 2; x++)
                //    {

                //        select_motif[x] = checkedListBox_motif.CheckedItems[x + 1].ToString().Split(',')[0];

                //    }
                //}

                List<string> select_motif = new List<string>();
                if (motif_dataGridView.SelectedRows.Count > 0)
                {
                    for (int i = motif_dataGridView.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        select_motif.Add(motif_dataGridView.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    
                }

                // score = await Task.Run(() => io.exp_score(select_protein, select_motif));

                if (level_radioButton.Checked == true)
                {
                    int b;
                    if (level_comboBox.SelectedIndex >= 0)
                    {

                        score = await Task.Run(() => io.exp_score_level(select_protein.ToArray(), select_motif.ToArray(), Int32.Parse(level_comboBox.SelectedItem.ToString())));
                    }
                    else
                    {
                        MessageBox.Show("カットオフレベルが正しく設定されていません",    "エラー",    MessageBoxButtons.OK,    MessageBoxIcon.Error);
                        score = new Dictionary<string, Dictionary<string, Dictionary<int, Score>>>();
                    }
                }
                else if (score_radioButton.Checked == true)
                {
                    double buf;
                    if (double.TryParse(Score_textbox.Text, out buf))
                    {

                        score = await Task.Run(() => io.exp_score_score(select_protein.ToArray(), select_motif.ToArray(), double.Parse(Score_textbox.Text)));
                    }else
                    {
                        MessageBox.Show("閾値スコアが正しく設定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        score = new Dictionary<string, Dictionary<string, Dictionary<int, Score>>>();
                    }
                }

                StringBuilder s = new StringBuilder();
                //Form4 f4 = new Form4();
                int all = select_protein.ToArray().Length * select_motif.ToArray().Length;
                int part = 0;
                label_time.Text = all.ToString();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = all;
                progressBar1.Value = 0;
                //f4.Init(all);
                //f4.Show();
                Dictionary<string, int> motif_list = new Dictionary<string, int>();
                Dictionary<string, int> pro_list = new Dictionary<string, int>();
                int result_entry_motif = 0;
                int result_block = 0;
                res_score = new Dictionary<string, Dictionary<string, Dictionary<int, Score>>>();
                foreach (string protein in select_protein)
                {


                    foreach (string motif in select_motif)
                    {
                        if (score.ContainsKey(protein) && score[protein].ContainsKey(motif) && score[protein][motif].Count > 0)
                        {
                            if (!res_score.ContainsKey(protein))
                            {
                                res_score[protein] = new Dictionary<string, Dictionary<int, Score>>();
                            }
                            if (!res_score[protein].ContainsKey(motif))
                            {
                                res_score[protein][motif] = new Dictionary<int, Score>();
                            }

                                result_entry_motif++;
                            if (motif_list.ContainsKey(motif))
                            {
                                motif_list[motif] = motif_list[motif] + 1;
                            }
                            else
                            {
                                motif_list[motif] = 0;
                            }
                            pro_list[protein] = 0;
                            s.Append("エントリー名" + protein + "vs" + "モチーフタイトル" + motif + "AC=" + io.motifs[motif].ac.ToString() + System.Environment.NewLine);
                            int old_key = 0;
                            Dictionary<int, int> well = new Dictionary<int, int>();
                            int well_key = 0;
                            int well_score = 0;
                            Score wel = new Score(0, "");
                            foreach (KeyValuePair<int, Score> sc in score[protein][motif])
                            {
                                if (sc.Value.end != wel.end || old_key == 0)
                                {
                                    //Console.WriteLine();
                                    well[well_key] = well_score;
                                    well_score = sc.Value.score;
                                    well_key = sc.Key;
                                    wel = sc.Value;
                                }
                                old_key = sc.Key;
                                if (sc.Value.score > well_score)
                                {
                                    well_key = sc.Key;
                                    well_score = sc.Value.score;
                                    wel = sc.Value;
                                }


                            }
                            well[well_key] = well_score;
                            Score old = new Score(0, "");
                            foreach (KeyValuePair<int, Score> sc in score[protein][motif])
                            {
                                if (old.end != sc.Value.end && old_key != 0)
                                {
                                    //Console.WriteLine();
                                }
                                old_key = sc.Key;

                                //Console.WriteLine("開始位置=" + s.Key + "\tスコア=" + s.Value.score+ "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
                                if (well.ContainsKey(sc.Key))
                                {
                                    //Console.WriteLine(" 開始位置=" + s.Key + "\tスコア=" + s.Value.score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
                                    s.Append("*" + sc.Value.start + "-" + sc.Value.end + "\tスコア=" + sc.Value.score + "\tNスコア=" + sc.Value.N_score + "\t文字列 " + sc.Value.score_str + System.Environment.NewLine);
                                    res_score[protein][motif][sc.Key] = sc.Value;
                                    result_block++;
                                }
                                else if (!well.ContainsKey(sc.Key) && well_radioButton.Checked==true)
                                {
                                    //Console.WriteLine("\t開始位置=" + s.Key + "\tスコア=" + s.Value.score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
                                    s.Append(" " + sc.Value.start + "-" + sc.Value.end + "\tスコア=" + sc.Value.score + "\tNスコア=" + sc.Value.N_score + "\t文字列 " + sc.Value.score_str + System.Environment.NewLine);
                                    res_score[protein][motif][sc.Key] = sc.Value;
                                }




                            }
                            part++;
                            progressBar1.Value = part;
                            //f4.update(part);
                        }
                    }
                }
                textBox1.Text = s.ToString();
                alltime.Stop();
                label_time.Text = alltime.Elapsed.ToString();
                string[] box_protein = new string[pro_list.Keys.Count];
                pro_list.Keys.CopyTo(box_protein, 0);
                listBox_protein.Items.Clear();
                listBox_protein.Items.AddRange(box_protein);
                listBox_motif.Items.Clear();
                listBox_motif.Items.AddRange(motif_list.Keys.ToArray());
                result_label.Text = "エントリー数:" + pro_list.Keys.Count + " " + "モチーフ数:" + motif_list.Count + " " + "一致検索数:" + result_entry_motif +" "+ "モチーフ候補部位数:" + result_block;
            }
        }

        //private void checkedListBox_protein_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    String s = this.checkedListBox_protein.Items[e.Index] as string;
        //    if (s.Equals("all"))
        //    {
        //        textBox1.Text = e.NewValue.ToString();
        //        if (e.NewValue.ToString().Equals("Checked"))
        //        {
        //            for (int i = 1; i < checkedListBox_protein.Items.Count; i++)
        //            {
        //               //checkedListBox_protein.SetSelected(i, true);
        //                checkedListBox_protein.SetItemChecked(i, true);
        //            }

        //        }
        //        else if (e.NewValue.ToString().Equals("Unchecked"))
        //        {
        //            for (int i = 1; i < checkedListBox_protein.Items.Count; i++)
        //            {
        //                //checkedListBox_protein.SetSelected(i, true);
        //                checkedListBox_protein.SetItemChecked(i, false);
        //            }
        //        }
        //    }
        //}

        //private void checkedListBox_motif_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    String s = this.checkedListBox_motif.Items[e.Index] as string;
        //    if (s.Equals("all"))
        //    {
        //        textBox1.Text = e.NewValue.ToString();
        //        if (e.NewValue.ToString().Equals("Checked"))
        //        {
        //            for (int i = 1; i < checkedListBox_motif.Items.Count; i++)
        //            {
        //                //checkedListBox_motif.SetSelected(i, true);
        //                checkedListBox_motif.SetItemChecked(i, true);
        //            }

        //        }
        //        else if (e.NewValue.ToString().Equals("Unchecked"))
        //        {
        //            for (int i = 1; i < checkedListBox_motif.Items.Count; i++)
        //            {
        //                //checkedListBox_motif.SetSelected(i, true);
        //                checkedListBox_motif.SetItemChecked(i, false);
        //            }
        //        }
        //    }
        //}

        private void button_List_protein_Click(object sender, EventArgs e)
        {
            if (listBox_protein.SelectedIndex != -1)
            {
                string select_title = listBox_protein.Text;
                //Dictionary<string, Dictionary<int, Score>> select_score = score[select_title];
                Dictionary<string, Dictionary<int, Score>> select_score = res_score[select_title];
                Entry select_entry = io.entrys[select_title];
                Form2 f2 = new Form2();
                f2.Init(select_title, select_entry, select_score);
                f2.Show();
            }
        }

        private void button_List_motif_Click(object sender, EventArgs e)
        {
            if (listBox_motif.SelectedIndex != -1)
            {
                string select_title = listBox_motif.Text;
                Dictionary<string, Dictionary<int, Score>> select_score = new Dictionary<string, Dictionary<int, Score>>();
                //foreach (KeyValuePair<string, Dictionary<string, Dictionary<int, Score>>> s in score)
                foreach (KeyValuePair<string, Dictionary<string, Dictionary<int, Score>>> s in res_score)
                {

                    //if (s.Value[select_title].Count > 0)
                    if (s.Value.ContainsKey(select_title))
                    {
                        //MessageBox.Show(s.Value[select_title].Count.ToString());
                        select_score[s.Key] = s.Value[select_title];
                    }
                }
                Form3 f3 = new Form3();
                f3.Init(select_title, select_score);
                f3.Show();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox_motif_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
