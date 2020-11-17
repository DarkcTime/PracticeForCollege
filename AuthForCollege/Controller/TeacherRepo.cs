using System;
using System.Collections.Generic;
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

        public List<Teacher> GetSearchResult(string search)
        {
            return context.Teachers.Where(i => i.FirstName.Contains(search)
            || i.LastName.Contains(search) || i.MiddleName.Contains(search)).ToList(); 
        }

    }
}
