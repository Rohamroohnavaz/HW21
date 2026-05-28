using HW21.Infrastructure.Data;
using HW21.Repository.MainRepositories;

namespace HW21.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new AppDbContext();

            var userRepo = new UserRepository(dbContext);
            
        }
    }
}
