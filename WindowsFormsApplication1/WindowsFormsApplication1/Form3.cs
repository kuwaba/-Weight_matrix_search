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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        internal void Init(string title, Dictionary<string, Dictionary<int, Score>> select_score)
        {
            motif_title.Text = title;
            string[] Keys = select_score.Keys.ToArray();
            foreach (string key in Keys)
            {
                foreach (KeyValuePair<int, Score> s in select_score[key])
                {
                    dataGridView1.Rows.Add(key, s.Value.score, s.Value.score_str);
                }
            }
            
        }
    }
}
