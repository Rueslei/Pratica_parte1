using Pratica_parte1.src.Models;

namespace Pratica_parte1.src.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool DeleteUsuario(string cpf)
        {
            var dbset = GetAllUsuarios();
            var usuario = dbset.Find(u => u.cpf == cpf);
            var result = dbset.Remove(usuario);

            File.WriteAllLines("usuarios.csv", dbset.Select(u => (string)u));

            return result;
        }
        public List<Usuario> GetAllUsuarios()
        {
            List<Usuario> list = new List<Usuario>();
            var data = File.ReadLines("usuarios.csv");

            foreach (var line in data)
            {
                Usuario usuario = line;

                list.Add(usuario);

            }
            return list;
        }
        public Usuario GetUsuario(string cpf)
        {
            var usuario = GetAllUsuarios().Find(u => u.cpf.Equals(cpf));
            return usuario;
        }

        public Usuario InsertUsuario(Usuario usuario)
        {
            var dbset = GetAllUsuarios();

            dbset.Add(usuario);

            File.WriteAllLines("usuarios.csv", dbset.Select(u => (string)u));


            return usuario;
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            var dbset = GetAllUsuarios();

            var entity = dbset.Find(u => u.cpf.Equals(usuario.cpf));
            if (entity != null)
            {
                dbset.Remove(entity);
                dbset.Add(usuario);
            }
            else
            {
                return false;
            }


            File.WriteAllLines("usuarios.csv", dbset.Select(u => (string)u));
            return true;
        }
    }
}
