using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{
    class Motif
    {

        public StringBuilder title = new StringBuilder();
        public StringBuilder ac = new StringBuilder();
        //StringBuilder match = new StringBuilder();
        //StringBuilder insert = new StringBuilder();
        StringBuilder fasta_title = new StringBuilder();
        //List<List<int>> matcha = new List<List<int>>();
        //List<List<int>> inserta = new List<List<int>>();
        Dictionary<int, double> R1 = new Dictionary<int, double>();
        Dictionary<int, double> R2 = new Dictionary<int, double>();
        Dictionary<int, double> R3 = new Dictionary<int, double>();
        Dictionary<int, double> R4 = new Dictionary<int, double>();
        Dictionary<int, double> R5 = new Dictionary<int, double>();
        public int length = 0;
        public List<Dictionary<string, int>> score_M = new List<Dictionary<string, int>>();
        public Dictionary<int, Dictionary<string, int>> score_I = new Dictionary<int, Dictionary<string, int>>();
        public StringBuilder alphabet = new StringBuilder();
        public Dictionary<int, int> cutoff = new Dictionary<int, int>();
        public Dictionary<int, int> cutoff_mode = new Dictionary<int, int>();
        public Dictionary<int, double> cutoff_n_score = new Dictionary<int, double>();
        public Dictionary<int,string> function = new Dictionary<int, string>();
        public int max_cutoff_level = -1;
        public int low_cutoff_level = 10;
        public int max_cutoff;
        public int max_score = 0;
        public int max_mode=-1;
        //public Dictionary<int, int> cutoff_score_list = new Dictionary<int, int>();
        //public Dictionary<int, int> max_score_list = new Dictionary<int, int>();
        public Dictionary<string, int> default_score_I = new Dictionary<string, int>(){
            {"B0",0},
            {"B1",0},
            {"E0",0},
            {"E1",0},
            {"BM",0},
            {"BD",0},
            {"MM",0},
            {"ME",0},
            {"II",0},
            {"DD",0},
            {"I",0},
            {"I0",0},
            {"DELETE",0},
            {"INSERT",0}
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
                        ac.Append(line.Substring(5, line.Length-6));
                    }
                    else if (line.IndexOf("/M:") != -1)
                    {
                        //Console.WriteLine(line);
                        string[] buf;
                        List<int> bufl = new List<int>();
                        Dictionary<string, int> score_M_buf = new Dictionary<string, int>();

                        if (line.Length > 9)
                        {
                            //match.Append(line.Substring(9, line.Length - 9) + "\n");
                            buf = line.Substring(9, line.Length - 9).Split(';');
                            //score_M_buf["M0"] = 0;
                            if (default_score_I.ContainsKey("DELETE"))
                            {
                                score_M_buf["DELETE"] = default_score_I["DELETE"];
                            }
                            else
                            {
                                score_M_buf["DELETE"] = 0;
                            }

                            if (default_score_I.ContainsKey("M0"))
                            {
                                score_M_buf["M0"] = default_score_I["M0"];
                            }else
                            {
                                score_M_buf["M0"] = 0;
                            }

                            for (int i = 0; i < buf.Length - 1; i++)
                            {
                                string[] b = buf[i].Split('=');
                                if (b[0].Trim().Equals("M"))
                                {
                                    

                                    string[] ms = b[1].Split(',');
                                    for (int j = 0; j < alphabet.Length; j++)
                                    {
                                        if (ms[j].ToString() == "*") { ms[j] = "-10000"; }
                                        score_M_buf[alphabet[j].ToString()] = Int32.Parse(ms[j]);
                                        bufl.Add(Int32.Parse(ms[j]));
                                    }
                                }
                                else if (b[0].Trim().Equals("M0"))
                                {
                                    score_M_buf["M0"] = Int32.Parse(b[1]);
                                }
                                else if (b[0].Trim().Equals("D"))
                                {
                                    score_M_buf["DELETE"] = Int32.Parse(b[1]);
                                }
                            }

                        }
                        else
                        {
                            if (default_score_I.ContainsKey("DELETE"))
                            {
                                score_M_buf["DELETE"] = default_score_I["DELETE"];
                            }
                            else
                            {
                                score_M_buf["DELETE"] = 0;
                            }

                            if (default_score_I.ContainsKey("M0"))
                            {
                                score_M_buf["M0"] = default_score_I["M0"];
                            }
                            else
                            {
                                score_M_buf["M0"] = 0;
                            }
                            for (int a = alphabet.Length; a < alphabet.Length; a++)
                            {
                                score_M_buf[alphabet[a].ToString()] = 0;

                            }
                            bufl.Add(0);

                        }
                        if (bufl.Count == 0)
                        {
                            bufl.Add(0);
                        }
                        max_score += bufl.Max();
                        //max_score_list[length-1 - lnum] = bufl.Max();
                        //max_score_list[lnum] = bufl.Max();
                        //Console.Write(max_score + " ");
                        //matcha.Add(bufl);
                        score_M.Add(score_M_buf);
                        lnum++;
                    }
                    else if (line.IndexOf("/I:") != -1)
                    {

                        //insert.Append(line.Substring(9, line.Length - 9) + "\n");
                        string[] buf = line.Substring(9, line.Length - 9).Split(';');
                        List<int> bufl = new List<int>();
                        Dictionary<string, int> dic = new Dictionary<string, int>(default_score_I);
                        for (int i = 0; i < buf.Length - 1; i++)
                        {
                            //Console.Write(buf[i]);
                            string[] b = buf[i].Split('=');
                            if (!b[1].Equals("*"))
                            {
                                if (!(b[0].Trim().Equals("I")))
                                {
                                    dic[b[0].Trim()] = Int32.Parse(b[1]);
                                }
                                else
                                {
                                    string[] al_score = b[1].Split(',');
                                    if (al_score.Length == 1)
                                    {
                                        dic["INSERT"] = Int32.Parse(al_score[0]);
                                    }
                                    else
                                    {
                                        for (int al_score_i = 0; al_score_i < al_score.Length; al_score_i++)
                                        {
                                            dic[alphabet[al_score_i].ToString().ToLower()] = Int32.Parse(al_score[al_score_i]);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dic.Remove(b[0].Trim());
                            }

                        }
                        //sConsole.Write(lnum);
                        score_I[lnum] = dic;


                    }
                    else if (line.IndexOf("/GENERAL") != -1)
                    {
                        alphabet.Append(line.Substring(line.IndexOf("ALPHABET") + 10, line.IndexOf(";", line.IndexOf("ALPHABET")) - 1 - (line.IndexOf("ALPHABET") + 10)));

                        length = Int32.Parse(line.Substring(line.IndexOf("LENGTH") + 7, line.IndexOf(";", line.IndexOf("LENGTH")) - (line.IndexOf("LENGTH") + 7)));
                        //cutoff_score_list[length] = 0;
                    }
                    else if (line.IndexOf("/NORMALIZATION:") != -1)
                    {
                        int mode = Int32.Parse(line.Substring(line.IndexOf("MODE") + 5, line.IndexOf(";", line.IndexOf("MODE")) - (line.IndexOf("MODE") + 5)));
                        if (max_mode == -1) { max_mode = mode; }
                        function[mode] = line.Substring(line.IndexOf("FUNCTION") + 9, line.IndexOf(";", line.IndexOf("FUNCTION")) - (line.IndexOf("FUNCTION") + 9));
                        R1[mode] = double.Parse(line.Substring(line.IndexOf("R1") + 3, line.IndexOf(";", line.IndexOf("R1")) - (line.IndexOf("R1") + 3)));
                        R2[mode] = double.Parse(line.Substring(line.IndexOf("R2") + 3, line.IndexOf(";", line.IndexOf("R2")) - (line.IndexOf("R2") + 3)));
                        if (function.Equals("GLE_ZSCORE"))
                        {
                            R3[mode]=double.Parse(line.Substring(line.IndexOf("R3") + 3, line.IndexOf(";", line.IndexOf("R3")) - (line.IndexOf("R3") + 3)));
                            R4[mode] = double.Parse(line.Substring(line.IndexOf("R4") + 3, line.IndexOf(";", line.IndexOf("R4")) - (line.IndexOf("R4") + 3)));
                            R5[mode] = double.Parse(line.Substring(line.IndexOf("R5") + 3, line.IndexOf(";", line.IndexOf("R5")) - (line.IndexOf("R5") + 3)));
                        }



                    }
                    else if (line.IndexOf("/CUT_OFF:") != -1)
                    {
                        int level =   Int32.Parse(line.Substring(line.IndexOf("LEVEL") + 6, line.IndexOf(";", line.IndexOf("LEVEL")) - (line.IndexOf("LEVEL") + 6)));
                        int score =   Int32.Parse(line.Substring(line.IndexOf("SCORE") + 6, line.IndexOf(";", line.IndexOf("SCORE")) - (line.IndexOf("SCORE") + 6)));
                        int mode =    Int32.Parse(line.Substring(line.IndexOf("MODE") + 5, line.IndexOf(";", line.IndexOf("MODE")) - (line.IndexOf("MODE") + 5)));
                        double n_score = Double.Parse(line.Substring(line.IndexOf("N_SCORE") + 8, line.IndexOf(";", line.IndexOf("N_SCORE")) - (line.IndexOf("N_SCORE") + 8)));
                        cutoff[level] = score;
                        cutoff_mode[level] = mode;
                        cutoff_n_score[level] = n_score;
                        if (level > max_cutoff_level)
                        {
                            max_cutoff = score;
                            max_cutoff_level = level;
                            max_mode = mode;
                        }
                        if (level < low_cutoff_level)
                        {                            
                            low_cutoff_level = level;                            
                        }
                    }
                    else if (line.IndexOf("/DEFAULT:") != -1)
                    {
                        String score_line = line.Substring(15, line.Length - 15);
                        string[] buf = score_line.Split(';');
                        for (int i = 0; i < buf.Length - 1; i++)
                        {
                            string[] b = buf[i].Split('=');
                            int tmp=0;
                            if (!b[1].Trim().Equals("*") && Int32.TryParse(b[1].Trim(),out tmp))
                            {
                                if (!(b[0].Trim().Equals("I")) && !(b[0].Trim().Equals("D")))
                                {
                                    //Console.WriteLine(line);
                                    //Console.Write(b[0] +" "+b[1]);
                                    default_score_I[b[0].Trim()] = Int32.Parse(b[1].Trim());
                                }
                                else if(b[0].Trim().Equals("I"))
                                {
                                    string[] al_score = b[1].Trim().Split(',');
                                    if (al_score.Length == 1)
                                    {
                                        default_score_I["INSERT"] = Int32.Parse(al_score[0]);
                                    }
                                    else
                                    {
                                        for (int al_score_i = 0; al_score_i < al_score.Length; al_score_i++)
                                        {
                                            default_score_I[alphabet[al_score_i].ToString().ToLower()] = Int32.Parse(al_score[al_score_i]);
                                        }
                                    }
                                }else if (b[0].Trim().Equals("D"))
                                {
                                    default_score_I["DELETE"] = Int32.Parse(b[1].Trim());
                                }
                            }
                            else
                            {
                                default_score_I.Remove(b[0].Trim());
                            }


                        }
                    }

                }

            }

            //cutoff_score_list[0] = max_cutoff - max_score;
            //cutoff_score_list[0] = max_score;
            //Console.WriteLine("0" + " " + cutoff_score_list[0]);
            for (int i = 1; i < length; i++)
            {
                //cutoff_score_list[i] = cutoff_score_list[i - 1] - max_score_list[i - 1];
                //Console.WriteLine(i + " " + cutoff_score_list[i]);
            }





        }

        public Dictionary<int, Score> ExamScore(string fasta)
        {
            List<int> score = new List<int>();
            List<StringBuilder> score_str = new List<StringBuilder>();
            Dictionary<int, Score> score_list = new Dictionary<int, Score>();

            //Console.Write(i + "文字目開始");
            //foreach(int k in score_I.Keys)
            //{
            //    Console.Write(k + ",");
            //}
            int max_s = max_cutoff;
            Score_ex m_score = new Score_ex( this, fasta);
            m_score.exam_score();

            for (int index = 0; index < fasta.Length; index++)
            {
                //if (max_cutoff < m_score.start_score_list[index])
                //{
                    score_list[index + 1] = new Score(m_score.start_score_list[index], m_score.start_string_list[index] );
                    score_list[index + 1].start = index + 1;
                    score_list[index + 1].endset();
                    //if (function[max_mode].Equals("LINEAR"))
                    //{
                    //    //m_score.N_score = R1 + (R2 * m_score.start_score_list[index]);
                    //    score_list[index + 1].N_score = R1[max_mode] + (R2[max_mode] * m_score.start_score_list[index]);
                    //}
                    //else if (function[max_mode].Equals("GLE_ZSCORE"))
                    //{
                    //    //m_score.N_score = (m_score.start_score_list[index] / (R1 * (1.0 - Math.Exp(R2 * m_score.start_string_list[index].Length - R3))) - R4) / R5;
                    //    score_list[index + 1].N_score = (m_score.start_score_list[index] / (R1[max_mode] * (1.0 - Math.Exp(R2[max_mode] * m_score.start_string_list[index].Length - R3[max_mode]))) - R4[max_mode]) / R5[max_mode]; 
                    //}
                    //score_list[index + 1] = new Score(m_score.start_score_list[index], new StringBuilder( m_score.start_string_list[index]), 0, new char(), this, fasta.Substring(index), 0, m_score.start_score_list[index]);
                    //score_list[i + 1] = m_score;
                //}
            }





            return score_list;
        }

        public double exam_Nscore(int level,Score s)
        {
            double N_score=0;
            int mode = cutoff_mode[level];
            if (function[mode].Equals("LINEAR"))
            {
                //m_score.N_score = R1 + (R2 * m_score.start_score_list[index]);
                N_score = (double)R1[mode] + ((double)R2[mode] * (double)s.score);
                
            }
            else if (function[mode].Equals("GLE_ZSCORE"))
            {
                //m_score.N_score = (m_score.start_score_list[index] / (R1 * (1.0 - Math.Exp(R2 * m_score.start_string_list[index].Length - R3))) - R4) / R5;
                N_score = (s.score / (R1[mode] * (1.0 - Math.Exp(R2[mode] * (s.end - s.start + 1) - R3[mode]))) - R4[mode]) / R5[mode];
            }
            //score_list[index + 1] = new Score(m_score.start_score_list[index], new StringBuilder( m_score.start_string_list[index]), 0, new char(), this, fasta.Substring(index), 0, m_score.start_score_list[index]);
            //score_list[i + 1] = m_score;
            return N_score;

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
