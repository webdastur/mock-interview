using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DefaultData;

internal static class DefaultUser
{
    internal static void DefaultSuperUser(this ModelBuilder modelBuilder)
    {
        byte[] passwordHash;
        byte[] passwordSalt;
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("mock"));
        }

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                LastName = "Ergashev",
                FirstName = "Azamat",
                Login = "hackaton",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = "998900000000",
                Role = Domain.Enums.Role.Admin
            });
    }
}
