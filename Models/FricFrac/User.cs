using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fric_frac.Models.FricFrac
{
    [Table("user")]
    public partial class User
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        [FromForm(Name = "User-Name")] //last les
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        [FromForm(Name = "User-Salt")] //last les
        public string Salt { get; set; }

        [Column(TypeName = "varchar(255)")]
        [FromForm(Name = "User-HashedPassword")] //last les
        public string HashedPassword { get; set; }

        [Column(TypeName = "int(11)")]
        [FromForm(Name = "User-PersonId")] //last les
        public int? PersonId { get; set; }

        [Column(TypeName = "int(11)")]
        [FromForm(Name = "User-RoleId")] //last les
        public int? RoleId { get; set; }

        [Key]
        [Column(TypeName = "int(11)")]
        [FromForm(Name = "User-Id")] //last les
        public int Id { get; set; }

        //--last les----------------------------------
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }



        //[ForeignKey(nameof(PersonId))]
        //[InverseProperty("User")]
        //public virtual Person Person { get; set; }
        ////[ForeignKey(nameof(RoleId))]
        //[InverseProperty("User")]
        //public virtual Role Role { get; set; }
    }
}
