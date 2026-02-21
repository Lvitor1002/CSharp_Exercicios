namespace BtgApi.Models
{
    public class Cliente
    {
        public int ClienteID{ get; set; }
        public string NomeCliente{ get; set; } = string.Empty;
        public List<Aplicacao> ListaAplicacoes { get; set; } = new List<Aplicacao>();
        public List<Resgate> ListaResgates { get; set; } = new List<Resgate>();

        //Motivo do private > O Entity Framework precisa de um construtor sem parâmetros para conseguir instanciar objetos ao materializar dados do banco.
        private Cliente() { }

        public Cliente(int clienteID, string nomeCliente)
        {
            ClienteID = clienteID;
            NomeCliente = nomeCliente;
        }
    }
}
