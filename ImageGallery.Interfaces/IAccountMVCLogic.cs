using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IAccountMVCLogic
    {
        Task CreateNewAccount(string gebruikersnaam, string wachtwoord, string email);

        bool CheckUser(string gebruikersnaam, string wachtwoord);

        Task ChangeUser(string gebruikersnaam, string wachtwoord, string oldUserName);

        string GetRol(string gebruikersnaam);

        IEnumerable<Accountlayout> GetAllUsers();

        Accountlayout GetUserByName(string username);

        string CheckValidAccount(string username, string wachtwoord);

        string CheckValidEmail(string email);
    }
}
