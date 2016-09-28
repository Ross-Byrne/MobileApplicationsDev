using LabTwo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTwo.Models
{
    class Breeds
    {
        public List<Dog> Dogs { get; set; }
        public String Name { get; set; }

        public Breeds(String databaseName)
        {
            Name = databaseName;
        }

        public async void GetDogs()
        {
            Dogs = await DogService.GetDogs();
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
    }
}
