using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fric_frac.Models.FricFrac
{
    [Table("eventtopic")]
    public partial class Eventtopic
    {
        public Eventtopic()
        {
        }

        [Required]
        [Column(TypeName = "varchar(120)")]
        [FromForm(Name = "Eventtopic-Name")]
        public string Name { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Eventtopic-Id")]
        public int Id { get; set; }

    }
}
