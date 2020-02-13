using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fric_frac.Models.FricFrac
{
    [Table("event")]
    public partial class Event
    {
        public Event()
        {

        }

        [Required]
        [Column(TypeName = "varchar(120)")]
        [FromForm(Name = "Event-Name")] //last les
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(120)")]
        [FromForm(Name = "Event-Location")] //last les
        public string Location { get; set; }

        [Column(TypeName = "datetime")]
        [FromForm(Name = "Event-Starts")] //last les
        public DateTime? Starts { get; set; }

        [Column(TypeName = "datetime")]
        [FromForm(Name = "Event-Ends")] //last les
        public DateTime? Ends { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        [FromForm(Name = "Event-Image")] //last les
        public string Image { get; set; }

        [Required]
        [Column(TypeName = "varchar(1024)")]
        [FromForm(Name = "Event-Description")] //last les
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "varchar(120)")]
        [FromForm(Name = "Event-OrganiserName")] //last les
        public string OrganiserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(120)")]
        [FromForm(Name = "Event-OrganiserDescription")] //last les
        public string OrganiserDescription { get; set; }

        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Event-EventcategoryId")] //last les
        public int? EventcategoryId { get; set; }

        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Event-EventtopicId")] //last les
        public int? EventtopicId { get; set; }

        [Key]
        [Column(TypeName = "int(11)")]
        [FromForm(Name = "Event-Id")]
        public int Id { get; set; }

        //--last les----------------------------------
        [ForeignKey("EventtopicId")]
        public Eventtopic Eventtopic { get; set; }

        [ForeignKey("EventcategoryId")]
        public Eventcategory Eventcategory { get; set; }

    }
}
