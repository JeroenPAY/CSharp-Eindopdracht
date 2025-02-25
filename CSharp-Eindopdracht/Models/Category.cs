using System.ComponentModel.DataAnnotations;

namespace CSharp_Eindopdracht.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Animal>? Animals { get; set; }
    }
}
