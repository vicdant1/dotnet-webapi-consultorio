using AutoMapper;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;

namespace Consultorio.Helpers
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Consulta, ConsultaDetalhesDTO>();
            CreateMap<AgendamentoAdicionarDTO, Consulta>();
        }
    }
}
