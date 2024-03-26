using Logic.Answers;
using Logic.Answers.Interfaces;
using Logic.Authors;
using Logic.Authors.Interfaces;
using Logic.Questions;
using Logic.Questions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Logic;

public static class LogicStartUp
{
    public static IServiceCollection TryAddLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IAnswerLogicManager, AnswerLogicManager>();
        serviceCollection.TryAddScoped<IAuthorLogicManager, AuthorLogicManager>();
        serviceCollection.TryAddScoped<IQuestionLogicManager, QuestionLogicManager>();
        return serviceCollection;
    }
}