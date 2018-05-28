using ImageGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Data
{
    public class SimpleImageGalleryDBContext : DbContext
    {
        public SimpleImageGalleryDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
        public DbSet<Accountlayout> Logingegevens { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
