using Api.Controllers.Answers.Requests;
using Api.Controllers.Answers.Responses;
using Logic.Answers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Logic.Answers.Models;
using Logic.Questions.Interfaces;
using Api.Controllers.Questions.Responses;
using Core.Exceptions;
using Api.Filters;

namespace Api.Controllers;

/// <summary>
/// Работа с обсуждением конкретного вопроса
/// </summary>
[Route("public/discussion")]
public class DiscussionController : ControllerBase
{
    private readonly IAnswerLogicManager _answerLogicManager;
    private readonly IQuestionLogicManager _questionLogicManager;

    public DiscussionController(IAnswerLogicManager answerLogicManager, IQuestionLogicManager questionLogicManager)
    {
        _answerLogicManager = answerLogicManager;
        _questionLogicManager = questionLogicManager;
    }


    /// <summary>
    /// Публикация ответа на вопрос
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("answer")]
    [ProducesResponseType(typeof(PublishAnswerResponseDto), 200)]
    public async Task<IActionResult> PublishAnswerAsync([FromBody] PublishAnswerRequestDto dto)
    {
        var id = await _answerLogicManager.PublishAsync(new AnswerInputModel() 
        { 
            AuthorId = dto.AuthorId,
            QuestionId = dto.QuestionId,
            Text = dto.Text
        });
        return Ok(new PublishAnswerResponseDto() 
        { 
            Id = id
        });
    }

    /// <summary>
    /// Получение вопроса и всех ответов
    /// </summary>
    /// <param name="questionId"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(DiscussionDto), 200)]
    public async Task<IActionResult> GetDiscussionAsync([FromQuery] Guid questionId)
    {
        var question = await _questionLogicManager.GetInfoAsync(questionId);
        var answers = await _answerLogicManager.GetAnswersAsync(questionId);

        var solution = answers
            .Where(it => it.Id == question.SolutionId)
            .FirstOrDefault();

        var discussion = new DiscussionDto()
        {
            Question = (QuestionDetailDto)question,
            Answers = answers.Except([solution]).Select(it => (AnswerDto)it).ToArray(),
            Solution = solution is not null? (AnswerDto)solution : null
        };

        return Ok(discussion);
    }

    /// <summary>
    /// Принятие ответа в качестве решения
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("accept")]
    [ProducesResponseType(typeof(AcceptSolutionResponseDto), 200)]
    public async Task<IActionResult> AcceptSolutionAsync([FromBody]AcceptSolutionRequestDto dto)
    {
        var id = await _answerLogicManager.AcceptSolutionAsync(dto.AnswerId);
        return Ok(new AcceptSolutionResponseDto()
        {
            AnswerId = id
        });
    }

    /// <summary>
    /// Удалить ответ
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("remove")]
    [RemovalExceptionFilter]
    [ProducesResponseType(typeof(RemoveAnswerResponseDto), 200)]
    public async Task<IActionResult> RemoveAnswerAsync([FromBody]RemoveAnswerRequestDto dto)
    {
        var id = await _answerLogicManager.RemoveAsync(dto.AnswerId);
        return Ok(new RemoveAnswerResponseDto()
        {
            AnswerId = id
        });
    }
}