using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IAdminLogicDal
    {
        Task DeletePost(int id);
        Task DeleteComment(int id);
        IEnumerable<Accountlayout> GetAllUsers(string username);
    }
}
