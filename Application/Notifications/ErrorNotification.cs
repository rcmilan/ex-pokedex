using MediatR;

namespace Application.Notifications
{
    internal sealed record ErrorNotification(string Exception, string? StackTrace) : INotification;
}
