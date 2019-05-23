using HealthFacility.Model;
using System;

namespace HealthFacility.Data
{
    public static class Converter
    {
        public static Address ConvertToAddress(string str)
        {
            if ((str.IndexOf("улица") != -1) && (str.IndexOf("дом") != -1) && (str.IndexOf("город") != -1) && (str.IndexOf("страна") != -1))
            {
                str = str.Replace("улица ", "");
                str = str.Replace(" дом ", "");
                str = str.Replace(" город ", "");
                str = str.Replace(" страна ", "");
                string[] words = str.Split(',');

                return new Address()
                {
                    Street = words[0],
                    House = Int32.Parse(words[1]),
                    City = words[2],
                    Country = words[3]
                };
            }

            return new Address()
            {
                Street = "",
                House = 0,
                City = "",
                Country = str
            };

        }
    }
}
