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
    class HouseViewHelper
    {
        public Visibility url { get; set; } = Visibility.Visible;
        public Visibility name { get; set; } = Visibility.Visible;
        public Visibility region { get; set; } = Visibility.Visible;
        public Visibility coatOfArms { get; set; } = Visibility.Visible;
        public Visibility words { get; set; } = Visibility.Visible;
        public Visibility titles { get; set; } = Visibility.Visible;
        public Visibility seats { get; set; } = Visibility.Visible;
        public Visibility currentLord { get; set; } = Visibility.Visible;
        public Visibility heir { get; set; } = Visibility.Visible;
        public Visibility overlord { get; set; } = Visibility.Visible;
        public Visibility founded { get; set; } = Visibility.Visible;
        public Visibility founder { get; set; } = Visibility.Visible;
        public Visibility diedOut { get; set; } = Visibility.Visible;
        public Visibility ancestralWeapons { get; set; } = Visibility.Visible;
        public Visibility cadetBranches { get; set; } = Visibility.Visible;
        public Visibility swornMembers { get; set; } = Visibility.Visible;
    }
}
