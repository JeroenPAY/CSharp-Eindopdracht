using System.Collections.Generic;

namespace CSharp_Eindopdracht.Models
{
    public class Zoo
    {
        public ICollection<Animal>? Animals { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Enclosure>? Enclosures { get; set; }

    }
}
