using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Entry
    {
        public StringBuilder main;
        public StringBuilder title;
        public String id;

        public Entry(StringBuilder title_in, StringBuilder main_in, String id_in)
        {
            title = title_in;
            main = new StringBuilder(main_in.ToString());
            id = id_in;
        }

        public static string ValidFileName(string s)
        {

            string valid = s;
            char[] invalidch = Path.GetInvalidFileNameChars();

            foreach (char c in invalidch)
            {
                valid = valid.Replace(c, '_');
            }
            return valid;
        }
    }
}
