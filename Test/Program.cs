using ImperatorSaveParser;
using Pdoxcl2Sharp;
using System;
using System.IO;

namespace Test
{
    class Program
    {
        static Save save;
        public static void Main()
        {
            using (FileStream fs = new FileStream(@"D:\test.rome", FileMode.Open))
            {
                save = ParadoxParser.Parse(fs, new Save());
                Console.WriteLine(save.Date);
                Console.WriteLine(save.CountryManager.Countries.Count);
                Console.WriteLine(save.FamilyManager.Families.Count);
            }
        }
    }
}