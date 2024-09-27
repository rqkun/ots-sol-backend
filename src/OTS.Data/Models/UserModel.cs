using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsDeleted { get; set; }
        public string AvatarSeed { get; set; } = "";
    }
    public class CreateUserModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public string? AvatarSeed { get; set; }

    }
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

    }
    public class LoginModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }

    public class ResetPasswordModel
    {
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Token { get; set; } = "";
        [Required]
        public string NewPassword { get; set; } = "";
    }
    public class ChangePasswordModel
    {
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string OldPassword { get; set; } = "";
        [Required]
        public string NewPassword { get; set; } = "";
    }
    public class TokenModel
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Token { get; set; } = "";
    }
}
