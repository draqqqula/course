using Api.Controllers.Questions.Requests;
using Api.Controllers.Questions.Responses;
using Logic.Questions.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Logic.Questions.Models;
using Core.Exceptions;
using Api.Filters;

namespace Api.Controllers;

/// <summary>
/// Работа со всеми вопросами
/// </summary>
[Route("public/questions")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionLogicManager _questionLogicManager;
    public QuestionController(IQuestionLogicManager questionLogicManager)
    {
        _questionLogicManager = questionLogicManager;
    }

    /// <summary>
    /// Опубликовать новый вопрос
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("ask")]
    [ProducesResponseType(typeof(PublishQuestionResponseDto), 200)]
    public async Task<IActionResult> PublishQuestionAsync([FromBody] PublishQuestionRequestDto dto)
    {
        var id = await _questionLogicManager.PublishAsync(new QuestionInputModel()
        {
            AuthorId = dto.AuthorId,
            Tags = dto.Tags,
            Text = dto.Text,
            Title = dto.Title,
        });
        return Ok(new PublishQuestionResponseDto() { Id = id });
    }

    /// <summary>
    /// Поиск по вопросам с фильтрацией
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> SearchAsync([FromQuery] SearchRequestDto options)
    {
        var result = await _questionLogicManager.SearchAsync(new SearchOptionsInputModel()
        {
            AuthorId = options.FromUser,
            FromDate = options.FromDate,
            ToDate = options.ToDate,
            Page = options.Page,
            PerPage = options.PerPage,
            ShowSolved = options.ShowSolved,
            Tags = options.Tags,
        });
        return Ok((SearchResponseDto)result);
    }

    /// <summary>
    /// Удалить вопрос
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("remove")]
    [RemovalExceptionFilter]
    [ProducesResponseType(typeof(RemoveQuestionRequestDto), 200)]
    public async Task<IActionResult> RemoveQuestionAsync([FromBody] RemoveQuestionRequestDto dto)
    {
        var id = await _questionLogicManager.RemoveAsync(dto.QuestionId);
        return Ok(new RemoveQuestionResponseDto()
        {
            QuestionId = id
        });
    }

    /// <summary>
    /// Отредактировать вопрос
    /// выполняется автором вопроса
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("edit")]
    [ProducesResponseType(typeof(EditQuestionResponseDto), 200)]
    public async Task<IActionResult> EditQuestionAsync([FromBody] EditQuestionRequestDto dto)
    {
        var id = await _questionLogicManager.EditAsync(new EditInputModel() 
        { 
            QuestionId = dto.QuestionId, 
            Text = dto.Text 
        });
        return Ok(new EditQuestionResponseDto()
        {
            Id = id
        });
    }
}