using System;

namespace EFCore02_03.Models
{
    public class Badge
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public DateTime IssuedAt { get; set; }

        public string Tier { get; set; } = string.Empty;

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
    }
}