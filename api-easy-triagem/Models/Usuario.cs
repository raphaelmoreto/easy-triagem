namespace Models
{
    public class Usuario
    {
        private readonly int ID;
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string SexoBiologico { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        private readonly int SituacaoStatus;

        public readonly DateTime DataCadastro;

        public Usuario (string nome, DateTime dataNascimento, string sexoBiologico, string cpf, string email, Endereco endereco)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            SexoBiologico = sexoBiologico;
            CPF = cpf;
            Email = email;
            Endereco = endereco;
            DataCadastro = DateTime.Now;
        }
    }
}
