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
    class AllHousesViewModel : ViewModelBase
    {
        public ObservableCollection<House> Houses{ get; set; } =
            new ObservableCollection<House>();
        private int PageSize = 20;

        private int PageNumber { get; set; } = 1;

        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await RefreshHouses();
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Refreshes the list of the houses with a new request
        /// </summary>
        /// <returns></returns>
        public async Task RefreshHouses()
        {
            Houses.Clear();
            var service = new HouseService();
            var houses = await service.GetHousesAsync(PageNumber, PageSize);
            foreach (House item in houses)
            {
                if (string.IsNullOrEmpty(item.name)) item.name = "Unknown";

                Houses.Add(item);
            }
        }

        /// <summary>
        /// Decrements page number and refreshes houses
        /// </summary>
        /// <returns></returns>
        public async Task PrevCharacters()
        {
            if (PageNumber > 1) PageNumber--;
            await RefreshHouses();
        }

        /// <summary>
        /// Increments page number and refreshes houses
        /// </summary>
        /// <returns></returns>
        public async Task NextCharacters()
        {
            PageNumber++;
            await RefreshHouses();
        }

        /// <summary>
        /// Navigates to the view of all books
        /// </summary>
        public void NavigateToBooks()
        {
            NavigationService.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Navigates to the view of all characters
        /// </summary>
        public void NavigateToCharacters()
        {
            NavigationService.Navigate(typeof(AllCharactersPage));
        }

        /// <summary>
        /// Navigation to a specified house
        /// </summary>
        /// <param name="houseUrl">url address of the house</param>
        public void NavigateToHouseDetails(string houseUrl)
        {
            NavigationService.Navigate(typeof(HouseDetailsPage), houseUrl);
        }

    }
}
