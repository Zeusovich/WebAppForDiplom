using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppForDiplom.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
       
    }
}
