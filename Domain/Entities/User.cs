using Domain.Enums;
using Domain.Entities.Base;

namespace Domain.Entities;

public class User : AuditableEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public Role Role { get; set; }

    public List<Project> Projects { get; set; }
    public List<Experience> Experiences { get; set; }
    public List<Interview> Interviews { get; set; }
    public List<Transaction> Transactions { get; set; }
}
