using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Infrastructure
{
    public class PasswrodHasher : IPasswrodHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPasswrod) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPasswrod);
    }
}
