using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IUserLogicDal
    {
        IEnumerable<GalleryImage> GetAllImages();

        IEnumerable<GalleryImage> GetImageByTag(string tag);

        GalleryImage GetImageById(int postId);

        Task SetNewImage(string title, string tags, Uri uri, string username);

        IEnumerable<Comment> GetCommentsByPostId(int postId);

        Task SetNewComment(string discription, string username, int imageId);
    }
}
