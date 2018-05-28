using ImageGallery.Interfaces;
using ImageGallery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Data
{
    public class UserDal : IUserLogicDal
    {
        private readonly SqlConnection connection = new SqlConnection("Data Source = (localdb)\\mssqllocaldb;Database=SimpleImageGallery;Trusted_Connection=True;MultipleActiveResultSets=true");

        public IEnumerable<GalleryImage> GetAllImages()
        {
            List<GalleryImage> allImages = new List<GalleryImage>();
            using (SqlCommand query = new SqlCommand("SELECT * FROM GalleryImages", connection))
            {
                connection.Open();
                try
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var image = new GalleryImage
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Created = Convert.ToDateTime(reader["Created"]),
                                Title = reader["Title"].ToString(),
                                Url = reader["Url"].ToString(),
                                Username = reader["Username"].ToString()
                            };


                            allImages.Add(image);
                        }
                        reader.Close();
                    } 
                }
                catch
                {

                }
                connection.Close();
            }
            return allImages;
        }

        public GalleryImage GetImageById(int postId)
        {
            using (SqlCommand query = new SqlCommand("SELECT * FROM GalleryImages WHERE Id = @PostId", connection))
            {
                connection.Open();
                query.Parameters.AddWithValue("@PostId", postId);
                var image = new GalleryImage();
                try
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            image.Id = Convert.ToInt32(reader["Id"]);
                            image.Created = Convert.ToDateTime(reader["Created"]);
                            image.Title = reader["Title"].ToString();
                            image.Url = reader["Url"].ToString();
                            image.Username = reader["Username"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch
                {
                    return null;
                }
                connection.Close();
                return image;
            }
        }

        public IEnumerable<ImageTag> GetTagsBySearch(string tag)
        {
            List<ImageTag> foundTags = new List<ImageTag>();
            using (SqlCommand query = new SqlCommand("SELECT * FROM ImageTags WHERE (Description LIKE '%' + @Tag + '%')", connection))
            {
                connection.Open();
                query.Parameters.AddWithValue("@Tag", tag);
                try
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var foundtag = new ImageTag
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Description = reader["Created"].ToString(),
                                GalleryImageId = Convert.ToInt32(reader["GalleryImageId"])
                            };

                            foundTags.Add(foundtag);
                        }
                        reader.Close();
                    }
                }
                catch
                {
                    return null;
                }
                connection.Close();
                return foundTags;
            }
        }

        public IEnumerable<GalleryImage> GetImageByTag(string tag)
        {
            IEnumerable<ImageTag> foundTags = GetTagsBySearch(tag);
            IEnumerable<GalleryImage> allImages = GetAllImages();
            List<GalleryImage> foundImages = new List<GalleryImage>();
            foreach(GalleryImage image in allImages)
            {
                foreach(ImageTag Tag in foundTags)
                {
                    if(Tag.GalleryImageId == image.Id)
                    {
                        foundImages.Add(image);
                    }
                }
            }
            return foundImages;
        }

        public async Task SetNewImage(string title, string tags, string uri, string username)
        {
            using (SqlCommand query = new SqlCommand("INSERT INTO GalleryImages(Created, Title, Url, Username) VALUES (@Created, @Title, @Url, @Username)", connection))
            {
                connection.Open();
                query.Parameters.AddWithValue("@Created", DateTime.Now);
                query.Parameters.AddWithValue("@Title", title);
                query.Parameters.AddWithValue("@Url", uri);
                query.Parameters.AddWithValue("@Username", username);
                query.ExecuteNonQuery();
                connection.Close();
            }
            List<ImageTag> Tags = ParseTags(tags);
            using (SqlCommand query = new SqlCommand("SELECT Id FROM GalleryImages WHERE Title = @Title AND Username = @Username)", connection))
            {
                connection.Open();
                query.Parameters.AddWithValue("@Title", title);
                query.Parameters.AddWithValue("@Username", username);
            }
        }

        public List<ImageTag> ParseTags(string tags)
        {
            return tags.Split(",").Select(tag => new ImageTag { Description = tag }).ToList();
        }

        public async Task CreateNewTags(List<ImageTag>Tags, int PostId)
        {
            foreach (ImageTag tag in Tags)
            {
                using (SqlCommand query = new SqlCommand("INSERT INTO ImageTags(Description, ImageId) VALUES (@Description, @ImageId)", connection))
                {
                    connection.Open();
                    query.Parameters.AddWithValue("@Description", tag.Description);
                    query.Parameters.AddWithValue("@ImageId", PostId);
                    query.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        

        public IEnumerable<Comment> GetCommentsByPostId(int PostId)
        {
            List<Comment> foundComments = new List<Comment>();
            using (SqlCommand query = new SqlCommand("SELECT * FROM Comments WHERE ImageId = @PostId", connection))
            {
                connection.Open();
                query.Parameters.AddWithValue("@PostId", PostId);
                try
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var comment = new Comment
                            {
                                CommentId = Convert.ToInt32(reader["CommentId"]),
                                Description = reader["Description"].ToString(),
                                Username = reader["Username"].ToString(),
                                Created = Convert.ToDateTime(reader["Created"]),
                                ImageId = Convert.ToInt32(reader["ImageId"])
                            };
                            foundComments.Add(comment);
                        }
                        reader.Close();
                    }
                }
                catch
                {
                    return null;
                }
                connection.Close();
                return foundComments;
            }
        }

        public async Task SetNewComment(string discription, string username, int imageId)
        {
            using (SqlCommand query = new SqlCommand("INSERT INTO Comments(Description, Username, Created, ImageId) VALUES (@Description, @Username, @Created, @ImageId)", connection))
            {
                connection.Open();
                query.Parameters.AddWithValue("@Description", discription);
                query.Parameters.AddWithValue("@Username", username);
                query.Parameters.AddWithValue("@Created", DateTime.Now);
                query.Parameters.AddWithValue("@ImageId", imageId);
                query.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
