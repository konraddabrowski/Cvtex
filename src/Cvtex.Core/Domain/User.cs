using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Cvtex.Core.Domain
{
    [Table("Users")]
    public class User
    {
        private static readonly Regex RegexName = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        [Key]
        public Guid Id { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Role { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Email { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        public virtual Address Address { get; protected set; }

        protected User()
        {
        }

        public User(Guid userId, string email, string username, string password, string salt)
        {
            Id = userId;
            Email = email;
            Username = username;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (!RegexName.IsMatch(username))
            {
                throw new DomainException(ErrorCodes.InvalidUsername, "Username is invalid");
            }

            Username = username.ToLowerInvariant();
            UpdateAt = DateTime.UtcNow;
        }
        
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(ErrorCodes.InvalidEmail, "Email con not be empty");
            }

            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdateAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password can not be empty.");
            }
            if (password.Length < 4)
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password has to contains at least 4 characters.");
            }
            if (password.Length > 100) {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password can not contain more than 100 characters");
            }
            if (Password == password)
            {
                return;   
            }

            Password = password;
            UpdateAt = DateTime.UtcNow;
        }
    }
}