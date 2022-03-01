using AutoMapper;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;

namespace Consultorio.Helpers
{
    public class EspecialidadeProfile : Profile
    {
        public EspecialidadeProfile()
        {
            CreateMap<Especialidade, EspecialidadeDetalhesDTO>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(src => src.Consultas.Count()));
        }
    }
}
