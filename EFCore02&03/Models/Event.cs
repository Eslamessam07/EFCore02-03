using EFCore02_03.Models;

namespace EFCore02_03.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        // Organizer relation
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;

        // Self relation (Parent Event)
        public int? ParentEventId { get; set; }
        public Event? ParentEvent { get; set; }   // nullable عشان مش كل event له parent

        public List<Event> Sessions { get; set; } = new();

        // Registrations (Many-to-Many via table)
        public List<Registration> Registrations { get; set; } = new();
    }
}