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
using AuthForCollege.BackEnd;
using AuthForCollege.Controller;
using AuthForCollege.View;

namespace AuthForCollege
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                SetAuthText();
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex);
            }
           

        }

        private void SetAuthText()
        {

            string role = string.Empty;

            switch (UserRepo.AuthUser.RoleId)
            {
                case 1:
                    role = "Студент";
                    break;
                case 2:
                    role = "Учитель";
                    this.MainFrame.Content = new ListTeachers();
                    break;
                case 3:
                    role = "Руководитель";
                    break;
            } 
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
