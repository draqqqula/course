namespace Api.Controllers.Authors.Requests
{
    /// <summary>
    /// Запрос на добавление автора
    /// </summary>
    public record CreateAuthorRequestDto
    {
        public required Guid ProfileId { get; init; }
    }
}
