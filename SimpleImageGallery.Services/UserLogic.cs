﻿using ImageGallery.Interfaces;
using ImageGallery.Models;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ImageGallery.Logic
{
    public class UserLogic : IUserMVCLogic
    {
        private readonly IUserLogicDal _logicdal;
        public UserLogic(IUserLogicDal logicdal)
        {
            this._logicdal = logicdal;
        }
        public IEnumerable<GalleryImage> GetAllImages()
        {
            return _logicdal.GetAllImages();
        }

        public GalleryImage GetImageById(int postId)
        {
            return _logicdal.GetImageById(postId);
        }

        public IEnumerable<GalleryImage> GetImageByTag(string tag)
        {
            return _logicdal.GetImageByTag(tag);
        }

        public Task SetNewImage(string title, string tags, Uri uri, string username)
        {
            //if(tags == "")

            return _logicdal.SetNewImage(title, tags, uri, username);
        }

        public IEnumerable<Comment> GetCommentsByPostId(int postId)
        {
            return _logicdal.GetCommentsByPostId(postId);
        }

        public Task SetNewComment(string discription, string username, int imageId)
        {
            return _logicdal.SetNewComment(discription, username, imageId);
        }

        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }
    }
}
