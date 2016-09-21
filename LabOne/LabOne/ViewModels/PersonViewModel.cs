using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabOne.Data;

namespace ViewModels
{
    public class PersonViewModel : NotificationBase<Person>
    {
        public PersonViewModel(Person person = null) : base(person) { }
        public String Name
        {
            get { return This.Name; }
            set { SetProperty(This.Name, value, () => This.Name = value); }
        }
        public int Age
        {
            get { return This.Age; }
            set { SetProperty(This.Age, value, () => This.Age = value); }
        }

        public string Address
        {
            get { return This.Address; }
            set { SetProperty(This.Address, value, () => This.Address = value); }
        }

        public int PhoneNumber
        {
            get { return This.PhoneNumber; }
            set { SetProperty(This.PhoneNumber, value, () => This.PhoneNumber = value); }
        }

        public string Email
        {
            get { return This.Email; }
            set { SetProperty(This.Email, value, () => This.Email = value); }
        }
    }
}
