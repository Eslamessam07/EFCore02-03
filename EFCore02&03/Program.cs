using EFCore02_03.Data;
using EFCore02_03.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore02_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Organizer + Profile
            var organizer = new Organizer
            {
                Name = "Tech Corp",
                IsVerified = true,
                Profile = new Profile
                {
                    Bio = "We organize tech events",
                    Website = "www.tech.com",
                    LogoUrl = "logo.png"
                }
            };

            // Main Event
            var mainEvent = new Event
            {
                Title = "Tech Conference",
                Description = "Big event",
                StartDate = DateTime.Now,
                MaxAttendees = 100,
                Organizer = organizer
            };

            // Session under main event
            var session = new Event
            {
                Title = "AI Workshop",
                Description = "AI session",
                StartDate = DateTime.Now,
                MaxAttendees = 30,
                Organizer = organizer,
                ParentEvent = mainEvent
            };

            // Attendee + Badge
            var attendee = new Attendee
            {
                FullName = "Ahmed Ali",
                Email = "ahmed@test.com",
                Street = "Street 1",
                City = "Cairo",
                Country = "Egypt",
                PostalCode = "12345",
                Badge = new Badge
                {
                    Number = 1,
                    IssuedAt = DateTime.Now,
                    Tier = "VIP"
                }
            };

            // Registration (many-to-many)
            var registration = new Registration
            {
                Attendee = attendee,
                Event = mainEvent,
                Note = "Excited!",
                RegisteredAt = DateTime.Now
            };

            mainEvent.Sessions.Add(session);

            context.Add(registration);

            context.SaveChanges();

            Console.WriteLine("Data inserted successfully");

            // Test data
            var events = context.Events
                .Include(e => e.Organizer)
                .Include(e => e.Sessions)
                .Include(e => e.Registrations)
                .ToList();

            foreach (var e in events)
            {
                Console.WriteLine("Event: " + e.Title);
                Console.WriteLine("Organizer: " + e.Organizer.Name);
                Console.WriteLine("Sessions count: " + e.Sessions.Count);
                Console.WriteLine("Registrations count: " + e.Registrations.Count);
                Console.WriteLine("------------------------");
            }
        }
    }
}