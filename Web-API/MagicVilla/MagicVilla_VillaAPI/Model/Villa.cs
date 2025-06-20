﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Model
{
    public class Villa
    {
        [Key]  // here Id column define the primary key 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //provide auto increment column value
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; } 
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
