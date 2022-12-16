using Application.Features.Clients.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        #region Commands

        CreateMap<CreateClienteCommand, Cliente>();

        #endregion
    }
}