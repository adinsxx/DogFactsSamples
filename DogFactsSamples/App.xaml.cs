using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DogFactsSamples
{
    public partial class App : Application
    {
        static DogFactDb _database;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static DogFactDb Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DogFactDb(); 
                    prefillDatabase();

                }
                return _database;
            }
        }
        static void prefillDatabase()
        {
            _database.ClearAllAsync();
            List<DogFactData> items = new List<DogFactData>();
            items.Add(new DogFactData() { ShortFact = "I don't like buses, they suck", AnImage = "pizza.jpg"});
            items.Add(new DogFactData() { ShortFact = "I'm a QA Engineer", AnImage = "discord.PNG" });
            items.Add(new DogFactData() { ShortFact = "I swam competitively for 12 years", AnImage = "sadcowboy.png" });
            items.Add(new DogFactData() { ShortFact = "Cilantro takes like soap to me", AnImage = "bronun.png" });
            items.Add(new DogFactData() { ShortFact = "I just really like Star Wars", AnImage = "starwars.jpg" });
            _database.InsertList(items);

        }
    }
}
