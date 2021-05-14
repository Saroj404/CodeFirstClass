using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstClass.Models
{
    public class Teacher
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

    }
}
