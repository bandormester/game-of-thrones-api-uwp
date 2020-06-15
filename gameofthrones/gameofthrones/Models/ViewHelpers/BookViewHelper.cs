using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace gameofthrones.Models.ViewHelpers
{
    /// <summary>
    /// Helps to assign Visibility to the Views
    /// </summary>
    class BookViewHelper
    {
        public Visibility url { get; set; } = Visibility.Visible;
        public Visibility name { get; set; } = Visibility.Visible;
        public Visibility isbn { get; set; } = Visibility.Visible;
        public Visibility authors { get; set; } = Visibility.Visible;
        public Visibility numberOfPages { get; set; } = Visibility.Visible;
        public Visibility publisher { get; set; } = Visibility.Visible;
        public Visibility country { get; set; } = Visibility.Visible;
        public Visibility mediaType { get; set; } = Visibility.Visible;
        public Visibility released { get; set; } = Visibility.Visible;
        public Visibility characters { get; set; } = Visibility.Visible;
        public Visibility povCharacters { get; set; } = Visibility.Visible;
    }
}
