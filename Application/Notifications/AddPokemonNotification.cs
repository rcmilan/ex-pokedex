using Domain.Entities;
using MediatR;

namespace Application.Notifications
{
    internal sealed record AddPokemonNotification : INotification
    {
        public AddPokemonNotification(Pokemon pokemon, bool success)
        {
            Id = pokemon.Id;
            Name = pokemon.Name;
            Success = success;
        }

        public int Id { get; private init; }
        public string Name { get; private init; }
        public bool Success { get; private init; }
    }
}
