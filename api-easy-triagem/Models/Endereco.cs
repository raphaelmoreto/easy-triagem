namespace Models
{
    public class Endereco
    {
        public int Logradouro { get; set; }
        public string _Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int EstadoUF { get; set; }
        public string CEP { get; set; }

        public Endereco()
        {
        }

        public Endereco(int logradouro, string endereco, string numero, string? complemento, string bairro, string cidade, int estadoUF, string cep)
        {
            Logradouro = logradouro;
            _Endereco = endereco;
            Numero = numero;
            Complemento = complemento ?? ""; //SE "complemento" FOR NULO, ATRIBUI UM VALOR VÁZIO
            Bairro = bairro;
            Cidade = cidade;
            EstadoUF = estadoUF;
            CEP = cep;
        }
    }
}
