using Pratica_parte1.src.Models;
using Pratica_parte1.src.Repositories;

namespace Pratica_parte1.src.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAllUsuarios();
        }

        public bool DeleteUsuario(string cpf)
        {
            return _usuarioRepository.DeleteUsuario(cpf);
        }

        public Usuario GetUsuario(string cpf)
        {
            var usuario =  _usuarioRepository.GetUsuario(cpf);   
            return usuario;
        }

        public Usuario InsertUsuario(Usuario usuario)
        {
            return _usuarioRepository.InsertUsuario(usuario);
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            return _usuarioRepository.UpdateUsuario(usuario);
        }
    }
}
