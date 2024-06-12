using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Notifications;
using FluentValidation;

namespace DevIO.Business.Services;

public abstract class BaseService
{
    private readonly INotifier _notifier;

    protected BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected bool Validate<TValidator, TEntity>(TValidator validator, TEntity? entity)
        where TValidator : AbstractValidator<TEntity>
        where TEntity : Entity
    {
        if (entity == null)
            return false;

        var validationResult = validator.Validate(entity);

        if (validationResult.IsValid)
            return true;

        foreach (var error in validationResult.Errors)
            Notify(error.ErrorMessage);

        return false;
    }

    protected void Notify(string message) =>
        _notifier.AddNotification(new Notification(message));
}
