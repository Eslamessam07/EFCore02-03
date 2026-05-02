using EFCore02_03.Models;
using System;
using System.Collections.Generic;

namespace EFCore02_03.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public bool IsVerified { get; set; }

        public Profile Profile { get; set; } = null!;
        public List<Event> Events { get; set; } = new();
    }
}