using LabTwo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTwo.ViewModels
{
    public class DogViewModel : NotificationBase<Dog>
    {
        public DogViewModel(Dog dog = null) : base(dog) { }

        public string Breed
        {
            get { return This.breed; }
            set { SetProperty(This.breed, value, () => This.breed = value); }
        }

        public string Category
        {
            get { return This.category; }
            set { SetProperty(This.category, value, () => This.category = value); }
        }

        public string Activity
        {
            get { return This.activity; }
            set { SetProperty(This.activity, value, () => This.activity = value); }
        }

        public string Grooming
        {
            get { return This.grooming; }
            set { SetProperty(This.grooming, value, () => This.grooming = value); }
        }

        public string Image
        {
            get { return This.image; }
            set { SetProperty(This.image, value, () => This.image = value); }
        }
        
    }
}
