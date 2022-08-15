using System;
using System.Collections.Generic;

namespace Room_Productivity.Models
{
    public partial class Boss
    {
        public Boss()
        {
            Users = new HashSet<User>();
        }

        public int IdBoss { get; set; }
        public int IdUser { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
