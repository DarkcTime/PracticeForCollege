using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthForCollege.View
{
    /// <summary>
    /// Логика взаимодействия для MainNavigate.xaml
    /// </summary>
    public partial class MainNavigate : NavigationWindow
    {
        public MainNavigate()
        {
            InitializeComponent();
            this.Navigate(new View.ListTeachers());
            
        }
    }
}
