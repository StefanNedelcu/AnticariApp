using AnticariApp.Utils.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

#nullable disable

namespace AnticariApp.Data.Context;

public partial class ACContext : DbContext
{
    private readonly ConnectionStrings _connectionSettings;

    public ACContext()
    {

    }

    public ACContext(DbContextOptions<ACContext> options, IOptions<ConnectionStrings> connectionStrings)
        : base(options)
    {
        _connectionSettings = connectionStrings.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL(_connectionSettings.DefaultConnection);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
