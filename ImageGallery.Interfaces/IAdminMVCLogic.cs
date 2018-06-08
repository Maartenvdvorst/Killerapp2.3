using ImageGallery.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IAdminMVCLogic
    {
        Task DeletePost(int id);
        Task DeleteComment(int id);
        IEnumerable<Accountlayout> GetAllUsers(string username);
        Task MakeUser(string username);
        Task MakeAdmin(string username);
    }
}
