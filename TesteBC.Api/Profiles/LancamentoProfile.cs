using AutoMapper;
using TesteBC.Api.Models;
using TesteBC.Api.Models.DTO;
using TesteBC.Api.Models.Reports;
using TesteBC.Domain.Models;

namespace TesteBC.Api.Profiles
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<LancamentoCreateDTO, LancamentoModel>().ForMember
                (
                    lancto => lancto.VlTotal,
                    opt => opt.MapFrom(lanctoDTO => lanctoDTO.VlLancamento + ((lanctoDTO.VlEncargos + lanctoDTO.VlJurosMora) - lanctoDTO.VlDesconto))
                 );
            CreateMap<LancamentoUpdateDTO, LancamentoModel>();
            CreateMap<LancamentoModel, LancamentoReadDTO>();

            CreateMap<LancamentoModel, LancamentosDiarioDTO>().ForMember(lanctoDTO => lanctoDTO.Nome, opt => opt.MapFrom(lancto => lancto.Entidade.Nome));
        }
    }
}
