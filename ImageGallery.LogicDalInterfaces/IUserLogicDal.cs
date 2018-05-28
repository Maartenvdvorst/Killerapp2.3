using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    interface IUserLogicDal
    {
        IEnumerable<GalleryImage> GetAllImages();
        IEnumerable<GalleryImage> GetImageByTag(string tag);
        GalleryImage GetImageById(int id);
        Task SetNewImage(string title, string tags, string uri, string Username);
        List<ImageTag> ParseTags(string tags);
        Task CreateNewAccount(string Gebruikersnaam, string Wachtwoord, string Email);
        bool CheckUser(string gebruikersnaam, string wachtwoord);
    }
}
