using DeliveryApp.Data;
using DeliveryApp.Models;
using DeliveryApp.Repositorio.Usuario;

namespace DeliveryApp.Repositorio.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel AdicionarUsuario(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel AtualizarUsuario(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if (usuarioDb == null)
            {
                throw new Exception("Houve um erro na atualização do usuário.");
            }

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();
            return usuarioDb;
        }

        public bool DeletarUsuario(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);

            if (usuarioDb == null)
            {
                throw new Exception("Houve um erro na deleção do usuário.");
            }

            _bancoContext.Usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}