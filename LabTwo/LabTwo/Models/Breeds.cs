using LabTwo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace LabTwo.Models
{
    class Breeds
    {
        public List<Dog> Dogs { get; set; }
        public string Name { get; set; }

        public static List<Dog> gDogList = new List<Dog>();


        public Breeds()
        {
            GetDogs();
            Dogs = gDogList;
            
        }

        public async void GetDogs()
        {
            //Dogs = await DogService.GetDogs();
            await LoadLocalData();
        }

        public void Add(Dog dog)
        {
            if (!Dogs.Contains(dog))
            {
                Dogs.Add(dog);
                DogService.Write(dog);
            }
        }

        public void Delete(Dog dog)
        {
            if (Dogs.Contains(dog))
            {
                Dogs.Remove(dog);
                DogService.Delete(dog);
            }
        }

        public void Update(Dog dog)
        {
            DogService.Write(dog);
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
