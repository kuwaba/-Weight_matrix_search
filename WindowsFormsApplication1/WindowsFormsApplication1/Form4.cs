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
    public partial class Form4 : Form
    {
        int all=0;
        int part;
        public Form4()
        {
            InitializeComponent();
        }
        internal void Init(int in_all)
        {
            all = in_all;
            progressBar1.Value = 0;
            label_all.Text = all.ToString();
            label_all.Update();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = all;
            progressBar1.Value = 0;
        }
        internal void update(int in_part)
        {
            progressBar1.Value = in_part;
            part = in_part;
            label_part.Text = part.ToString() + "/";
            label_part.Update();
        }
    }
}
