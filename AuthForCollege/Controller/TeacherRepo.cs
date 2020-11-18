using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthForCollege.Model; 

namespace AuthForCollege.Controller
{
    class TeacherRepo : ModelRepo
    {
        public List<Teacher> GetTeachers()
        {
            return context.Teachers.ToList(); 
        } 

        public ObservableCollection<Teacher> GetSearchResult(string search)
        {
            return new ObservableCollection<Teacher>(context.Teachers.Where(i => i.FirstName.Contains(search)
            || i.LastName.Contains(search) || i.MiddleName.Contains(search)).ToList()); 
        }

    }
}
