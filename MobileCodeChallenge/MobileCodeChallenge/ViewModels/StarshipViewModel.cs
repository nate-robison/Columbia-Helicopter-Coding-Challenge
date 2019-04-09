
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MobileCodeChallenge.Model;
using MobileCodeChallenge.Services;
using Xamarin.Forms;

namespace MobileCodeChallenge.ViewModels
{
    public class StarshipDetailViewModel : INotifyPropertyChanged
    {
        StarshipImageService StarshipImageService;
        Starship starship;
        ImageSource starshipImageSource;
        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public ImageSource StarshipImageSource
        {
            get { return starshipImageSource; }
            set
            {
                starshipImageSource = value;
                OnPropertyChanged();
            }
        }
        
        public Starship Starship
        {
            get { return starship; }
            set
            {
                starship = value;
                Task.Run(async () => await GetStarshipImageForDetailPage());
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public StarshipDetailViewModel(Starship starship)
        {
          
            StarshipImageService = new StarshipImageService();
            Starship = starship;

        }

        private async Task GetStarshipImageForDetailPage()
        {
            IsBusy = true;
            try
            {
                var imageURL = await StarshipImageService.GetImageUrl(starship.Name);
                StarshipImageSource = ImageSource.FromUri(new Uri(imageURL));
            }
            catch
            {
                //Future implementation might include showing default image or alerting we are unable to get image
                //As well as reportin issues.
            }
            IsBusy = false;
            
        }
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }

}
