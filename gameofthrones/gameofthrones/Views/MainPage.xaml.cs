using gameofthrones.Models;
using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace gameofthrones.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Books_ItemClick(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("lefutott");
            var book = (Book)e.ClickedItem;
            ViewModel.NavigateToBookDetails(book.url);

        }

        private void ToCharacters_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("lefutott");
            ViewModel.NavigateToCharacters();
        }

        private void ToHouses_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("lefutott");
            ViewModel.NavigateToHouses();
        }
    }
}