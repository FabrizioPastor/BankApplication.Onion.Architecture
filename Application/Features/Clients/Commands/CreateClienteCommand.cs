using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
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
    public CreateClienteCommandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }

    private readonly IRepositoryAsync<Cliente> _repositoryAsync;
    private readonly IMapper _mapper;
    public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var nuevoRegistro = _mapper.Map<Cliente>(request);
        var data = await _repositoryAsync.AddAsync(nuevoRegistro, cancellationToken);
        return new Response<int>(data.Id);
    }
}