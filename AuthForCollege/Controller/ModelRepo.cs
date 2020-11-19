using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthForCollege.BackEnd;
using AuthForCollege.Model; 

namespace AuthForCollege.Controller
{
    class ModelRepo
    {
        protected static CollegeEntities context = new CollegeEntities();
        
        public bool SaveChanges()
        {
            try
            {
                context.SaveChanges();
                return true; 
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException db)
            {
                SharedClass.MessageBoxWarning("Данные заполнены некорректно");
                return false; 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ve)
            {
                SharedClass.MessageBoxWarning("Данные заполнены некорректно");
                return false; 
            }            
        }

    }
}
