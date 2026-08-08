using IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Models;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Repositories;

public class UserRepository
{
    private static readonly List<User> Users = new();
    private static int _nextId = 1;

    public User? Validate(string username, string password) =>
        Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                               && u.Password == password);

    public bool Exists(string username) =>
        Users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

    public void Add(User user)
    {
        user.Id = _nextId++;
        Users.Add(user);
    }
}
