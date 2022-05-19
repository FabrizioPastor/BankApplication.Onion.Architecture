using Application.Wrappers;
using FluentValidation;
using MediatR;

namespace Application.Features.Clients.Commands;

public class CreateClienteCommand : IRequest<Response<int>>
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Direction { get; set; }
}

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<int>>
{
    public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}