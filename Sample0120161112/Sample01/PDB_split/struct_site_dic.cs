using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDB_split
{
    class struct_site_dic
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        Dictionary<string, Dictionary<string, struct_site>> struct_site_list { get; set; }

        public struct_site_dic()
        {
            struct_site_list = new Dictionary<string, Dictionary<string, struct_site>>();
            string[] pdb_fs = System.IO.Directory.GetFiles(@"PDB", "*", System.IO.SearchOption.AllDirectories);
            Console.WriteLine(pdb_fs.Length);
            
            Dictionary<string, Dictionary<String, Dictionary<int, int>>> seq_amino = new Dictionary<string, Dictionary<String, Dictionary<int, int>>>();
            StreamWriter result = new StreamWriter(@"result.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            foreach (string file_f in pdb_fs)
            {
                using (StreamReader r = new StreamReader(file_f))
                {
                    string[] cif_split = r.ReadToEnd().Split('#');
                    Console.WriteLine(cif_split.Length);
                    string name = cif_split[0].Split('_')[1].Trim();
                    Console.WriteLine(name);
                    struct_site_list[name] = new Dictionary<string, struct_site>();
                    seq_amino[name] = new Dictionary<String, Dictionary<int, int>>();
                    foreach (string cif_part in cif_split)
                    {
                        if (cif_part.IndexOf("_struct_site.") >= 0)
                        {

                            string[] lines = cif_part.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                            Console.WriteLine(lines[1]);
                            if (lines[1].IndexOf("loop") != 0)
                            {
                                Dictionary<string, string> struct_site = new Dictionary<string, string>();

                                //foreach (string line in lines)
                                for (int i = 1; i < lines.Length; i++)
                                {
                                    string line = lines[i];
                                    string[] line_sp = line.Split(new string[] { " " }, 2, StringSplitOptions.RemoveEmptyEntries);
                                    struct_site[line_sp[0]] = line_sp[1].Trim();
                                }
                                this.struct_site_list[name][struct_site["_struct_site.id"]] = (new struct_site(name, struct_site["_struct_site.id"], struct_site["_struct_site.details"], struct_site["_struct_site.pdbx_evidence_code"]));
                            }
                            else
                            {
                                //foreach (string line in lines)
                                for (int i = 0; i < lines.Length; i++)
                                {
                                    string line = lines[i];
                                    if (line.IndexOf("_") != 0 && line.IndexOf("loop") == -1 && line.Trim().Length > 2)
                                    {
                                        string[] line_sp = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                        if (line_sp.Length >= 3)
                                        {
                                            StringBuilder dete = new StringBuilder();
                                            //Console.WriteLine(line_sp.Length);
                                            for (int j = 1; j < line_sp.Length - 1; j++)
                                            {
                                                dete.Append(line_sp[j] + " ");
                                            }
                                            //Console.WriteLine(line_sp[0]);
                                            this.struct_site_list[name][line_sp[0]] = (new struct_site(name, line_sp[0], dete.ToString(), line_sp[line_sp.Length - 1]));
                                        }
                                        else
                                        {
                                            string id = line.Trim();
                                            i++;
                                            StringBuilder dete = new StringBuilder();
                                            if (lines[i].IndexOf(";") == 0)
                                            {
                                                dete.Append(lines[i].Substring(1));
                                                i++;
                                                while (lines[i].IndexOf(";") != 0)
                                                {
                                                    dete.Append(lines[i] + " ");
                                                    i++;
                                                }

                                            }
                                            i++;
                                            string pdbx_evidence_code = lines[i].Trim();
                                            this.struct_site_list[name][id] = (new struct_site(name, id, dete.ToString(), pdbx_evidence_code));



                                        }

                                    }
                                }
                            }
                        }
                        else if (cif_part.IndexOf("_struct_site_gen.") >= 0)
                        {
                            foreach (string line in cif_part.Split('\n'))
                            {
                                if (line.IndexOf("_") != 0 && line.IndexOf("loop") == -1 && line.Length > 4)
                                {
                                    Console.WriteLine(line);
                                    string[] line_sp = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                    //Console.WriteLine("b"+line_sp.Length);
                                    struct_site_gen ssg = new struct_site_gen();
                                    ssg.id = line_sp[0];
                                    ssg.site_id = line_sp[1];
                                    int buf;
                                    //if(Int32.TryParse(line_sp[8],out buf))
                                    //{
                                    //    line_sp[8] = alphabet.Substring(buf-1, 1);
                                    //}
                                    ssg.auth_asym_id = line_sp[8];
                                    ssg.auth_seq_id = line_sp[9];

                                    //Console.WriteLine(line_sp[1]);

                                    this.struct_site_list[name][line_sp[1]].add_struct_site_gen(ssg);
                                }
                            }
                        }
                        else if (cif_part.IndexOf("_pdbx_poly_seq_scheme.") >= 0)
                        {

                            int amino_no = 1;
                            string[] lines = cif_part.Split('\n');
                            int auth_asym_id_no = -1;
                            for (int i = 1; i < lines.Length; i++)
                            {


                                string line = lines[i];
                                //if (line.IndexOf("auth_asym_id") > 0)
                                //{
                                //    auth_asym_id_no = i - 1;
                                //}

                                if (line.IndexOf("_") != 0 && line.IndexOf("loop_") == -1 && line.Length > 4)
                                {

                                    string[] line_sp = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                    //Console.WriteLine("c"+line_sp.Length);
                                    int seq_no;
                                    if (!seq_amino[name].ContainsKey(line_sp[0]))
                                    {
                                        seq_amino[name][line_sp[0]] = new Dictionary<int, int>();
                                    }
                                    if (Int32.TryParse(line_sp[6], out seq_no))
                                    {
                                        if (seq_no > 0)
                                        {
                                            seq_amino[name][line_sp[0]][seq_no] = amino_no;
                                            amino_no++;
                                        }
                                    }

                                }
                            }
                            foreach (KeyValuePair<string, struct_site> s_s in this.struct_site_list[name])
                            {
                                //foreach(struct_site_gen s_s_g in s_s.Value.struct_site_gen)

                                for (int j = 0; j < s_s.Value.struct_site_gen.Count; j++)
                                {
                                    string auth_asym_id = s_s.Value.struct_site_gen[j].auth_asym_id;
                                    if (seq_amino[name].ContainsKey(s_s.Value.struct_site_gen[j].auth_asym_id) && seq_amino[name][auth_asym_id].ContainsKey(Int32.Parse(s_s.Value.struct_site_gen[j].auth_seq_id)))
                                    {
                                        s_s.Value.struct_site_gen[j].amino_id = seq_amino[name][auth_asym_id][Int32.Parse(s_s.Value.struct_site_gen[j].auth_seq_id)];
                                    }
                                }
                            }



                        }
                    }


                }

            }

            Console.WriteLine("PDB_NAME,struct_site.id,_struct_site.details,_struct_site_gen.auth_asym_id,auth_seq_id,amino_id");
            foreach (KeyValuePair<string, Dictionary<string, struct_site>> s_s in this.struct_site_list)
            {
                string name = s_s.Key;
                Console.WriteLine(name);
                foreach (KeyValuePair<string, struct_site> s in s_s.Value)
                {


                    //string auth_asym_id="";
                    //StringBuilder auth_seq_id= new StringBuilder();
                    //StringBuilder amino_id = new StringBuilder();
                    //foreach(struct_site_gen s_s_g in s.Value.struct_site_gen)
                    //{
                    //    auth_asym_id = s_s_g.auth_asym_id;
                    //    auth_seq_id.Append(s_s_g.auth_seq_id + " ");
                    //    Console.WriteLine(s_s_g.auth_seq_id);
                    //    Console.WriteLine(auth_asym_id);
                    //    //if (seq_amino[name].ContainsKey(s_s_g.auth_asym_id) && seq_amino[name][auth_asym_id].ContainsKey(Int32.Parse(s_s_g.auth_seq_id))){
                    //    //    amino_id.Append(seq_amino[name][auth_asym_id][Int32.Parse(s_s_g.auth_seq_id)] + " ");
                    //    //}
                    //    amino_id.Append(s_s_g.amino_id+" ");
                    //}
                    //result.WriteLine(name+";"+s.Value.id + ";" + s.Value.details + ";" + auth_asym_id + ";" + auth_seq_id + ";" + amino_id );

                    result.WriteLine(s.Value.print());
                }
            }



        }
    }
}
