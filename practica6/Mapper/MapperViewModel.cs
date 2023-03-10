using Modelos;
using AutoMapper;
using ViewModels;

namespace Mappers 
{
    public class MapperViewModel:Profile {
        public MapperViewModel(){
            CreateMap<Cliente,Cliente_CargarViewModel>().ReverseMap();
            CreateMap<Cliente,Cliente_IndexViewModel>().ReverseMap();
            CreateMap<Cliente,Cliente_ModificarViewModel>().ReverseMap();
            CreateMap<Activos_Inactivos,Cliente_Activos_InactivosViewModel>().ReverseMap();
        
            CreateMap<Usuario,Usuario_IndexViewModel>().ReverseMap();
        }
    }
}