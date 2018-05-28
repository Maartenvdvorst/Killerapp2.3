using ImageGallery.Interfaces;
using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Logic
{
    public class AccountLogic : IAccountMVCLogic
    {
        private readonly IAccountLogicDal _accountdal;
        public AccountLogic(IAccountLogicDal logicdal)
        {
            this._accountdal = logicdal;
        }

        public Task CreateNewAccount(string gebruikersnaam, string wachtwoord, string email)
        {
            return _accountdal.CreateNewAccount(gebruikersnaam, wachtwoord, email);
        }

        public IEnumerable<Accountlayout> GetAllUsers()
        {
            return _accountdal.GetAllUsers();
        }

        public Accountlayout GetUserByName(string username)
        {
            return _accountdal.GetUserByName(username);
        }

        public bool CheckUser(string gebruikersnaam, string wachtwoord)
        {
            try
            {
                if (((GetUserByName(gebruikersnaam)).Wachtwoord) == wachtwoord)
                {
                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public string GetPasswordByUsername(string username)
        {
            return _accountdal.GetPasswordByUsername(username);
        }

        public Task ChangeUser(string gebruikersnaam, string wachtwoord, string oldUserName)
        {
            return _accountdal.ChangeUser(gebruikersnaam, wachtwoord, oldUserName);
        }

        public string GetRol(string gebruikersnaam)
        {
            return _accountdal.GetRol(gebruikersnaam);
        }
    }
}
