using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace My_Personal_Project.Models
{
    public class LoginModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="First Name Must Required")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z]+(?:\s[A-Za-z]+)*$",ErrorMessage = "Only Accept Charecter")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name Must Required")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z]+(?:\s[A-Za-z]+)*$", ErrorMessage ="Only Accept Charecter")]
        public string Last_Name { get; set; }
        public string? Phone { get; set; }

        [Required(ErrorMessage ="Email Must Required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z]+([.-]?[a-zA-Z]+)*\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password Must Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Must Required")]
        [Compare("Password", ErrorMessage = "Passworn Do Not Match")]
        public string Confirm_Password { get; set; }
    }
}
