using Pratica_parte1.src.Models;

namespace Pratica_parte1.src.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetAllUsuarios();

        Usuario GetUsuario(string cpf);
        Usuario InsertUsuario(Usuario usuario);
        bool UpdateUsuario(Usuario usuario);
        bool DeleteUsuario(string cpf);
    }
}
