using AutoMapper;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected readonly IMapper _mapper;
    protected readonly INotifier _notifier;

    protected MainController(IMapper mapper, INotifier notifier)
    {
        _mapper = mapper;
        _notifier = notifier;
    }

    protected ActionResult CustomResponse()
    {
        if (!_notifier.HasNotifications)
            return NoContent();

        return HandleErrors();
    }

    protected ActionResult CustomResponse<T>(T response)
    {
        if (!_notifier.HasNotifications)
            return Ok(response);

        return HandleErrors();
    }

    private ActionResult HandleErrors()
    {
        var notifications = _notifier.GetNotifications();
        var messages = notifications.Select(notification => notification.Message);

        return BadRequest(new
        {
            Errors = messages,
        });
    }
}
