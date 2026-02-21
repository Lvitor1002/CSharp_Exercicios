using System.Text;
using System.Text.Json;
using Teste.Exceptions;
using Teste.Models;
using Teste.Services.Interfaces;
using Teste.Utils;

namespace Teste.Services
{
    public class TimeService : ITimeService
    {
        //Atributos
        private readonly IPokemonService _pokemonService;

        // Dicionário que armazena todos os times
        private readonly Dictionary<string, Time> _time = new Dictionary<string, Time>();

        private readonly ILogger<TimeService> _logger; //Para registro de mensagens de log durante a execução da aplicação
        private readonly string PERSISTENCIA_PATH;


        //Construtor
        public TimeService(IPokemonService pokemonService, IConfiguration config, ILogger<TimeService> logger)
        {
            _pokemonService = pokemonService;
            _logger = logger;

            //Se 'Persistencia' for nula, traga o padrão
            string nomeArquivo = config["Persistencia"] ?? "default.json";

            //Caminho completo absoluto para o arquivo de persistência
            PERSISTENCIA_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);

            // Garantir que o diretório pai exista
            string diretorio = Path.GetDirectoryName(PERSISTENCIA_PATH)!;

            if (string.IsNullOrEmpty(diretorio)) 
            {
                _logger.LogError($"Erro ao criar diretório: {diretorio}!");
                throw new ApiException($"Erro ao criar diretório!");
            }
            Directory.CreateDirectory(diretorio);
            _logger.LogInformation($"Diretório criado: {diretorio}!");

            CarregarTimes();
        }


        public async Task<Time> CriarTime(TimeRecord timeRecord)
        {
            if (timeRecord.ListaTimeR.Count > 6)
            {
                throw new ApiException("Máximo de 6 Pokémons por time");
            }

            var tasks = timeRecord.ListaTimeR
                .Select(nome => _pokemonService.BuscarPokemonPorNome(nome))
                .ToList(); 

            var pokemons = await Task.WhenAll(tasks);

            var listaPokemons = pokemons.ToList(); //Para lista


            // Gera um novo ID baseado na quantidade atual de times no dicionário
            var novoID = _time.Count + 1;

            //Cria o novo objeto Time 
            var novoTime = new Time {
                NomeProprietario = timeRecord.ProprietarioR,
                ListaPokemons = listaPokemons
            };

            //Adiciona o novo time ao dicionário usando o ID como chave
            _time.Add(
                novoID.ToString(),
                novoTime
            );

            await Salvar();
            return novoTime;
        }

        public Time BuscarTimePorID(string id)
        {
            return _time.FirstOrDefault(x => x.Key == id).Value
                ?? throw new ApiException($"Time com o id[{id}] não foi encontrado!");
        }

        public Dictionary<string, Time> ProcuarTodosTimes() => _time;


        //Private porque será chamado aqui nesta classe
        private void CarregarTimes()
        {
            if (!File.Exists(PERSISTENCIA_PATH)) {
                _logger.LogWarning($"Arquivo não encontrado: {PERSISTENCIA_PATH}!");
                return;
            }

            try
            {
                string json = File.ReadAllText(PERSISTENCIA_PATH, Encoding.UTF8);

                if (string.IsNullOrWhiteSpace(json))
                {
                    _logger.LogWarning("Arquivo de persistência vazio");
                    return;
                }

                var arquivoPersistencia = JsonSerializer.Deserialize<JsonDocument>(json);

                arquivoPersistencia?.RootElement
                    .EnumerateObject()
                    .ToList()
                    .ForEach(t =>
                    {
                        var nomeArquivo = t.Name;
                        var elemento = arquivoPersistencia.RootElement.GetProperty(nomeArquivo);

                        _time.Add(nomeArquivo, elemento.Deserialize<Time>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!);
                    });
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Erro ao carregar times");
                throw new ApiException($"Erro ao carregar times: {ex.Message}");
            }
        }

        //Private porque será chamado aqui nesta classe
        private async Task Salvar()
        {
            try
            {
                string diretorio = Path.GetDirectoryName(PERSISTENCIA_PATH)!;
                if (string.IsNullOrEmpty(diretorio)) 
                {
                    _logger.LogError("Diretorio está vazio!");
                    return;
                }
                Directory.CreateDirectory(diretorio);
                
                string json = JsonSerializer.Serialize(_time);

                await File.WriteAllTextAsync(PERSISTENCIA_PATH,json, Encoding.UTF8 );

                _logger.LogInformation("Times salvos com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar times");
                throw new ApiException($"Erro ao salvar times: {ex.Message}");
            }
        }
    }
}
