using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Imperator.Save.Parser
{
    public static class GameDataParser
    {
        public static IEnumerable<ProvinceName> GetProvinceNames()
        {
            var list = new List<ProvinceName>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"provincenames_l_english.yml");
            using (StreamReader sr = new StreamReader(path)) 
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        var provIdStr = line.Split(":")[0].Split("PROV")[1];
                        var provId = int.Parse(provIdStr);
                        var provName = line.Split("\"")[1].Trim();
                        list.Add(new ProvinceName{ProvinceId = provId, Name = provName});
                    }
                    catch
                    {
                        //ignored line
                    }
                }
            }

            return list;
        }
        public static IEnumerable<CountryName> GetCountryNames()
        {
            var list = new List<CountryName>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"countries_l_english.yml");
            using (StreamReader sr = new StreamReader(path)) 
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        var countryTag = line.Split(":")[0].Trim();
                        if(countryTag.Contains("_") || countryTag.Contains("#") || countryTag.Length > 10) continue;
                        var countryName = line.Split("\"")[1].Trim();
                        list.Add(new CountryName{CountryTag = countryTag, Name = countryName});
                    }
                    catch
                    {
                        //ignored line
                    }
                }
            }

            return list;
        }
        public static IEnumerable<Culture> GetCultures()
        {
            var list = new List<Culture>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"cultures_l_english.yml");
            using (StreamReader sr = new StreamReader(path)) 
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        var cultureId = line.Split(":")[0].Trim();
                        if(cultureId.Contains("malename") || cultureId.Contains("#")) continue;
                        var name = line.Split("\"")[1].Trim();
                        list.Add(new Culture{CultureId = cultureId, Name = name});
                    }
                    catch
                    {
                        //ignored line
                    }
                }
            }

            return list;
        }
        public static IEnumerable<Religion> GetReligions()
        {
            var list = new List<Religion>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"text_l_english.yml");
            using (StreamReader sr = new StreamReader(path)) 
            {
                string line;
                bool isReligionSection = false;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        if (isReligionSection && line.Contains("#")) isReligionSection = false;
                        if (line.Contains("######RELIGIONS######")) isReligionSection = true;
                        if (!isReligionSection || line.Contains("#") || line.Contains("desc_")) continue;
                        var religionId = line.Split(":")[0].Trim();
                        var name = line.Split("\"")[1].Trim();
                        list.Add(new Religion{ReligionId = religionId, Name = name});
                    }
                    catch
                    {
                        //ignored line
                    }
                }
            }

            return list;
        }
    }
}
