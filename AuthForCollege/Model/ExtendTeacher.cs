using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForCollege.Model
{
    public partial class Teacher
    {
        public ICollection<Gender> Genders { get; set; }
          
    }
}
