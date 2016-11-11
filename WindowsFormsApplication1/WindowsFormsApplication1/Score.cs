using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Score
    {
        public int score;
        public string score_str;
        public double N_score;
        public int start;
        public int end;
        public int over_level = -100;

        public Score(int s, string s_str)
        {
            score = s;
            score_str = s_str;
        }
        public void endset()
        {
            end = start - 1;
            for (int i = 0; i < score_str.Length; i++)
            {
                if (score_str[i] != '-')
                {

                    end++;
                }
            }
        }
        static public Dictionary<int, Score> read_result(string filename)
        {
            Dictionary<int, Score> return_score = new Dictionary<int, Score>();
            using (StreamReader r = new StreamReader(filename))
            {
                string line;
                int lnum = 0;

                while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                {
                    //Console.WriteLine(line);
                    if (lnum != 0)
                    {
                        //Console.Write(line);
                        string[] sco = line.Split(',');
                        if (sco.Count() == 6)
                        {
                            return_score[Int32.Parse(sco[2])] = new Score(Int32.Parse(sco[4]), sco[5]);
                            return_score[Int32.Parse(sco[2])].start = Int32.Parse(sco[2]);
                            return_score[Int32.Parse(sco[2])].end = Int32.Parse(sco[3]);
                            //return_score[Int32.Parse(sco[2])].N_score = Double.Parse(sco[5]);
                        }
                    }
                    lnum++;
                }
            }
            return return_score;
        }
    }
}
