using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections;

namespace Sample01
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding utf8Enc = Encoding.UTF8;
            StreamWriter writer =
              new StreamWriter(@"result.txt", false, System.Text.Encoding.GetEncoding("Shift_JIS"));
            //Console.SetOut(writer);
            //writer.WriteLine("テスト書き込みです。");
            List < StringBuilder> fasta = new List<StringBuilder>();
            StringBuilder profile = new StringBuilder();
            StringBuilder title = new StringBuilder();
            StringBuilder match = new StringBuilder();
            List < StringBuilder> fasta_title = new List<StringBuilder>();
            List<List<int>> matcha = new List<List<int>>();
            //int length=0;
            List<int> score = new List<int>();
            StringBuilder alphabet = new StringBuilder();
            List<Motif> motif=new List<Motif>();
            Dictionary<int, Dictionary<int, Dictionary<int, Score>>> score_list = new Dictionary<int, Dictionary<int, Dictionary<int, Score>>>();
          
            string[] fastas = System.IO.Directory.GetFiles(@"fasta", "*", System.IO.SearchOption.AllDirectories);
            foreach (string file_f in fastas)
            {
                //int i=0;
                using (StreamReader r = new StreamReader(file_f))
                {
                    string line;
                    int a = 0;
                    while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                    {
                        //Console.Write(line.IndexOf(">"));
                        if(line.IndexOf(">") == 0)
                        {
                            fasta.Add(new StringBuilder());
                            //fasta_title.Add(new StringBuilder());
                            a = 0;
                        }
                        if (a != 0)
                        {
                            fasta[fasta.Count-1].Append(line);
                            
                        }
                        else
                        {
                            fasta_title.Add(new StringBuilder( line));
                            a = 1;
                        }

                    }
                    //Console.WriteLine(fasta);
                }
            }
            
            string[] motif_fs = System.IO.Directory.GetFiles(@"prosite", "*", System.IO.SearchOption.AllDirectories);
            List<StringBuilder> motifs = new List<StringBuilder>();
            
            foreach(string motif_f in motif_fs)
            {
                using ( StreamReader r = new StreamReader(motif_f))
                {
                    string line;
                    while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                    {
                        //Console.Write(line.IndexOf(">"));
                        if (line.IndexOf("//") == 0)
                        {
                            motifs.Add(new StringBuilder());
                            //fasta_title.Add(new StringBuilder());
                        }
                        else if(line.IndexOf("CC") != 0)
                        {
                            if(motifs.Count == 0)
                            {
                                motifs.Add(new StringBuilder());
                            }
                            motifs[motifs.Count-1].Append(new StringBuilder(line + "\n"));
                            
                        }

                    }
                }
            }
            foreach (StringBuilder f_m in motifs)
            {
                motif.Add(new Motif(f_m.ToString()));
            }
            int index= 0;
            TimeSpan alltime= new TimeSpan();
            foreach(StringBuilder entry in fasta)
            {
                score_list[score_list.Count] = new Dictionary<int, Dictionary<int, Score>>();
                foreach(Motif query in motif)
                {
                    System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

                    Console.WriteLine("エントリー名" + fasta_title[index] + "vs" + "モチーフタイトル" + query.title.ToString() + "AC=" + query.ac.ToString());
                    score_list[score_list.Count - 1][score_list[score_list.Count - 1].Count] = query.ExamScore(entry.ToString());
                    int old_key = 0;
                    foreach (KeyValuePair<int, Score> s in score_list[score_list.Count - 1][score_list[score_list.Count - 1].Count - 1])
                    {
                        if ((s.Key - old_key) > 1 && old_key != 0)
                        {
                            Console.WriteLine();
                        }
                        old_key = s.Key;
                        //Console.WriteLine("開始位置=" + s.Key + "\tスコア=" + s.Value.score+ "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.score_str);
                        Console.WriteLine("開始位置=" + s.Key + "\tスコア=" + s.Value.well_score + "\tNスコア=" + s.Value.N_score + "\t文字列 " + s.Value.well_score_str);



                    }

                    sw.Stop();
                    alltime += sw.Elapsed;
                    Console.WriteLine("処理時間:" + sw.Elapsed + "合計時間:" + alltime);
                    
                }
                index++;
            }
            //Dictionary<int,Score> ef_score = ef_hand.ExamScore(fasta.ToString());
            writer.Close();


        }
    }

    
}