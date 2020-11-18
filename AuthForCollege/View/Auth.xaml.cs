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
using System.Windows.Shapes;

using AuthForCollege.Controller;
using AuthForCollege.BackEnd;
using System.Windows.Threading;

namespace AuthForCollege.View
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private UserRepo userRepo = new UserRepo();
     
        public Auth()
        {
            InitializeComponent();
           

        }

        #region UI Events
        private void AuthClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsFieldsEmpty())
                {
                    SharedClass.MessageBoxWarning("Все поля должны быть заполнены");
                    return;
                }

                if (userRepo.IsAuth(this.txtLogin.Text.Trim(), this.txtPassword.Text.Trim()))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    SharedClass.MessageBoxWarning($"Неправильный логин или пароль."); 
                }
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex);     
            }
          

        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

     
        
        private bool IsFieldsEmpty()
        {
            return string.IsNullOrWhiteSpace(this.txtLogin.Text) || string.IsNullOrWhiteSpace(this.txtPassword.Text);             
        }


    }
}
