using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Data
{
    public class ChatApplicationDbContext : IdentityDbContext
	{
		public ChatApplicationDbContext(DbContextOptions<ChatApplicationDbContext> options) : base(options)
		{

		}

		public void Seed()
		{
			if (!this.Database.IsInMemory())
			{
				return;
			}
			SeedUsers();
		}

		private void SeedUsers()
		{
			//Password Test123$
			var passwordHash = "AQAAAAEAACcQAAAAECp9VnV5jgDyqQqacxkrC+OcWFUM1+mavZ4+mxxhqtm/dg9UTVq1vhgAKFsblrEXDA==";

			//User for Admin role
			var email = "r0886600@student.vives.be";
			var user = new IdentityUser
			{
				UserName = email,
				Email = email,
				NormalizedEmail = email.ToUpperInvariant(),
				NormalizedUserName = email.ToUpperInvariant(),
				PasswordHash = passwordHash
			};
			Users.Add(user);

			//Normal user without roles
			var memberEmail = "jane.doe@student.vives.be";
			var member = new IdentityUser
			{
				UserName = memberEmail,
				Email = memberEmail,
				NormalizedEmail = memberEmail.ToUpperInvariant(),
				NormalizedUserName = memberEmail.ToUpperInvariant(),
				PasswordHash = passwordHash
			};
			Users.Add(member);

			this.SaveChanges();
		}
	}
}
