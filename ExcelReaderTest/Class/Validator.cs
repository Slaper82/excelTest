using System;

namespace ExcelReaderTest.Class
{
    public  class Validator
    {
        /// <summary>
        /// zadanie dodatkowe
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ValidateNumber(string number)
        {
            string res=  String.Empty;
            foreach (char c in number)
            {
                if (char.IsDigit(c))
                {
                    res += c;
                }
                else break;
            }
            return res;
        }
    }
}
