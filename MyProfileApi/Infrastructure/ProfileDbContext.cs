using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

internal class ProfileDbContext : DbContext
{
    private const string ConnectionName = "DefaultConnection";

    public DbSet<Profile> Profiles { get; set; }

    public ProfileDbContext() : base()
    {
        AppSettings = new ConfigurationBuilder()
        .Add(new JsonConfigurationSource { Path = "datasettings.json", ReloadOnChange = true })
        .Build();
    }

    public IConfigurationRoot AppSettings { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = AppSettings.GetConnectionString(ConnectionName);
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.UseLazyLoadingProxies();
    }
}
