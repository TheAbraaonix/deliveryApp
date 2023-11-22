using DeliveryApp.Models;

namespace DeliveryApp.Repositorio.Usuario
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);

        List<UsuarioModel> BuscarTodos();

        UsuarioModel AdicionarUsuario(UsuarioModel usuario);

        UsuarioModel AtualizarUsuario(UsuarioModel usuario);

        bool DeletarUsuario(int id);
    }
}
