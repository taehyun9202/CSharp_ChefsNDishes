using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ChefNDish
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public int Calories {get;set;}
        [Required]
        public int Tastiness {get;set;}
        public string Description {get;set;}
        public int ChefId {get;set;}
        public Chef Owner {get;set;} // should this be list<Chef> instead?
    }
}