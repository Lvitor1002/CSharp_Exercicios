namespace BtgApi.Utils
{

    //[STATIC] > Qualquer parte do sistema pode acessar sem precisar criar instâncias da classe
    public static class ConfigConexao
    {
        public static string ConnectionStrings { get; set; } = string.Empty;
    }
}
