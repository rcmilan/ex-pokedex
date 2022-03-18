using Application.Commands;
using Application.Notifications;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers
{
    internal class AddPokemonCommandHandler : IRequestHandler<AddPokemon, Pokemon>
    {

        protected readonly IMediator _mediator;
        protected readonly IRepository<Pokemon, int> _repository;

        public AddPokemonCommandHandler(IMediator mediator, IRepository<Pokemon, int> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Pokemon> Handle(AddPokemon request, CancellationToken cancellationToken)
        {
            var pokemon = new Pokemon(request.Id, request.Name);

            bool success;

            try
            {
                await _repository.AddAsync(pokemon);
                success = true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification(ex.Message, ex.StackTrace), cancellationToken);
                success = false;
            }

            await _mediator.Publish(new AddPokemonNotification(pokemon, success));

            return pokemon;
        }
    }
}
