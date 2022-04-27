using System;
using System.Collections.Generic;

namespace DogFactsSamples
{
    public class DogFactData
    {
        public DogFactData()
        {
        }
        public static IEnumerable<DogFactData> All { private set; get; }
        public string ShortFact { get; set; }

        public string AnImage { get; set; }
        static DogFactData()
        {
            List<DogFactData> all = new List<DogFactData>();
            all.Add(new DogFactData() { ShortFact = "I don't like buses, they suck", AnImage = "pizza.jpg"});
            all.Add(new DogFactData() { ShortFact = "I'm a QA Engineer", AnImage = "discord.PNG" });
            all.Add(new DogFactData() { ShortFact = "I swam competitively for 12 years", AnImage = "sadcowboy.png" });
            all.Add(new DogFactData() { ShortFact = "Cilantro takes like soap to me", AnImage = "bronun.png" });
            all.Add(new DogFactData() { ShortFact = "I just really like Star Wars", AnImage = "starwars.jpg" });
            All = all;

        }
    }
}