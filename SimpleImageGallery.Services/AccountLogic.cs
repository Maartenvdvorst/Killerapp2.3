using ImageGallery.Interfaces;
using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            //var passwordhash = new MD5CryptoServiceProvider();
            //var data = Encoding.ASCII.GetBytes(wachtwoord);
            //var hashedpassword = passwordhash.ComputeHash(data);
            if (gebruikersnaam == "" || wachtwoord == "")
            {
                return false;
            }

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

        public Task ChangeUser(string gebruikersnaam, string wachtwoord, string oldUserName)
        {
            if (wachtwoord != "")
            {
                return _accountdal.ChangeUserUsernameAndWachtwoord(gebruikersnaam, wachtwoord, oldUserName);
            }
            else
            {
                return _accountdal.ChangeUserUsername(gebruikersnaam, oldUserName);
            }
        }

        public string GetRol(string gebruikersnaam)
        {
            return _accountdal.GetRol(gebruikersnaam);
        }

        public bool CheckDuplicateUser(string username)
        {
            IEnumerable<Accountlayout> Alleusers = _accountdal.GetAllUsers();
            foreach (Accountlayout account in Alleusers)
            {
                if (account.Gebruikersnaam == username)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckDuplicateEmail(string email)
        {
            IEnumerable<string> allemails = _accountdal.AllEmails();
            foreach (string mail in allemails)
            {
                if (mail == email)
                {
                    return true;
                }
            }

            return false;
        }

        public string CheckValidAccount(string username, string wachtwoord)
        {
            string errormessage = "";
            if (username == null || wachtwoord == null)
            {
                errormessage = "Een of meerder velden niet ingevuld";
            }

            if (CheckDuplicateUser(username) == true)
            {
                errormessage = "gebruikersnaam is al ingebruik";
                return errormessage;
            }

            return errormessage;
        }

        public string CheckValidEmail(string email)
        {
            string errormessage = "";
            if (email == null)
            {
                errormessage = "Een of meerder velden niet ingevuld";
                return errormessage;
            }
            else
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                }
                catch
                {
                    errormessage = "Email niet valide";
                    return errormessage;
                }

                if (CheckDuplicateEmail(email) == true)
                {
                    errormessage = "Email is al ingebruik";
                    return errormessage;
                }
            }
            return errormessage;
        }
    }
}
