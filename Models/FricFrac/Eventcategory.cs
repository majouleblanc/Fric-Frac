using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fric_frac.Models.FricFrac
{
    [Table("eventcategory")]
    public partial class Eventcategory
    {
        public Eventcategory()
        {
        }

        [Required]
        [Column(TypeName = "varchar(120)")]
        [FromForm(Name = "Eventcategory-Name")]
        public string Name { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Eventcategory-Id")]
        public int Id { get; set; }

    }
}
