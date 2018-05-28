using ImageGallery.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IUserMVCLogic
    {
        IEnumerable<GalleryImage> GetAllImages();

        IEnumerable<GalleryImage> GetImageByTag(string tag);

        GalleryImage GetImageById(int postId);

        Task SetNewImage(string title, string tags, string uri, string username);

        List<ImageTag> ParseTags(string tags);

        IEnumerable<Comment> GetCommentsByPostId(int postId);

        Task SetNewComment(string discription, string username, int imageId);
    }
}
