using Dal.Answers.Interfaces;
using Logic.Answers.Interfaces;
using Logic.Answers.Models;
using Dal.Answers.Models;
using Dal.Authors.Interfaces;
using Dal.Questions.Interfaces;
using Dal.Questions.Models;
using Logic.Answers.ViewModels;
using MyProfileConnectionLib.ConnectionServices.Interfaces;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAnsweredCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAskedCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceSolvedCounter;

namespace Logic.Answers;

/// <inheritdoc/>
internal class AnswerLogicManager : IAnswerLogicManager
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IProfileConnectionService _profileConnection;
    public AnswerLogicManager(
        IAnswerRepository answerRepository, 
        IAuthorRepository authorRepository,
        IQuestionRepository questionRepository,
        IProfileConnectionService profileConnection)
    {
        _answerRepository = answerRepository;
        _authorRepository = authorRepository;
        _questionRepository = questionRepository;
        _profileConnection = profileConnection;
    }

    /// <summary>
    /// Получение вопроса по уникальному идентификатору
    /// </summary>
    /// <param name="questionId"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    private async Task<QuestionDal> GetQuestion(Guid questionId) => await _questionRepository
        .GetInfoAsync(questionId)
            ?? throw new NullReferenceException($"Question with Id {questionId} not found.");

    /// <inheritdoc/>
    public async Task<Guid> PublishAsync(AnswerInputModel answer)
    {
        var question = await GetQuestion(answer.QuestionId);

        var dal = new AnswerDal()
        {
            Author = await _authorRepository.GetInfoAsync(answer.AuthorId),
            Question = question,
            Text = answer.Text,
            CreationTime = DateTime.UtcNow,
        };
        await _answerRepository.CreateAsync(dal);
        await _profileConnection.IncreaceAnsweredCounter(new IncreaceAnsweredCounterRequest()
        {
            Id = answer.AuthorId,
            Amount = 1
        });
        return dal.Id;
    }

    /// <inheritdoc/>
    public async Task<AnswerViewModel[]> GetAnswersAsync(Guid questionId)
    {
        var question = await GetQuestion(questionId);

        return question.Answers.Select(dal => new AnswerViewModel()
        {
            Id = dal.Id,
            AuthorId = dal.Author.Id,
            Text = dal.Text,
            AuthorName = dal.Author.Name,
            CreationTime = dal.CreationTime,

        }).ToArray();
    }

    /// <inheritdoc/>
    public async Task<Guid?> AcceptSolutionAsync(Guid answerId)
    {
        return await _questionRepository.AcceptSolutionAsync(answerId);
    }

    /// <inheritdoc/>
    public async Task<Guid?> RemoveAsync(Guid answerId)
    {
        return await _answerRepository.RemoveAsync(answerId);
    }
}
