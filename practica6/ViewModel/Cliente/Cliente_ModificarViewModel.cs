using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class Cliente_ModificarViewModel {
        public int IdCliente {get;set;}
        
         [Required( ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string Apellido {get;set;}

         [Required( ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string Nombre {get;set;}

        [DataType(DataType.Date, ErrorMessage = "Formato invalido.")] 
        public DateTime FechaDeNacimiento {get;set;}
        
        [StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string Direccion {get;set;}

        [Phone( ErrorMessage = "Formato invalido.")]
        public int Telefono {get;set;}
    }
}