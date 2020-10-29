using System.ComponentModel.DataAnnotations;

namespace ItAcademy.Project.Music.Client.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
