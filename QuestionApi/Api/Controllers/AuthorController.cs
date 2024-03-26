using Api.Controllers.Authors.Requests;
using Logic.Authors.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Logic.Authors.Models;
using Api.Controllers.Authors.Responses;

namespace Api.Controllers;

/// <summary>
/// Работа с авторами
/// </summary>
[Route("public/authors")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorLogicManager _authorLogicManager;
    public AuthorController(IAuthorLogicManager authorLogicManager)
    {
        _authorLogicManager = authorLogicManager;
    }

    /// <summary>
    /// Добавить автора
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateAuthorResponseDto), 200)]
    public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorRequestDto dto)
    {
        var id = await _authorLogicManager.CreateAsync(
            new AuthorInputModel() 
            { 
                AuthorName = dto.Name 
            });
        return Ok(new CreateAuthorResponseDto { Id = id });
    }
}