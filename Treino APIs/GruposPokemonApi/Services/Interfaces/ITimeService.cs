using Teste.Models;
using Teste.Utils;

namespace Teste.Services.Interfaces
{
    public interface ITimeService
    {
        public Task<Time> CriarTime(TimeRecord timeR);
        public Dictionary<string, Time> ProcuarTodosTimes();
        public Time BuscarTimePorID(string id);
    }
}
