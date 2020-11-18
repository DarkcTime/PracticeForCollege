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
using System.Collections.ObjectModel;

namespace AuthForCollege.View
{
    /// <summary>
    /// Interaction logic for ListTeachers.xaml
    /// </summary>
    public partial class ListTeachers : Page
    {
        private ObservableCollection<Teacher> teachersnol { get; set; }
        public ObservableCollection<Teacher> teachers { get { return teachersnol; } set { teachersnol = value; } }
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
            //this.MainDataGrid.ItemsSource = this.teacherRepo.GetTeachers();
            //Genders = this.genderRepo.GetGenders();
            teachersnol = new ObservableCollection<Teacher>(teacherRepo.GetTeachers());
            //MainDataGrid.ItemsSource = teachers;
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //teachers.RemoveAt(1);
            //teachers.Add(new Teacher());
            teachers.Clear();
            teachers = teacherRepo.GetSearchResult(TxbSearch.Text);
            //teachersnol = teacherRepo.GetSearchResult(TxbSearch.Text);
            //foreach (var item in teacherRepo.GetSearchResult(TxbSearch.Text))
            //{
            //    teachers.Add(item);
            //}
            //Teachers = teacherRepo.GetSearchResult(this.TxbSearch.Text);
            //if (string.IsNullOrWhiteSpace(this.TxbSearch.Text)) return;
            //this.MainDataGrid.ItemsSource = null;
            //this.MainDataGrid.ItemsSource = this.teacherRepo.GetSearchResult(this.TxbSearch.Text);
        }
    }
}
