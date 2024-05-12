using DLP.Application.Interfaces.Repositories;
using DLP.Application.Interfaces.Services;
using DLP.Core.Models;
using DLP.Core.ValueObjects;
using DLP.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly IPasswrodHasher _passwrodHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(
            IUserRepository usersRepository, 
            IPasswrodHasher passwrodHasher,
            IJwtProvider jwtProvider)
        {
             _usersRepository = usersRepository;
            _passwrodHasher = passwrodHasher;
            _jwtProvider = jwtProvider;
        }
        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            var result = _passwrodHasher.Verify(password, user.PasswordHash);

            if(result  == false)
            {
                throw new Exception("Failed to LOGIN");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

        public async Task Register(
            string firstName, 
            string lastName, 
            string userName, 
            string email, 
            string password, 
            string gender, 
            bool isTeacher)
        {
            var _hashedPassword = _passwrodHasher.Generate(password);
            var _userName = UserName.Create(userName).Value;
            var _email = Email.Create(email).Value;
            var _gender = Gender.Create(gender).Value;

            var user = User.Create(Guid.NewGuid(), firstName, lastName, _userName, _email, _hashedPassword, _gender, isTeacher);
            await _usersRepository.Add(user.Value);
        }
    }
}
