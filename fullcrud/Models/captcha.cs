using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fullcrud.Models
{
    public class captcha
    {
        public string CaptchaCode()
        {
            char ch1, ch2, ch3, ch4, ch5, ch6;
            Random r = new Random();
            ch1 = (char)(r.Next(65, 92));
            ch2 = (char)(r.Next(97, 122));
            ch3 = (char)(r.Next(50, 55));
            ch4 = (char)(r.Next(78, 92));
            ch5 = (char)(r.Next(100, 122));
            ch6 = (char)(r.Next(50, 55));
            string cph = ch1 + "" + ch2 + "" + ch3 + "" + ch4 + "" + ch5 + "" + ch6;
            return cph;

        }




    }
}



