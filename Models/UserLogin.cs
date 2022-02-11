using System.ComponentModel.DataAnnotations;

namespace WebAppForDiplom.Models
{
    public class UserLogin
    {
        [Required,MaxLength(256)]
        public string UserName { get; set;}
        [Required, DataType(DataType.Password)]
        public string Password { get; set;}
        public string ReturnUrl { get; set;}
    }
}
