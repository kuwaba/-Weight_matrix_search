using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    class Score_ex
    {

        Motif motif;
        String fasta;
        //int[,] MtoScore;
        int[,] ScorefromM;
        //int[,] ItoScore;
        int[,] ScorefromI;
        //int[,] DtoScore;
        int[,] ScorefromD;
        //int[,] BtoScore;
        int[] ScorefromB;
        //String[,] MtoString;
        string[,] StringM;
        //String[,] ItoString;
        string[,] StringI;
        //String[,] DtoString;
        string[,] StringD;
        //String[,] BtoString;
        string[] StringB;

        public int[] start_score_list;
        public string[] start_string_list;

        public Score_ex(Motif moti, String fast)
        {
            motif = moti;
            fasta = fast;
            //MtoScore = new int[fasta.Length + 1, moti.length + 1];
            //ItoScore = new int[fasta.Length + 1, moti.length + 1];
            //DtoScore = new int[fasta.Length + 1, moti.length + 1];
            //BtoScore = new int[fasta.Length + 1, moti.length + 1];
            //MtoScore[fasta.Length, moti.length] = ItoScore[fasta.Length, moti.length] = DtoScore[fasta.Length, moti.length] = BtoScore[fasta.Length, moti.length] = 0;
            ScorefromM = new int[fasta.Length + 1, 2];
            ScorefromI = new int[fasta.Length + 1, 2];
            ScorefromD = new int[fasta.Length + 1, 2];
            ScorefromB = new int[fasta.Length + 1];



            //MtoString = new String[fasta.Length + 1, moti.length + 1];
            //ItoString = new String[fasta.Length + 1, moti.length + 1];
            //DtoString = new String[fasta.Length + 1, moti.length + 1];
            //BtoString = new String[fasta.Length + 1, moti.length + 1];
            //MtoString[fasta.Length, moti.length] = ItoString[fasta.Length, moti.length] = DtoString[fasta.Length, moti.length] = BtoString[fasta.Length, moti.length] = "";
            StringM = new string[fasta.Length + 1, 2];
            StringI = new string[fasta.Length + 1, 2];
            StringD = new string[fasta.Length + 1, 2];
            StringB = new string[fasta.Length + 1];

            start_score_list = new int[fasta.Length];
            start_string_list = new string[fasta.Length];
            endset();
        }






        public int endset()
        {
            int e_score = 0;
            int e_index = motif.length;


            //内部終了スコアの格納
            if (motif.score_I.ContainsKey(e_index) && motif.score_I[e_index].ContainsKey("E1"))
            {
                e_score = motif.score_I[e_index]["E1"];
                Console.Write(motif.score_I[e_index]["E1"]);
            }
            else if (motif.default_score_I.ContainsKey("E1"))
            {
                e_score = motif.default_score_I["E1"];
            }
            else
            {
                e_score = -10000;
            }
            for (int i = 0; i <= fasta.Length; i++)
            {
                //MtoScore[i, e_index] = ItoScore[i, e_index] = DtoScore[i, e_index] = e_score;
                ScorefromM[i, 1] = ScorefromI[i, 1] = ScorefromD[i, 1] = e_score;
            }
            ////外部終了スコアの格納
            //for (int i = 0; i < motif.length - 1; i++)
            //{
            //    if (motif.score_I.ContainsKey(i) && motif.score_I[i].ContainsKey("E0"))
            //    {
            //        e_score = motif.score_I[i]["E0"];
            //    }
            //    else if (motif.default_score_I.ContainsKey("E0"))
            //    {
            //        e_score = motif.default_score_I["E0"];
            //    }
            //    else
            //    {
            //        e_score = -100000;
            //    }
            //    MtoScore[fasta.Length, i] = ItoScore[fasta.Length, i] = DtoScore[fasta.Length, i] = e_score;
            //}
            for (int p = 0; p < fasta.Length; p++)
            {
                ScorefromB[p] = -10000;

            }

            return 0;
        }

        char[] stalist = { 'M', 'D', 'I' };

        public int exam_score()
        {
            for (int m_index = motif.length - 1; m_index >= 0; m_index--)
            {
                int e0_score;
                if (motif.score_I.ContainsKey(m_index) && motif.score_I[m_index].ContainsKey("E0"))
                {
                    e0_score = motif.score_I[m_index]["E0"];
                }
                else if (motif.default_score_I.ContainsKey("E0"))
                {
                    e0_score = motif.default_score_I["E0"];
                }
                else
                {
                    //e_score = -100000;
                    e0_score = 0;
                }
                if (m_index != motif.length)
                {
                    ScorefromM[fasta.Length, 1] = ScorefromI[fasta.Length, 1] = ScorefromD[fasta.Length, 1] = e0_score;
                }
                ScorefromM[fasta.Length, 0] = ScorefromI[fasta.Length, 0] = ScorefromD[fasta.Length, 0] = e0_score;
                for (int p_index = fasta.Length - 1; p_index >= 0; p_index--)
                {
                    //Console.WriteLine(p_index + "\t" + m_index);


                    int m_score = -10000;
                    int i_score = -10000;
                    int d_score = -10000;
                    int e_score = -10000;
                    int max_score = -10000;

                    int bm_score = -10000;
                    int bi_score = -10000;
                    int bd_score = -10000;
                    int bmax_score = -10000;

                    String m_string = "";
                    String i_string = "";
                    String d_string = "";
                    String e_string = "";
                    String max_string = "";

                    string bm_string = "";
                    string bi_string = "";
                    string bd_string = "";
                    string bmax_string = "";



                    if (motif.score_I.ContainsKey(m_index))
                    {
                        foreach (char status in stalist)
                        {

                            m_score = -10000;
                            i_score = -10000;
                            d_score = -10000;
                            e_score = -10000;

                            if (m_index != 0)
                            {
                                if (motif.score_I[m_index].ContainsKey(status + "M"))
                                {
                                    m_score = motif.score_I[m_index][status + "M"];
                                    if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
                                    {
                                        m_score += motif.score_M[m_index][fasta[p_index].ToString()];
                                    }
                                    else
                                    {
                                        if (motif.score_M[m_index].ContainsKey("M0"))
                                        {
                                            m_score += motif.score_M[m_index]["M0"];
                                        }
                                    }
                                    //score_str.Append(fasta[p_index].ToString());
                                    //m_string = fasta[p_index].ToString() + MtoString[p_index + 1, m_index + 1];
                                    m_string = fasta[p_index].ToString() + StringM[p_index + 1, 1];
                                    //m_index++;
                                    //p_index++;
                                    //m_score += MtoScore[p_index + 1, m_index + 1];
                                    m_score += ScorefromM[p_index + 1, 1];

                                }
                                if (motif.score_I[m_index].ContainsKey(status + "D"))
                                {
                                    d_score = motif.score_I[m_index][status + "D"];
                                    if (motif.score_M[m_index].ContainsKey("DELETE"))
                                    {
                                        d_score += motif.score_M[m_index]["DELETE"];
                                    }
                                    else if (motif.default_score_I.ContainsKey("DELETE"))
                                    {
                                        d_score += motif.default_score_I["DELETE"];
                                    }
                                    //score_str.Append("-");
                                    //d_string = "-" + DtoString[p_index, m_index + 1];
                                    d_string = "-" + StringD[p_index, 1];
                                    //m_index++;
                                    ////p_index++;
                                    //d_score += DtoScore[p_index, m_index + 1];
                                    d_score += ScorefromD[p_index, 1];
                                }
                                if (motif.score_I[m_index].ContainsKey(status + "I"))
                                {
                                    i_score = motif.score_I[m_index][status + "I"];
                                    if (motif.score_I[m_index].ContainsKey(fasta[p_index].ToString().ToLower()))
                                    {
                                        //Console.Write(motif.score_I[m_index][fasta[p_index].ToString().ToLower()]);
                                        i_score += motif.score_I[m_index][fasta[p_index].ToString().ToLower()];
                                    }
                                    else if (motif.score_I[m_index].ContainsKey("INSERT"))
                                    {
                                        i_score += motif.score_I[m_index]["INSERT"];
                                    }
                                    if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                                    {
                                        if (motif.score_I[m_index].ContainsKey("I0"))
                                        {
                                            i_score += motif.score_I[m_index]["I0"];
                                        }
                                        else if (motif.default_score_I.ContainsKey("I0"))
                                        {
                                            i_score += motif.default_score_I["I0"];
                                        }
                                    }
                                    //score_str.Append(fasta[p_index].ToString().ToLower());
                                    //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                    i_string = fasta[p_index].ToString().ToLower() + StringI[p_index + 1, 0];
                                    ////m_index++;
                                    //p_index++;
                                    //i_score += ItoScore[p_index + 1, m_index];
                                    i_score += ScorefromI[p_index + 1, 0];
                                }
                                if (motif.score_I[m_index].ContainsKey(status + "E"))
                                {
                                    if (motif.score_I[m_index].ContainsKey("E1"))
                                    {
                                        e_score = motif.score_I[m_index][status + "E"];
                                        e_score += motif.score_I[m_index]["E1"];

                                        //score_str.Append(fasta[p_index].ToString().ToLower());
                                        //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                        e_string = "";
                                        for (int ei = m_index; ei < motif.length; ei++)
                                        {
                                            e_string = e_string + "-";
                                        }
                                    }
                                }
                            }


                            if (motif.score_I[m_index].ContainsKey("BM") && m_index == 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.score_I[m_index].ContainsKey("B0"))
                                    {
                                        m_score = motif.score_I[m_index]["B0"];
                                    }
                                    else
                                    {
                                        m_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.score_I[m_index].ContainsKey("B1"))
                                    {
                                        m_score = motif.score_I[m_index]["B1"];
                                    }
                                    else
                                    {
                                        m_score = -10000;
                                    }
                                }

                                m_score += motif.score_I[m_index]["BM"];
                                if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
                                {
                                    m_score += motif.score_M[m_index][fasta[p_index].ToString()];
                                }
                                else
                                {
                                    if (motif.score_M[m_index].ContainsKey("M0"))
                                    {
                                        m_score += motif.score_M[m_index]["M0"];
                                    }
                                }
                                //score_str.Append(fasta[p_index].ToString());
                                //m_string = fasta[p_index].ToString() + MtoString[p_index + 1, m_index + 1];
                                m_string = fasta[p_index].ToString() + StringM[p_index + 1, 1];
                                //m_index++;
                                //p_index++;
                                //m_score += MtoScore[p_index + 1, m_index + 1];
                                m_score += ScorefromM[p_index + 1, 1];
                            }
                            if (motif.score_I[m_index].ContainsKey("BD") && m_index == 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.score_I[m_index].ContainsKey("B0"))
                                    {
                                        d_score = motif.score_I[m_index]["B0"];
                                    }
                                    else
                                    {
                                        d_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.score_I[m_index].ContainsKey("B1"))
                                    {
                                        d_score = motif.score_I[m_index]["B1"];
                                    }
                                    else
                                    {
                                        d_score = -10000;
                                    }
                                }
                                d_score += motif.score_I[m_index]["BD"];
                                if (motif.score_M[m_index].ContainsKey("DELETE"))
                                {
                                    d_score += motif.score_M[m_index]["DELETE"];
                                }
                                //score_str.Append("-");
                                //d_string = "-" + DtoString[p_index, m_index + 1];
                                d_string = "-" + StringD[p_index, 1];
                                //m_index++;
                                ////p_index++;
                                //d_score += DtoScore[p_index, m_index + 1];
                                d_score += ScorefromD[p_index, 1];
                            }
                            if (motif.score_I[m_index].ContainsKey("BI") && m_index == 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.score_I[m_index].ContainsKey("B0"))
                                    {
                                        i_score = motif.score_I[m_index]["B0"];
                                    }
                                    else
                                    {
                                        i_score = -10000;
                                    }
                                }
                                else
                                {

                                    if (motif.score_I[m_index].ContainsKey("B1"))
                                    {
                                        i_score = motif.score_I[m_index]["B1"];
                                    }
                                    else
                                    {
                                        i_score = -10000;
                                    }
                                }
                                i_score += motif.score_I[m_index]["BI"];
                                if (motif.score_I[m_index].ContainsKey(fasta[p_index].ToString().ToLower()))
                                {
                                    i_score += motif.score_I[m_index][fasta[p_index].ToString().ToLower()];
                                }
                                else if (motif.score_I[m_index].ContainsKey("INSERT"))
                                {
                                    i_score += motif.score_I[m_index]["INSERT"];
                                }
                                else if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                                {
                                    if (motif.score_I[m_index].ContainsKey("I0"))
                                    {
                                        i_score += motif.score_I[m_index]["I0"];
                                    }
                                    else if (motif.default_score_I.ContainsKey("I0"))
                                    {
                                        i_score += motif.default_score_I["I0"];
                                    }
                                }
                                //score_str.Append(fasta[p_index].ToString().ToLower());
                                //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                i_string = fasta[p_index].ToString().ToLower() + StringI[p_index + 1, 0];
                                ////m_index++;
                                //p_index++;
                                //i_score += ItoScore[p_index + 1, m_index];
                                i_score += ScorefromI[p_index + 1, 0];
                            }
                            if (motif.score_I[m_index].ContainsKey("BM") && m_index != 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.score_I[m_index].ContainsKey("B0"))
                                    {
                                        bm_score = motif.score_I[m_index]["B0"];
                                    }
                                    else
                                    {
                                        bm_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.score_I[m_index].ContainsKey("B1"))
                                    {
                                        bm_score = motif.score_I[m_index]["B1"];
                                    }
                                    else
                                    {
                                        bm_score = -10000;
                                    }
                                }

                                bm_score += motif.score_I[m_index]["BM"];
                                if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
                                {
                                    bm_score += motif.score_M[m_index][fasta[p_index].ToString()];
                                }
                                else
                                {
                                    if (motif.score_M[m_index].ContainsKey("M0"))
                                    {
                                        bm_score += motif.score_M[m_index]["M0"];
                                    }
                                }
                                //score_str.Append(fasta[p_index].ToString());
                                //m_string = fasta[p_index].ToString() + MtoString[p_index + 1, m_index + 1];
                                bm_string = fasta[p_index].ToString() + StringM[p_index + 1, 1];
                                //m_index++;
                                //p_index++;
                                //m_score += MtoScore[p_index + 1, m_index + 1];
                                bm_score += ScorefromM[p_index + 1, 1];
                            }
                            if (motif.score_I[m_index].ContainsKey("BD") && m_index != 0)
                            {

                                if (p_index == 0)
                                {
                                    if (motif.score_I[m_index].ContainsKey("B0"))
                                    {
                                        bd_score = motif.score_I[m_index]["B0"];
                                    }
                                    else
                                    {
                                        bd_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.score_I[m_index].ContainsKey("B1"))
                                    {
                                        bd_score = motif.score_I[m_index]["B1"];
                                    }
                                    else
                                    {
                                        bd_score = -10000;
                                    }
                                }

                                bd_score += motif.score_I[m_index]["BD"];
                                if (motif.score_M[m_index].ContainsKey("DELETE"))
                                {
                                    bd_score += motif.score_M[m_index]["DELETE"];
                                }
                                //score_str.Append("-");
                                //d_string = "-" + DtoString[p_index, m_index + 1];
                                bd_string = "-" + StringD[p_index, 1];
                                //m_index++;
                                ////p_index++;
                                //d_score += DtoScore[p_index, m_index + 1];
                                bd_score += ScorefromD[p_index, 1];
                            }
                            if (motif.score_I[m_index].ContainsKey("BI") && m_index != 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.score_I[m_index].ContainsKey("B0"))
                                    {
                                        bi_score = motif.score_I[m_index]["B0"];
                                    }
                                    else
                                    {
                                        bi_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.score_I[m_index].ContainsKey("B1"))
                                    {
                                        bi_score = motif.score_I[m_index]["B1"];
                                    }
                                    else
                                    {
                                        bi_score = -10000;
                                    }
                                }


                                bi_score += motif.score_I[m_index]["BI"];
                                if (motif.score_I[m_index].ContainsKey(fasta[p_index].ToString().ToLower()))
                                {
                                    //Console.Write(motif.score_I[m_index][fasta[p_index].ToString().ToLower()]);
                                    i_score += motif.score_I[m_index][fasta[p_index].ToString().ToLower()];
                                }
                                else if (motif.score_I[m_index].ContainsKey("INSERT"))
                                {
                                    //Console.Write(motif.score_I[m_index]["INSERT"]);
                                    i_score += motif.score_I[m_index]["INSERT"];
                                }
                                if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                                {
                                    if (motif.score_I[m_index].ContainsKey("I0"))
                                    {
                                        i_score += motif.score_I[m_index]["I0"];
                                    }
                                    else if (motif.default_score_I.ContainsKey("I0"))
                                    {
                                        i_score += motif.default_score_I["I0"];
                                    }
                                }

                                //score_str.Append(fasta[p_index].ToString().ToLower());
                                //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                bi_string = fasta[p_index].ToString().ToLower() + StringI[p_index + 1, 0];
                                ////m_index++;
                                //p_index++;
                                //i_score += ItoScore[p_index + 1, m_index];
                                bi_score += ScorefromI[p_index + 1, 0];
                            }


                            //Console.WriteLine("M"+ m_score + "\tI"+ i_score + "\tD" + d_score);
                            if (d_score >= i_score && d_score >= m_score && d_score >= e_score)
                            {
                                max_score = d_score;
                                max_string = d_string;
                            }
                            else if (i_score >= m_score && i_score >= d_score && i_score >= e_score)
                            {
                                max_score = i_score;
                                max_string = i_string;
                            }
                            else if (e_score >= m_score && e_score >= d_score && e_score >= i_score)
                            {
                                max_score = e_score;
                                max_string = e_string;
                            }
                            else
                            {
                                max_score = m_score;
                                max_string = m_string;
                            }
                            if (p_index == fasta.Length - 1)
                            {
                                for (int nokori = (motif.length - m_index) - (fasta.Length - p_index); nokori > 0; nokori--)
                                {
                                    max_string = max_string + '-';
                                }

                            }




                            if (status == 'M')
                            {
                                //MtoScore[p_index, m_index] = max_score;
                                //MtoString[p_index, m_index] = max_string;
                                ScorefromM[p_index, 0] = max_score;
                                StringM[p_index, 0] = max_string;

                            }
                            else if (status == 'I')
                            {
                                //ItoScore[p_index, m_index] = max_score;
                                //ItoString[p_index, m_index] = max_string;
                                ScorefromI[p_index, 0] = max_score;
                                StringI[p_index, 0] = max_string;
                            }
                            else if (status == 'D')
                            {
                                //DtoScore[p_index, m_index] = max_score;
                                //DtoString[p_index, m_index] = max_string;
                                ScorefromD[p_index, 0] = max_score;
                                StringD[p_index, 0] = max_string;

                            }
                            //Console.WriteLine(max_score + ": " + max_string);
                            if (status == 'M')
                            {
                                int p_m = p_index - m_index;
                                if (p_index - m_index < 0) { p_m = p_index; }
                                if (bd_score >= bi_score && bd_score >= bm_score)
                                {
                                    bmax_score = bd_score;
                                    bmax_string = bd_string;
                                }
                                else if (bi_score >= bm_score && bi_score >= bd_score)
                                {
                                    bmax_score = bi_score;
                                    bmax_string = bi_string;
                                }
                                else
                                {
                                    bmax_score = bm_score;
                                    bmax_string = bm_string;
                                }
                                //if (bmax_string.Length != 0)
                                //{
                                //    bmax_string = '*' + bmax_string.Substring(1);
                                //}else
                                //{
                                //    bmax_string = '*' + bmax_string;
                                //}
                                for (int m = m_index; m > 0; m--)
                                {
                                    bmax_string = '-' + bmax_string;
                                }
                                //if (bmax_score > BtoScore[p_m, 0])
                                //if (bmax_score > ScorefromB[p_m])
                                if (bmax_score > ScorefromB[p_index])
                                {
                                    //BtoScore[p_m, 0] = bmax_score;
                                    //BtoString[p_m, 0] = bmax_string;
                                    //ScorefromB[p_m] = bmax_score;
                                    //StringB[p_m] = bmax_string;
                                    ScorefromB[p_index] = bmax_score;
                                    StringB[p_index] = bmax_string;

                                }


                            }
                        }

                    }
                    else   //挿入の行がない場合
                    {
                        foreach (char status in stalist)
                        {
                            m_score = -10000;
                            i_score = -10000;
                            d_score = -10000;
                            e_score = -10000;

                            if (m_index != 0)
                            {
                                if (motif.default_score_I.ContainsKey(status + "M"))
                                {
                                    m_score = motif.default_score_I[status + "M"];
                                    if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
                                    {
                                        m_score += motif.score_M[m_index][fasta[p_index].ToString()];
                                    }
                                    else
                                    {
                                        if (motif.default_score_I.ContainsKey("M0"))
                                        {
                                            m_score += motif.default_score_I["M0"];
                                        }
                                    }
                                    //score_str.Append(fasta[p_index].ToString());
                                    //m_string = fasta[p_index].ToString() + MtoString[p_index + 1, m_index + 1];
                                    m_string = fasta[p_index].ToString() + StringM[p_index + 1, 1];
                                    //m_index++;
                                    //p_index++;
                                    //m_score += MtoScore[p_index + 1, m_index + 1];
                                    m_score += ScorefromM[p_index + 1, 1];

                                }
                                if (motif.default_score_I.ContainsKey(status + "D"))
                                {
                                    d_score = motif.default_score_I[status + "D"];
                                    if (motif.default_score_I.ContainsKey("DELETE"))
                                    {
                                        d_score += motif.default_score_I["DELETE"];
                                    }
                                    else if (motif.default_score_I.ContainsKey("DELETE"))
                                    {
                                        d_score += motif.default_score_I["DELETE"];
                                    }
                                    //score_str.Append("-");
                                    //d_string = "-" + DtoString[p_index, m_index + 1];
                                    d_string = "-" + StringD[p_index, 1];
                                    //m_index++;
                                    ////p_index++;
                                    //d_score += DtoScore[p_index, m_index + 1];
                                    d_score += ScorefromD[p_index, 1];
                                }
                                if (motif.default_score_I.ContainsKey(status + "I"))
                                {
                                    i_score = motif.default_score_I[status + "I"];
                                    if (motif.default_score_I.ContainsKey(fasta[p_index].ToString().ToLower()))
                                    {
                                        //Console.Write(motif.default_score_I[fasta[p_index].ToString().ToLower()]);
                                        i_score += motif.default_score_I[fasta[p_index].ToString().ToLower()];
                                    }
                                    else if (motif.default_score_I.ContainsKey("INSERT"))
                                    {
                                        i_score += motif.default_score_I["INSERT"];
                                    }
                                    if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                                    {
                                        if (motif.default_score_I.ContainsKey("I0"))
                                        {
                                            i_score += motif.default_score_I["I0"];
                                        }
                                        else if (motif.default_score_I.ContainsKey("I0"))
                                        {
                                            i_score += motif.default_score_I["I0"];
                                        }
                                    }
                                    //score_str.Append(fasta[p_index].ToString().ToLower());
                                    //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                    i_string = fasta[p_index].ToString().ToLower() + StringI[p_index + 1, 0];
                                    ////m_index++;
                                    //p_index++;
                                    //i_score += ItoScore[p_index + 1, m_index];
                                    i_score += ScorefromI[p_index + 1, 0];
                                }
                                if (motif.default_score_I.ContainsKey(status + "E"))
                                {
                                    if (motif.default_score_I.ContainsKey("E1"))
                                    {
                                        e_score = motif.default_score_I[status + "E"];
                                        e_score += motif.default_score_I["E1"];

                                        //score_str.Append(fasta[p_index].ToString().ToLower());
                                        //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                        e_string = "";
                                        for (int ei = m_index; ei < motif.length; ei++)
                                        {
                                            e_string = e_string + "-";
                                        }
                                    }
                                }
                            }


                            if (motif.default_score_I.ContainsKey("BM") && m_index == 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.default_score_I.ContainsKey("B0"))
                                    {
                                        m_score = motif.default_score_I["B0"];
                                    }
                                    else
                                    {
                                        m_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.default_score_I.ContainsKey("B1"))
                                    {
                                        m_score = motif.default_score_I["B1"];
                                    }
                                    else
                                    {
                                        m_score = -10000;
                                    }
                                }

                                m_score += motif.default_score_I["BM"];
                                if (motif.default_score_I.ContainsKey(fasta[p_index].ToString()))
                                {
                                    m_score += motif.default_score_I[fasta[p_index].ToString()];
                                }
                                else
                                {
                                    if (motif.default_score_I.ContainsKey("M0"))
                                    {
                                        m_score += motif.default_score_I["M0"];
                                    }
                                }
                                //score_str.Append(fasta[p_index].ToString());
                                //m_string = fasta[p_index].ToString() + MtoString[p_index + 1, m_index + 1];
                                m_string = fasta[p_index].ToString() + StringM[p_index + 1, 1];
                                //m_index++;
                                //p_index++;
                                //m_score += MtoScore[p_index + 1, m_index + 1];
                                m_score += ScorefromM[p_index + 1, 1];
                            }
                            if (motif.default_score_I.ContainsKey("BD") && m_index == 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.default_score_I.ContainsKey("B0"))
                                    {
                                        d_score = motif.default_score_I["B0"];
                                    }
                                    else
                                    {
                                        d_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.default_score_I.ContainsKey("B1"))
                                    {
                                        d_score = motif.default_score_I["B1"];
                                    }
                                    else
                                    {
                                        d_score = -10000;
                                    }
                                }
                                d_score += motif.default_score_I["BD"];
                                if (motif.default_score_I.ContainsKey("DELETE"))
                                {
                                    d_score += motif.default_score_I["DELETE"];
                                }
                                //score_str.Append("-");
                                //d_string = "-" + DtoString[p_index, m_index + 1];
                                d_string = "-" + StringD[p_index, 1];
                                //m_index++;
                                ////p_index++;
                                //d_score += DtoScore[p_index, m_index + 1];
                                d_score += ScorefromD[p_index, 1];
                            }
                            if (motif.default_score_I.ContainsKey("BI") && m_index == 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.default_score_I.ContainsKey("B0"))
                                    {
                                        i_score = motif.default_score_I["B0"];
                                    }
                                    else
                                    {
                                        i_score = -10000;
                                    }
                                }
                                else
                                {

                                    if (motif.default_score_I.ContainsKey("B1"))
                                    {
                                        i_score = motif.default_score_I["B1"];
                                    }
                                    else
                                    {
                                        i_score = -10000;
                                    }
                                }
                                i_score += motif.default_score_I["BI"];
                                if (motif.default_score_I.ContainsKey(fasta[p_index].ToString().ToLower()))
                                {
                                    i_score += motif.default_score_I[fasta[p_index].ToString().ToLower()];
                                }
                                else if (motif.default_score_I.ContainsKey("INSERT"))
                                {
                                    i_score += motif.default_score_I["INSERT"];
                                }
                                else if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                                {
                                    if (motif.default_score_I.ContainsKey("I0"))
                                    {
                                        i_score += motif.default_score_I["I0"];
                                    }
                                    else if (motif.default_score_I.ContainsKey("I0"))
                                    {
                                        i_score += motif.default_score_I["I0"];
                                    }
                                }
                                //score_str.Append(fasta[p_index].ToString().ToLower());
                                //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                i_string = fasta[p_index].ToString().ToLower() + StringI[p_index + 1, 0];
                                ////m_index++;
                                //p_index++;
                                //i_score += ItoScore[p_index + 1, m_index];
                                i_score += ScorefromI[p_index + 1, 0];
                            }
                            if (motif.default_score_I.ContainsKey("BM") && m_index != 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.default_score_I.ContainsKey("B0"))
                                    {
                                        bm_score = motif.default_score_I["B0"];
                                    }
                                    else
                                    {
                                        bm_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.default_score_I.ContainsKey("B1"))
                                    {
                                        bm_score = motif.default_score_I["B1"];
                                    }
                                    else
                                    {
                                        bm_score = -10000;
                                    }
                                }

                                bm_score += motif.default_score_I["BM"];
                                if (motif.default_score_I.ContainsKey(fasta[p_index].ToString()))
                                {
                                    bm_score += motif.default_score_I[fasta[p_index].ToString()];
                                }
                                else
                                {
                                    if (motif.default_score_I.ContainsKey("M0"))
                                    {
                                        bm_score += motif.default_score_I["M0"];
                                    }
                                }
                                //score_str.Append(fasta[p_index].ToString());
                                //m_string = fasta[p_index].ToString() + MtoString[p_index + 1, m_index + 1];
                                bm_string = fasta[p_index].ToString() + StringM[p_index + 1, 1];
                                //m_index++;
                                //p_index++;
                                //m_score += MtoScore[p_index + 1, m_index + 1];
                                bm_score += ScorefromM[p_index + 1, 1];
                            }
                            if (motif.default_score_I.ContainsKey("BD") && m_index != 0)
                            {

                                if (p_index == 0)
                                {
                                    if (motif.default_score_I.ContainsKey("B0"))
                                    {
                                        bd_score = motif.default_score_I["B0"];
                                    }
                                    else
                                    {
                                        bd_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.default_score_I.ContainsKey("B1"))
                                    {
                                        bd_score = motif.default_score_I["B1"];
                                    }
                                    else
                                    {
                                        bd_score = -10000;
                                    }
                                }

                                bd_score += motif.default_score_I["BD"];
                                if (motif.default_score_I.ContainsKey("DELETE"))
                                {
                                    bd_score += motif.default_score_I["DELETE"];
                                }
                                //score_str.Append("-");
                                //d_string = "-" + DtoString[p_index, m_index + 1];
                                bd_string = "-" + StringD[p_index, 1];
                                //m_index++;
                                ////p_index++;
                                //d_score += DtoScore[p_index, m_index + 1];
                                bd_score += ScorefromD[p_index, 1];
                            }
                            if (motif.default_score_I.ContainsKey("BI") && m_index != 0)
                            {
                                if (p_index == 0)
                                {
                                    if (motif.default_score_I.ContainsKey("B0"))
                                    {
                                        bi_score = motif.default_score_I["B0"];
                                    }
                                    else
                                    {
                                        bi_score = -10000;
                                    }
                                }
                                else
                                {
                                    if (motif.default_score_I.ContainsKey("B1"))
                                    {
                                        bi_score = motif.default_score_I["B1"];
                                    }
                                    else
                                    {
                                        bi_score = -10000;
                                    }
                                }


                                bi_score += motif.default_score_I["BI"];
                                if (motif.default_score_I.ContainsKey(fasta[p_index].ToString().ToLower()))
                                {
                                    //Console.Write(motif.default_score_I[fasta[p_index].ToString().ToLower()]);
                                    i_score += motif.default_score_I[fasta[p_index].ToString().ToLower()];
                                }
                                else if (motif.default_score_I.ContainsKey("INSERT"))
                                {
                                    //Console.Write(motif.default_score_I["INSERT"]);
                                    i_score += motif.default_score_I["INSERT"];
                                }
                                if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                                {
                                    if (motif.default_score_I.ContainsKey("I0"))
                                    {
                                        i_score += motif.default_score_I["I0"];
                                    }
                                    else if (motif.default_score_I.ContainsKey("I0"))
                                    {
                                        i_score += motif.default_score_I["I0"];
                                    }
                                }

                                //score_str.Append(fasta[p_index].ToString().ToLower());
                                //i_string = fasta[p_index].ToString().ToLower() + ItoString[p_index + 1, m_index];
                                bi_string = fasta[p_index].ToString().ToLower() + StringI[p_index + 1, 0];
                                ////m_index++;
                                //p_index++;
                                //i_score += ItoScore[p_index + 1, m_index];
                                bi_score += ScorefromI[p_index + 1, 0];
                            }


                            //Console.WriteLine(p_index+"/" + m_index +"M"+ m_score + "\tI"+ i_score + "\tD" + d_score+ "\tE" + e_score);
                            if (d_score >= i_score && d_score >= m_score && d_score >= e_score)
                            {
                                max_score = d_score;
                                max_string = d_string;
                            }
                            else if (i_score >= m_score && i_score >= d_score && i_score >= e_score)
                            {
                                max_score = i_score;
                                max_string = i_string;
                            }
                            else if (e_score > m_score && e_score > d_score && e_score > i_score)
                            {
                                max_score = e_score;
                                max_string = e_string;
                            }
                            else
                            {
                                max_score = m_score;
                                max_string = m_string;
                            }
                            if (p_index == fasta.Length - 1)
                            {
                                for (int nokori = (motif.length - m_index) - (fasta.Length - p_index); nokori > 0; nokori--)
                                {
                                    max_string = max_string + '-';
                                }

                            }




                            if (status == 'M')
                            {
                                //MtoScore[p_index, m_index] = max_score;
                                //MtoString[p_index, m_index] = max_string;
                                ScorefromM[p_index, 0] = max_score;
                                StringM[p_index, 0] = max_string;

                            }
                            else if (status == 'I')
                            {
                                //ItoScore[p_index, m_index] = max_score;
                                //ItoString[p_index, m_index] = max_string;
                                ScorefromI[p_index, 0] = max_score;
                                StringI[p_index, 0] = max_string;
                            }
                            else if (status == 'D')
                            {
                                //DtoScore[p_index, m_index] = max_score;
                                //DtoString[p_index, m_index] = max_string;
                                ScorefromD[p_index, 0] = max_score;
                                StringD[p_index, 0] = max_string;

                            }
                            //Console.WriteLine(max_score + ": " + max_string);
                            if (status == 'M')
                            {
                                int p_m = p_index - m_index;
                                if (p_index - m_index < 0) { p_m = p_index; }
                                if (bd_score >= bi_score && bd_score >= bm_score)
                                {
                                    bmax_score = bd_score;
                                    bmax_string = bd_string;
                                }
                                else if (bi_score >= bm_score && bi_score >= bd_score)
                                {
                                    bmax_score = bi_score;
                                    bmax_string = bi_string;
                                }
                                else
                                {
                                    bmax_score = bm_score;
                                    bmax_string = bm_string;
                                }
                                //if (bmax_string.Length != 0)
                                //{
                                //    bmax_string = '*' + bmax_string.Substring(1);
                                //}else
                                //{
                                //    bmax_string = '*' + bmax_string;
                                //}
                                for (int m = m_index; m > 0; m--)
                                {
                                    bmax_string = '-' + bmax_string;
                                }
                                //if (bmax_score > BtoScore[p_m, 0])
                                //if (bmax_score > ScorefromB[p_m])
                                if (bmax_score > ScorefromB[p_index])
                                {
                                    //BtoScore[p_m, 0] = bmax_score;
                                    //BtoString[p_m, 0] = bmax_string;
                                    //ScorefromB[p_m] = bmax_score;
                                    //StringB[p_m] = bmax_string;
                                    ScorefromB[p_index] = bmax_score;
                                    StringB[p_index] = bmax_string;

                                }


                            }
                        }
                        //if (m_index == 0)
                        //{
                        //    if (p_index == 0)
                        //    {
                        //        if (motif.default_score_I.ContainsKey("B0"))
                        //        {
                        //            max_score = motif.default_score_I["B0"];
                        //        }
                        //        else
                        //        {
                        //            max_score = -10000;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (motif.default_score_I.ContainsKey("B1"))
                        //        {
                        //            max_score = motif.default_score_I["B1"];
                        //        }
                        //        else
                        //        {
                        //            max_score = -10000;
                        //        }
                        //    }

                        //}
                        ////max_score = motif.default_score_I[fasta[p_index].ToString()];
                        //if (motif.default_score_I.ContainsKey(fasta[p_index].ToString()))
                        //{
                        //    max_score = motif.default_score_I[fasta[p_index].ToString()];
                        //}
                        //else
                        //{
                        //    if (motif.default_score_I.ContainsKey("M0"))
                        //    {
                        //        max_score = motif.default_score_I["M0"];
                        //    }
                        //}
                        ////score_str.Append(fasta[p_index].ToString());
                        ////m_string = fasta[p_index].ToString() + MtoString[p_index + 1, m_index + 1];
                        //max_string = fasta[p_index].ToString() + StringM[p_index + 1, 1];
                        ////m_index++;
                        ////p_index++;
                        ////m_score += MtoScore[p_index + 1, m_index + 1];
                        //max_score += ScorefromM[p_index + 1, 1];

                        //if (p_index == fasta.Length - 1)
                        //{
                        //    //max_string = max_string + '$';
                        //    for (int nokori = (motif.length - m_index) - (fasta.Length - p_index) - 1; nokori > 0; nokori--)
                        //    {
                        //        max_string = max_string + '-';
                        //    }
                        //    if ((motif.length - m_index) - (fasta.Length - p_index) > 0)
                        //    {
                        //        if (motif.score_I.ContainsKey(m_index) && motif.score_I[m_index].ContainsKey("E0"))
                        //        {
                        //            max_score += motif.score_I[m_index]["E0"];
                        //        }
                        //        else if (motif.default_score_I.ContainsKey("E0"))
                        //        {
                        //            max_score += motif.default_score_I["E0"];
                        //        }
                        //    }
                        //}
                        ////} else if (m_index == motif.length - 1)
                        ////{
                        ////    if (motif.default_score_I.ContainsKey("E1"))
                        ////    {
                        ////        max_score += motif.default_score_I["E1"];
                        ////    }
                        ////}

                        ////MtoScore[p_index, m_index] = max_score;
                        ////MtoString[p_index, m_index] = max_string;
                        ////ItoScore[p_index, m_index] = max_score;
                        ////ItoString[p_index, m_index] = max_string;
                        ////DtoScore[p_index, m_index] = max_score;
                        ////DtoString[p_index, m_index] = max_string;
                        //ScorefromM[p_index, 0] = max_score;
                        //ScorefromI[p_index, 0] = max_score;
                        //ScorefromD[p_index, 0] = max_score;
                        //StringM[p_index, 0] = max_string;
                        //StringI[p_index, 0] = max_string;
                        //StringD[p_index, 0] = max_string;                   
                    }
                }
                //for(int i=0; i <= fasta.Length; i++)
                //{
                //    ScorefromM[i, 1] = ScorefromM[i, 0];
                //    ScorefromI[i, 1] = ScorefromI[i, 0];
                //    ScorefromD[i, 1] = ScorefromD[i, 0];
                //    StringM[i, 1] = StringM[i, 0];
                //    StringI[i, 1] = StringI[i, 0];
                //    StringD[i, 1] = StringD[i, 0];
                //    Console.Write(ScorefromM[i, 0] + ",");
                //}
                //Console.WriteLine("");
            }
            Console.WriteLine("");
            //それぞれの先頭から最も高いスコアを選ぶ。(ほんとはすべて同じ値?)
            for (int i = 0; i < fasta.Length; i++)
            {
                //Console.WriteLine((i + 1) + "行目M" + ScorefromM[i, 0] + ":" + StringM[i, 0]);
                //Console.WriteLine((i + 1) + "行目I" + ScorefromI[i, 0] + ":" + StringI[i, 0]);
                //if (MtoScore[i, 0] >= ItoScore[i, 0] && MtoScore[i, 0] >= DtoScore[i, 0] && MtoScore[i, 0] >= BtoScore[i, 0])
                if (ScorefromM[i, 0] >= ScorefromI[i, 0] && ScorefromM[i, 0] >= ScorefromD[i, 0] && ScorefromM[i, 0] >= ScorefromB[i])
                {
                    //start_score_list[i] = MtoScore[i, 0];
                    //start_string_list[i] = MtoString[i, 0];
                    start_score_list[i] = ScorefromM[i, 0];
                    start_string_list[i] = StringM[i, 0];
                }
                //else if ((ItoScore[i, 0] > MtoScore[i, 0] && ItoScore[i, 0] >= DtoScore[i, 0] && ItoScore[i, 0] >= BtoScore[i, 0]))
                else if ((ScorefromI[i, 0] > ScorefromM[i, 0] && ScorefromI[i, 0] >= ScorefromD[i, 0] && ScorefromI[i, 0] >= ScorefromB[i]))
                {
                    //start_score_list[i] = ItoScore[i, 0];
                    //start_string_list[i] = ItoString[i, 0];
                    start_score_list[i] = ScorefromI[i, 0];
                    start_string_list[i] = StringI[i, 0];
                }
                //else if ((DtoScore[i, 0] > MtoScore[i, 0] && DtoScore[i, 0] >= ItoScore[i, 0] && DtoScore[i, 0] >= BtoScore[i, 0]))
                else if ((ScorefromD[i, 0] > ScorefromM[i, 0] && ScorefromD[i, 0] >= ScorefromI[i, 0] && ScorefromD[i, 0] >= ScorefromB[i]))
                {
                    //start_score_list[i] = DtoScore[i, 0];
                    //start_string_list[i] = DtoString[i, 0];
                    start_score_list[i] = ScorefromD[i, 0];
                    start_string_list[i] = StringD[i, 0];
                }
                else
                {
                    //start_score_list[i] = BtoScore[i, 0];
                    //start_string_list[i] = BtoString[i, 0];
                    start_score_list[i] = ScorefromB[i];
                    start_string_list[i] = StringB[i];
                }
                //Console.Write(start_score_list[i] + ",");
            }

            //for(int i = motif.length; i > 0 ; i--)
            //{
            //    Console.WriteLine(MtoScore[53, i] + MtoString[53,i]);
            //}
            //Console.WriteLine(BtoScore[77, 0]);
            //Console.WriteLine(MtoScore[77, 0]);
            //Console.WriteLine(DtoScore[77, 0]);
            //Console.WriteLine(ItoScore[77, 0]);
            return 0;

        }
    }
}
