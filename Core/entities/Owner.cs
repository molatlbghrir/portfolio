namespace Core.entities
{
    public class Owner : EntityBase
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string profil { get; set; }
        public Address Address { get; set; }
    }
}
