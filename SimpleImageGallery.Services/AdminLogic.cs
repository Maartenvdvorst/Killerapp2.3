using ImageGallery.Interfaces;
using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Logic
{
    public class AdminLogic : UserLogic, IAdminMVCLogic
    {
        private readonly IAdminLogicDal _Adminlogicdal;
        private readonly IUserLogicDal _Userlogicdal;
        public AdminLogic(IUserLogicDal userLogicDal, IAdminLogicDal adminLogicDal) :base(userLogicDal)
        {
            this._Userlogicdal = userLogicDal;
            this._Adminlogicdal = adminLogicDal;
        }

        public Task DeletePost(int id)
        {
            return _Adminlogicdal.DeletePost(id);
        }

        public Task DeleteComment(int id)
        {
            return _Adminlogicdal.DeleteComment(id);
        }

        public IEnumerable<Accountlayout> GetAllUsers(string username)
        {
            return _Adminlogicdal.GetAllUsers(username);
        }
    }
}
