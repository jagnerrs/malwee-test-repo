using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MalweeTest.Web
{
    public static class Util
    {
        public static string MonthDescription(int mes)
        {
            string result = string.Empty;

            switch (mes)
            {
                case 1:
                    result = "JANEIRO";
                    break;
                case 2:
                    result = "FEVEREIRO";
                    break;
                case 3:
                    result = "MARÇO";
                    break;
                case 4:
                    result = "ABRIL";
                    break;
                case 5:
                    result = "MAIO";
                    break;
                case 6:
                    result = "JUNHO";
                    break;
                case 7:
                    result = "JULHO";
                    break;
                case 8:
                    result = "AGOSTO";
                    break;
                case 9:
                    result = "SETEMBRO";
                    break;
                case 10:
                    result = "OUTUBRO";
                    break;
                case 11:
                    result = "NOVEMBRO";
                    break;
                case 12:
                    result = "DEZEMBRO";
                    break;
                default:
                    break;
            }


            return result;
        }
    }
}