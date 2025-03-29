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

        public readonly DateTime DataCadastro = DateTime.Now;

        public readonly int SituacaoStatus;
    }
}
