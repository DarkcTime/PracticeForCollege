using AuthForCollege.BackEnd;
using AuthForCollege.Controller;
using AuthForCollege.Model;
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
    /// Interaction logic for AddNewTeacher.xaml
    /// </summary>
    public partial class AddNewTeacher : Page
    {
        public Teacher Teacher { get; set; }

        private GenderRepo genderRepo = new GenderRepo();
        private TeacherRepo teacherRepo = new TeacherRepo();
        public AddNewTeacher()
        {
            InitializeComponent();
            Teacher = new Teacher();
            this.Teacher.Genders = genderRepo.GetGenders();
            this.DataContext = Teacher; 

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if(!teacherRepo.AddNewTeacher(Teacher)) return;

            SharedClass.MessageBoxInformation("Учитель успешно добавлен в базу данных");
            SharedClass.OpenNewPage(this, new ListTeachers());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            SharedClass.OpenNewPage(this, new ListTeachers()); 
        }
    }
}
