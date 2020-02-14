using System;
using System.ComponentModel.DataAnnotations;

namespace NinjaInfoCards.Models
{
    public class Ninja
    {
        [Key]
        public int NinjaId { get; set; }

        [Required (ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Age is required")]
        [Range (0, 125, ErrorMessage = "Enter a valid age (0 to 125)")]
        public int? Age { get; set; }

        [Required (ErrorMessage = "Village is required")]
        public string Village { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public void Print ()
        {
            Console.WriteLine($"{NinjaId} | {Name} | {Age} | {Village}");
        }
    }
}