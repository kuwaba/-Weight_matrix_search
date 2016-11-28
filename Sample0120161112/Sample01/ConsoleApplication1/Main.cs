using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Score_exam
{
    class Main
    {
        //StreamWriter exam_pama = new StreamWriter(@"exam_pama.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
        StreamWriter exam_pama;
        public string result_filename = "exam_pama_res.txt";
        public string pa_filename = "PAresultEF.txt";
        public string ma_filename = "top_level0EF.txt";
        struct_site_dic s_s_d;
        public Main()
        { }
        public void ex_score()
        {
            exam_pama = new StreamWriter(result_filename, false, System.Text.Encoding.GetEncoding("utf-8"));
            //string pa_filename = "PAresultEF.txt";
            //string ma_filename = "top_level-1EF.txt";
            Assembly myAssembly = Assembly.GetEntryAssembly();
            string path = myAssembly.Location;
            System.IO.Path.Combine(Path.GetDirectoryName(path), pa_filename);
            Console.WriteLine(System.IO.Path.Combine(Path.GetDirectoryName(path), pa_filename));
            Console.WriteLine(File.Exists(System.IO.Path.Combine(Path.GetDirectoryName(path), pa_filename)));
            Console.WriteLine(File.Exists(path));
            Console.WriteLine(path);
            if (File.Exists(System.IO.Path.Combine(Path.GetDirectoryName(path), pa_filename)) && File.Exists(System.IO.Path.Combine(Path.GetDirectoryName(path), ma_filename)))
            {
                //StreamWriter exam_pama = new StreamWriter(@"exam_pama.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
                Dictionary<string, SortedList<int, Score>> pa_scores = Score.read_paresult(pa_filename);
                Dictionary<string, SortedList<int, Score>> ma_scores = Score.read_maresult(ma_filename);
                SortedSet<string> protein_list = new SortedSet<string>();
                s_s_d = new struct_site_dic();
                foreach (string s in pa_scores.Keys)
                {
                    protein_list.Add(s);
                }
                foreach (string s in ma_scores.Keys)
                {
                    protein_list.Add(s);
                }
                foreach (string protein in protein_list)
                {
                    //exam_pama.WriteLine(protein);
                    Console.WriteLine(protein);
                    string buf_pdb = protein.ToString().Split('[')[1].Split(']')[0];

                    string pdbid = buf_pdb.Substring(0, buf_pdb.Length - 1);
                    string chain = buf_pdb.Substring(buf_pdb.Length - 1, 1);
                    if (pa_scores.ContainsKey(protein) && ma_scores.ContainsKey(protein))
                    {
                        int pa_index = 0;
                        int ma_index = 0;
                        bool all_over_lap = false;
                        //Console.WriteLine(pa_scores[protein].Count);
                        //while (ma_index < ma_scores[protein].Count)
                        while (pa_index < pa_scores[protein].Count || ma_index < ma_scores[protein].Count)
                        {
                            Console.WriteLine(pa_index + " " + ma_index);
                            //Score ma_score = ma_scores[protein].Values[ma_index];
                            //foreach (int p_key in pa_scores[protein].Keys)
                            //{
                            //    Score pa_score = pa_scores[protein][p_key];
                            //    if ((pa_scores[protein][p_key].start >= ma_score.start) && (pa_scores[protein][p_key].end <= ma_score.end))
                            //    {
                            //        all_over_lap = true;
                            //        pa_scores[protein][p_key].overlap = true;
                            //        bool ketugou = false;
                            //        struct_site s_s_buf = new struct_site("", "", "", "");
                            //        string struct_conf = "";
                            //        if (s_s_d.struct_site_list.ContainsKey(pdbid))
                            //        {
                            //            foreach (KeyValuePair<string, struct_site> s_s in s_s_d.struct_site_list[pdbid])
                            //            {
                            //                if (chain.Equals(s_s.Value.asym_id()))
                            //                {
                            //                    foreach (int amino_no in s_s.Value.amino_list())
                            //                    {
                            //                        if (amino_no > ma_score.start && amino_no < ma_score.end)
                            //                        {
                            //                            ketugou = true;
                            //                            s_s_buf = s_s.Value;
                            //                        }
                            //                    }
                            //                }
                            //            }
                            //            for (int i = ma_score.start - 1; i < ma_score.end - 1; i++)
                            //            {
                            //                struct_conf = struct_conf + s_s_d.struct_conf_type(pdbid, chain, i);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            //Console.WriteLine(pdbid);
                            //        }
                            //        if (ketugou)
                            //        {
                            //            exam_pama.WriteLine(protein + "#" + pa_score.start + "-" + pa_score.end + "#" + pa_score.score_str + "#" + ma_score.start + "-" + ma_score.end + "#" + ma_score.over_level + "#" + ma_score.score + "#" + ma_score.score_str + "#" + struct_conf + "#" + s_s_buf.print());
                            //            //Console.WriteLine(ma_score.score_str);
                            //            //Console.WriteLine(struct_conf);
                            //        }
                            //        else
                            //        {
                            //            exam_pama.WriteLine(protein + "#" + pa_score.start + "-" + pa_score.end + "#" + pa_score.score_str + "#" + ma_score.start + "-" + ma_score.end + "#" + ma_score.over_level + "#" + ma_score.score + "#" + ma_score.score_str + "#" + struct_conf);
                            //        }
                            //    }
                            //}
                            //if (all_over_lap == false)
                            //{
                            //    //Score ma_score = ma_scores[protein].Values[ma_index];
                            //    this.print_ma(ma_score, protein);

                            //    ma_index++;
                            //}


                            if (pa_index < pa_scores[protein].Count && ma_index < ma_scores[protein].Count)
                            {
                                Score pa_score = pa_scores[protein].Values[pa_index];
                                Score ma_score = ma_scores[protein].Values[ma_index];
                                if ((pa_score.start >= ma_score.start) && (pa_score.end <= ma_score.end))
                                {
                                    bool ketugou = false;
                                    struct_site s_s_buf = new struct_site("", "", "", "");
                                    string struct_conf = "";
                                    if (s_s_d.struct_site_list.ContainsKey(pdbid))
                                    {
                                        foreach (KeyValuePair<string, struct_site> s_s in s_s_d.struct_site_list[pdbid])
                                        {
                                            if (chain.Equals(s_s.Value.asym_id()))
                                            {
                                                foreach (int amino_no in s_s.Value.amino_list())
                                                {
                                                    if (amino_no > ma_score.start && amino_no < ma_score.end)
                                                    {
                                                        ketugou = true;
                                                        s_s_buf = s_s.Value;
                                                    }
                                                }
                                            }
                                        }
                                        for (int i = ma_score.start - 1; i < ma_score.end - 1; i++)
                                        {
                                            struct_conf = struct_conf + s_s_d.struct_conf_type(pdbid, chain, i);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(pdbid);
                                    }
                                    if (ketugou)
                                    {
                                        exam_pama.WriteLine(protein + "#" + pa_score.start + "-" + pa_score.end + "#" + pa_score.score_str + "#" + ma_score.start + "-" + ma_score.end + "#" + ma_score.over_level + "#" + ma_score.score + "#" + ma_score.score_str + "#" + struct_conf + "#" + s_s_buf.print());
                                        //Console.WriteLine(ma_score.score_str);
                                        //Console.WriteLine(struct_conf);
                                    }
                                    else
                                    {
                                        exam_pama.WriteLine(protein + "#" + pa_score.start + "-" + pa_score.end + "#" + pa_score.score_str + "#" + ma_score.start + "-" + ma_score.end + "#" + ma_score.over_level + "#" + ma_score.score + "#" + ma_score.score_str + "#" + struct_conf);
                                    }
                                    //pa_index++;
                                    pa_index = pa_index + 1;
                                    ma_index++;
                                }
                                else if (pa_score.start <= ma_score.start)
                                {
                                    this.print_pa(pa_score, protein);
                                    pa_index++;
                                }
                                else if ((pa_score.start > ma_score.start) && (pa_score.end > ma_score.end))
                                {
                                    this.print_ma(ma_score, protein);

                                    ma_index++;
                                }
                            }
                            else if (pa_index < pa_scores[protein].Count && ma_index >= ma_scores[protein].Count)
                            {

                                Score pa_score = pa_scores[protein].Values[pa_index];
                                this.print_pa(pa_score, protein);

                                pa_index++;
                            }
                            else if (pa_index >= pa_scores[protein].Count && ma_index < ma_scores[protein].Count)
                            {
                                Score ma_score = ma_scores[protein].Values[ma_index];
                                this.print_ma(ma_score, protein);

                                ma_index++;
                            }

                        }

                        //foreach (int p_key in pa_scores[protein].Keys)
                        //{
                        //    Score pa_score = pa_scores[protein][p_key];
                        //    if (pa_score.overlap == false)
                        //    {
                        //        this.print_pa(pa_score, protein);
                        //    }
                        //}


                    }
                    else if (pa_scores.ContainsKey(protein) && !ma_scores.ContainsKey(protein))
                    {

                        foreach (Score pa_score in pa_scores[protein].Values)
                        {
                            this.print_pa(pa_score, protein);


                        }
                    }
                    else if (!pa_scores.ContainsKey(protein) && ma_scores.ContainsKey(protein))
                    {
                        foreach (Score ma_score in ma_scores[protein].Values)
                        {
                            this.print_ma(ma_score, protein);

                        }
                    }
                }
                exam_pama.Close();
            }
        }

        public string print_pa(Score pa_score, string protein)
        {
            string ret = "";
            //Score pa_score = pa_scores[protein].Values[pa_index];
            string buf_pdb = protein.ToString().Split('[')[1].Split(']')[0];

            string pdbid = buf_pdb.Substring(0, buf_pdb.Length - 1);
            string chain = buf_pdb.Substring(buf_pdb.Length - 1, 1);
            bool ketugou = false;
            struct_site s_s_buf = new struct_site("", "", "", "");
            string struct_conf = "";
            if (s_s_d.struct_site_list.ContainsKey(pdbid))
            {
                foreach (KeyValuePair<string, struct_site> s_s in s_s_d.struct_site_list[pdbid])
                {
                    if (chain.Equals(s_s.Value.asym_id()))
                    {
                        foreach (int amino_no in s_s.Value.amino_list())
                        {
                            if (amino_no > pa_score.start && amino_no < pa_score.end)
                            {
                                ketugou = true;
                                s_s_buf = s_s.Value;
                            }
                        }
                    }
                }
                for (int i = pa_score.start - 1; i < pa_score.end - 1; i++)
                {
                    struct_conf = struct_conf + s_s_d.struct_conf_type(pdbid, chain, i);
                }
            }
            else
            {
                //Console.WriteLine(pdbid);
            }
            if (ketugou)
            {
                exam_pama.WriteLine(protein + "#" + pa_score.start + "-" + pa_score.end + "#" + pa_score.score_str + "#" + "#" + "#" + "#" + "#" + struct_conf + "#" + s_s_buf.print());
                //Console.WriteLine(pa_score.score_str);
                //Console.WriteLine(struct_conf);
            }
            else
            {
                exam_pama.WriteLine(protein + "#" + pa_score.start + "-" + pa_score.end + "#" + pa_score.score_str + "#" + "#" + "#" + "#" + "#" + struct_conf + "#");
                // Console.WriteLine(pa_score.score_str);
                //Console.WriteLine(struct_conf);
            }
            return ret;
        }

        public string print_ma(Score ma_score, string protein)
        {
            string ret = "";
            //Score pa_score = pa_scores[protein].Values[pa_index];
            string buf_pdb = protein.ToString().Split('[')[1].Split(']')[0];

            string pdbid = buf_pdb.Substring(0, buf_pdb.Length - 1);
            string chain = buf_pdb.Substring(buf_pdb.Length - 1, 1);
            bool ketugou = false;
            struct_site s_s_buf = new struct_site("", "", "", "");
            string struct_conf = "";
            foreach (KeyValuePair<string, struct_site> s_s in s_s_d.struct_site_list[pdbid])
            {
                if (chain.Equals(s_s.Value.asym_id()))
                {
                    foreach (int amino_no in s_s.Value.amino_list())
                    {
                        if (amino_no > ma_score.start && amino_no < ma_score.end)
                        {
                            ketugou = true;
                            s_s_buf = s_s.Value;
                        }
                    }
                }


            }
            for (int i = ma_score.start; i <= ma_score.end; i++)
            {
                struct_conf = struct_conf + s_s_d.struct_conf_type(pdbid, chain, i);
            }
            if (ketugou)
            {
                exam_pama.WriteLine(protein + "#" + "#" + "#" + ma_score.start + "-" + ma_score.end + "#" + ma_score.over_level + "#" + ma_score.score + "#" + ma_score.score_str + "#" + struct_conf + "#" + s_s_buf.print());
                //Console.WriteLine(ma_score.score_str);
                //Console.WriteLine(struct_conf);
            }
            else
            {
                exam_pama.WriteLine(protein + "#" + "#" + "#" + ma_score.start + "-" + ma_score.end + "#" + ma_score.over_level + "#" + ma_score.score + "#" + ma_score.score_str + "#" + struct_conf + "#");
                //Console.WriteLine(ma_score.score_str);
                //Console.WriteLine(struct_conf);
            }
            return ret;
        }


    }
}
