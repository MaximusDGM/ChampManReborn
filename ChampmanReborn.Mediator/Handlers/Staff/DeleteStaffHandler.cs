using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Staff;

namespace ChampManReborn.Mediator.Handlers.Staff;

public class DeleteStaffHandler(IStaffService staffService) : IRequestHandler<DeleteStaffCommand>
{
    public async Task<Unit> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
    {
        await staffService.DeleteStaffAsync(request.Id);

        return Unit.Value;
    }
}