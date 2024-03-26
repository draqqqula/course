using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Фильтр для методов удаления данных
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class RemovalExceptionFilter : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DataNotFoundException)
        {
            Handle(context, 404);
        }
        else if (context.Exception is ForbiddenRemovalException)
        {
            Handle(context, 400);
        }
    }

    /// <summary>
    /// Изменяет статус-код ответа на <paramref name="statusCode"/> и содержимое ответа на текст ошибки.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="statusCode"></param>
    private static void Handle(ExceptionContext context, int statusCode)
    {
        context.HttpContext.Response.StatusCode = statusCode;
        context.ExceptionHandled = true;
        context.Result = new ContentResult
        {
            Content = context.Exception.Message
        };
    }
}
