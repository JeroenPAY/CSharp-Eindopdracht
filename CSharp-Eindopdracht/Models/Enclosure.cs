using CSharp_Eindopdracht.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CSharp_Eindopdracht.Models
{
    public class Enclosure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public Climate Climate { get; set; }

        [Required]
        public HabitatType HabitatType { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Size { get; set; } 

        [Required]
        public SecurityLevel SecurityLevel { get; set; }

        public ICollection<Animal>? Animals { get; set; }
    }
}
