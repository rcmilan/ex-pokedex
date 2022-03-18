using Application.Notifications;
using MediatR;
using System.Text.Json;

namespace Application.EventHandlers
{
    internal class LogEventHandler : INotificationHandler<AddPokemonNotification>
    {
        public Task Handle(AddPokemonNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("ADD: {0}", JsonSerializer.Serialize(notification));
            }, cancellationToken);
        }
    }
}
