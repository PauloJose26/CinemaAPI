using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CinemaAPI.Data;

public class CinemaContext : DbContext
{
    public CinemaContext(DbContextOptions options) : base(options) { }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecoes { get; set; }
}
