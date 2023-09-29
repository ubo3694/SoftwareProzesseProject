using Assignment1.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
    public class TrainingContext : DbContext
    {
        public TrainingContext() { }

        public TrainingContext(DbContextOptions<TrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Training> Trainings { get; set; } = null!;
    }
}
