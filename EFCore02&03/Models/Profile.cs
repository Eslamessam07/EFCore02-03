using System;

namespace EFCore02_03.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string Bio { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;
    }
}