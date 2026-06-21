using System.ComponentModel.DataAnnotations;

namespace WebApplication1.WebDTO
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required" ,AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phonenumber is required")]
        public long Phonenumber { get; set; }
    }
}
