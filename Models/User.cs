﻿using Microsoft.AspNetCore.Identity;
using System;

namespace WebAppForDiplom.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
       
    }
}
