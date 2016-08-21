using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{
    class Score
    {
        public int score;
        public double N_score;
        List<Score> score_list = new List<Score>();
        public StringBuilder score_str = new StringBuilder();
        public List<int> num_list = new List<int>();
        char status;
        Motif motif;
        String fasta;
        int m_index;
        int p_in;
        public int well_score;
        public StringBuilder well_score_str = new StringBuilder();
        int p_index;
        List<int> score_stack = new List<int>();
        List<char> status_stack = new List<char>();

        public Score(int s, StringBuilder s_str, int m_in, char sta, Motif moti, String fast, int p_in, int well)
        {
            score = s;
            score_str = s_str;
            status = sta;
            motif = moti;
            fasta = fast;
            m_index = m_in;
            this.p_in = p_in;
            well_score = well;
        }


        //public List<Score> exam_score()
        //{


        //    int buf = score;

        //    StringBuilder buf_str = score_str;
        //    //Console.Write( well_score - motif.cutoff_score_list[m_index]);
        //    for (int p_index = p_in; m_index <= motif.length && p_index < fasta.Length; p_index++)
        //    {
        //        num_list.Add(buf);
        //        List<KeyValuePair<string, int>> in_list;
        //        //Console.WriteLine(status + " " + score_str + " " + (buf + motif.cutoff_score_list[m_index]) +"<"+ well_score);
        //        //Console.Write(status);
        //        //if (buf < (motif.cutoff_score_list[m_index] - well_score)) { return score_list; }
        //        if ((buf + motif.cutoff_score_list[m_index]) < well_score) { return score_list; }
        //        if (motif.score_I.ContainsKey(m_index))
        //        {

        //            int iscore;
        //            string istatus;
        //            if (m_index == motif.length) { status = 'E'; istatus = "E"; }
        //            if (m_index < motif.length && p_index >= fasta.Length - 1)
        //            {
        //                if (motif.default_score_I.ContainsKey("E0"))
        //                {
        //                    buf += motif.default_score_I["E0"];
        //                }
        //                for (int m = m_index; m < motif.length; m++)
        //                {
        //                    buf_str.Append("-");
        //                }
        //            }
        //            in_list = new List<KeyValuePair<string, int>>(motif.score_I[m_index]);
        //            iscore = in_list[0].Value;
        //            istatus = in_list[0].Key;
        //            int m_buf = m_index;
        //            int buf_buf = buf;
        //            StringBuilder buf_str_buf = new StringBuilder().Append(buf_str);
        //            char status_buf = status;
        //            //bool in_f = false;
        //            for (int inbuf = 0; inbuf < in_list.Count; inbuf++)
        //            {
        //                if (in_list[inbuf].Key[0] == status && in_list[inbuf].Key.Length != 1)
        //                {
        //                    iscore = in_list[inbuf].Value;
        //                    istatus = in_list[inbuf].Key;

        //                    if (status == 'B')
        //                    {
        //                        buf_buf = motif.score_I[m_index]["B1"];
        //                        buf = motif.score_I[m_index]["B1"];
        //                        //buf_buf += motif.score_M[m_index][fasta[p_index].ToString()];
        //                        //buf_str_buf.Append(fasta[p_index].ToString());
        //                        //status_buf = 'M';
        //                        //status = 'M';
        //                        //m_buf++;
        //                    }

        //                    //if (istatus[0] == 'B')
        //                    //{
        //                    //    int b_buf = motif.score_I[m_index]["B1"];
        //                    //    StringBuilder b_str = new StringBuilder();
        //                    //    for (int i = 0; i < m_index; i++)
        //                    //    {
        //                    //        b_str.Append("-");
        //                    //    }
        //                    //    switch (istatus[istatus.Length - 1])
        //                    //    {


        //                    //        case 'M':
        //                    //            Score sco_bm;


        //                    //            if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
        //                    //            {
        //                    //                sco_bm = new Score(b_buf + iscore + motif.score_M[m_index][fasta[p_index].ToString()], new StringBuilder(b_str.ToString() + fasta[p_index].ToString()), m_index + 1, 'M', motif, fasta, p_index + 1, well_score);
        //                    //            }
        //                    //            else
        //                    //            {
        //                    //                sco_bm = new Score(b_buf + iscore + motif.score_M[m_index]["M0"], b_str, m_index + 1, 'M', motif, fasta, p_index + 1, well_score);

        //                    //            }
        //                    //            score_list.AddRange(sco_bm.exam_score());

        //                    //            break;
        //                    //        case 'I':
        //                    //            Score sco_bi;


        //                    //            if (motif.score_I[m_index].ContainsKey(fasta[p_index].ToString().ToLower()))
        //                    //            {
        //                    //                sco_bi = new Score(b_buf + iscore + motif.score_I[m_index][fasta[p_index].ToString().ToLower()],new StringBuilder( b_str.Append(fasta[p_index].ToString().ToLower()).ToString()), m_index, 'I', motif, fasta, p_index + 1, well_score);
        //                    //            }
        //                    //            else
        //                    //            {
        //                    //                sco_bi = new Score(b_buf + iscore, b_str.Append(fasta[p_index].ToString().ToLower()), m_index, 'I', motif, fasta, p_index + 1, well_score);

        //                    //            }
        //                    //            score_list.AddRange(sco_bi.exam_score());


        //                    //            break;
        //                    //        case 'D':
        //                    //            Score sco_bd;

        //                    //            sco_bd = new Score(buf + iscore + motif.score_M[m_index]["DELETE"], new StringBuilder(b_str.ToString() + "-"), m_index + 1, 'D', motif, fasta, p_index, well_score);
        //                    //            score_list.AddRange(sco_bd.exam_score());

        //                    //            break;


        //                    //    }
        //                    //}
        //                    //else
        //                    //{

        //                        switch (istatus[istatus.Length - 1])
        //                        {

        //                            case '1':
        //                                if (istatus[0] == 'E')
        //                                {
        //                                    //Console.WriteLine(p_index);
        //                                    buf_buf += iscore;
        //                                    m_buf = motif.length + 1;

        //                                }
        //                                break;
        //                            case 'M':
        //                                //Score sco_md = new Score(buf + iscore + motif.default_score_I["D"], new StringBuilder(buf_str.ToString() + "-"), m_index + 1, 'D', motif, fasta, p_index, new List<int>());
        //                                //score_list.AddRange(sco_md.exam_score());
        //                                buf_buf += iscore;
        //                                if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
        //                                {
        //                                    buf_buf += motif.score_M[m_index][fasta[p_index].ToString()];
        //                                }
        //                                else
        //                                {
        //                                    buf_buf += motif.score_M[m_index]["M0"];
        //                                }
        //                                buf_str_buf.Append(fasta[p_index].ToString());
        //                                status_buf = 'M';
        //                                m_buf++;
        //                                num_list.Add(buf);
        //                                //in_f = false;

        //                                break;
        //                            case 'I':

        //                                //in_f = true;
        //                                //buf += iscore;
        //                                //buf_str.Append(fasta[p_index].ToString().ToLower());
        //                                //status = 'I';
        //                                //Score sco_i = new Score(buf + iscore + motif.score_I[m_index]["I"], new StringBuilder(buf_str.ToString() + fasta[p_index].ToString().ToLower()), m_index, 'I', motif, fasta, p_index + 1, new List<int>());
        //                                Score sco_i;
        //                                if (motif.score_I[m_index].ContainsKey(fasta[p_index].ToString().ToLower()))
        //                                {
        //                                    sco_i = new Score(buf + iscore + motif.score_I[m_index]["I"] + motif.score_I[m_index][fasta[p_index].ToString().ToLower()], new StringBuilder(buf_str.ToString() + fasta[p_index].ToString().ToLower()), m_index, 'I', motif, fasta, p_index + 1, well_score);
        //                                }
        //                                else
        //                                {
        //                                    sco_i = new Score(buf + iscore + motif.score_I[m_index]["I"], new StringBuilder(buf_str.ToString() + fasta[p_index].ToString().ToLower()), m_index, 'I', motif, fasta, p_index + 1, well_score);
        //                                }
        //                                score_list.AddRange(sco_i.exam_score());

        //                                break;
        //                            case 'D':
        //                                //buf += iscore;
        //                                //buf_str.Append("-");
        //                                //status = 'D';
        //                                //m_index++;
        //                                //Score sco_d = new Score(buf + iscore, new StringBuilder(buf_str.ToString() + "-"), m_index+1, 'D', motif, fasta, p_index + 1);

        //                                //Score sco_d = new Score(buf + iscore, new StringBuilder(buf_str.ToString() + "-"), m_index + 1, 'D', motif, fasta, p_index + 1, new List<int>());

        //                                Score sco_d = new Score(buf + iscore + motif.score_M[m_index]["DELETE"], new StringBuilder(buf_str.ToString() + "-"), m_index + 1, 'D', motif, fasta, p_index, well_score);
        //                                score_list.AddRange(sco_d.exam_score());

        //                                break;


        //                        }
        //                    //}
        //                }
        //            }
        //            status = status_buf;
        //            m_index = m_buf;
        //            //m_index = m_index + 1;
        //            buf = buf_buf;
        //            buf_str = buf_str_buf;
        //            //list.Reverse();

        //        }
        //        else
        //        {
        //            //Score sco_md = new Score(buf +  motif.default_score_I["D"], new StringBuilder(buf_str.ToString() + "-"), m_index + 1, 'D', motif, fasta, p_index, new List<int>());
        //            //score_list.AddRange(sco_md.exam_score());
        //            //Console.Write(fasta[p_index].ToString() + motif.score_M[m_index][fasta[p_index].ToString()]);
        //            buf += motif.score_M[m_index][fasta[p_index].ToString()];
        //            buf_str.Append(fasta[p_index].ToString());
        //            m_index++;
        //            status = 'M';


        //        }


        //    }
        //    score_str = buf_str;
        //    score = buf;
        //    if (well_score < score)
        //    {
        //        //Console.Write(well_score + "->" + score);
        //        well_score = score;
        //    }
        //    score_list.Insert(0, this);
        //    return score_list;
        //}




        public int exam_scrore()
        {


            bool end = false;
            
            //Console.Write(fasta.Length);
            //Console.Write(status);
            //以下の場合は探索の終了
            if (m_index == motif.length) //モチーフの最後まで探索した
            {
                //内部終了スコアの加算
                if (motif.score_I.ContainsKey(m_index) && motif.score_I[m_index].ContainsKey("E1"))
                {
                     score += motif.score_I[m_index]["E1"];
                }
                else if (motif.default_score_I.ContainsKey("E1"))
                {
                    score += motif.default_score_I["E1"];
                }
                //優秀だったら更新
                if (well_score < score)
                {
                    well_score = score;
                    //先頭が開始出なかったら
                    if (status_stack.LastIndexOf('B') > 1)
                    {
                        int b_index = status_stack.IndexOf('B');
                        StringBuilder score_str_b = new StringBuilder(score_str.ToString());
                        score_str_b.Remove(0, b_index);
                        for (int i = 0; i < b_index; i++)
                        {
                            score_str_b.Insert(0, '-');
                        }
                        well_score_str = score_str_b;
                    }
                    else
                    {
                        well_score_str = new StringBuilder( score_str.ToString());
                    }
                    //Console.WriteLine(well_score + " " + well_score_str);
                }
                end = true;

            }
            //else if (m_index < motif.length && p_index >= fasta.Length - 1) //fastaの最後まで探索した
            else if (m_index < motif.length && p_index >= fasta.Length - 1) //fastaの最後まで探索した
            {
                //外部終了スコアの加算
                if (motif.score_I.ContainsKey(m_index) && motif.score_I[m_index].ContainsKey("E0"))
                {
                    score += motif.score_I[m_index]["E0"];
                }
                else if (motif.default_score_I.ContainsKey("E0"))
                {
                    score += motif.default_score_I["E0"];
                }
                StringBuilder score_str_b = new StringBuilder(score_str.ToString());
                for (int m = m_index; m < motif.length; m++)
                {
                    score_str_b.Append("-");
                }
                //優秀だったら更新
                if (well_score < score)
                {
                    well_score = score;
                    well_score_str = score_str_b;
                }
                end = true;
            }
            //枝刈りと終了だったものの巻き戻し
            //onsole.WriteLine(score + motif.cutoff_score_list[m_index] + " < " + well_score + "\t" + new String(status_stack.ToArray()) + " " + score_str +"あ");
            if (((score + motif.cutoff_score_list[m_index]) < well_score) || end || (motif.length - m_index > fasta.Length - p_index && score + motif.cutoff_score_list[m_index] - motif.cutoff_score_list[m_index + fasta.Length - p_index] < well_score))//今のスコア+今後のマッチ数で最大加算されるスコア < 現在の優秀スコア
            {
                //Console.Write(end.ToString() + "い");
                //なるつもりだったステータスにより進めた探索位置を巻き戻す
                if (status == 'M')
                {
                    m_index--;
                    p_index--;
                }
                else if (status == 'D')
                {
                    m_index--;
                    //p_index--;
                }
                else if (status == 'I')
                {
                    //m_index--;
                    p_index--;
                }
                //ステータスとスコアと文字列をを前に戻す
                if (score_stack.Count != 0)
                {
                    score = score_stack[score_stack.Count - 1];
                    status = status_stack[status_stack.Count - 1];
                    if (status == 'B')
                    {
                        status_stack.RemoveAt(status_stack.Count - 1);
                        status = status_stack[status_stack.Count - 1];
                    }
                    score_str.Remove(score_str.Length - 1, 1);
                }
                return -1;
            }
            //if(motif.length - m_index > fasta.Length - p_index)
            //{
            //    if()
            //    Console.WriteLine(score + motif.cutoff_score_list[m_index] + " < " + well_score + new String(status_stack.ToArray()) + " " + score_str);
            //    Console.WriteLine(score + motif.cutoff_score_list[m_index] - motif.cutoff_score_list[m_index + fasta.Length - p_index] + " < " + well_score + new String(status_stack.ToArray()) + " " + score_str);
            //}

            score_stack.Add(score);
            status_stack.Add(status);
            //Console.WriteLine(status + " " + score_str);
            
            if (motif.score_I.ContainsKey(m_index))
            {


                if (m_index != 0)
                {
                    if (motif.score_I[m_index].ContainsKey(status + "M"))
                    {
                        score += motif.score_I[m_index][status + "M"];
                        if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
                        {
                            score += motif.score_M[m_index][fasta[p_index].ToString()];
                        }
                        else
                        {
                            if (motif.score_M[m_index].ContainsKey("M0"))
                            {
                                score += motif.score_M[m_index]["M0"];
                            }
                        }
                        status = 'M';
                        score_str.Append(fasta[p_index].ToString());
                        m_index++;
                        p_index++;
                        exam_scrore();
                    }
                    if (motif.score_I[m_index].ContainsKey(status + "D"))
                    {
                        score += motif.score_I[m_index][status + "D"];
                        if (motif.score_M[m_index].ContainsKey("DELETE"))
                        {
                            score += motif.score_M[m_index]["DELETE"];
                        }
                        status = 'D';
                        score_str.Append("-");
                        m_index++;
                        //p_index++;
                        exam_scrore();
                    }
                    if (motif.score_I[m_index].ContainsKey(status + "I"))
                    {
                        bool i10 = true;
                        for(int i = 1; i < 10; i++)
                        {
                            if (status_stack.Count - i > 0)
                            {
                                if ('I' != status_stack[status_stack.Count - i])
                                {
                                    i10 = false;
                                }
                            }else
                            {
                                i10=false;
                            }
                        }
                        if (!i10)
                        {
                            score += motif.score_I[m_index][status + "I"];
                            if (motif.score_I[m_index].ContainsKey(fasta[p_index].ToString().ToLower()))
                            {
                                score += motif.score_I[m_index][fasta[p_index].ToString().ToLower()];
                            }else if (motif.score_I[m_index].ContainsKey("alpha"))
                            {
                                score += motif.score_I[m_index]["alpha"];
                            }
                            else if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                            {
                                if (motif.score_I[m_index].ContainsKey("I0"))
                                {
                                    score += motif.score_I[m_index]["I0"];
                                }
                                else if (motif.default_score_I.ContainsKey("I0"))
                                {
                                    score += motif.default_score_I["I0"];
                                }
                            }
                            status = 'I';
                            score_str.Append(fasta[p_index].ToString().ToLower());
                            //m_index++;
                            p_index++;
                            exam_scrore();
                        }
                    }
                }

                if (motif.score_I[m_index].ContainsKey("BM") && m_index == 0)
                {

                    if (motif.score_I[m_index].ContainsKey("B1"))
                    {
                        score = motif.score_I[m_index]["B1"];
                    }
                    else
                    {
                        score = 0;
                    }
                    status_stack.Add('B');
                    score += motif.score_I[m_index]["BM"];
                    if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
                    {
                        score += motif.score_M[m_index][fasta[p_index].ToString()];
                    }
                    else
                    {
                        if (motif.score_M[m_index].ContainsKey("M0"))
                        {
                            score += motif.score_M[m_index]["M0"];
                        }
                    }
                    status = 'M';
                    score_str.Append(fasta[p_index].ToString());
                    m_index++;
                    p_index++;
                    exam_scrore();
                }
                if (motif.score_I[m_index].ContainsKey("BD") && m_index == 0)
                {

                    if (motif.score_I[m_index].ContainsKey("B1"))
                    {
                        score = motif.score_I[m_index]["B1"];
                    }
                    else
                    {
                        score = 0;
                    }
                    status_stack.Add('B');
                    score += motif.score_I[m_index]["BD"];
                    if (motif.score_M[m_index].ContainsKey("DELETE"))
                    {
                        score += motif.score_M[m_index]["DELETE"];
                    }
                    status = 'D';
                    score_str.Append("-");
                    m_index++;
                    //p_index++;
                    exam_scrore();
                }
                if (motif.score_I[m_index].ContainsKey("BI") && m_index == 0)
                {

                    if (motif.score_I[m_index].ContainsKey("B1"))
                    {
                        score = motif.score_I[m_index]["B1"];
                    }
                    else
                    {
                        score = 0;
                    }
                    status_stack.Add('B');
                    score += motif.score_I[m_index]["BI"];
                    if (motif.score_I[m_index].ContainsKey(fasta[p_index].ToString().ToLower()))
                    {
                        score += motif.score_I[m_index][fasta[p_index].ToString().ToLower()];
                    }
                    else if (motif.alphabet.ToString().IndexOf(fasta[p_index].ToString()) == -1)
                    {
                        if (motif.score_I[m_index].ContainsKey("I0"))
                        {
                            score += motif.score_I[m_index]["I0"];
                        }
                        else if (motif.default_score_I.ContainsKey("I0"))
                        {
                            score += motif.default_score_I["I0"];
                        }
                    }
                    status = 'I';
                    score_str.Append(fasta[p_index].ToString().ToLower());
                    //m_index++;
                    p_index++;
                    exam_scrore();
                }



            }
            else
            {

                if (motif.score_M[m_index].ContainsKey(fasta[p_index].ToString()))
                {
                    score += motif.score_M[m_index][fasta[p_index].ToString()];
                }
                else
                {
                    if (motif.score_M[m_index].ContainsKey("M0"))
                    {
                        score += motif.score_M[m_index]["M0"];
                    }
                }
                status = 'M';
                score_str.Append(fasta[p_index].ToString());
                m_index++;
                p_index++;
                exam_scrore();
            }
            if (status == 'M')
            {
                m_index--;
                p_index--;
            }
            else if (status == 'D')
            {
                m_index--;
                //p_index--;
            }
            else if (status == 'I')
            {
                //m_index--;
                p_index--;
            }
          
            score_stack.RemoveAt(score_stack.Count - 1);
            status_stack.RemoveAt(status_stack.Count - 1);
            //ステータスとスコアと文字列をを前に戻す
            if (score_stack.Count != 0)
            {
                score = score_stack[score_stack.Count - 1];
                status = status_stack[status_stack.Count - 1];
                if (status == 'B')
                {
                    status_stack.RemoveAt(status_stack.Count - 1);
                    status = status_stack[status_stack.Count - 1];
                }
                score_str.Remove(score_str.Length - 1, 1);
            }
            
            return 0;
        }

    }
}
