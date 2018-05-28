using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.Models
{
    public class Accountlayout
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string Rol { get; set; }
    }
}
