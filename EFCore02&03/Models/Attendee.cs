using System;
using System.Collections.Generic;

namespace EFCore02_03.Models
{
    public class Attendee
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public Badge Badge { get; set; } = null!;

        public List<Registration> Registrations { get; set; } = new();
    }
}