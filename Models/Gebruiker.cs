using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models;

namespace Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }

        [Display(Name = "Gebruikersnaam")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "name Required")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Wachtwoord")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "minimum 6 char")]
        public string Wachtwoord { get; set; }

        [Display(Name = "Herhaal wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("Wachtwoord", ErrorMessage = "Confirm password")]
        public string ConfirmWachtwoord { get; set; }

        [Display(Name = "Geboortedatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
    }
}