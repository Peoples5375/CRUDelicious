using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int UserID{get;set;}

        [Required(ErrorMessage="Needs a name")]
        public string Name{get;set;}

        [Required(ErrorMessage="Need a Chef")]
        public string Chef{get;set;}

        [Required(ErrorMessage="Give a Rating")]
        public int Tastiness{get;set;}

        [Required(ErrorMessage="Needs to be greater than 0")]
        [Range(1,9000)]
        public int Calories{get;set;}
        
        [Required(ErrorMessage="Needs to have a Description")]
        public string Description{get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}