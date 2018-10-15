using System;
using System.ComponentModel.DataAnnotations;

namespace LostintheWoods.Models
{
    public class BaseEntity{}
    public class AllTrails
    {
        [Key]
        public int id {get;set;}
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z_ ]+$", ErrorMessage = "Name can only contain letters")]
        public string trail_name {get;set;}
        [MinLength(2)]
        public string description {get;set;}
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Numbers in miles")]
        public string length{get;set;}
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "only numbers in feet")]
        public string elevation{get;set;}
        public string latitude{get;set;}
        public string longitude{get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }

}