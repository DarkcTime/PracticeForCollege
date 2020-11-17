using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuthForCollege.Model; 
namespace AuthForCollege.Controller
{
    class UserRepo : ModelRepo
    {        
        public static User AuthUser { get; private set; }

         public bool IsAuth(string login, string password)
        {
            var user = context.Users.ToList().Where(i => i.Login == login && i.Password == password); 

            if(user.Count() > 0)
            {
                AuthUser = user.FirstOrDefault();
                return true; 
            }
          
            return false;
        }        

    }
}
