using HealthFacility.Model;
using System;

namespace HealthFacility.Data
{
    public static class Converter
    {
        public static Address ConvertToAddress(string str)
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
    }
}
