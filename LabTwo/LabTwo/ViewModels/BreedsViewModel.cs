using LabTwo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTwo.ViewModels
{
    public class BreedsViewModel : NotificationBase
    {
        Breeds breeds;

        public BreedsViewModel(String name)
        {
            breeds = new Breeds();
            _SelectedIndex = -1;
            // Load the database
            foreach (var dog in breeds.Dogs)
            {
                var np = new DogViewModel(dog);
                np.PropertyChanged += Dog_OnNotifyPropertyChanged;
                _Dogs.Add(np);
            }
        }

        ObservableCollection<DogViewModel> _Dogs
           = new ObservableCollection<DogViewModel>();
        public ObservableCollection<DogViewModel> Dogs
        {
            get { return _Dogs; }
            set { SetProperty(ref _Dogs, value); }
        }

        String _Name;
        public String Name
        {
            get { return breeds.Name; }
        }

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedDogs)); }
            }
        }

        public DogViewModel SelectedDogs
        {
            get { return (_SelectedIndex >= 0) ? _Dogs[_SelectedIndex] : null; }
        }

        public void Add()
        {
            var dog = new DogViewModel();
            dog.PropertyChanged += Dog_OnNotifyPropertyChanged;
            Dogs.Add(dog);
            breeds.Add(dog);
            SelectedIndex = Dogs.IndexOf(dog);
        }

        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var dog = Dogs[SelectedIndex];
                Dogs.RemoveAt(SelectedIndex);
                breeds.Delete(dog);
            }
        }

        void Dog_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            breeds.Update((DogViewModel)sender);
        }
    }
}
