using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motiflength
{
    class Motif
    {

        public StringBuilder title = new StringBuilder();
        public StringBuilder ac = new StringBuilder();
        StringBuilder match = new StringBuilder();
        StringBuilder insert = new StringBuilder();
        StringBuilder fasta_title = new StringBuilder();
        List<List<int>> matcha = new List<List<int>>();
        List<List<int>> inserta = new List<List<int>>();
        double R1;
        double R2;
        double R3;
        double R4;
        double R5;
        public int length = 0;
        public List<Dictionary<string, int>> score_M  = new List<Dictionary<string, int>>();
        public Dictionary<int, Dictionary<string, int>> score_I = new Dictionary<int, Dictionary<string, int>>();
        public StringBuilder alphabet = new StringBuilder();
        Dictionary<int, int> cutoff = new Dictionary<int, int>();
        string function;
        public int max_cutoff_level = -1;
        public int max_cutoff;
        public int max_score = 0;
        public Dictionary<int,int> cutoff_score_list = new Dictionary<int, int>();
        public Dictionary<int, int> max_score_list = new Dictionary<int, int>();
        public Dictionary<string, int> default_score_I= new Dictionary<string, int>(){
            {"B0",0},
            {"B1",0},
            {"E0",0},
            {"E1",0},
            {"BM",0},
            //{"BD",0},
            {"MM",0},
            {"ME",0},
            {"II",0},
            {"DD",0},
            {"I",0},
            {"I0",0},
            {"D",0}
       };



        public Motif(String filename)
        {
            //using (StreamReader r = new StreamReader(filename))
            using (StringReader r = new StringReader(filename))
            {
                string line;
                int lnum = 0;

                while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                {
                    if ((line.IndexOf("ID") == 0))
                    {
                        title.Append(line.Substring(5));
                    }
                    else if ((line.IndexOf("AC") == 0))
                    {
                        ac.Append(line.Substring(5));
                    }
                    //else if (line.IndexOf("/M:") != -1)
                    //{
                    //    match.Append(line.Substring(9, line.Length - 9) + "\n");
                    //    string[] buf = line.Substring(9, line.Length - 9).Split(';');
                    //    List<int> bufl = new List<int>();
                    //    Dictionary<string, int> score_M_buf = new Dictionary<string, int>();
                    //    score_M_buf["M0"] = 0;
                    //    score_M_buf["DELETE"] = 0;
                    //    for (int i = 0; i < buf.Length - 1; i++)
                    //    {
                    //        string[] b = buf[i].Split('=');
                    //        if (b[0].Trim().Equals("M"))
                    //        {
                    //            string[] ms = b[1].Split(',');
                    //            for (int j = 0; j < alphabet.Length; j++)
                    //            {
                    //                score_M_buf[alphabet[j].ToString()] = Int32.Parse(ms[j]);
                    //                bufl.Add(Int32.Parse(ms[j]));
                    //            }
                    //        }
                    //        else if (b[0].Trim().Equals("M0"))
                    //        {
                    //            score_M_buf["M0"] = Int32.Parse(b[1]);
                    //        }
                    //        else if (b[0].Trim().Equals("D"))
                    //        {
                    //            score_M_buf["DELETE"] = Int32.Parse(b[1]);
                    //        }
                    //    }
                    //    max_score += bufl.Max();
                    //    //max_score_list[length-1 - lnum] = bufl.Max();
                    //    max_score_list[lnum] = bufl.Max();
                    //    //Console.Write(max_score + " ");
                    //    matcha.Add(bufl);
                    //    score_M.Add(score_M_buf);
                    //    lnum++;
                    //}
                    //else if (line.IndexOf("/I:") != -1)
                    //{

                    //    insert.Append(line.Substring(9, line.Length - 9) + "\n");
                    //    string[] buf = line.Substring(9, line.Length - 9).Split(';');
                    //    List<int> bufl = new List<int>();
                    //    Dictionary<string, int> dic = new Dictionary<string, int>(default_score_I);
                    //    for (int i = 0; i < buf.Length - 1; i++)
                    //    {
                    //        //Console.Write(buf[i]);
                    //        string[] b = buf[i].Split('=');
                    //        if (!b[1].Equals("*"))
                    //        {
                    //            if (!(b[0].Trim().Equals("I")))
                    //            {
                    //                dic[b[0].Trim()] = Int32.Parse(b[1]);
                    //            }
                    //            else
                    //            {
                    //                string[] al_score = b[1].Split(',');
                    //                for (int al_score_i = 0; al_score_i < al_score.Length; al_score_i++)
                    //                {
                    //                    dic[alphabet[al_score_i].ToString().ToLower()] = Int32.Parse(al_score[al_score_i]);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            dic.Remove(b[0].Trim());
                    //        }

                    //    }
                    //    //sConsole.Write(lnum);
                    //    score_I[lnum] = dic;


                    //}
                    else if (line.IndexOf("/GENERAL") != -1)
                    {
                        alphabet.Append(line.Substring(line.IndexOf("ALPHABET") + 10, line.IndexOf(";", line.IndexOf("ALPHABET")) - 1 - (line.IndexOf("ALPHABET") + 10)));

                        length = Int32.Parse(line.Substring(line.IndexOf("LENGTH") + 7, line.IndexOf(";", line.IndexOf("LENGTH")) - (line.IndexOf("LENGTH") + 7)));
                        cutoff_score_list[length] = 0;
                    }
                    //else if (line.IndexOf("/NORMALIZATION:") != -1)
                    //{
                    //    function = line.Substring(line.IndexOf("FUNCTION") + 9, line.IndexOf(";", line.IndexOf("FUNCTION")) - (line.IndexOf("FUNCTION") + 9));
                    //    R1 = double.Parse(line.Substring(line.IndexOf("R1") + 3, line.IndexOf(";", line.IndexOf("R1")) - (line.IndexOf("R1") + 3)));
                    //    R2 = double.Parse(line.Substring(line.IndexOf("R2") + 3, line.IndexOf(";", line.IndexOf("R2")) - (line.IndexOf("R2") + 3)));
                    //    if (function.Equals("GLE_ZSCORE"))
                    //    {
                    //        R3 = double.Parse(line.Substring(line.IndexOf("R3") + 3, line.IndexOf(";", line.IndexOf("R3")) - (line.IndexOf("R3") + 3)));
                    //        R4 = double.Parse(line.Substring(line.IndexOf("R4") + 3, line.IndexOf(";", line.IndexOf("R4")) - (line.IndexOf("R4") + 3)));
                    //        R5 = double.Parse(line.Substring(line.IndexOf("R5") + 3, line.IndexOf(";", line.IndexOf("R5")) - (line.IndexOf("R5") + 3)));
                    //    }



                    //}
                    //else if (line.IndexOf("/CUT_OFF:") != -1)
                    //{
                    //    int level = Int32.Parse(line.Substring(line.IndexOf("LEVEL") + 6, line.IndexOf(";", line.IndexOf("LEVEL")) - (line.IndexOf("LEVEL") + 6)));
                    //    int score = Int32.Parse(line.Substring(line.IndexOf("SCORE") + 6, line.IndexOf(";", line.IndexOf("SCORE")) - (line.IndexOf("SCORE") + 6)));

                    //    cutoff[level] = score;
                    //    if (level > max_cutoff_level)
                    //    {
                    //        max_cutoff = score;
                    //        max_cutoff_level = level;
                    //    }
                    //}
                    //else if (line.IndexOf("/DEFAULT:") != -1)
                    //{
                    //    String score_line = line.Substring(15, line.Length - 15);
                    //    string[] buf = score_line.Split(';');
                    //    for (int i = 0; i < buf.Length - 1; i++)
                    //    {
                    //        string[] b = buf[i].Split('=');
                    //        if (!b[1].Equals("*"))
                    //        {
                    //            default_score_I[b[0].Trim()] = Int32.Parse(b[1]);
                    //        }
                    //        else
                    //        {
                    //            default_score_I.Remove(b[0].Trim());
                    //        }

                    //    }
                    //}

                }

            }

            //cutoff_score_list[0] = max_cutoff - max_score;
            //cutoff_score_list[0] =  max_score;
            ////Console.WriteLine("0" + " " + cutoff_score_list[0]);
            //for (int i = 1; i < length; i++)
            //{
            //    cutoff_score_list[i] = cutoff_score_list[i - 1] - max_score_list[i - 1];
            //    //Console.WriteLine(i + " " + cutoff_score_list[i]);
            //}





        }

        public Dictionary<int, Score> ExamScore(string fasta)
        {
            List<int> score = new List<int>();
            List<StringBuilder> score_str = new List<StringBuilder>();
            Dictionary<int, Score> score_list = new Dictionary<int, Score>();
            //for (int i = 0; i < (fasta.Length - length); i++)
            //for (int i = 38; i < 39; i++)
            for (int i = 0; i < (fasta.Length); i++)
            {
                //int buf = 0;
                //char status = 'B';
                //Console.Write(i + "文字目開始");
                Score score_buf = new Score(0, new StringBuilder(), 0, 'B', this, fasta.Substring(i), 0, max_cutoff);
                //score_list.Add(score_buf.exam_score());
                
                int max_s = max_cutoff;
                int max_i = -1;
                Score m_score = new Score(0, new StringBuilder(), 0, new char(), this, fasta.Substring(i), 0, max_cutoff);
                m_score.exam_scrore();
                //foreach (Score s_b in score_buf.exam_score())
                //{
                //    if (max_s < s_b.score)
                //    {
                //        max_s = s_b.score;
                //        max_i = i;
                //        m_score = new Score(s_b.score, s_b.score_str, 0, 'B', this, fasta.Substring(i), 0, 0);
                //        if (function.Equals("LINEAR"))
                //        {
                //            m_score.N_score = R1 + (R2 * m_score.score);
                //        }
                //        else if (function.Equals("GLE_ZSCORE"))
                //        {
                //            m_score.N_score = (m_score.score / (R1 * (1.0 - Math.Exp(R2 * m_score.score_str.Length - R3))) - R4) / R5;
                //        }


                //    }
                //}
                //if (max_i != -1)
                //{
                //    score_list[i + 1] = m_score;
                //}
                if (max_cutoff < m_score.well_score)
                {
                    if (function.Equals("LINEAR"))
                    {
                        m_score.N_score = R1 + (R2 * m_score.well_score);
                    }
                    else if (function.Equals("GLE_ZSCORE"))
                    {
                        m_score.N_score = (m_score.well_score / (R1 * (1.0 - Math.Exp(R2 * m_score.well_score_str.Length - R3))) - R4) / R5;
                    }
                    //score_list[i + 1] = new Score(m_score.well_score, m_score.well_score_str, 0, new char(), this, fasta.Substring(i), 0, 0);
                    score_list[i + 1] = m_score;
                }


            }

       
            return score_list;
        }

        public int get_length()
        {
            return length;
        }

        static List<KeyValuePair<string, int>>
        sortByValue(Dictionary<string, int> dict)
        {
            List<KeyValuePair<string, int>> list
              = new List<KeyValuePair<string, int>>(dict);

            // Valueの大きい順にソート
            list.Sort(
              delegate (KeyValuePair<string, int> kvp1, KeyValuePair<string, int> kvp2)
              {
                  return kvp2.Value - kvp1.Value;
              });
            return list;
        }

    }
}
