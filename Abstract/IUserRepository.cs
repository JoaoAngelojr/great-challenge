using System.Threading.Tasks;
using great_challenge.Abstract;
using great_challenge.Models;

namespace great_challenge.Abstract
{
    public interface IUserRepository : IGreatRepository<User>
    {
        Task<User> GetUserByCpfOrRg(string document);
    }
}