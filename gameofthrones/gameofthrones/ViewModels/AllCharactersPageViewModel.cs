using gameofthrones.Models;
using gameofthrones.Services;
using gameofthrones.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace gameofthrones.ViewModels
{
    class AllCharactersPageViewModel : ViewModelBase
    {
        public ObservableCollection<Character> Characters { get; set; } =
            new ObservableCollection<Character>();
        private int PageSize = 30;

        private int PageNumber { get; set; } = 1;

        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await RefreshCharacters();
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Refreshes the list of the characters with a new request
        /// </summary>
        /// <returns></returns>
        public async Task RefreshCharacters()
        {
            Characters.Clear();
            var service = new CharacterService();
            var characters = await service.GetCharactersAsync(PageNumber, PageSize);
            foreach (Character item in characters)
            {
                if (string.IsNullOrEmpty(item.name)) item.name = "Unknown";

                Characters.Add(item);
            }
        }

        /// <summary>
        /// Decrements page number and refreshes characters
        /// </summary>
        /// <returns></returns>
        public async Task PrevCharacters()
        {
            if (PageNumber > 1) PageNumber--;
            await RefreshCharacters();
        }


        /// <summary>
        /// Increments page number and refreshes characters
        /// </summary>
        /// <returns></returns>
        public async Task NextCharacters()
        {
            PageNumber++;
            await RefreshCharacters();
        }

        /// <summary>
        /// Navigates to the view of all bookgs
        /// </summary>
        public void NavigateToBooks()
        {
            NavigationService.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Navigates to the view of all houses
        /// </summary>
        public void NavigateToHouses()
        {
            NavigationService.Navigate(typeof(AllHousesPage));
        }

        /// <summary>
        /// Navitation to a specified Character
        /// </summary>
        /// <param name="charUrl">url address of the character</param>
        public void NavigateToCharacterDetails(string charUrl)
        {
            NavigationService.Navigate(typeof(CharacterDetailsPage), charUrl);
        }
    }
}
