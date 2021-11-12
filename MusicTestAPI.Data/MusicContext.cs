using Microsoft.EntityFrameworkCore;
using MusicTestAPI.Data.Entities;
using System.Diagnostics.CodeAnalysis;

public class MusicContext : DbContext
{


    public MusicContext(DbContextOptions<MusicContext> options) : base(options)
    { 
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Author> Authors { get; set; }

}
