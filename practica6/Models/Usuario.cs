namespace Modelos
{  
    public class Usuario {
        public int IdUsuario{get;set;}
        public string NombreUsuario{get;set;}
        public int Telefono {get;set;}
        public bool Activo {get;set;}
        public Usuario(int IdUsuario, string NombreUsuario,int Telefono,bool Activo){
            this.IdUsuario = IdUsuario;
            this.NombreUsuario = NombreUsuario;
            this.Telefono = Telefono;
            this.Activo = Activo;
        }
        public Usuario(){}
    }
}