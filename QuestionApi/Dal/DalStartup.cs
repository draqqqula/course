using Dal.Answers;
using Dal.Answers.Interfaces;
using Dal.Authors;
using Dal.Authors.Interfaces;
using Dal.Edits;
using Dal.Edits.Interfaces;
using Dal.Questions;
using Dal.Questions.Interfaces;
using Dal.Tags;
using Dal.Tags.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dal;

public static class DalStartup
{
    public static IServiceCollection TryAddDal(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<QuestionDbContext>();
        serviceCollection.TryAddScoped<IAnswerRepository, AnswerRepository>();
        serviceCollection.TryAddScoped<IAuthorRepository, AuthorRepository>();
        serviceCollection.TryAddScoped<IQuestionRepository, QuestionRepository>();
        serviceCollection.TryAddScoped<ITagRepository, TagRepository>();
        serviceCollection.TryAddScoped<IEditRepository, EditRepository>();
        return serviceCollection;
    }
}
