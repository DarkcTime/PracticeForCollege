using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthForCollege.Model; 

namespace AuthForCollege.Controller
{
    class ModelRepo
    {
        protected static CollegeEntities context = new CollegeEntities();
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
