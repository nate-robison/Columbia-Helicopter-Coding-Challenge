using MobileCodeChallenge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Starships";
            InitializeComponent();
            BindingContext = new StarshipListViewModel();
        }
    }
}
