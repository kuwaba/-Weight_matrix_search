using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        Entry entry;
        public Form2()
        {
            InitializeComponent();
        }
        public void Set_protein_title(string title)
        {
            protein_title.Text = title;
        }
        internal void Init(string title,Entry sel_entry, Dictionary<string, Dictionary<int, Score>> select_score)
        {
            protein_title.Text = title;
            entry = sel_entry;
            richTextBox_protein.Text = sel_entry.main.ToString();
            List<string> score_list = new List<string>(); 
            for(int i = 0; i < sel_entry.main.Length; i++)
            {
                foreach(KeyValuePair<string,Dictionary<int,Score>> score in select_score)
                {
                    if (score.Value.ContainsKey(i))
                    {
                        string buf = score.Value[i].start + "-" + score.Value[i].end + ";\t"+score.Key + "\tスコア:" + score.Value[i].score + "; Nスコア" + score.Value[i].N_score + "; 文字列" + score.Value[i].score_str;
                        score_list.Add(buf);
                    }
                }
            }
            listBox_score.Items.AddRange(score_list.ToArray());
        }

        private void listBox_score_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox_protein.Select(0, entry.main.Length);
            richTextBox_protein.SelectionBackColor = Color.Transparent;
            string score_s = listBox_score.Text;
            string[] start_end = score_s.Split(';')[0].Split('-');
            richTextBox_protein.Select(Int32.Parse(start_end[0])-1, Int32.Parse(start_end[1])- Int32.Parse(start_end[0]));
            richTextBox_protein.SelectionBackColor = Color.Yellow; // 色を設定
        }
    }
}
