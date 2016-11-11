using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class IO
    {
        StreamWriter debug =
             new StreamWriter(@"debug.txt", false, System.Text.Encoding.GetEncoding("utf-8"));

        //List<entry> entrys = new List<entry>();
        public Dictionary<string, Entry> entrys = new Dictionary<string, Entry>();
        public void read_fasta(string[] filename)
        {
            entrys = new Dictionary<string, Entry>();
            string[] fastas = filename;
            //foreach (string file_f in fastas)
            foreach (string file_f in filename)
            {
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

        }

        public void get_result_protein()
        {

            //Dictionary<string, Entry> entrys = new Dictionary<string, Entry>();
            string protein_folder = System.IO.Path.Combine("result", "protein");
            if (!Directory.Exists(protein_folder))
            {
                Directory.CreateDirectory(protein_folder);
            }
            string[] fastas = System.IO.Directory.GetFiles(protein_folder, "*", System.IO.SearchOption.AllDirectories);
            foreach(string fasta in fastas)
            {
                string file_f = System.IO.Path.GetFileNameWithoutExtension(fasta);
                entrys[file_f] = new Entry(new StringBuilder(), new StringBuilder(), file_f);
                //Console.WriteLine(fasta);
                //タンパク質の中身を全部読む
                if (File.Exists(fasta))
                {
                    using (StreamReader r = new StreamReader(fasta))
                    {
                        string buf_title = r.ReadLine();
                        string title ="";
                        if (buf_title.ToString().Split('|').Length > 4)
                        {
                            title = buf_title.ToString().Split('|')[4];
                        }
                        else if (buf_title.ToString().IndexOf("[") == 1)
                        {
                            if (buf_title.ToString().Split('[')[1].Split(']').Length > 1)
                            {
                                title = buf_title.ToString().Split('[')[1].Split(']')[1];
                            }
                        }
                        else
                        {
                            title = Entry.ValidFileName(buf_title.ToString());
                        }
                        //entrys[file_f] = new Entry(new StringBuilder(r.ReadLine()), new StringBuilder(r.ReadLine()), file_f);
                        entrys[file_f] = new Entry(new StringBuilder( title), new StringBuilder(), file_f);
                    }
                }
            }
            //return entrys;

        }

        public string[] get_protein_titles()
        {
            string[] titles = new string[entrys.Keys.Count];
            entrys.Keys.CopyTo(titles, 0);
            //string[] titles = new string[entrys.Count];
            //for(int i = 0; i < entrys.Count; i++)
            //{
            //    titles[i] = entrys[i].title;
            //}
            return titles;
        }

        public Dictionary<string, Motif> motifs = new Dictionary<string, Motif>();

        public void read_motif(string[] filename)
        {
            List<StringBuilder> motifs_str = new List<StringBuilder>();

            foreach (string motif_f in filename)
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
                                motifs_str.Add(new StringBuilder());
                                motifs_str[motifs_str.Count - 1].Append(new StringBuilder(line + "\n"));
                            }
                            else
                            {
                                matrix = false;
                            }
                        }
                        else if (line.IndexOf("CC") != 0 && matrix)
                        {
                            if (motifs_str.Count == 0)
                            {
                                motifs_str.Add(new StringBuilder());
                            }
                            motifs_str[motifs_str.Count - 1].Append(new StringBuilder(line + "\n"));

                        }

                    }
                }
            }
            foreach (StringBuilder f_m in motifs_str)
            {
                Motif bufmotif = new Motif(f_m.ToString());
                motifs[bufmotif.ac.ToString() +bufmotif.title.ToString()] = bufmotif;
                //motifs[bufmotif.title.ToString()] = bufmotif;
            }
        }

        public void get_result_motif()
        {

            //Dictionary<string, Entry> entrys = new Dictionary<string, Entry>();
            string motif_folder = System.IO.Path.Combine("result", "motif");
            if (!Directory.Exists(motif_folder))
            {
                Directory.CreateDirectory(motif_folder);
            }
            string[] querys = System.IO.Directory.GetFiles(motif_folder, "*", System.IO.SearchOption.AllDirectories);
            foreach (string motif in querys)
            {
                string file_f = System.IO.Path.GetFileNameWithoutExtension(motif);
                StreamReader mot = new StreamReader(motif);
                motifs[file_f] = new Motif(mot.ReadToEnd());
                
            }
            //return entrys;

        }

        public List<string> get_motif_level(string[] select_motif)
        {
            List<string> levels = new List<string>();
            foreach(string motif in select_motif)
            {
                if (motifs.ContainsKey(motif))
                {
                    foreach(int level in motifs[motif].cutoff.Keys)
                    {
                        if (!levels.Contains(level.ToString()))
                        {
                            levels.Add(level.ToString());
                        }
                    }
                }
            }
            return levels;

        }  


        public string[] get_motif_titles()
        {

            string[] titles = new string[motifs.Keys.Count];
            
            motifs.Keys.CopyTo(titles, 0);
            for (int i = 0; i < titles.Count(); i++)
            {
                titles[i] = titles[i] + "," + motifs[titles[i]].title;
            }
            return titles;
            //string[] titles = new string[motifs.Count];
            //for (int i = 0; i < motifs.Count; i++)
            //{
            //    titles[i] = motifs[i].title.ToString();
            //}
        }
        public string[] get_motif_keys()
        {

            string[] titles = new string[motifs.Keys.Count];

            motifs.Keys.CopyTo(titles, 0);
            
            return titles;
            //string[] titles = new string[motifs.Count];
            //for (int i = 0; i < motifs.Count; i++)
            //{
            //    titles[i] = motifs[i].title.ToString();
            //}
        }


        public Dictionary<string, Dictionary<string,Dictionary<int, Score>>> exp_score(string[] select_protein, string[] select_motif)
        {

            Dictionary<string, Dictionary<string, Dictionary<int, Score>>> score = new Dictionary<string, Dictionary<string, Dictionary<int, Score>>>();
            Form4 f4 = new Form4();
            int part = 0;
            f4.Init(select_protein.Length * select_motif.Length);
            f4.Show();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 8;

            //Parallel.ForEach(select_protein, options, protein =>

            foreach (string protein in select_protein)
            {
                score[protein] = new Dictionary<string, Dictionary<int, Score>>();

                string fasta = System.IO.Path.Combine("result", System.IO.Path.Combine("protein",protein+".fasta"));
                MessageBox.Show(fasta);
                if (File.Exists(fasta))
                {
                    using (StreamReader r = new StreamReader(fasta))
                    {
                        entrys[protein] = new Entry(new StringBuilder(r.ReadLine()), new StringBuilder(r.ReadLine()), protein);
                    }
                }

                foreach (string motif in select_motif)
                {
                    score[protein][motif] = new Dictionary<int, Score>();
                    Motif query = motifs[motif];
                    debug.WriteLine(query.title);
                    //score[protein][motif] = new Dictionary<int, Score>();
                    string resfolder = System.IO.Path.Combine("result", protein);
                    string resfile = System.IO.Path.Combine(resfolder, motif + ".out");
                    debug.WriteLine(resfile);
                    Dictionary<int, Score> buf_score = new Dictionary<int, Score>();
                    if (File.Exists(resfile))
                    {
                        
                        //sco[entry.Value.title.ToString()][query.title.ToString()] = Score.read_result(resfile);
                        buf_score = new Dictionary<int, Score>(Score.read_result(resfile));
                    }
                    else
                    {
                        
                        //sco[entry.Value.title.ToString()][query.title.ToString()] = new Dictionary<int, Score>();
                        buf_score = new Dictionary<int, Score>();
                    }
                    
                    foreach (KeyValuePair<int, Score> cs in buf_score)
                    {
                        List<int> level_list = query.cutoff.Keys.ToList();
                        level_list.Sort();
                        
                        foreach (int level in level_list)
                        {
                            //debug.WriteLine(cs.Value.score + ">" + query.cutoff[level]);
                            //if (cs.Value.score > query.cutoff[query.low_cutoff_level])
                            if (cs.Value.score > query.cutoff[level])
                            {
                                score[protein][motif][cs.Key] = cs.Value;
                                score[protein][motif][cs.Key].N_score = query.exam_Nscore(level, cs.Value);
                                score[protein][motif][cs.Key].over_level = level;
                            }
                        }
                    }
                    part++;
                    f4.update(part);
                    Application.DoEvents();


                }
                
            }
            //debug.Close();
            return score;
        }



        public Dictionary<string, Dictionary<string, Dictionary<int, Score>>> exp_score_level(string[] select_protein, string[] select_motif,int threshold_level)
        {

            
            Dictionary<string, Dictionary<string, Dictionary<int, Score>>> score = new Dictionary<string, Dictionary<string, Dictionary<int, Score>>>();
            Form4 f4 = new Form4();
            int part = 0;
            f4.Init(select_protein.Length * select_motif.Length);
            f4.Show();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 8;

            //Parallel.ForEach(select_protein, options, protein =>

            foreach (string protein in select_protein)
            {
                score[protein] = new Dictionary<string, Dictionary<int, Score>>();

                string fasta = System.IO.Path.Combine("result", System.IO.Path.Combine("protein", protein + ".fasta"));
                if (File.Exists(fasta))
                {
                    using (StreamReader r = new StreamReader(fasta))
                    {
                        entrys[protein] = new Entry(new StringBuilder(r.ReadLine()), new StringBuilder(r.ReadLine()), protein);
                    }
                }

                foreach (string motif in select_motif)
                {
                    score[protein][motif] = new Dictionary<int, Score>();
                    Motif query = motifs[motif];
                    debug.WriteLine(query.title);
                    //score[protein][motif] = new Dictionary<int, Score>();
                    string resfolder = System.IO.Path.Combine("result", protein);
                    string resfile = System.IO.Path.Combine(resfolder, motif + ".out");
                    debug.WriteLine(resfile);
                    Dictionary<int, Score> buf_score = new Dictionary<int, Score>();
                    if (File.Exists(resfile))
                    {

                        //sco[entry.Value.title.ToString()][query.title.ToString()] = Score.read_result(resfile);
                        buf_score = new Dictionary<int, Score>(Score.read_result(resfile));
                    }
                    else
                    {

                        //sco[entry.Value.title.ToString()][query.title.ToString()] = new Dictionary<int, Score>();
                        buf_score = new Dictionary<int, Score>();
                    }

                    foreach (KeyValuePair<int, Score> cs in buf_score)
                    {
                        List<int> level_list = query.cutoff.Keys.ToList();
                        level_list.Sort();

                        foreach (int level in level_list)
                        {
                            if (level >= threshold_level)
                            {
                                //debug.WriteLine(cs.Value.score + ">" + query.cutoff[level]);
                                //if (cs.Value.score > query.cutoff[query.low_cutoff_level])
                                if (cs.Value.score > query.cutoff[level])
                                {
                                    score[protein][motif][cs.Key] = cs.Value;
                                    score[protein][motif][cs.Key].N_score = query.exam_Nscore(level, cs.Value);
                                    score[protein][motif][cs.Key].over_level = level;
                                }
                            }
                        }
                    }
                    part++;
                    f4.update(part);
                    Application.DoEvents();


                }

            }
            //debug.Close();
            f4.Close();
            return score;
        }
        

        public Dictionary<string, Dictionary<string, Dictionary<int, Score>>> exp_score_score(string[] select_protein, string[] select_motif, double threshold_score)
        {

            


            Dictionary<string, Dictionary<string, Dictionary<int, Score>>> score = new Dictionary<string, Dictionary<string, Dictionary<int, Score>>>();
            Form4 f4 = new Form4();
            int part = 0;
            f4.Init(select_protein.Length * select_motif.Length);
            f4.Show();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 8;

            //Parallel.ForEach(select_protein, options, protein =>

            foreach (string protein in select_protein)
            {
                score[protein] = new Dictionary<string, Dictionary<int, Score>>();

                string fasta = System.IO.Path.Combine("result", System.IO.Path.Combine("protein", protein + ".fasta"));
                if (File.Exists(fasta))
                {
                    using (StreamReader r = new StreamReader(fasta))
                    {
                        entrys[protein] = new Entry(new StringBuilder(r.ReadLine()), new StringBuilder(r.ReadLine()), protein);
                    }
                }

                foreach (string motif in select_motif)
                {
                    score[protein][motif] = new Dictionary<int, Score>();
                    Motif query = motifs[motif];
                    debug.WriteLine(query.title);
                    //score[protein][motif] = new Dictionary<int, Score>();
                    string resfolder = System.IO.Path.Combine("result", protein);
                    string resfile = System.IO.Path.Combine(resfolder, motif + ".out");
                    debug.WriteLine(resfile);
                    Dictionary<int, Score> buf_score = new Dictionary<int, Score>();
                    if (File.Exists(resfile))
                    {

                        //sco[entry.Value.title.ToString()][query.title.ToString()] = Score.read_result(resfile);
                        buf_score = new Dictionary<int, Score>(Score.read_result(resfile));
                    }
                    else
                    {

                        //sco[entry.Value.title.ToString()][query.title.ToString()] = new Dictionary<int, Score>();
                        buf_score = new Dictionary<int, Score>();
                    }

                    foreach (KeyValuePair<int, Score> cs in buf_score)
                    {
                        List<int> level_list = query.cutoff.Keys.ToList();
                        level_list.Sort();


                        if (query.exam_Nscore(query.max_cutoff_level, cs.Value) >= threshold_score) {

                            score[protein][motif][cs.Key] = cs.Value;
                            score[protein][motif][cs.Key].N_score = query.exam_Nscore(query.max_cutoff_level, cs.Value);
                            score[protein][motif][cs.Key].over_level = -100;
                        }
                        
                    }
                    part++;
                    f4.update(part);
                    Application.DoEvents();


                }

            }
            f4.Close();
            //debug.Close();
            return score;
        }

    }
}
