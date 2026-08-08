using IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Models;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Repositories;

public class AttendeeVisitRepository
{
    private static readonly List<AttendeeVisit> Attendees = new();
    private static int _nextId = 1;

    public List<AttendeeVisit> GetAll() => Attendees.OrderByDescending(a => a.CheckInTime).ToList();

    public AttendeeVisit? GetById(int id) => Attendees.FirstOrDefault(a => a.Id == id);

    public void Add(AttendeeVisit attendee)
    {
        attendee.Id = _nextId++;
        attendee.CheckInTime = DateTime.Now;
        attendee.Status = "Present";
        Attendees.Add(attendee);
    }

    public void Update(AttendeeVisit attendee)
    {
        var existing = GetById(attendee.Id);
        if (existing == null) return;

        existing.TicketNumber = attendee.TicketNumber;
        existing.FirstName = attendee.FirstName;
        existing.LastName = attendee.LastName;
        existing.Organization = attendee.Organization;
        existing.ContactNumber = attendee.ContactNumber;
        existing.Email = attendee.Email;
        existing.EventName = attendee.EventName;
        existing.Notes = attendee.Notes;
    }

    public void CheckOut(int id)
    {
        var attendee = GetById(id);
        if (attendee == null) return;
        attendee.CheckOutTime = DateTime.Now;
        attendee.Status = "Left Event";
    }

    public void Delete(int id)
    {
        var attendee = GetById(id);
        if (attendee != null) Attendees.Remove(attendee);
    }

    public IEnumerable<AttendeeVisit> Search(string? term)
    {
        if (string.IsNullOrWhiteSpace(term)) return GetAll();

        term = term.Trim();
        return GetAll().Where(a =>
            a.TicketNumber.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            a.FirstName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            a.LastName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            a.Organization.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            a.EventName.Contains(term, StringComparison.OrdinalIgnoreCase));
    }
}
