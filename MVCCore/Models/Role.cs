using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContosoUniversity.Models;

namespace MVCCore.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
