using System.ComponentModel.DataAnnotations;
namespace ViewModels
{
    public class Usuario_IndexViewModel {
        [Required( ErrorMessage = "Campo Requerido.")]
        public int IdUsuario{get;set;}
        [Required( ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string NombreUsuario{get;set;}
        
    }
}