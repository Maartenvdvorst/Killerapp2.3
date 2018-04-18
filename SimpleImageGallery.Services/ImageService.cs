using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;

namespace SimpleImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly SimpleImageGalleryDBContext _ctx;
        public ImageService(SimpleImageGalleryDBContext ctx)
        {
            this._ctx = ctx;
        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages
                .Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return _ctx.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetByTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
