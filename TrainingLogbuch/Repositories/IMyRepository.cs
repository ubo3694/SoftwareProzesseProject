using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Model;

namespace MVC_Frontend.Repositories
{
    public interface IMyRepository
    {
        Task<IEnumerable<Training>> GetAllTrainings();
        Task<Training> GetTrainingById(long id);
        Task AddTraining(Training training);
        Task DeleteTraining(long id);  // Hinzugefügte Methode zum Löschen eines Trainings
        // Weitere Methoden, je nach Bedarf...
    }
}
