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
            CreateMap<CreateUsuarioDto, Usuarios>()
                .ForMember(dest => dest.Sn_Funcionario, opt => opt.MapFrom(src => src.SnFuncionario))
                .ForMember(dest => dest.Ds_Usuario, opt => opt.MapFrom(src => src.DsUsuario))
                .ForMember(dest => dest.Dt_Create, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Sn_Ativo, opt => opt.MapFrom(src => true));

            // Mapeamento para UPDATE
            CreateMap<UpdateUsuarioDto, Usuarios>()
    .ForMember(dest => dest.Sn_Ativo, opt => opt.MapFrom(src => src.SnAtivo))
    .ForMember(dest => dest.Sn_Funcionario, opt => opt.MapFrom(src => src.SnFuncionario))
    .ForMember(dest => dest.Ds_Usuario, opt => opt.MapFrom(src => src.DsUsuario))
    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
    {
        // Regra: só mapeia se o valor NÃO for o "default" do tipo

        if (srcMember == null)
            return false;

        var type = srcMember.GetType();

        if (Nullable.GetUnderlyingType(type) != null)
        {
            return true;
        }

        if (srcMember is string str)
            return !string.IsNullOrWhiteSpace(str);

        if (srcMember is int intValue && type == typeof(int))
            return intValue != 0;

        if (srcMember is bool)
            return true;

        return true;
    }));

            CreateMap<UpdateModulesDto, Modulo>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
