using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ChefNDish
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public DateTime BOD {get;set;}
        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Dish> Dishes {get;set;}
    }
}