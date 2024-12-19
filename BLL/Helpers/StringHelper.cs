using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
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
        //Bir metnin null, boş veya sadece boşluklardan oluşup oluşmadığını kontrol eder.
        public static bool IsNullOrEmptyOrWhitespace(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
       // Bu metot, verilen uzunluktan daha uzun olan bir metni keser ve sonuna ek bir karakter ekler.
        public static string TruncateString(string text, int maxLength, string suffix = "...")
        {
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + suffix;
            }
            return text;
        }
        //Bu metot, telefon numarasını belirli bir formata sokar.
        public static string FormatPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Replace(" ", "").Insert(3, " ").Insert(7, " ");
        }
        //Bir metnin, diğer metni büyük/küçük harf duyarsız bir şekilde içerip içermediğini kontrol eder.
        public static bool ContainsIgnoreCase(string source, string substring)
        {
            return source.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        //Rastgele bir string oluşturur. Örneğin, şifre oluşturma gibi.
        public static string GenerateRandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, length)
                                       .Select(x => chars[random.Next(chars.Length)])
                                       .ToArray());
        }
        //Bir metni başlık formatına dönüştürür(ilk harf büyük, diğer harfler küçük).
        public static string StringToTitleCase(string text)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(text.ToLower());
        }
        //Bir e-posta adresinin geçerli olup olmadığını kontrol eder.

        public static bool IsEmailValid(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
        
}
