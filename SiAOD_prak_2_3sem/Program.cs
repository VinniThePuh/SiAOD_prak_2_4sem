using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiAOD_prak_2_3sem
{
    static class Program
    {
        public struct data
        {
            public string date;
            public string num;
            public string val;
        }

        [STAThread]
        static void Main()
        {
            data[] arr = new data[4000];
            WebClient wc = new WebClient();
            string answer = wc.DownloadString("https://cbr.ru/currency_base/dynamics/?UniDbQuery.Posted=True&UniDbQuery.mode=1&UniDbQuery.date_req1=&UniDbQuery.date_req2=&UniDbQuery.VAL_NM_RQ=R01535&UniDbQuery.From=01.01.2010&UniDbQuery.To=01.01.2020");
            int length = answer.Length;

            Regex regex = new Regex(@"<td>(\S*)");
            MatchCollection matches = regex.Matches(answer);

            int j = 0;

            // qqq

            for (int i = 0; i < matches.Count; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        arr[j].date = matches[i].Value;
                        break;
                    case 1:
                        arr[j].num = matches[i].Value;
                        break;
                    case 2:
                        arr[j].val = matches[i].Value;
                        j++;
                        break;
                }
            }

            int n = j;
            j = 0;
            for (int i = 0; i < n; i++)
            {

                string str = "";
                for (int k = 0; k < arr[i].date.Length; k++)
                {
                    if (arr[i].date[k] != '<' && arr[i].date[k] != 't' && arr[i].date[k] != 'd' && arr[i].date[k] != '>' && arr[i].date[k] != '/' && arr[i].date[k] != '\n')
                    {
                        str += arr[i].date[k];
                    }
                }
                arr[i].date = str;
                Class1.transs[j] = str;
                str = "";
                for (int k = 0; k < arr[i].num.Length; k++)
                {
                    if (arr[i].num[k] != '<' && arr[i].num[k] != 't' && arr[i].num[k] != 'd' && arr[i].num[k] != '>' && arr[i].num[k] != '/')
                    {
                        str += arr[i].num[k];
                    }
                }
                arr[i].num = str;
                str = "";
                for (int k = 0; k < arr[i].val.Length; k++)
                {
                    if (arr[i].val[k] != '<' && arr[i].val[k] != 't' && arr[i].val[k] != 'd' && arr[i].val[k] != '>' && arr[i].val[k] != '/')
                    {
                        str += arr[i].val[k];
                    }
                }
                arr[i].val = str;

                Class1.transi[j] = double.Parse(str);
                j++;
                Class1.num = j;
                str = "";
            }
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

