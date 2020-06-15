using gameofthrones.Models;
using gameofthrones.Models.ViewHelpers;
using gameofthrones.Services;
using gameofthrones.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace gameofthrones.ViewModels
{
    class HouseDetailsPageViewModel : ViewModelBase
    {
        private House _house;
        public House House
        {
            get { return _house; }
            set { Set(ref _house, value); }
        }
        public ObservableCollection<House> CadetBranches { get; set; } = new ObservableCollection<House>();
        public ObservableCollection<Character> SwornMembers{ get; set; } = new ObservableCollection<Character>();
        public HouseViewHelper ViewHelper { get; set; } = new HouseViewHelper();


        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var houseUrl = (string)parameter;
            var service = new HouseService();
            House = await service.GetHouseAsync(houseUrl);

            checkVisibility();

            Array.Sort(House.titles, (y, x) => x.Length.CompareTo(y.Length));
            Array.Sort(House.seats, (y, x) => x.Length.CompareTo(y.Length));
            Array.Sort(House.ancestralWeapons, (y, x) => x.Length.CompareTo(y.Length));
            Array.Sort(House.cadetBranches, (y, x) => x.Length.CompareTo(y.Length));
      

            await LoadCadetBranches();
            await LoadCurrentlord();
            await LoadFounder();
            await LoadHeir();
            await LoadOverlord();
            await LoadSwornMembers();
            

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        private void checkVisibility()
        {
            ViewHelper.region = string.IsNullOrEmpty(House.region) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.coatOfArms = string.IsNullOrEmpty(House.coatOfArms) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.words = string.IsNullOrEmpty(House.words) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.currentLord = string.IsNullOrEmpty(House.currentLord) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.heir = string.IsNullOrEmpty(House.heir) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.overlord = string.IsNullOrEmpty(House.overlord) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.founded = string.IsNullOrEmpty(House.founded) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.founder = string.IsNullOrEmpty(House.founder) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.diedOut = string.IsNullOrEmpty(House.diedOut) ? Visibility.Collapsed : Visibility.Visible;
            if (House.titles.Length == 0 || (House.titles.Length == 1 && string.IsNullOrEmpty(House.titles.ElementAt(0))))
            {
                ViewHelper.titles = Visibility.Collapsed;
            }
            if (House.seats.Length == 0 || (House.seats.Length == 1 && string.IsNullOrEmpty(House.seats.ElementAt(0))))
            {
                ViewHelper.seats = Visibility.Collapsed;
            }
            if (House.ancestralWeapons.Length == 0 || (House.ancestralWeapons.Length == 1 && string.IsNullOrEmpty(House.ancestralWeapons.ElementAt(0))))
            {
                ViewHelper.ancestralWeapons = Visibility.Collapsed;
            }
            if (House.cadetBranches.Length == 0 || (House.cadetBranches.Length == 1 && string.IsNullOrEmpty(House.cadetBranches.ElementAt(0))))
            {
                ViewHelper.cadetBranches = Visibility.Collapsed;
            }
            if (House.swornMembers.Length == 0 || (House.swornMembers.Length == 1 && string.IsNullOrEmpty(House.swornMembers.ElementAt(0))))
            {
                ViewHelper.swornMembers = Visibility.Collapsed;
            }

            RaisePropertyChanged("ViewHelper");
        }

        private async Task LoadCadetBranches()
        {
            var service = new HouseService();
            CadetBranches.Clear();

            foreach (string url in House.cadetBranches)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    House h = await service.GetHouseAsync(url);
                    CadetBranches.Add(h);
                    RaisePropertyChanged("CadetBranches");
                }
            }
        }

        private async Task LoadSwornMembers()
        {
            var service = new CharacterService();
            SwornMembers.Clear();

            foreach (string url in House.swornMembers)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    Character c = await service.GetCharacterAsync(url);
                    SwornMembers.Add(c);
                    RaisePropertyChanged("SwornMembers");
                }
            }
        }

        public Character Founder { get; set; } = new Character();
        private async Task LoadFounder()
        {
            if (!string.IsNullOrEmpty(House.founder))
            {
                var service = new CharacterService();
                Founder = await service.GetCharacterAsync(House.founder);
                RaisePropertyChanged("Founder");
            }
        }

        public Character Heir { get; set; } = new Character();
        private async Task LoadHeir()
        {
            if (!string.IsNullOrEmpty(House.heir))
            {
                var service = new CharacterService();
                Heir = await service.GetCharacterAsync(House.heir);
                RaisePropertyChanged("Heir");
            }
        }


        public House Overlord { get; set; } = new House();
        private async Task LoadOverlord()
        {
            if (!string.IsNullOrEmpty(House.overlord))
            {
                var service = new HouseService();
                Overlord = await service.GetHouseAsync(House.overlord);
                RaisePropertyChanged("Overlord");
            }
        }

        public Character Currentlord { get; set; } = new Character();
        private async Task LoadCurrentlord()
        {
            if (!string.IsNullOrEmpty(House.currentLord))
            {
                var service = new CharacterService();
                Currentlord = await service.GetCharacterAsync(House.currentLord);
                RaisePropertyChanged("Currentlord");
            }
        }

        /// <summary>
        /// Navigates to a specified house
        /// </summary>
        /// <param name="houseUrl">url address of the huse</param>
        public void NavigateToHouseDetails(string houseUrl)
        {
            NavigationService.Navigate(typeof(HouseDetailsPage), houseUrl);
        }

        /// <summary>
        /// Navigates to a specified character
        /// </summary>
        /// <param name="charUrl">url address of the character</param>
        public void NavigateToCharacterDetails(string charUrl)
        {
            NavigationService.Navigate(typeof(CharacterDetailsPage), charUrl);
        }

    }
}
