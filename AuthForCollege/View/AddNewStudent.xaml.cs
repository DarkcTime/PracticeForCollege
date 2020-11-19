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
using AuthForCollege.Model; 

namespace AuthForCollege.View
{
    /// <summary>
    /// Interaction logic for AddNewStudent.xaml
    /// </summary>
    public partial class AddNewStudent : Page
    {
        public Model.Student Student { get; set; }

        private GenderRepo genderRepo = new GenderRepo();
        private StudentRepo studentRepo = new StudentRepo();
        public AddNewStudent()
        {
            InitializeComponent();
            Student = new Model.Student();
            this.Student.Genders = genderRepo.GetGenders();
            this.Student.Statuses = studentRepo.GetStatusStudents();
            this.Student.Groups = studentRepo.GetGroups();
            this.DataContext = Student;
            
            //Student.
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!studentRepo.AddStudent(Student)) return;

                SharedClass.MessageBoxInformation("Студент успешно добавлен в таблицу");
                SharedClass.OpenNewPage(this, new ListStudents());
            }         
            catch(Exception ex){
                SharedClass.MessageBoxError(ex.Message);
            }
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            SharedClass.OpenNewPage(this, new ListStudents());
        }
    }
}
