using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IAccountLogicDal
    {
        Task CreateNewAccount(string gebruikersnaam, byte[] wachtwoord, string email);

        Task ChangeUserUsernameAndWachtwoord(string gebruikersnaam, byte[] wachtwoord, string oldUserName);

        Task ChangeUserUsername(string gebruikersnaam, string oldUserName);

        string GetRol(string gebruikersnaam);

        IEnumerable<Accountlayout> GetAllUsers();

        Accountlayout GetUserByName(string username);

        IEnumerable<string> AllEmails();

        bool Checkuser(string username, byte[] password);
    }
}
