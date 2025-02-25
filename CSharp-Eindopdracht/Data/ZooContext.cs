using CSharp_Eindopdracht.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CSharp_Eindopdracht.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
