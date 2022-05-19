using FireSharp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HALFFLUX_main_website.Models;

public class ApplicationContexts : DbContext
{
    public ApplicationContexts(DbContextOptions<ApplicationContexts> options) : base(options)
    {
        
    }

    public DbSet<Changelog> Changelogs { get; set; }
    public DbSet<User> Users { get; set; }
}