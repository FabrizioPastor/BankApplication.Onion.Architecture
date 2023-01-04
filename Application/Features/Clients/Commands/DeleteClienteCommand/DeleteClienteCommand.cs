using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.DeleteClienteCommand;

public class DeleteClienteCommand: IRequest<Response<int>>
{
    public int Id { get; set; }
}

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<int>>
{
    private readonly IRepositoryAsync<Cliente> _repositoryAsync;
    private readonly IMapper _mapper;

    public DeleteClienteCommandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var record = await _repositoryAsync.GetByIdAsync(request.Id);
        if (record is null)
            throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
        await _repositoryAsync.DeleteAsync(record);
        await _repositoryAsync.SaveChangesAsync();
        return new Response<int>(record.Id);
    }
}