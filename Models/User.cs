using System;
using System.Collections.Generic;

namespace Room_Productivity.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int IdBoss { get; set; }
        public int IdOffice { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? Registration { get; set; }
        public bool Active { get; set; }
        public bool Special { get; set; }
        public string? Name { get; set; }

        public virtual Boss IdBossNavigation { get; set; } = null!;
        public virtual Oficce IdOfficeNavigation { get; set; } = null!;
    }
}
