using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForCollege.Model
{
    public partial class Student
    {
        public virtual ICollection<Gender> Genders { get; set; }
        public virtual ICollection<StatusStudent> Statuses { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
