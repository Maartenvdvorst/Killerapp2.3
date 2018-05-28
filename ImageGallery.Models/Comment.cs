using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public int ImageId { get; set; }
    }
}
