using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Dal.Authors.Models;
using Dal.Questions.Models;
using Dal.Answers.Models;
using Dal.Tags.Models;
using Dal.Edits.Models;

namespace Dal;

public class QuestionDbContext : DbContext
{
    private const string ConnectionName = "DefaultConnection";

    public QuestionDbContext() : base()
    {
        AppSettings = new ConfigurationBuilder()
        .Add(new JsonConfigurationSource { Path = "datasettings.json", ReloadOnChange = true })
        .Build();
    }

    public DbSet<AuthorDal> Authors { get; set; }
    public DbSet<QuestionDal> Questions { get; set; }
    public DbSet<AnswerDal> Answers { get; set; }
    public DbSet<TagDal> Tags { get; set; }
    public DbSet<EditDal> Edits { get; init; } 

    public IConfigurationRoot AppSettings { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = AppSettings.GetConnectionString(ConnectionName);
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.UseLazyLoadingProxies();
    }
}
