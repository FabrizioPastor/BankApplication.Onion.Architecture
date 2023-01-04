using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.CreateClienteCommand;

public class CreateClienteCommand : IRequest<Response<int>>
{
    public string? Name { get; set; } = default;
    public string? LastName { get; set; }  = default;
    public DateTime BirthDay { get; set; }  = default;
    public string? PhoneNumber { get; set; }  = default;
    public string? Email { get; set; }  = default;
    public string? Direction { get; set; }  = default;
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
        Cliente data;
        try
        {
            data = await _repositoryAsync.AddAsync(nuevoRegistro, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return new Response<int>(data.Id);
    }
}