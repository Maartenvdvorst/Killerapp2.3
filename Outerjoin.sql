SELECT GalleryImages.Id, GalleryImages.Url, GalleryImages.Username, ImageTags.Id, ImageTags.GalleryImageId
FROM GalleryImages FULL OUTER JOIN ImageTags ON GalleryImages.Id = ImageTags.GalleryImageId;