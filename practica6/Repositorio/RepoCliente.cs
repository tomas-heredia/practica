using Modelos;

using Microsoft.Data.Sqlite;
namespace Repo
{
    public class RepoCliente:IRepoCliente {
        
        //conexion con db
        string connectionString = "Data Source= Base/practica3.db;Cache=Shared";
        public RepoCliente(){
        
        }

        public void cargarCliente(Cliente Cliente){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Clientes (Apellido,Nombre,Direccion,Telefono,FechaDeNacimiento) VALUES (@apellido,@nombre, @direccion,@telefono, @fechaDeNacimiento)", conexion);
                insertar.Parameters.AddWithValue("@apellido", Cliente.Apellido);
                insertar.Parameters.AddWithValue("@nombre", Cliente.Nombre);
                insertar.Parameters.AddWithValue("@direccion", Cliente.Direccion);
                insertar.Parameters.AddWithValue("@telefono", Cliente.Telefono);
                insertar.Parameters.AddWithValue("@fechaDeNacimiento", Cliente.FechaDeNacimiento);
                
                insertar.ExecuteReader();
                conexion.Close();
                
                
            }

        }
        public List<Cliente> ConsultaCliente(){
            List<Cliente> ListaClientes = new List<Cliente>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Clientes WHERE Activo = 1", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {   
                    string direccion = "";
                    if (query["Direccion"] != System.DBNull.Value)
                    {
                        direccion = query["Direccion"].ToString();
                    }
                    DateTime fecha = DateTime.Today;
                    if (query["FechaDeNacimiento"] != System.DBNull.Value)
                    {
                        fecha= Convert.ToDateTime(query["FechaDeNacimiento"]);
                    }
                    var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }

                                                                //ID,          Apellido               Nombre                    
                        ListaClientes.Add(new Cliente(query.GetInt32(0), query.GetString(1), query.GetString(2),fecha ,direccion,Telefono, query.GetBoolean(6))  );
                    }
                conexion.Close();
                }
            return ListaClientes;
        } 

         public void EliminarCliente(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("UPDATE Clientes SET Activo = 0 WHERE IdCliente = @Id", conexion);
                select.Parameters.AddWithValue("@Id",id);
                
                select.ExecuteReader();
                conexion.Close();
                
                
                
            }


        }

        public void ActualizarCliente(Cliente Cliente){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("UPDATE Clientes SET Apellido = @apellido, Nombre = @nombre, Direccion = @direccion,FechaDeNacimiento = @fechaDeNacimiento , Telefono = @telefono WHERE IdCliente = @Id", conexion);
                    select.Parameters.AddWithValue("@nombre", Cliente.Nombre);
                    select.Parameters.AddWithValue("@direccion", Cliente.Direccion);
                    select.Parameters.AddWithValue("@telefono", Cliente.Telefono);
                    select.Parameters.AddWithValue("@apellido", Cliente.Apellido);
                    select.Parameters.AddWithValue("@fechaDeNacimiento", Cliente.FechaDeNacimiento);
                    
                    select.Parameters.AddWithValue("@Id",Cliente.IdCliente);
                    
                    select.ExecuteNonQuery();
                    conexion.Close();
                        
                    
            }
        }

        public Cliente TomarCliente(int id){
            
             using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    Cliente nuevoCliente = new Cliente();
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Clientes where IdCliente = @Id ", conexion);
                 select.Parameters.AddWithValue("@Id",id);
                var query = select.ExecuteReader();
                while (query.Read())
                {
                    string direccion = "";
                    if (query["Direccion"] != System.DBNull.Value)
                    {
                        direccion= query["Direccion"].ToString() ;
                    }
                    DateTime fecha = DateTime.Today;
                    if (query["FechaDeNacimiento"] != System.DBNull.Value)
                    {
                        fecha= Convert.ToDateTime(query["FechaDeNacimiento"]);
                    }
                    var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }
                                                //ID,          Apellido               Nombre                    
                    nuevoCliente = new Cliente(query.GetInt32(0), query.GetString(1), query.GetString(2),fecha,direccion ,Telefono , query.GetBoolean(6)   );
                }   
                conexion.Close();
                return nuevoCliente;
                }
        }
        public int ClientesActivos(){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    var Activos = 0;
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("SELECT * FROM Clientes where Activo == 1 ", conexion);
                    
                    var query = select.ExecuteReader();
                    while (query.Read())
                    {
                        Activos ++;
                      }   
                    conexion.Close();
                    return Activos;
                    }
        }
        public int ClientesInactivos(){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    var Inactivos = 0;
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("SELECT * FROM Clientes where Activo == 0 ", conexion);
                    
                    var query = select.ExecuteReader();
                    while (query.Read())
                    {
                        Inactivos ++;
                      }   
                    conexion.Close();
                    return Inactivos;
                    }
        }
        
    }
}