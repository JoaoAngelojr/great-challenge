using great_challenge.Abstract;
using great_challenge.Models;

namespace great_challenge.BLL
{
    public class UsersBLL : GenericBLL<User>
    {
        public UsersBLL(IGreatRepository<User> context) : base(context)
        {
        }
    }
}