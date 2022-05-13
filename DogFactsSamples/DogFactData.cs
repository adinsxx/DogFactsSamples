using System;
using System.Collections.Generic;
using SQLite;

namespace DogFactsSamples
{
    public class DogFactData
    {
        [PrimaryKey, AutoIncrement]
        public static IEnumerable<DogFactData> All { private set; get; }
        public int ID { get; set; }
        public string ShortFact { get; set; }
        public string AnImage { get; set; }
        static DogFactData()
        {


        }
    }
}