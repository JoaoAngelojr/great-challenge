using System;
using System.Threading.Tasks;
using great_challenge.Abstract;
using great_challenge.Models;
using great_challenge.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace great_challenge.BLL
{
    public class UsersBLL : GenericBLL<User>
    {
        public UsersBLL(IGreatRepository<User> context) : base(context)
        {
        }

        public async Task<User> CreateUser(UserViewModel user) 
        {
            User newUser = new User();
            DateTime birthDate = DateTime.Parse(user.BirthDate);
            newUser.Name = user.Name;
            newUser.BirthDate = birthDate;
            newUser.Cpf = user.Cpf;
            newUser.Rg = user.Rg;
            newUser.RegistrationDate = DateTime.Now;
            newUser.MothersName = user.MothersName;
            newUser.FathersName = user.FathersName;

            await this.Create(newUser);
            return newUser;
        }
    }
}