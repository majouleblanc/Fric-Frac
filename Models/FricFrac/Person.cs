using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fric_frac.Models.FricFrac
{
    [Table("person")]
    public partial class Person
    {
        public Person()
        {
            //User = new HashSet<User>();
        }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [FromForm(Name = "Person-FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(120)")]
        [FromForm(Name = "Person-LastName")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(255)")]
        [FromForm(Name = "Person-Email")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(255)")]
        [FromForm(Name = "Person-Password")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(255)")]
        [FromForm(Name = "Person-Address1")]
        public string Address1 { get; set; }

        [Column(TypeName = "varchar(255)")]
        [FromForm(Name = "Person-Address2")]
        public string Address2 { get; set; }

        [Column(TypeName = "varchar(20)")]
        [FromForm(Name = "Person-PostalCode")]
        public string PostalCode { get; set; }

        [Column(TypeName = "varchar(80)")]
        [FromForm(Name = "Person-City")]
        public string City { get; set; }

        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Person-CountryId")]
        public int? CountryId { get; set; }

        [Column(TypeName = "varchar(25)")]
        [FromForm(Name = "Person-Phone1")]
        public string Phone1 { get; set; }

        [Column(TypeName = "datetime")]
        [FromForm(Name = "Person-Birthday")]
        public DateTime? Birthday { get; set; }

        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Person-Rating")]
        public int? Rating { get; set; }

        [Key]
        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Person-Id")]
        public int Id { get; set; }

        //last les
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        //[ForeignKey(nameof(CountryId))]
        //[FromForm(Name = "Person-Country")]
        //public virtual Country Country { get; set; }

        //[InverseProperty("Person")]
        //public virtual ICollection<User> User { get; set; }
    }
}
