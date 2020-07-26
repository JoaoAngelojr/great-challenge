using System.Threading.Tasks;
using great_challenge.Abstract;
using great_challenge.Models;

namespace great_challenge.Repository
{
    public class UserRepository : GreatRepository<User>, IUserRepository
    {
        protected greatContext _context;

        public UserRepository(greatContext context) : base(context) { }

        public async Task<User> GetUserByCpfOrRg(string document)
        {
            return await Find(u => u.Cpf == document || u.Rg == document);
        }
    }
}