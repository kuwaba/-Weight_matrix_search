using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score_exam
{
    class Score
    {
        public int score;
        public string score_str;
        public double N_score;
        public int start;
        public int end;
        public int over_level = -100;
        public bool overlap = false;

        public Score(int s, string s_str)
        {
            score = s;
            score_str = s_str;
        }
        public void endset()
        {
            end = start-1;
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

        static public Dictionary<string, SortedList<int ,Score>> read_maresult(string filename)
        {
            Dictionary<string, SortedList<int, Score>> result = new Dictionary<string, SortedList<int, Score>>();

            using (StreamReader r = new StreamReader(filename))
            {
                string line;
                string protein_name = "";
                while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                {
                    //Console.WriteLine(line);
                    if (line.IndexOf(">") == 0)
                    {
                        protein_name = line.TrimEnd();
                        result[protein_name] = new SortedList<int, Score>();
                        //Console.Write(line);
                    }else if(line.IndexOf("*") == 0)
                    {
                        Score buf_score = new Score(0, "");
                        string[] score_line = line.Split('\t');
                        if (score_line.Count() > 4)
                        {
                            string[] start_end = score_line[0].Split('-');
                            buf_score.start = Int32.Parse(start_end[0].Substring(1, start_end[0].Length - 1));
                            buf_score.end = Int32.Parse(start_end[1].Substring(0, start_end[1].Length));

                            buf_score.over_level = Int32.Parse(score_line[1].Split('=')[1]);

                            buf_score.score = Int32.Parse(score_line[2].Split('=')[1]);

                            buf_score.N_score = Double.Parse(score_line[3].Split('=')[1]);

                            buf_score.score_str = score_line[4].Split(' ')[1];

                            result[protein_name][buf_score.start] = buf_score;
                        }
                    }
                }
            }

            return result;
        }

        static public Dictionary<string, SortedList<int, Score>> read_paresult(string filename)
        {
            Dictionary<string, SortedList<int, Score>> result = new Dictionary<string, SortedList<int, Score>>();

            using (StreamReader r = new StreamReader(filename))
            {
                string line;
                string protein_name = "";
                while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                {
                    //Console.WriteLine(line);
                    if (line.IndexOf(">") == 0)
                    {
                        protein_name = line.TrimEnd();
                        result[protein_name] = new SortedList<int, Score>();
                        //Console.Write(line);
                    }
                    else if (line.IndexOf("{") == 0)
                    {
                        Score buf_score = new Score(0, "");
                        string[] score_line = line.Split(' ');

                        buf_score.start = Int32.Parse(score_line[3]);
                        buf_score.end = buf_score.start + Int32.Parse(score_line[5]);

                        buf_score.over_level = 0;

                        buf_score.score = 0;

                        buf_score.N_score = 0;

                        buf_score.score_str = score_line[1];

                        result[protein_name][buf_score.start] = buf_score;
                        buf_score.start = buf_score.start + 1;
                        //buf_score.end = buf_score.end;

                    }
                }
            }

            return result;
        }

    }
}
