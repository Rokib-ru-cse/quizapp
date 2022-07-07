using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace QuizApp.Models.ViewModels
{
    public class UserViewModel
    {

        public string? Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length 2")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minlength is 4")]
        public string Password { get; set; }
        public UserViewModel()
        {

        }

        public UserViewModel(IdentityUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.PasswordHash;
        }

    }
}
