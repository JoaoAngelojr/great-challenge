using System;
using System.Linq;
using System.Threading.Tasks;
using great_challenge.Abstract;
using great_challenge.Models;
using great_challenge.ViewModel;
using great_challenge.Functions;
using System.Collections.Generic;

namespace great_challenge.BLL
{
    public class UsersBLL : GenericBLL<User>
    {
        private readonly ValidationFunctions _validationFunctions;
        private readonly RegexFunctions _regexFunctions;

        public UsersBLL(IGreatRepository<User> context) : base(context)
        {
            _validationFunctions = new ValidationFunctions();
            _regexFunctions = new RegexFunctions();
        }

        public async Task<User> CreateUser(UserViewModel user)
        {
            if(user.Cpf.Length != 11)
                throw new Exception("The Cpf value must have 11 caracters.");
            else 
            {
                bool cpfIsValid = _validationFunctions.IsCpfValid(user.Cpf);

                if(!cpfIsValid)
                    throw new Exception("Invalid CPF.");
            }

            User newUser = new User();
            DateTime birthDate = DateTime.Parse(user.BirthDate);
            newUser.Name = user.Name;
            newUser.BirthDate = birthDate;
            newUser.Cpf = user.Cpf;
            newUser.Rg = user.Rg;
            newUser.RegistrationDate = DateTime.Now;
            newUser.MothersName = user.MothersName;
            newUser.FathersName = user.FathersName;
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;
            newUser.UserRole = user.UserRole;

            await this.Create(newUser);
            return newUser;
        }

        public async Task<IEnumerable<User>> GetUsersByName(string expression)
        {
            string cleanExpression = _regexFunctions.ClearSearchExpression(expression);
            return (await GetAll()).Where(
                                    x => _regexFunctions.ClearSearchExpression(x.Name)
                                                    .Contains(cleanExpression));
        }
    }
}