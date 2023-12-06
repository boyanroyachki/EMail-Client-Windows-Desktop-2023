using EMailClient.Core;

namespace EMailClient.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private object currentView;

        //Relay Commands:
        public RelayCommand HomeViewCommand{ get; set; }
        public RelayCommand DiscoveryViewCommand{ get; set; }


        public HomeViewModel HomeViewModel{ get; set; }
        public DiscoveryViewModel DiscoveryViewModel { get; set; }

        public object CurrentView
        {
            get { return currentView; }
            set 
            {
                currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeViewModel = new HomeViewModel();
            DiscoveryViewModel = new DiscoveryViewModel();

            CurrentView = this.HomeViewModel;

            HomeViewCommand = new RelayCommand(x =>
            {
                CurrentView = HomeViewModel;
            });

            DiscoveryViewCommand = new RelayCommand(x =>
            {
                CurrentView = DiscoveryViewModel;
            });
        }
    }
}
