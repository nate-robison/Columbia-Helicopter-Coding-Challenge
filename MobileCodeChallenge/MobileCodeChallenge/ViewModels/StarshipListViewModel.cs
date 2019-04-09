using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MobileCodeChallenge.Model;
using MobileCodeChallenge.Services;

namespace MobileCodeChallenge.ViewModels
{
     public class StarshipListViewModel : INotifyPropertyChanged
    {
        StarshipDataService StarshipListService;
        ObservableCollection<Starship> starships;
        bool isBusy;
        public ObservableCollection<Starship> Starships
        {
            get { return starships; }
            set
            {
                starships = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public StarshipListViewModel()
        {
            StarshipListService = new StarshipDataService();
            Task.Run(async() => await LoadAndPopulateStarshipList());

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task LoadAndPopulateStarshipList()
        {
           
            IsBusy = true;
            Starships = await StarshipListService.GetAllStarShips();
            IsBusy = false;
            
        }
       
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        
    }
}
