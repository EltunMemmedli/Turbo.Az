using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public class ProfilController
    {
        ArrayList profil;

        public ProfilController()
        {
            profil = new ArrayList();
        }

        public void AddList(Profil user)
        {
            profil.Add(user);
        }

        public bool SignIn(string email, string password)
        {
            bool valid = false;

            foreach (Profil allUsers in profil)
            {
                if (email == allUsers.Email && password == allUsers.Password)
                {
                    valid = true;

                    Console.WriteLine($"Welcome, {allUsers.Name} {allUsers.Surname}!");
                    break;  // İstifadəçi tapıldıqda dövrü dayandırırıq
                }
            }

            return valid;  // valid dəyərini qaytarırıq
        }


        public void SignUp(string name,
                                   string surname,
                                   string email,
                                   string password
                                   )
        {

            Profil newUser = new Profil(name, surname, email, password);
            profil.Add(newUser);

            int counter = 1;
            Console.Clear();

            Console.WriteLine($"Welcome, {newUser.Name} {newUser.Surname}!");

        }
    }
}
