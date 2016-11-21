using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace Sample01
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding utf8Enc = Encoding.UTF8;
            StreamWriter writer =
              new StreamWriter(@"result.txt", false, System.Text.Encoding.GetEncoding("Shift_JIS"));
            //StreamWriter EF =
            //  new StreamWriter(@"protein_EF2.txt", false, System.Text.Encoding.GetEncoding("Shift_JIS"));
            //StreamWriter two_best =
            //  new StreamWriter(@"tow_best.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            //StreamWriter test =
            //  new StreamWriter(@"test_aa.txt", false, System.Text.Encoding.GetEncoding("utf-8"));

            StreamWriter top = new StreamWriter(@"top.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            //StreamWriter cut = new StreamWriter(@"cut.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            //Console.SetOut(writer);
            //writer.WriteLine("テスト書き込みです。");
            //List<StringBuilder> fasta = new List<StringBuilder>();
            StringBuilder profile = new StringBuilder();
            StringBuilder title = new StringBuilder();
            StringBuilder match = new StringBuilder();
            List<StringBuilder> fasta_title = new List<StringBuilder>();
            List<List<int>> matcha = new List<List<int>>();
            //int length=0;
            List<int> score = new List<int>();
            StringBuilder alphabet = new StringBuilder();
            List<Motif> motif = new List<Motif>();
            Dictionary<int, Dictionary<int, Dictionary<int, Score>>> score_list = new Dictionary<int, Dictionary<int, Dictionary<int, Score>>>();
            Dictionary<string, Entry> entrys = new Dictionary<string, Entry>();

            Debug.WriteLine("Debug Information-Product Starting ");
            Debug.Indent();

            string[] fastas = System.IO.Directory.GetFiles(@"fasta", "*", System.IO.SearchOption.AllDirectories);
            foreach (string file_f in fastas)
            {
                //int i=0;
                using (StreamReader r = new StreamReader(file_f))
                {
                    string line;
                    StringBuilder buf_title = new StringBuilder();
                    StringBuilder buf_main = new StringBuilder();
                    String buf_id = "test";
                    int a = 0;
                    while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                    {
                        //Console.Write(line.IndexOf(">"));
                        if (line.IndexOf(">") == 0)
                        {
                            //fasta.Add(new StringBuilder());
                            //fasta_title.Add(new StringBuilder());
                            //fasta_title.Add(new StringBuilder(line));
                            if (a != 0)
                            {
                                int renban = 0;
                                while (entrys.ContainsKey(buf_id))
                                {
                                    Console.Write(buf_id);
                                    renban++;
                                    buf_id = buf_id + "+" + renban;
                                }
                                entrys[buf_id] = new Entry(buf_title, buf_main, buf_id);
                                buf_main = new StringBuilder();

                            }
                            buf_title = new StringBuilder(line);
                            if (buf_title.ToString().Split('|').Length > 3)
                            {
                                buf_id = buf_title.ToString().Split('|')[3];
                            }
                            else if (buf_title.ToString().IndexOf("[") == 1)
                            {
                                buf_id = buf_title.ToString().Split('[')[1].Split(']')[0];
                            }
                            else
                            {
                                buf_id = Entry.ValidFileName(buf_title.ToString());
                            }

                            a = 1;
                        }
                        else
                        {
                            //fasta[fasta.Count - 1].Append(line);
                            buf_main.Append(line);
                        }

                    }
                    entrys[buf_id] = new Entry(buf_title, buf_main, buf_id);
                    //Console.WriteLine(fasta);
                }
            }

            //foreach(KeyValuePair<string,Entry> e in entrys)
            //{
            //    test.Write(e.Value.id);
            //}

            string[] motif_fs = System.IO.Directory.GetFiles(@"prosite", "*", System.IO.SearchOption.AllDirectories);
            List<StringBuilder> motifs = new List<StringBuilder>();

            foreach (string motif_f in motif_fs)
            {
                using (StreamReader r = new StreamReader(motif_f))
                {
                    string line;
                    bool matrix = false;

                    while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                    {
                        //Console.Write(line.IndexOf(">"));
                        if (line.IndexOf("//") == 0)
                        {
                            //motifs.Add(new StringBuilder());
                            //fasta_title.Add(new StringBuilder());
                        }
                        else if (line.IndexOf("ID") == 0)
                        {
                            if (line.IndexOf("MATRIX.") > 0)
                            {
                                matrix = true;
                                motifs.Add(new StringBuilder());
                                motifs[motifs.Count - 1].Append(new StringBuilder(line + "\n"));
                            }
                            else
                            {
                                matrix = false;
                            }
                        }
                        else if (line.IndexOf("CC") != 0 && matrix)
                        {
                            if (motifs.Count == 0)
                            {
                                motifs.Add(new StringBuilder());
                            }
                            motifs[motifs.Count - 1].Append(new StringBuilder(line + "\n"));
                        }
                    }
                }
            }
            foreach (StringBuilder f_m in motifs)
            {
                motif.Add(new Motif(f_m.ToString()));
            }

            //int index = 0;
            System.Diagnostics.Stopwatch alltime = System.Diagnostics.Stopwatch.StartNew();

            Dictionary<string, Dictionary<string, Dictionary<int, Score>>> sco = new Dictionary<string, Dictionary<string, Dictionary<int, Score>>>();
            //for (int i = 0; i < fasta.Count; i++)
            foreach (KeyValuePair<string, Entry> entry in entrys)
            {

                foreach (Motif query in motif)
                {
                    //sco[fasta_title[i].ToString()] = new Dictionary<string, Dictionary<int, Score>>();
                    //sco[fasta_title[i].ToString()][query.title.ToString()] = new Dictionary<int, Score>();
                    sco[entry.Value.title.ToString()] = new Dictionary<string, Dictionary<int, Score>>();
                    sco[entry.Value.title.ToString()][query.title.ToString()] = new Dictionary<int, Score>();
                    //foreach (KeyValuePair<int, double> cutoff in query.cutoff_n_score)
                    //{
                    //    cut.WriteLine(query.title.ToString() + "," + cutoff.Key + "," + cutoff.Value);
                    //}
                }
            }
            //cut.Close();
            //for (int i = 0; i < fasta.Count; i++)
            int cnt = 0;
            foreach (KeyValuePair<string, Entry> entry in entrys)
            {
                cnt++;
                string resfolder = "result";

                resfolder = System.IO.Path.Combine("result", entry.Value.id);
                if (!Directory.Exists(resfolder))
                {
                    Directory.CreateDirectory(resfolder);
                }
                if (!Directory.Exists(System.IO.Path.Combine("result", "protein")))
                {
                    Directory.CreateDirectory(System.IO.Path.Combine("result", "protein"));
                }

                //bool diff = true;
                if (File.Exists(System.IO.Path.Combine(System.IO.Path.Combine("result", "protein"), entry.Value.id + ".fasta")))
                {
                    //StreamReader r = new StreamReader(System.IO.Path.Combine(System.IO.Path.Combine("result", "protein"), entry.Value.id + ".fasta"));
                    //if (fasta_title[i].Equals(r.ReadLine()))
                    //{
                    //    if (fasta[i].Equals(r.ReadLine()))
                    //    {
                    //        diff = false;
                    //    }

                    //}
                    //r.Close();

                }
                //if (diff == true)
                if (!File.Exists(System.IO.Path.Combine(System.IO.Path.Combine("result", "protein"), entry.Value.id + ".fasta")))
                {
                    //Console.WriteLine("違った" + entry.Value.id);
                    StreamWriter out_protein =
              new StreamWriter(System.IO.Path.Combine(System.IO.Path.Combine("result", "protein"), entry.Value.id + ".fasta"), false, System.Text.Encoding.GetEncoding("utf-8"));
                    out_protein.WriteLine(entry.Value.title.ToString());
                    out_protein.WriteLine(entry.Value.main.ToString());
                    out_protein.Close();
                }

            }
            //test.WriteLine("");
            //test.WriteLine(cnt);
            for (int i = 0; i < motif.Count; i++)
            {
                string motif_name = motif[i].ac.ToString() + ".profile";
                bool diff = true;
                if (!Directory.Exists(System.IO.Path.Combine("result", "motif")))
                {
                    Directory.CreateDirectory(System.IO.Path.Combine("result", "motif"));
                }
                if (File.Exists(System.IO.Path.Combine(System.IO.Path.Combine("result", "motif"), motif_name)))
                {
                    StreamReader r = new StreamReader(System.IO.Path.Combine(System.IO.Path.Combine("result", "motif"), motif_name));
                    if (motifs[i].Equals(r.ReadToEnd()))
                    {
                        diff = false;
                    }
                    r.Close();
                }
                //if (diff == true)
                if (!File.Exists(System.IO.Path.Combine(System.IO.Path.Combine("result", "motif"), motif_name)))
                {
                    //Console.WriteLine("違った" + motif_name);
                    StreamWriter out_motif =
              new StreamWriter(System.IO.Path.Combine(System.IO.Path.Combine("result", "motif"), motif_name), false, System.Text.Encoding.GetEncoding("utf-8"));
                    out_motif.Write(motifs[i]);
                    out_motif.Close();
                }
            }

            //for (int i=0; i < fasta.Count; i++)
            //{
            //    Parallel.ForEach(motif, new ParallelOptions { MaxDegreeOfParallelism = 32 }, query =>
            //    //Parallel.ForEach(motif, query =>
            //    {
            //        Console.WriteLine(fasta_title[i].ToString() + " vs " + query.title.ToString());
            //        sco[fasta_title[i].ToString()][query.title.ToString()] = query.ExamScore(fasta[i].ToString());
            //        Console.WriteLine(alltime.Elapsed);
            //    });
            //}
            if (!Directory.Exists("result"))
            {
                Directory.CreateDirectory("result");
            }


            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 24;
            //int all = fasta.Count * motif.Count;
            int all = entrys.Count * motif.Count;
            int n = 0;
            Console.Write("fasta" + entrys.Count + "title" + fasta_title.Count);
            Parallel.ForEach(entrys, options, entry =>
             {

                 string resfolder = "result";
                 resfolder = System.IO.Path.Combine("result", entry.Value.id);
                 Console.WriteLine(n + "/" + all + " " + entry.Value.title.ToString());

                 foreach (Motif query in motif)
                 {

                    //Console.WriteLine(n + "/" + all + " " + entry.Value.title.ToString() + " vs " + query.ac.ToString() + query.title.ToString());
                    string resfile = System.IO.Path.Combine(resfolder, query.ac.ToString() + ".out");
                     Dictionary<int, Score> buf_score = new Dictionary<int, Score>();
                    //Console.WriteLine(entry.Value.main.ToString());
                    if (File.Exists(resfile))
                     {
                        //sco[fasta_title[i].ToString()][query.title.ToString()] = Score.read_result(resfile);
                        //buf_score = Score.read_result(resfile);
                    }
                     else
                     {
                        //sco[fasta_title[i].ToString()][query.title.ToString()] = new Dictionary<int, Score>();
                        //以下一時的にコメント
                        buf_score = query.ExamScore(entry.Value.main.ToString());
                         string resoutfile = System.IO.Path.Combine(resfolder, query.ac.ToString() + ".out");

                         StringBuilder f_out = new StringBuilder();
                         f_out.AppendLine("protein,motif,start,end,score,string");
                        //p_m_result.WriteLine("protein,motif,start,end,score,string");
                        //foreach (KeyValuePair<int, Score> s in sco[fasta_title[i].ToString()][query.title.ToString()])
                        foreach (KeyValuePair<int, Score> s in buf_score)
                         {
                            //if (s.Value.score > query.cutoff[query.low_cutoff_level])
                            if (query.exam_Nscore(query.low_cutoff_level, s.Value) > 0)
                             {
                                 f_out.AppendLine(entry.Value.id + "," + query.ac.ToString() + "," + s.Value.start + "," + s.Value.end + "," + s.Value.score + "," + s.Value.score_str);
                                //p_m_result.WriteLine(entry.Value.id + "," + query.ac.ToString() + "," + s.Value.start + "," + s.Value.end + "," + s.Value.score + "," + s.Value.score_str);
                            }
                         }
                        //cut.Write(f_out);
                        //cut.Close();
                        StreamWriter p_m_result =
                             new StreamWriter(resoutfile, false, Encoding.GetEncoding("utf-8"));
                         p_m_result.Write(f_out);
                         p_m_result.Close();
                     }


                    //Console.WriteLine(alltime.Elapsed);
                }
                 n++;
                 Console.WriteLine(alltime.Elapsed);

             });
            Console.WriteLine(alltime.Elapsed);


            






            //int e_in=-1;
            //Dictionary<int, StreamWriter> top_level_dic = new Dictionary<int, StreamWriter>();
            //top_level_dic[0] =  new StreamWriter(@"top_level0.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            //top_level_dic[-1] = new StreamWriter(@"top_level-1.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            ////for (int i = 0; i < fasta.Count; i++)
            //foreach (KeyValuePair<string, Entry> entry in entrys)
            //{
            //    e_in++;
            //    score_list[score_list.Count] = new Dictionary<int, Dictionary<int, Score>>();
            //    int m_in = -1;
            //    Dictionary<int, Dictionary<string, Score>> best_score = new Dictionary<int, Dictionary<string, Score>>();
            //    foreach (Motif query in motif)
            //    {
            //        m_in++;
            //        //Console.Write(i + " / " + fasta.Count + "  " + m_in + " / " + motif.Count);
            //        //Console.WriteLine("エントリー名" + fasta_title[i] + "vs" + "モチーフタイトル" + query.title.ToString() + "AC=" + query.ac.ToString());
            //        Console.Write(e_in + " / " + entrys.Count + "  " + m_in + " / " + motif.Count);
            //        Console.WriteLine("エントリー名" + entry.Value.title+ "vs" + "モチーフタイトル" + query.title.ToString() + "AC=" + query.ac.ToString());
            //        Dictionary<int , bool> level_write = new Dictionary<int, bool>();
            //        level_write[0] = false;
            //        level_write[-1] = false;
            //        System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            //        Dictionary<int, Score> cutoff_score = new Dictionary<int, Score>();

            //        //上の流用
            //        string resfolder = "result";

            //        resfolder = System.IO.Path.Combine("result", entry.Value.id);
            //        string resfile = System.IO.Path.Combine(resfolder, query.ac.ToString() + ".out");
            //        Dictionary<int, Score> buf_score = new Dictionary<int, Score>();
            //        Console.WriteLine(resfile);
            //        if (File.Exists(resfile))
            //        {
            //            //sco[entry.Value.title.ToString()][query.title.ToString()] = Score.read_result(resfile);
            //            buf_score = Score.read_result(resfile);
            //        }
            //        else
            //        {
            //            //sco[entry.Value.title.ToString()][query.title.ToString()] = new Dictionary<int, Score>();
            //            buf_score = Score.read_result(resfile);
            //        }
            //        //上の流用

            //        //foreach (KeyValuePair<int, Score> cs in sco[entry.Value.title.ToString()][query.title.ToString()])
            //        foreach (KeyValuePair<int, Score> cs in buf_score)
            //        {
            //            List<int> level_list = query.cutoff.Keys.ToList();
            //            level_list.Sort();
            //            foreach (int level in level_list) {
            //                //if (cs.Value.score > query.cutoff[query.low_cutoff_level])
            //                if (cs.Value.score > query.cutoff[level])
            //                {
            //                    cutoff_score[cs.Key] = cs.Value;
            //                    cutoff_score[cs.Key].N_score = query.exam_Nscore(level, cs.Value);
            //                    cutoff_score[cs.Key].over_level = level;
            //                }
            //            }
            //        }
            //        if (cutoff_score.Count > 0)
            //        {
            //            EF.WriteLine(entry.Value.title);
            //            EF.WriteLine(entry.Value.main);
            //            //Console.WriteLine("エントリー名" + fasta_title[index] + "vs" + "モチーフタイトル" + query.title.ToString() + "AC=" + query.ac.ToString());

            //            writer.WriteLine(entry.Value.title + " vs " + query.title.ToString() + "AC=" + query.ac.ToString());
            //            top.WriteLine("");
            //            top.WriteLine(entry.Value.title + " vs " + query.title.ToString() + "AC=" + query.ac.ToString());
            //            int old_key = 0;
            //            Dictionary<int, int> well = new Dictionary<int, int>();
            //            int well_key = 0;
            //            int well_score = 0;
            //            Score wel = new Score(0, "");
            //            foreach (KeyValuePair<int, Score> s in cutoff_score)
            //            {
            //                //if (((s.Key - old_key > 1) || (s.Value.end != wel.end))  && old_key != 0)
            //                if (s.Value.end != wel.end && old_key != 0)
            //                {
            //                    //Console.WriteLine();
            //                    well[well_key] = well_score;
            //                    well_score = s.Value.score;
            //                    well_key = s.Key;
            //                    wel = s.Value;
            //                }
            //                old_key = s.Key;
            //                if (s.Value.score > well_score)
            //                {
            //                    well_key = s.Key;
            //                    well_score = s.Value.score;
            //                    wel = s.Value;
            //                }
            //                //Console.WriteLine("開始位置=" .Key + "\tスコア=" + s.Value.score+ "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
            //                //Console.WriteLine("開始位置=" + s.K+ sey + "\tスコア=" + s.Value.well_score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.well_score_str);



            //            }
            //            well[well_key] = well_score;
            //            Score old = new Score(0, "");
            //            foreach (KeyValuePair<int, Score> s in cutoff_score)
            //            {
            //                //if (((s.Key - old_key) > 1 || wel.end != s.Value.end) && old_key != 0 )
            //                if (old.end != s.Value.end && old_key != 0)
            //                {
            //                    writer.WriteLine("");
            //                }
            //                old_key = s.Key;

            //                //Console.WriteLine("開始位置=" + s.Key + "\tスコア=" + s.Value.score+ "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
            //                if (!well.ContainsKey(s.Key))
            //                {
            //                    //Console.WriteLine("\t開始位置=" + s.Key + "\tスコア=" + s.Value.score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
            //                    //writer.WriteLine(" 開始位置=" + s.Key + "\tスコア=" + s.Value.score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
            //                    writer.WriteLine(" " + s.Value.start + "-" + s.Value.end + "\tScore=" + s.Value.score + "\tNScore=" + s.Value.N_score + "\tString " + s.Value.score_str);
            //                }
            //                else
            //                {
            //                    if (!best_score.ContainsKey(s.Key))
            //                    {
            //                        best_score[s.Key] = new Dictionary<string, Score>();
            //                    }
            //                    if (!best_score[s.Key].ContainsKey(query.title.ToString()))
            //                    {
            //                        best_score[s.Key][query.title.ToString()] = s.Value;
            //                    }
            //                    //best_score[s.Key][query.title.ToString()].Add(s.Value);
            //                    //Console.WriteLine(" 開始位置=" + s.Key + "\tスコア=" + s.Value.score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
            //                    writer.WriteLine("*" + s.Value.start + "-" + s.Value.end + "\tScore=" + s.Value.score + "\tNScore=" + s.Value.N_score + "\tString " + s.Value.score_str);
            //                    top.WriteLine("*" + s.Value.start + "-" + s.Value.end +"\tLevel="+ s.Value.over_level+ "\tScore=" + s.Value.score + "\tNScore=" + s.Value.N_score + "\tString " + s.Value.score_str);
            //                    foreach(KeyValuePair<int,StreamWriter> top_le in top_level_dic)
            //                    {
            //                        if(top_le.Key <= s.Value.over_level)
            //                        {
            //                            if (level_write[top_le.Key] == false)
            //                            {
            //                                top_le.Value.WriteLine(entry.Value.title);
            //                                level_write[top_le.Key] = true;
            //                            }
            //                            top_le.Value.WriteLine("*" + s.Value.start + "-" + s.Value.end + "\tLevel=" + s.Value.over_level + "\tScore=" + s.Value.score + "\tNScore=" + s.Value.N_score + "\tString " + s.Value.score_str);
            //                        }
            //                    }

            //                }

            //                old = s.Value;

            //            }

            //            //sw.Stop();
            //            //alltime += sw.Elapsed;
            //            //Console.WriteLine("処理時間:" + sw.Elapsed + "合計時間:" + alltime.Elapsed);
            //            //Debug.WriteLine("処理時間:" + sw.Elapsed + "合計時間:" + alltime);

            //        }

            //        //score_list[score_list.Count - 1][score_list[score_list.Count - 1].Count].Clear();
            //        sw.Stop();
            //        //alltime += sw.Elapsed;
            //        Console.WriteLine("処理時間:" + sw.Elapsed + "合計時間:" + alltime.Elapsed);
            //        //Debug.WriteLine("処理時間:" + sw.Elapsed + "合計時間:" + alltime);
            //    }
            //    foreach (KeyValuePair<int, Dictionary<string, Score>> best in best_score)
            //    {
            //        if (best.Value.Count > 1)
            //        {
            //            two_best.WriteLine(entry.Value.title);
            //            foreach (KeyValuePair<string, Score> s in best.Value)
            //            {
            //                two_best.WriteLine(s.Key + "\t" + s.Value.start + "-" + s.Value.end + "\tスコア=" + s.Value.score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
            //            }
            //        }
            //    }
            //}
            //two_best.Close();
            //alltime.Stop();
            ////Console.WriteLine(alltime.Days + "日" + alltime.Hours + "時" + alltime.Minutes + "分" + alltime.Seconds + "秒"  );
            ////Dictionary<int,Score> ef_score = ef_hand.ExamScore(fasta.ToString());
            //writer.Close();
            //top.Close();


        }

    }



}