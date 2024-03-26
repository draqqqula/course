namespace Api.Controllers.Authors.Responses
{
    /// <summary>
    /// Ответ на запрос на добавление автора
    /// </summary>
    public record CreateAuthorResponseDto
    {
        public required Guid Id { get; set; }
    }
}
