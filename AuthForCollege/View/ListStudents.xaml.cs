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

using AuthForCollege.Model;
using AuthForCollege.Controller;
using AuthForCollege.BackEnd;

namespace AuthForCollege.View
{
    /// <summary>
    /// Interaction logic for ListStudents.xaml
    /// </summary>
    public partial class ListStudents : Page
    {
        public List<Gender> Genders { get; set; }
        public List<StatusStudent> Statuses { get; set; }
        public List<Group> Groups { get; set; }

        private GenderRepo genderRepo = new GenderRepo();
        private StudentRepo studentRepo = new StudentRepo();


        public ListStudents()
        {
            InitializeComponent();
            this.DataContext = this; 
            LoadCollections();
           
        }

        private void LoadCollections()
        {
            Genders = genderRepo.GetGenders();
            Statuses = studentRepo.GetStatusStudents();
            Groups = studentRepo.GetGroups();
            this.MainDataGrid.ItemsSource = studentRepo.GetStudents(); 
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.MainDataGrid.ItemsSource = null;
            this.MainDataGrid.ItemsSource = this.studentRepo.
                GetSearchStudentsResult(this.TxbSearch.Text);
        }

        private void AddNewStudent(object sender, RoutedEventArgs e)
        {
            SharedClass.OpenNewPage(this, new AddNewStudent());  
        }

        private void SaveStudent(object sender, RoutedEventArgs e)
        {
            studentRepo.SaveChanges();
            SharedClass.MessageBoxInformation("Данные успешно изменены в БД");
        }
    }
}
