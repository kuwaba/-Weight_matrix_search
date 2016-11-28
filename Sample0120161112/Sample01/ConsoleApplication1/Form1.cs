using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Score_exam
{
    public partial class Form1 : Form
    {
        Main main;
        public Form1()
        {
            InitializeComponent();
            main = new Main();
        }

        private void pa_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog2.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string l_protein = "";
                
                for (int i = 0; i < openFileDialog2.FileNames.Length; i++)
                {
                    //textBox1.Text += openFileDialog1.FileNames[i] + "\r\n";
                    Label buflabel = new Label();
                    buflabel.Text = openFileDialog2.FileNames[i];
                   
                    l_protein = l_protein + openFileDialog2.FileNames[i];


                }
                pares_textBox.Text = l_protein;
                main.pa_filename = l_protein;
                //
            }
        }

        private void ma_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string l_protein = "";

                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    //textBox1.Text += openFileDialog1.FileNames[i] + "\r\n";
                    Label buflabel = new Label();
                    buflabel.Text = openFileDialog1.FileNames[i];

                    l_protein = l_protein + openFileDialog1.FileNames[i];


                }
                mares_textBox.Text = l_protein;
                main.ma_filename = l_protein;
                //
            }
        }

        private void result_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string l_protein = "";

                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    //textBox1.Text += openFileDialog1.FileNames[i] + "\r\n";
                    Label buflabel = new Label();
                    buflabel.Text = openFileDialog1.FileNames[i];

                    l_protein = l_protein + openFileDialog1.FileNames[i];


                }
                result_textBox.Text = l_protein;
                main.result_filename　= l_protein;
                //
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            main.ex_score();
        }
    }
}
