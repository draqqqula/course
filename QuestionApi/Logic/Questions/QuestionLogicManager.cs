using Dal.Questions.Interfaces;
using Dal.Tags.Interfaces;
using Logic.Questions.Interfaces;
using Logic.Questions.Models;
using Dal.Questions.Models;
using Dal.Authors.Interfaces;
using Dal.Tags.Models;
using Core.Dal.Extensions;
using Microsoft.EntityFrameworkCore;
using Logic.Questions.ViewModels;
using Dal.Edits.Models;
using Dal.Edits.Interfaces;

namespace Logic.Questions;

/// <inheritdoc/>
internal class QuestionLogicManager : IQuestionLogicManager
{
    private readonly IQuestionRepository _questionRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IEditRepository _editRepository;

    public QuestionLogicManager(
        IQuestionRepository questionRepository, 
        ITagRepository tagRepository, 
        IAuthorRepository authorRepository,
        IEditRepository editRepository)
    {
        _questionRepository = questionRepository;
        _tagRepository = tagRepository;
        _authorRepository = authorRepository;
        _editRepository = editRepository;
    }

    /// <inheritdoc/>
    public async Task<Guid> PublishAsync(QuestionInputModel question)
    {
        var tags = await BuildTagListAsync(question.Tags);
        var questionDal = new QuestionDal()
        {
            Author = await _authorRepository.GetInfoAsync(question.AuthorId),
            CreationTime = DateTime.UtcNow,
            Text = question.Text,
            Title = question.Title,
            Tags = tags.ToList()
        };
        foreach (var tag in tags)
        {
            tag.Questions.Add(questionDal);
        }
        return await _questionRepository.CreateAsync(questionDal);
    }

    /// <inheritdoc/>
    private async Task<TagDal[]> BuildTagListAsync(string[] tags)
    {
        List<TagDal> newTags = [];
        var models = new List<TagDal>();

        foreach (var tag in tags)
        {
            var dal = await _tagRepository.FindTagAsync(tag) ?? AddToList(tag, newTags);
            models.Add(dal);
        }

        await _tagRepository.AddRangeAsync(newTags.ToArray());

        return models.ToArray();
    }

    /// <summary>
    /// Добавить тег в список. 
    /// Создаёт dal из текста и добавляет в список
    /// </summary>
    /// <param name="text"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    private static TagDal AddToList(string text, List<TagDal> list)
    {
        var dal = new TagDal() { Text = text };
        list.Add(dal);
        return dal;
    }

    /// <inheritdoc/>
    public async Task<SearchResultViewModel> SearchAsync(SearchOptionsInputModel options)
    {
        var pageInfo = _questionRepository.GetAll()
            .WhereIfNotNull(options.FromDate, it => it.CreationTime > options.FromDate)
            .WhereIfNotNull(options.ToDate, it => it.CreationTime <= options.ToDate)
            .WhereIf(!options.ShowSolved, it => it.SolutionId == null)
            .WhereIfNotNull(options.AuthorId, it => it.Author.Id == options.AuthorId)
            .WhereIf(options.Tags is not null, it => 
                it.Tags
                .Select(it => it.Text)
                .Intersect(options.Tags).Any())
            .OrderBy(it => it.CreationTime)
            .ToPageInfo(options.Page, options.PerPage);
        var models = await pageInfo.Collection.ToArrayAsync();
        return new SearchResultViewModel()
        {
            Questions = models
            .Select(it => (QuestionSummaryViewModel)it)
            .ToArray(),
            CurrentPage = pageInfo.CurrentPage,
            TotalPages = pageInfo.TotalPages
        };
    }

    /// <inheritdoc/>
    public async Task<QuestionDetailViewModel> GetInfoAsync(Guid id)
    {
        var dal = await _questionRepository.GetInfoAsync(id) 
            ?? throw new ArgumentException($"Question {id} not found.");

        return (QuestionDetailViewModel)dal;
    }

    /// <inheritdoc/>
    public async Task<Guid?> RemoveAsync(Guid id)
    {
        return await _questionRepository.RemoveAsync(id);
    }

    /// <inheritdoc/>
    public async Task<Guid> EditAsync(EditInputModel edit)
    {
        var question = await _questionRepository.GetInfoAsync(edit.QuestionId)
            ?? throw new ArgumentException($"Question {edit.QuestionId} not found.");
        return await _editRepository.AddAsync(new EditDal()
        {
            Question = question,
            PublishTime = DateTime.UtcNow,
            Text = edit.Text,
        });
    }
}
