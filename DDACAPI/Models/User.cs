using System.ComponentModel.DataAnnotations;

namespace DDACAPI.Models
{
    public enum Role
    {
        Customer, // 0
        Staff,    // 1
        Admin     // 2
    }
    public class User
    {
        public User()
        {

        }
        [Key]
        public int Id
        {
            get;
            set;
        }
        [Required]
        public string FullName
        {
            get;
            set;
        }
        [Required]
        public string Username
        {
            get;
            set;
        }
        [Required]
        public string Password
        {
            get;
            set;
        }
        [Required]
        public string Email
        {
            get;
            set;
        }
        [Required]
        public Role Type
        {
            get;
            set;
        }

    }
}
