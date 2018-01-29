using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sxva_saqartvelo_back_end.Helpers
{
    public class PasswordHashHelper
    {
        //Password Hash
        public string MD5Hash(string input)
        {
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            string md5 = "";
            for (int i = 0; i < data.Length; i++)
            {
                md5 += data[i].ToString("x2");
            }
            return md5;
        }
    }
}