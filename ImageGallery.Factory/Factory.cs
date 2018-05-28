using ImageGallery.Data;
using ImageGallery.Interfaces;
using ImageGallery.Logic;
using System;

namespace ImageGallery.Factory
{
    public class Factory
    {
        public UserLogic Getuserlogic(IUserLogicDal userlogic)
        {
            UserLogic newlogic = new UserLogic(userlogic);
            return newlogic;
        }

        public AccountLogic Getaccountlogic(IAccountLogicDal accountLogic)
        {
            AccountLogic newlogic = new AccountLogic(accountLogic);
            return newlogic;
        }

        public AdminLogic Getadminlogic(IUserLogicDal userlogicdal, IAdminLogicDal adminlogicdal)
        {
            AdminLogic newlogic = new AdminLogic(userlogicdal, adminlogicdal);
            return newlogic;
        }

        public UserDal Getuserdal()
        {
            UserDal newdata = new UserDal();
            return newdata;
        }

        public AccountData Getaccountdata()
        {
            AccountData newdata = new AccountData();
            return newdata;
        }

        public AdminData Getadmindata()
        {
            AdminData newdata = new AdminData();
            return newdata;
        }
    }
}
