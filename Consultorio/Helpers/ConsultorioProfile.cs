using AutoMapper;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;

namespace Consultorio.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Paciente, PacienteDetalhesDTO>();
            CreateMap<Consulta, ConsultaDTO>()
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(p => p.Profissional.Nome))
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(e => e.Especialidade.Nome));

            CreateMap<PacienteAdicionarDTO, Paciente>();
            CreateMap<PacienteEditarDTO, Paciente>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Paciente, PacienteDTO>();
        }
    }
}
