using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDB_split
{
    class struct_site
    {
        public string id { get; }
        public string details { get; }
        public string pdbx_evidence_code { get; }
        public List<struct_site_gen> struct_site_gen { get; } 
        public string pdbid { get; set; }

        public struct_site(string pdbid,string id, string details, string pdbx_evidence_code)
        {
            this.id = id;
            this.details = details;
            this.pdbx_evidence_code = pdbx_evidence_code;
            struct_site_gen = new List<PDB_split.struct_site_gen>();
            this.pdbid = pdbid;
        }

        public void add_struct_site_gen(struct_site_gen ssg)
        {
            struct_site_gen.Add(ssg);
        }

        public List<int> amino_list()
        {
            List<int> retun_list = new List<int>();
            foreach(struct_site_gen ssg in this.struct_site_gen)
            {
                retun_list.Add( ssg.amino_id);
            }
            return retun_list;
        }

        public string print()
        {
            string name = this.id;
            Console.WriteLine(name);
            
                string auth_asym_id = "";
                StringBuilder auth_seq_id = new StringBuilder();
                StringBuilder amino_id = new StringBuilder();
                foreach (struct_site_gen s_s_g in this.struct_site_gen)
                {
                    auth_asym_id = s_s_g.auth_asym_id;
                    auth_seq_id.Append(s_s_g.auth_seq_id + " ");
                    Console.WriteLine(s_s_g.auth_seq_id);
                    Console.WriteLine(auth_asym_id);
                    //if (seq_amino[name].ContainsKey(s_s_g.auth_asym_id) && seq_amino[name][auth_asym_id].ContainsKey(Int32.Parse(s_s_g.auth_seq_id)))
                    //{
                    //    amino_id.Append(seq_amino[name][auth_asym_id][Int32.Parse(s_s_g.auth_seq_id)] + " ");
                    //}
                    amino_id.Append(s_s_g.amino_id + " ");
                }
                
            
            return pdbid + ";" +id + ";" + details + ";" + auth_asym_id + ";" + auth_seq_id + ";" + amino_id;
        }
        
    }
}
