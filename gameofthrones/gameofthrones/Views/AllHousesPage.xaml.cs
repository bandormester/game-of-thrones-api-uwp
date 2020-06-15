using gameofthrones.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace gameofthrones.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllHousesPage : Page
    {
        public AllHousesPage()
        {
            this.InitializeComponent();
        }

        private async System.Threading.Tasks.Task PrevButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            await ViewModel.PrevCharacters();
        }

        private async System.Threading.Tasks.Task NextButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            await ViewModel.NextCharacters();
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("lefutott");
            ViewModel.NavigateToBooks();
        }

        private void Characters_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("lefutott");
            ViewModel.NavigateToCharacters();
        }

        private async void NextButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.NextCharacters();
        }

        private async void PrevButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.PrevCharacters();
        }

        private void Houses_ItemClick(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("lefutott");
            var house = (House)e.ClickedItem;
            ViewModel.NavigateToHouseDetails(house.url);

        }
    }
}
