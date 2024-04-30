using AutoMapper;
using WebApiCQRS.Application.DTO;
using WebApiCQRS.Domain.Entities;

namespace WebApiCQRS.Application.Mappings
{
    public class DTOToDomainMap : Profile
    {
        public DTOToDomainMap()
        {
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
        }
    }
}