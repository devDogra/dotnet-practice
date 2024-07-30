using Fliu.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace Fliu.Models
{
    public class Shirt
    {
        [Required]
        public int? ShirtId { get; set; }
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Shirt_EnsureCorrectSizing]
        public int Size { get; set; }
        
        public string? Gender { get; set; }
        [Required]
        [Range(100, 5000)]
        
        public double Price { get; set; }
        // Default value for ForGym: 
        public bool ForGym { get; set; } = true; 
        public override string ToString() {
            return $@"
                ShirtId: {ShirtId},
                Brand: {Brand},
                Color: {Color}, 
                Size: {Size}, 
                Gender: {Gender}, 
                Price: {Price},
                For Gym: {ForGym}
            ";
        }
    }


}
