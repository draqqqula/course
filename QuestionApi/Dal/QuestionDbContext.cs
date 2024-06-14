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
    public QuestionDbContext(DbContextOptions<QuestionDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<AuthorDal> Authors { get; set; }
    public DbSet<QuestionDal> Questions { get; set; }
    public DbSet<AnswerDal> Answers { get; set; }
    public DbSet<TagDal> Tags { get; set; }
    public DbSet<EditDal> Edits { get; init; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}
