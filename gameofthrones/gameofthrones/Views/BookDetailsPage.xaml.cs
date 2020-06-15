using gameofthrones.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Services.NavigationService;
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
    public sealed partial class BookDetailsPage : Page
    {
        public BookDetailsPage()
        {
            this.InitializeComponent();
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.NextCharacters();
        }

        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.PreviousCharacters();
        }

        private void Characters_Click(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("lefutott");
            var character = (Character)e.ClickedItem;
            ViewModel.NavigateToCharacterDetails(character.url);

        }
    }
}
