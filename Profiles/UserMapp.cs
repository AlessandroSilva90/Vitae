using AutoMapper;

// Models
using Core_Providentia_vitae.Models;
using Core_Providentia_vitae.Models.Admin;

// DTO´s
using Core_Providentia_vitae.DTO.RH;
using Core_Providentia_vitae.DTO.Modules;
using Core_Providentia_vitae.Models.RH;

namespace Core_Providentia_vitae.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            // Mapeamento para CREATE
            CreateMap<CreateUsuarioDto, Usuario>()
                .ForMember(dest => dest.Sn_Funcionario, opt => opt.MapFrom(src => src.Snfuncionario))
                .ForMember(dest => dest.Ds_Usuario, opt => opt.MapFrom(src => src.DsUsuario))
                .ForMember(dest => dest.Dt_Create, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Sn_Ativo, opt => opt.MapFrom(src => true));

            // Mapeamento para UPDATE
            CreateMap<UpdateUsuarioDto, Usuario>()
     .ForMember(dest => dest.Sn_Ativo, opt => opt.MapFrom(src => src.Snativo))
     .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
     {
         if (srcMember == null) return false;

         if (srcMember is string str)
             return !string.IsNullOrWhiteSpace(str);

         if (srcMember is int intValue)
             return intValue != 0;


         if (srcMember is bool boolValue)
             return true; // Sempre mapeia booleans

         return true;
     }));

        }
    }
}
