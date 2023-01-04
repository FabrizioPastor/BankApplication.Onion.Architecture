using Application.Exceptions;
using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.UpdateClienteCommand;

public class UpdateClienteCommand: IRequest<Response<int>>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Direction { get; set; }
}

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
{
    private readonly IRepositoryAsync<Cliente> _repositoryAsync;
    private readonly IMapper _mapper;

    public UpdateClienteCommandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var record = await _repositoryAsync.GetByIdAsync(request.Id);
        if (record is null)
            throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
        record.Name = request.Name;
        record.LastName = request.LastName;
        record.BirthDay = request.BirthDay;
        record.Email = request.Email;
        record.Direction = request.Direction;

        await _repositoryAsync.UpdateAsync(record);

        return new Response<int>(record.Id);
    }
}