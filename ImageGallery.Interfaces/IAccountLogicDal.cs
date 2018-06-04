using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IAccountLogicDal
    {
        Task CreateNewAccount(string gebruikersnaam, string wachtwoord, string email);

        Task ChangeUserUsernameAndWachtwoord(string gebruikersnaam, string wachtwoord, string oldUserName);

        Task ChangeUserUsername(string gebruikersnaam, string oldUserName);

        string GetRol(string gebruikersnaam);

        IEnumerable<Accountlayout> GetAllUsers();

        Accountlayout GetUserByName(string username);

        IEnumerable<string> AllEmails();
    }
}
