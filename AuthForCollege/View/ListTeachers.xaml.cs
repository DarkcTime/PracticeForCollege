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
    /// Interaction logic for ListTeachers.xaml
    /// </summary>
    public partial class ListTeachers : Page
    {
        public List<Teacher> Teachers { get; set; }
        //public List<Gender> Genders { get; set; }
        public List<Gender> GendersList{ get; set; }

        private TeacherRepo teacherRepo = new TeacherRepo(); 
        private GenderRepo genderRepo = new GenderRepo(); 
        public ListTeachers()
        {
            InitializeComponent();
            this.DataContext = this;
            GendersList = this.genderRepo.GetGenders();
            this.MainDataGrid.ItemsSource = this.teacherRepo.GetTeachers();
            //Genders = this.genderRepo.GetGenders();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(this.TxbSearch.Text)) return;
            this.MainDataGrid.ItemsSource = null;
            this.MainDataGrid.ItemsSource = this.teacherRepo.GetSearchResult(this.TxbSearch.Text);
        }

        private void SaveTeacher(object sender, RoutedEventArgs e)
        {
            if(teacherRepo.SaveChanges())
                SharedClass.MessageBoxInformation("Данные успешно изменены в БД");

        }

        private void AddNewTeacher(object sender, RoutedEventArgs e)
        {
            SharedClass.OpenNewPage(this, new AddNewTeacher());
        }

    }
}
