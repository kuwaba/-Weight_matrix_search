using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score_exam
{
    class struct_conf_list
    {
        public List<struct_conf> s_c_list = new List<struct_conf>();
        public string return_struct(int seq_no,string auth_asym_id)
        {
            string str = "*";
            //Console.Write(seq_no + ",");
            foreach (struct_conf s_c in this.s_c_list)
            {
             
                if (s_c.beg_auth_asym_id == auth_asym_id && s_c.beg_auth_seq_id <= seq_no && s_c.end_auth_seq_id >= seq_no)
                {
                    
                    str = s_c.conf_type_id.Substring(0, 1);
                }
            }
            return str;
        }
    }

    
}
