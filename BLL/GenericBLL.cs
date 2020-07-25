using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using great_challenge.Abstract;

namespace great_challenge.BLL
{
    public class GenericBLL<T> where T : class
    {
        private readonly IGreatRepository<T> _context;

        public GenericBLL(IGreatRepository<T> context) => _context = context;

        public async Task Create(T obj) => await _context.Create(obj);

        public async Task<IEnumerable<T>> GetAll() => (await _context.GetAll()).ToList();

        public async Task<T> Find(long id) => await _context.Find(id);

        public async Task Update(T obj) => await _context.Update(obj);

        public async Task<bool> Exists(long id) => (await Find(id)) != null;

        public async Task Delete(long id)
        {
            var obj = await _context.Find(id);
            await _context.Delete(obj);
        }
    }
}