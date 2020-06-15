using gameofthrones.Models;
using gameofthrones.Models.ViewHelpers;
using gameofthrones.Services;
using gameofthrones.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace gameofthrones.ViewModels
{
    class BookDetailsPageViewModel : ViewModelBase
    {
        
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { Set(ref _book, value); }
        }
        public ObservableCollection<Character> PovCharacters { get; set; } = new ObservableCollection<Character>();
        public BookViewHelper ViewHelper { get; set; } = new BookViewHelper();
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public int FirstCharacterId { get; set; } = 0;
        private int pageSize = 30;

        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var bookUrl = (string)parameter;
            var service = new BookService();
            Book = await service.GetBookAsync(bookUrl);

            checkVisibility();
            FirstCharacterId = 0;

            await LoadPovCharacters();
            await RefreshCharacters();

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Assigning the values of the visibility helper 
        /// </summary>
        private void checkVisibility()
        {
            ViewHelper.isbn = string.IsNullOrEmpty(Book.isbn) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.numberOfPages = Book.numberOfPages == 0 ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.publisher = string.IsNullOrEmpty(Book.publisher) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.country = string.IsNullOrEmpty(Book.country) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.mediaType = string.IsNullOrEmpty(Book.mediaType) ? Visibility.Collapsed : Visibility.Visible;
            ViewHelper.released = Book.released == null ? Visibility.Collapsed : Visibility.Visible;
            if (Book.authors.Length == 0 || (Book.authors.Length == 1 && string.IsNullOrEmpty(Book.authors.ElementAt(0))))
            {
                ViewHelper.authors = Visibility.Collapsed;
            }
            else ViewHelper.authors = Visibility.Visible;

            if (Book.characters.Length == 0 || (Book.characters.Length == 1 && string.IsNullOrEmpty(Book.characters.ElementAt(0))))
            {
                ViewHelper.characters = Visibility.Collapsed;
            }
            else ViewHelper.characters = Visibility.Visible;

            if (Book.povCharacters.Length == 0 || (Book.povCharacters.Length == 1 && string.IsNullOrEmpty(Book.povCharacters.ElementAt(0))))
            {
                ViewHelper.povCharacters = Visibility.Collapsed;
            }
            else ViewHelper.povCharacters = Visibility.Visible;

            RaisePropertyChanged("ViewHelper");
        }

        /// <summary>
        /// Loads the next page of the characters
        /// </summary>
        /// <returns></returns>
        public async Task NextCharacters()
        {

            if (FirstCharacterId + pageSize < Book.characters.Length)
            {
                FirstCharacterId += pageSize;

                await RefreshCharacters();
            }
        }

        /// <summary>
        /// Loads the previous page of the characters
        /// </summary>
        /// <returns></returns>
        public async Task PreviousCharacters()
        {
            if (FirstCharacterId > 0)
            {
                FirstCharacterId = FirstCharacterId - pageSize > 0 ? FirstCharacterId - pageSize : 0;

                await RefreshCharacters();
            }
        }

        /// <summary>
        /// Refreshes the list of characters
        /// </summary>
        /// <returns></returns>
        private async Task RefreshCharacters()
        {
            var service = new CharacterService();
            Characters.Clear();
            int sign = FirstCharacterId + pageSize < Book.characters.Length ? FirstCharacterId + pageSize : Book.characters.Length;

            for (int i = FirstCharacterId; i < sign; i++)
            {
                if (!string.IsNullOrEmpty(Book.characters.ElementAt(i))){
                    Character c = await service.GetCharacterAsync(Book.characters.ElementAt(i));
                    Characters.Add(c);
                    }
            }
        }

        private async Task LoadPovCharacters()
        {
            var service = new CharacterService();

            foreach (string url in Book.povCharacters)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    Character c = await service.GetCharacterAsync(url);
                    PovCharacters.Add(c);
                    
                }
            }
        }

        /// <summary>
        /// Navigates to a specified characters
        /// </summary>
        /// <param name="characterUrl">url address of the character</param>
        public void NavigateToCharacterDetails(string characterUrl)
        {
            NavigationService.Navigate(typeof(CharacterDetailsPage), characterUrl);
        }


    }
}
