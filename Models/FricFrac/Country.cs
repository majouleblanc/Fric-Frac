using Microsoft.AspNetCore.Mvc;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fric_frac.Models.FricFrac
{
    [Table("country")]
    public partial class Country
    {
        public Country()
        {
        }

        [Required]
        [StringLength(50)]
        [MySqlCharset("utf8mb4")]
        [FromForm(Name = "Country-Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(2)]
        [FromForm(Name = "Country-Code")]
        public string Code { get; set; }
        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Country-Id")]
        public int Id { get; set; }
        [FromForm(Name = "Country-Desc")]
        [StringLength(256)]
        public string Desc { get; set; }
    }
}
