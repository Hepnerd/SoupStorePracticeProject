using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoupStorePracticeProject.Models;

namespace SoupStorePracticeProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SoupStorePracticeProject.Models.Store> Store { get; set; }
        public DbSet<SoupStorePracticeProject.Models.Cart> Cart { get; set; }
    }
}