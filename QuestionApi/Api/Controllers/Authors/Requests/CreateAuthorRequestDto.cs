namespace Api.Controllers.Authors.Requests
{
    /// <summary>
    /// Запрос на добавление автора
    /// </summary>
    public record CreateAuthorRequestDto
    {
        public required string Name { get; init; }
    }
}
