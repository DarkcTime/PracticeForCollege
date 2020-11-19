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
                LoadWindowDependingOnTheRole(); 
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex);
            }
           

        }

        private void LoadWindowDependingOnTheRole()
        {
            switch (UserRepo.AuthUser.Role.IdRole)
            {
                case 1:
                    this.MainFrame.Content = new Student();
                    this.BtnStudents.Visibility = Visibility.Hidden;
                    this.BtnTeachers.Visibility = Visibility.Hidden;                  
                    break;
                case 2:                    
                    this.MainFrame.Content = new ListStudents();
                    this.BtnStudents.Visibility = Visibility.Visible;
                    this.BtnTeachers.Visibility = Visibility.Hidden;                    
                    break;
                case 3:
                    this.MainFrame.Content = new ListStudents();
                    this.BtnStudents.Visibility = Visibility.Visible;
                    this.BtnTeachers.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void StudentsClick(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new ListStudents(); 
        }
        private void TeachersClick(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new ListTeachers();            
        }

        private enum Lists
        {
            Students, Teachers
        }

        private enum Roles
        {
            Студент, Учитель, Завуч
        }
    }
}
