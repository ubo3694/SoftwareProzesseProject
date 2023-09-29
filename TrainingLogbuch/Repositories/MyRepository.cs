using Assignment1;
using Assignment1.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Frontend.Repositories
{
    public class MyRepository : IMyRepository
    {
        private readonly TrainingContext _context;

        public MyRepository(TrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await _context.Trainings.AsNoTracking().ToListAsync();
        }

        public async Task<Training> GetTrainingById(long id)
        {
            return await _context.Trainings.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTraining(Training training)
        {
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();
        }

        // Additional methods as needed...
        public async Task DeleteTraining(long id)
        {
            var training = await _context.Trainings.FindAsync(id);
            if (training != null)
            {
                _context.Trainings.Remove(training);
                await _context.SaveChangesAsync();
            }
        }

    }
}
