using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuthForCollege.Model; 

namespace AuthForCollege.Controller
{
    class StudentRepo : ModelRepo 
    {
        public List<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public List<StatusStudent> GetStatusStudents()
        {
            return context.StatusStudents.ToList(); 
        } 

        public List<Group> GetGroups()
        {
            return context.Groups.ToList(); 
        }

        public List<Student> GetSearchStudentsResult(string search)
        {
            return context.Students.Where(i => i.FirstName.Contains(search)
            || i.LastName.Contains(search) || i.MiddleName.Contains(search)).ToList();
        }


        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            SaveChanges();
        }
    }
}
