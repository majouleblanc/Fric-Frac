using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fric_frac.Models.FricFrac
{
    [Table("role")]
    public partial class Role
    {
        public Role()
        {
           // User = new HashSet<User>();
        }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [FromForm(Name = "Role-Name")]
        public string Name { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Role-Id")]
        public int Id { get; set; }

        //[InverseProperty("Role")]
        //public virtual ICollection<User> User { get; set; }
    }
}
