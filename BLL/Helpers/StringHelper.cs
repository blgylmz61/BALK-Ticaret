using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public static class StringHelper
    {
        public static string CapitalizeFirstLetterOfEachWord(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var textTrim = text.TrimStart();
            var words = textTrim.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            return string.Join(" ", words);
        }
    }

}
