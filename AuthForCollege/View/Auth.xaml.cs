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
        private DispatcherTimer dispatcherTimer;
        private Counter Counter; 

        public Auth()
        {
            InitializeComponent();
            Counter = new Counter();
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
                    SharedClass.MessageBoxWarning($"Неправильный логин или пароль. Попыток до блокировки {3 - Counter.counter}");
                    if (!Counter.IsAddCount())
                    {
                        blockMode();
                        return;
                    }
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

        #region CounterTrying
        private void CreateTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += timerTick;
            dispatcherTimer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            setTextForBlock(Counter.numberSecond);
            if (!Counter.IsMinusSeconds()) startMode();
        }

        private void blockMode()
        {
            IsEnabledElements(false);
            CreateTimer();
            setTextForBlock(60);
        }
        private void startMode()
        {
            IsEnabledElements(true);
            this.dispatcherTimer.Stop();
            this.txtTimer.Text = string.Empty;

        }
        private void IsEnabledElements(bool isEnabled)
        {
            this.txtLogin.IsEnabled = isEnabled;
            this.txtPassword.IsEnabled = isEnabled;
            this.btnAuth.IsEnabled = isEnabled;

        }

        private void setTextForBlock(int sec)
        {
            this.txtTimer.Text = $"До снятия блокировки {sec}";
        }

        #endregion
        private bool IsFieldsEmpty()
        {
            return string.IsNullOrWhiteSpace(this.txtLogin.Text) || string.IsNullOrWhiteSpace(this.txtPassword.Text);             
        }


    }
}
