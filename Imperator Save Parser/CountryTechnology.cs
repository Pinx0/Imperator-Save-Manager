using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryTechnology: IParadoxRead
    { 
        public int Level { get; set; }
        public double Progress { get; set; }
     
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "level":
                    Level = parser.ReadInt32();
                    break;
                case "progress":
                    Progress = parser.ReadDouble();
                    break;
              
            }
           
        }
    }
}