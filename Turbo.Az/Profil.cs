using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public class Profil
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Profil(string name,
                        string surname,
                        string email,
                        string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password; 
        }
    }
}
