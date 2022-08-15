namespace Room_Productivity.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IdBoss { get; set; }
        public int IdOffice { get; set; }
        public byte[] Image { get; set; }
        public DateTime Registration { get; set; }
        public bool Active { get; set; }
        public bool Special { get; set; }
    }
}
