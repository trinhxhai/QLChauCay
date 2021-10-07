using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChauCayCanh.Business
{
    public class CommonTask
    {
        
        public static DateTime StrToDate(string s)
        {
            return DateTime.Parse(s);
        }
        
        public static string NextId(string CurrentId)
        {
            if (String.IsNullOrEmpty(CurrentId))
            {
                return "000";
            }

            int id = int.Parse(CurrentId);
            id++;
            string ans = id.ToString();
            while (ans.Length < 3)
            {
                ans = "0" + ans;
            }
            return ans;
        }
    }
}
