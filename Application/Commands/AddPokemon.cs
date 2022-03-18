using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public sealed record AddPokemon(int Id, string Name) : IRequest<Pokemon>;
}
