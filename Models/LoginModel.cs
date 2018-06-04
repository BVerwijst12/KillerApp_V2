using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class LoginModel
    {
        [Display(Name = "Gebruikersnaam")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Naam Invullen")]
        public string Username { get; set; }

        [Display(Name = "Wachtwoord")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wachtwoord invullen")]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [Display(Name = "onthoud mij")]
        public bool RememberMe { get; set; }

    }
}