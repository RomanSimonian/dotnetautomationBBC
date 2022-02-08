using System;
using System.Text;

namespace BBC1withLoremIpsum
{
    public static class GenerateData
    {
        public static string GenerateRandomString(int size, bool lowerCase = true)
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();

            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                stringBuilder.Append(ch);
            }
            if (lowerCase) return stringBuilder.ToString().ToLower();
            return stringBuilder.ToString();
        }
        public static string GenerateRandomEmail(string nameDomen, int size = 10)
        {
            return GenerateRandomString(size)+ "@" + nameDomen;
        }
        public static int GenerateRandomNumber(int minValue , int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }
        public static string GenerateRandomPhoneNumber(string codeCountry, int sizeNumber)
        {
            int[] array = new int[sizeNumber];
            var random = new Random();
            string phoneNumber = "";

            for (int i = 0; i < sizeNumber; i++)
            {
                array[i] = random.Next(10);
                phoneNumber += array[i];
            }
            return codeCountry + phoneNumber;
        }
    }
}
