using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Mmodel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }
    public class Tdata : DbContext
    {
        public Tdata(DbContextOptions<Tdata> options) : base(options)
        {

        }
        public DbSet<Mmodel> Patient_Details { get; set; }
    }
}
