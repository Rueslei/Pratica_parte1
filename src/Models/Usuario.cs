namespace Pratica_parte1.src.Models
{
    public class Usuario
    {
        public Usuario(string cpf, string nome, DateTime data_nascimento)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.data_nascimento = data_nascimento;
        }

        public string cpf { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; }

        public static implicit operator string(Usuario usuario)
       => $"{usuario.cpf},{usuario.nome},{usuario.data_nascimento.ToString("yyyy-MM-dd")}";

        public static implicit operator Usuario(string line)
        {
            var data = line.Split(",");
            return new Usuario(
                data[0],
                data[1],
                data[2].ToDateTime());
        }
    }
    public static class StringExtension
    {
        public static DateTime ToDateTime(this string value)
        {
            var data = value.Split("-");
            return new DateTime(
                int.Parse(data[0]),
                int.Parse(data[1]),
                int.Parse(data[2]));
        }
    }
}
