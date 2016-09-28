using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Dog> GetDogs()
        {
            Debug.WriteLine("GET for dogs.");
            return new List<Dog>()
            {
                new Dog() { breed="Japanese Spitz", category="Utility", activity="Medium Exercise", grooming="Demanding", image="/Images/spitz.jpg"}
            };
        }

        public static void Write(Dog dog)
        {
            Debug.WriteLine("INSERT dog with breed " + dog.breed);
        }

        public static void Delete(Dog dog)
        {
            Debug.WriteLine("DELETE dog with breed " + dog.breed);
        }
    }
}
