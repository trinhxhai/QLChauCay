using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        // String validation 
        public bool IsOnlyUnicode(String s)
        {
            return Regex.IsMatch(s, "[^\u0000-\u007F]");
        }


        // image


        public static List<string> AllowImageExtentions()
        {
            return new List<string> { ".png", ".jpg" };
        }
        public static Image BytesToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] stringToBytes(string src)
        {
            int numOfBytes = src.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(src.Substring(8 * i, 16));
            }
            return bytes;
        }

        
    }

    
}
