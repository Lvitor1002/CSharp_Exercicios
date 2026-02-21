
using System.Text.Json;

namespace BackEndPicPay.Services.Autorizador
{
    public class AutorizadorService : IAutorizadorService
    {

        //privado e imutável 
        private readonly HttpClient _httpClient;
        public AutorizadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        private const string URL = "https://util.devi.tools/api/v2/authorize";


        //Classe interna representando a parte de dados da resposta
        //Mapeia o campo "authorization" do JSON
        private class DataResponse
        {
            public bool authorization { get; set; }
        }


        //Classe interna que representa a estrutura completa da resposta
        //Contém status geral e objeto de dados aninhado
        private class ApiResponse
        {
            public string status { get; set; }
            public DataResponse data { get; set; }
        }


        public async Task<bool> Autorizar()
        {
            //Variável para armazenar o conteúdo bruto da resposta
            string conteudo = string.Empty;

            //Faz chamada GET assíncrona para o serviço externo
            var respostaApi = await _httpClient.GetAsync(URL);

            if (!respostaApi.IsSuccessStatusCode) 
            {
                return false;
            }

            conteudo = await respostaApi.Content.ReadAsStringAsync();

            //Desserializa o JSON para o objeto RespostaApi
            //Converte a string em estrutura de dados tipada
            var resultado = JsonSerializer.Deserialize<ApiResponse>(conteudo);

            //Retorna true se for "sucesso", false caso contrário
            return resultado?.status == "sucesso";
        }
    }
}
