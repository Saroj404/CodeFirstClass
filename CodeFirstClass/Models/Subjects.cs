using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstClass.Models
{
    public class Subjects
    {
        [Key]
        public int id { get; set; }
        [StringLength(5)]
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Classes Class { get; set; }
    }
}
