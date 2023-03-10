using Modelos;

namespace Repo;
public interface IRepoCliente
{
    void cargarCliente(Cliente Cliente);
    void EliminarCliente(int id);
    List<Cliente> ConsultaCliente();

    Cliente TomarCliente(int id);
    void ActualizarCliente(Cliente Cliente);
}