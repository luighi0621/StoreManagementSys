using Microsoft.AspNet.Identity.EntityFramework;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Dal
{
    public class UserDbContext: IdentityDbContext<ApplicationUser>
    {
        public UserDbContext()
            : base("UserDbContext", throwIfV1Schema: false)
        {
        }

        public static UserDbContext Create()
        {
            return new UserDbContext();
        }
    }
}
