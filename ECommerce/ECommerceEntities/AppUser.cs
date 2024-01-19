using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Lastame { get; set; }
    }
}
