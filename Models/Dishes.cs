using System.ComponentModel.DataAnnotations;
using System;
namespace CRUDILICIOUS.Models
{
    public class Dish
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int DishId { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [MinLength(2, ErrorMessage = "Min Dish Name Length is 2")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Required Field")]
        public string Chef { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [Range(1, 10, ErrorMessage = "One to Ten, Buddy")]
        public int Tastiness { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Calories must be numeric")]

        public int Calories { get; set; }


        [MinLength(20, ErrorMessage = "If you're gonna write something, really write something.")]
        public string Description{ get; set; }


        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}