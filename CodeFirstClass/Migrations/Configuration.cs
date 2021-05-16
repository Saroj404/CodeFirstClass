namespace CodeFirstClass.Migrations
{
    using CodeFirstClass.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstClass.Models.CodeFirst>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstClass.Models.CodeFirst context)
        {
            var user = new User() { Username = "Admin", Password = "admin123" };
            var userFromDB = context.Users.FirstOrDefault(p => p.Username == user.Username);
            if(userFromDB==null)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                userFromDB.Password = user.Password;
                context.Entry(userFromDB).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
