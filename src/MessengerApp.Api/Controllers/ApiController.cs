using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MessengerApp.Api.Common.Http;

namespace MessengerApp.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> Errors)
    {
        HttpContext.Items[HttpContextItemKeys.Errors] = Errors;

        var firstError = Errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}