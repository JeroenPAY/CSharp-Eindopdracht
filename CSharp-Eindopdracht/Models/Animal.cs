using CSharp_Eindopdracht.Models.Enums;
using CSharp_Eindopdracht.Models;
using System.ComponentModel.DataAnnotations;

namespace CSharp_Eindopdracht.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Species { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? EnclosureId { get; set; }
        public Enclosure? Enclosure { get; set; }

        [Required]
        public Size Size { get; set; }

        [Required]
        public DietaryClass DietaryClass { get; set; }

        [Required]
        public ActivityPattern ActivityPattern { get; set; }

        [Range(0.1, double.MaxValue)]
        public double SpaceRequirement { get; set; }

        [Required]
        public SecurityLevel SecurityRequirement { get; set; }
    }
}
