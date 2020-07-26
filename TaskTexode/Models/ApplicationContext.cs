using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace TaskTexode
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext ()
            : base("DbConnection")
        { }

        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<UserRecord> UserRecords { get; set; }

        public List<ApplicationUser>  GetAllUsers()
        {
            var allUsers= ApplicationUsers.ToList();

            foreach (ApplicationUser applicationUser in allUsers)
            {
                this.Entry(applicationUser).Collection("UserRecords").Load();
            }
            return allUsers;
        }

        public ApplicationUser FindUserByName(string userName)
        {
            var users = ApplicationUsers.ToList();
            foreach (ApplicationUser user in users)
            {
                if (user.Name == userName)
                {
                    this.Entry(user).Collection("UserRecords").Load();
                    return user;
                }
            }
            return null;
            }
        }
}
