using AutoMapper;
using TesteBC.Domain.Models;
using TesteBC.Api.Models.DTO;

namespace TesteBC.Api.Profiles
{
    public class EntidadeProfile : Profile
    {
        public EntidadeProfile()
        {
            CreateMap<EntidadeCreateDTO, EntidadeModel>();
            CreateMap<EntidadeUpdateDTO, EntidadeModel>();
            CreateMap<EntidadeModel, EntidadeReadDTO>();
        }
    }
}
