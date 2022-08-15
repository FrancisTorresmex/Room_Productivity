using System;
using System.Collections.Generic;

namespace Room_Productivity.Models
{
    public partial class Oficce
    {
        public Oficce()
        {
            Users = new HashSet<User>();
        }

        public int IdOffice { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
