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
    class CharacterDetailsPageViewModel : ViewModelBase
    {
        private Character _character;
        public Character Character
        {
            get { return _character; }
            set { Set(ref _character, value); }
        }
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Book> PovBooks { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<House> Allegiances { get; set; } = new ObservableCollection<House>();
        public Character Spouse { get; set; } = new Character();
        public CharacterViewHelper ViewHelper { get; set; } = new CharacterViewHelper();

        public override async Task OnNavigatedToAsync(
           object parameter, NavigationMode mode, IDictionary<string, object> state)
        {    
            var charUrl = (string)parameter;
            var service = new CharacterService();
            Character = await service.GetCharacterAsync(charUrl);

            Array.Sort(Character.aliases, (y, x) => x.Length.CompareTo(y.Length));
            Array.Sort(Character.titles, (y, x) => x.Length.CompareTo(y.Length));
            Array.Sort(Character.allegiances, (y, x) => x.Length.CompareTo(y.Length));

            checkVisibility();

            await LoadPovBooks();
            await LoadBooks();
            await LoadSpouse();
            await LoadAllegiances();

            RaisePropertyChanged("Character");

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        private async Task LoadPovBooks()
        {
            var service = new BookService();
            PovBooks.Clear();

            foreach (string url in Character.povBooks)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    Book b = await service.GetBookAsync(url);
                    PovBooks.Add(b);
                    RaisePropertyChanged("PovBooks");
                }
            }
        }

        private async Task LoadBooks()
        {
            var service = new BookService();
            Books.Clear();

            foreach (string url in Character.books)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    Book b = await service.GetBookAsync(url);
                    Books.Add(b);
                    RaisePropertyChanged("Books");
                }
            }
        }

        private async Task LoadAllegiances()
        {
            var service = new HouseService();
            Allegiances.Clear();

            foreach (string url in Character.allegiances)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    House a = await service.GetHouseAsync(url);
                    Allegiances.Add(a);
                    RaisePropertyChanged("Allegiances");
                }
            }
        }

        private async Task LoadSpouse()
        {
            if (!string.IsNullOrEmpty(Character.spouse))
            {
                var service = new CharacterService();
            
                Spouse = await service.GetCharacterAsync(Character.spouse);
                RaisePropertyChanged("Spouse");
            }
        }

        private void checkVisibility()
        {
            ViewHelper.gender = string.IsNullOrEmpty(Character.gender) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.culture = string.IsNullOrEmpty(Character.culture) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.born = string.IsNullOrEmpty(Character.born) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.died = string.IsNullOrEmpty(Character.died) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.father = string.IsNullOrEmpty(Character.father) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.mother = string.IsNullOrEmpty(Character.mother) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.spouse = string.IsNullOrEmpty(Character.spouse) ? Visibility.Collapsed : Visibility.Visible;

            if (Character.titles.Length == 0 || (Character.titles.Length == 1 && string.IsNullOrEmpty(Character.titles.ElementAt(0))))
            {
                ViewHelper.titles = Visibility.Collapsed;
            }
            if (Character.aliases.Length == 0 || (Character.aliases.Length == 1 && string.IsNullOrEmpty(Character.aliases.ElementAt(0))))
            {
                ViewHelper.aliases = Visibility.Collapsed;
            }
            if (Character.allegiances.Length == 0 || (Character.allegiances.Length == 1 && string.IsNullOrEmpty(Character.allegiances.ElementAt(0))))
            {
                ViewHelper.allegiances = Visibility.Collapsed;
            }
            if (Character.books.Length == 0 || (Character.books.Length == 1 && string.IsNullOrEmpty(Character.books.ElementAt(0))))
            {
                ViewHelper.books = Visibility.Collapsed;
            }
            if (Character.povBooks.Length == 0 || (Character.povBooks.Length == 1 && string.IsNullOrEmpty(Character.povBooks.ElementAt(0))))
            {
                ViewHelper.povBooks = Visibility.Collapsed;
            }
            if (Character.tvSeries.Length == 0 || (Character.tvSeries.Length == 1 && string.IsNullOrEmpty(Character.tvSeries.ElementAt(0))))
            {
                ViewHelper.tvSeries = Visibility.Collapsed;
            }
            if (Character.playedBy.Length == 0 || (Character.playedBy.Length == 1 && string.IsNullOrEmpty(Character.playedBy.ElementAt(0))))
            {
                ViewHelper.playedBy = Visibility.Collapsed;
            }

            RaisePropertyChanged("ViewHelper");
        }

        /// <summary>
        /// Navigates to a specified book
        /// </summary>
        /// <param name="bookUrl">url address of the book</param>
        public void NavigateToBookDetails(string bookUrl)
        {
            NavigationService.Navigate(typeof(BookDetailsPage), bookUrl);
        }

        /// <summary>
        /// Navigates to a specified house
        /// </summary>
        /// <param name="houseUrl">url address of the house</param>
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
