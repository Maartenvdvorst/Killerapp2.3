using System;
using ImageGallery.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IUserMVCLogic
    {
        IEnumerable<GalleryImage> GetAllImages();

        IEnumerable<GalleryImage> GetImageByTag(string tag);

        GalleryImage GetImageById(int postId);

        Task SetNewImage(string title, string tags, Uri uri, string username);

        IEnumerable<Comment> GetCommentsByPostId(int postId);

        Task SetNewComment(string discription, string username, int imageId);

        CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName);
    }
}
