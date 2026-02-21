namespace Teste.Exceptions
{
    public class ApiException : Exception
    {

        public string Titulo { get; set; } = "Erro na Api";
        public int StatusCode { get; set; } = 500;

        public ApiException(string msg) : base(msg){ }
        public ApiException(string msg, int statusCode) : base(msg) 
        {
            StatusCode = statusCode;
        }
    }
}
