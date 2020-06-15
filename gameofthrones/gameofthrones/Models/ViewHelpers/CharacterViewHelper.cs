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
    class CharacterViewHelper
    {
        public Visibility url { get; set; } = Visibility.Visible;
        public Visibility name { get; set; } = Visibility.Visible;
        public Visibility gender { get; set; } = Visibility.Visible;
        public Visibility culture { get; set; } = Visibility.Visible;
        public Visibility born { get; set; } = Visibility.Visible;
        public Visibility died { get; set; } = Visibility.Visible;
        public Visibility titles { get; set; } = Visibility.Visible;
        public Visibility aliases { get; set; } = Visibility.Visible;
        public Visibility father { get; set; } = Visibility.Visible;
        public Visibility mother { get; set; } = Visibility.Visible;
        public Visibility spouse { get; set; } = Visibility.Visible;
        public Visibility allegiances { get; set; } = Visibility.Visible;
        public Visibility books { get; set; } = Visibility.Visible;
        public Visibility povBooks { get; set; } = Visibility.Visible;
        public Visibility tvSeries { get; set; } = Visibility.Visible;
        public Visibility playedBy { get; set; } = Visibility.Visible;
    }
}
