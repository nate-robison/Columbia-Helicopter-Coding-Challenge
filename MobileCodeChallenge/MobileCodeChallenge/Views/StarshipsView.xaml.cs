using MobileCodeChallenge.Model;
using MobileCodeChallenge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarshipsView : ContentPage
    {
        public StarshipsView()
        {
            Title = "Starships";
            InitializeComponent();
            BindingContext = new StarshipListViewModel();
        }

        public void ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var starship = (Starship)e.Item;
            if (starship == null)
            {
                return;
            }
            var starshipDetailView = new StarshipView()
            {
                Title = starship.Name
            };
            var starshipDetailViewModel = new StarshipDetailViewModel(starship);
            starshipDetailView.BindingContext = starshipDetailViewModel;
            Navigation.PushAsync(starshipDetailView);

        }
    }
}
