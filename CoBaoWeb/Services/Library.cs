using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoBaoWeb.Services
{
    public class Library
    {
        public static string NumberToText(Int64 number)
        {
            var so = new[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            var hang = new[] { "", "nghìn", "triệu", "tỉ" };
            int i, j;
            int donvi, chuc, tram;
            string str;
            string sNumber = number.ToString();
            str = "";
            i = number.ToString().Length;
            j = 0;
            if (sNumber == "0")
            {
                return so[0];
            }
            while (j <= (i - 1))
            {
                if (sNumber.Substring(0, 1) == "0")
                {
                    number = int.Parse(sNumber.Substring(i - j));
                    sNumber = number.ToString();
                }
                j = j + 1;
            }
            i = sNumber.Length;
            if (i == 0)
            {
                str = "";
            }
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = int.Parse(sNumber.Substring(i - 1, 1));
                    i = i - 1;
                    if (i > 0)
                    {
                        chuc = int.Parse(sNumber.Substring(i - 1, 1));
                    }
                    else
                    {
                        chuc = -1;
                    }
                    i = i - 1;
                    if (i > 0)
                    {
                        tram =
                          int.Parse(sNumber.Substring(i - 1, 1));
                    }
                    else
                    {
                        tram = -1;
                    }
                    i = i - 1;
                    if (donvi > 0 || chuc > 0 || tram > 0 || (j % 3 == 0))
                    {
                        if (j % 3 != 0)
                        {
                            str = hang[(j - 1) % 3 + 1] + " " + str;
                        }
                        else
                        {
                            if (true)
                            {
                                string temp;
                                int k;
                                temp = "";
                                for (k = 1; k <= j / 3; k++)
                                {
                                    temp = " tỉ" + temp;
                                }
                                str = temp + ", " + str;
                            }
                        }
                    }
                    j = j + 1;
                    if (donvi == 1)
                    {
                        if (chuc > 1)
                            str = "mốt" + " " + str;
                        else
                            str = "một" + " " + str;
                    }
                    else
                    {
                        if (donvi == 5 && chuc > 0)
                        {
                            str = "lăm" + " " + str;
                        }
                        else if (donvi > 0)
                        {
                            str = so[donvi] + " " + str;
                        }
                    }
                    if (chuc < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (chuc == 0 && donvi > 0)
                        {
                            str = "lẻ" + " " + str;
                        }
                        else if (chuc == 1)
                        {
                            str = "mười" + " " + str;
                        }

                        else if (chuc > 1)
                        {
                            str = so[chuc] + " " + "mươi" + " " + str;
                        }
                    }

                    if (tram < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (tram > 0 || chuc > 0 || donvi > 0)
                        {
                            str = so[tram] +
                                  " " + "trăm" + " " + str;
                        }
                    }
                }
            }
            while (str != str.Replace(", tỉ", ","))
            {
                str = str.Replace(", tỉ", ",");
            }
            while (str != str.Replace(", ,", ","))
            {
                str = str.Replace(", ,", ",");
            }
            str = str.Trim();
            str = str.Substring(0, 1).ToUpper() + str.Substring(1);
            str = str.Substring(0, str.Length - 1);
            str = str.Trim();
            //if (str.Length > 50)
            //{
            //  int index = str.IndexOf(" ", 50) + 1;
            //  str = str.Substring(0, index) +
            //        "\n" + str.Substring(index);
            //}
            //if (str.EndsWith("tỉ") || str.EndsWith("triệu") || str.EndsWith("nghìn") ||
            //    str.EndsWith("trăm") || str.EndsWith("mươi") || str.EndsWith("ười"))
            //    str += " đồng chẵn";
            //else
            //    str += " đồng";
            return str;
        }
    }
}
