using NUnit.Framework;

namespace Data
{
    public class GameData
    {
        static private string[] Levels =
        {
            "Level1",
            "RocketScene"
        };

        public static string[] levels { get =>  Levels; }
    }
    

}

