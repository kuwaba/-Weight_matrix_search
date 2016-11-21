using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score_exam
{
    class struct_site_gen
    {
        public string id { set; get; }
        public string site_id { set; get; }
        public string auth_asym_id { set; get; }
        public string auth_seq_id { set; get; }
        public int amino_id { set; get; }
        public string auth_comp_id_3 { set; get; }
        public string auth_comp_id_1
        {
            get {
                //Console.Write(auth_comp_id_3.ToUpper());
                if (amino3to1.ContainsKey(auth_comp_id_3.ToUpper()))
                {
                    return amino3to1[auth_comp_id_3.ToUpper()];
                }
                return " ";
            }
        }

        Dictionary<string, string> amino3to1 = new Dictionary<string, string>()
        {
            { "ALA" , "A"},
            { "ASX" , "B"},
            { "CYS" , "C"},
            { "ASP" , "D"},
            { "GLU" , "E"},
            { "PHE" , "F"},
            { "GLY" , "G"},
            { "HIS" , "H"},
            { "ILE" , "I"},
            { "LYS" , "K"},
            { "LEU" , "L"},
            { "MET" , "M"},
            { "ASN" , "N"},
            { "PRO" , "P"},
            { "GLN" , "Q"},
            { "ARG" , "R"},
            { "SER" , "S"},
            { "THR" , "T"},
            { "SEC" , "U"},
            { "VAL" , "V"},
            { "TRP" , "W"},
            { "XAA" , "X"},
            { "TYR" , "Y"},
            { "GLX" , "Z"}
        };



    }
}
