﻿namespace ImageGallery.Models
{
    public class ImageTag
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int GalleryImageId { get; set; }
    }
}