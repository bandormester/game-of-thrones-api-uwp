using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using gameofthrones.Services;
using System.Collections.ObjectModel;
using gameofthrones.Models;
using gameofthrones.Views;

namespace gameofthrones.ViewModels
{
    public class AllBooksPageViewModel : ViewModelBase
    {
        public ObservableCollection<Book> Books{ get; set; } =
            new ObservableCollection<Book>();

        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Books.Clear();
            var service = new BookService();
            var books = await service.GetBooksAsync();
            foreach (var item in books)
            {
                Books.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Navitation to a specified Book
        /// </summary>
        /// <param name="bookUrl">url address of the book</param>
        public void NavigateToBookDetails(string bookUrl)
        {
            NavigationService.Navigate(typeof(BookDetailsPage), bookUrl);
        }

        /// <summary>
        /// Navigation to the view of all characters
        /// </summary>
        public void NavigateToCharacters()
        {
            NavigationService.Navigate(typeof(AllCharactersPage));
        }

        /// <summary>
        /// Navigation to the view of all houses
        /// </summary>
        public void NavigateToHouses()
        {
            NavigationService.Navigate(typeof(AllHousesPage));
        }
    }
}
