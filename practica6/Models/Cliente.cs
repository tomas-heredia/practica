namespace Modelos
{  
   public class Cliente {
    public int IdCliente {get;set;}
    public string Nombre {get;set;}
    public string Apellido {get;set;}
    public DateTime FechaDeNacimiento {get;set;}
    public string Direccion {get;set;}
    public int Telefono{get;set;}
    public bool Activo {get;set;}

    public Cliente(int IdCliente, string Apellido, string Nombre, DateTime FechaDeNacimiento, string Direccion, int Telefono, bool Activo){
        this.IdCliente = IdCliente;
        this.Apellido = Apellido;
        this.Nombre = Nombre;
        this.FechaDeNacimiento = FechaDeNacimiento;
        this.Direccion = Direccion;
        this.Telefono = Telefono;
        this.Activo = Activo;
    }
    public Cliente (){}
   } 
}