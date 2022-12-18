using Domain.Enums;
using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

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
    public int? ImageId { get; set; }
    public File Image { get; set; } 

    [NotMapped]
    public string FullName =>
        $"{LastName} {FirstName} {MiddleName}";

    public ICollection<Project> Projects { get; set; }
    public ICollection<Experience> Experiences { get; set; }
    public ICollection<Interview> Interviews { get; set; }
}
