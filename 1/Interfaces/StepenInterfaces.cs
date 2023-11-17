using _1.Database;
using _1.Filters.PrepodStepenFilters;
using _1.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _1.Interfaces.StepenInterfaces
{
    public interface IStepenService
    {
        public Task<Prepod[]> GetPrepodsByStepenAsync(PrepodStepenFilter filter, CancellationToken cancellationToken);
    }

    public class StepenService : IStepenService
    {
        private readonly PrepodDbcontext _dbContext;
        public StepenService(PrepodDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByStepenAsync(PrepodStepenFilter filter, CancellationToken cancellationToken = default)
        {
            var stepen = _dbContext.Set<Prepod>().Where(w => w.Stepen.StepenName == filter.Name_stepen).ToArrayAsync(cancellationToken);

            return stepen;
        }
    }
}
