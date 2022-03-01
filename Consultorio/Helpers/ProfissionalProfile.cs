using AutoMapper;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;

namespace Consultorio.Helpers
{
    public class ProfissionalProfile : Profile
    {
        public ProfissionalProfile()
        {
            CreateMap<Profissional, ProfissionalDetalhesDTO>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(p => p.Consultas.Count()))
                .ForMember(dest => dest.Especialidades, opt => opt.MapFrom(p => p.Especialidades.ForEach(item)));
        }
    }
}
