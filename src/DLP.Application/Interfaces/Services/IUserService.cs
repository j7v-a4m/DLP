using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);
        Task Register(string firstName, string lastName, string userName, string email, string password, string gender, bool isTeacher) ;
    }
}
