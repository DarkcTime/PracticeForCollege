using AuthForCollege.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuthForCollege.Controller
{
    class GenderRepo : ModelRepo
    {
        
        public List<Gender> GetGenders()
        {
            //context.Teachers.FirstOrDefault().GendersCollection.FirstOrDefault().Name;
            return context.Genders.ToList();

        }
        
    }
}
