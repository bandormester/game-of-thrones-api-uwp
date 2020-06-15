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
    public sealed partial class CharacterDetailsPage : Page
    {
        public CharacterDetailsPage()
        {
            this.InitializeComponent();
        }

        private void Books_Click(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("lefutott");
            var book = (Book)e.ClickedItem;
            ViewModel.NavigateToBookDetails(book.url);

        }

        private void Allegiance_Click(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("lefutott");
            var house = (House)e.ClickedItem;
            ViewModel.NavigateToHouseDetails(house.url);
        }

        private void Spouse_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("lefutott");
            ViewModel.NavigateToCharacterDetails(ViewModel.Spouse.url);
        }
    }
}
