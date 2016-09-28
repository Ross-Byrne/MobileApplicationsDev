using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace LabTwo.Data
{
    public class Dog
    {
        public string breed { get; set; }
        public string category { get; set; }
        public string activity { get; set; }
        public string grooming { get; set; }
        public string image { get; set; }
    }

    class DogService
    {
        public static String Name = "Dog Data Service.";

        private static List<Dog> gDogList = new List<Dog>();
        public static async Task<List<Dog>> GetDogs()
        {
            Debug.WriteLine("GET for dogs.");

            gDogList = null;
            await LoadLocalData();

            return new List<Dog>(gDogList);
        }

        public static void Write(Dog dog)
        {
            Debug.WriteLine("INSERT dog with breed " + dog.breed);
        }

        public static void Delete(Dog dog)
        {
            Debug.WriteLine("DELETE dog with breed " + dog.breed);
        }

        public static async Task LoadLocalData()
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\myDogs.txt");
            var result = await FileIO.ReadTextAsync(file);

            var jDogList = JsonArray.Parse(result);
            CreateDogsList(jDogList);
        }

        private static void CreateDogsList(JsonArray jDogList)
        {
            foreach (var item in jDogList)
            {
                var oneDog = item.GetObject();
                Dog nDog = new Dog();

                foreach (var key in oneDog.Keys)
                {
                    IJsonValue value;
                    if (!oneDog.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "breed":
                            nDog.breed = value.GetString();
                            break;
                        case "category":
                            nDog.category = value.GetString();
                            break;
                        case "grooming":
                            nDog.grooming = value.GetString();
                            break;
                        case "activity":
                            nDog.activity = value.GetString();
                            break;
                        case "image":
                            nDog.image = value.GetString();
                            break;
                    } // end switch
                } // end foreach(var key in oneDog.Keys )
                gDogList.Add(nDog);
            } // end foreach (var item in jDogList)
        }
    }
}
