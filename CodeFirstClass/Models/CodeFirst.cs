using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstClass.Models
{
    public class CodeFirst : DbContext
    {
        
        public CodeFirst()
            : base("name=CodeFirst")
        {
        }

        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Classes> Class { get; set; }

        public virtual DbSet<Teacher> ClassTeacher { get; set; }
        public virtual DbSet<User> Users { get; set; }


    }

    
}