using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleBilling.Model
{
    public class BillingDBInitializer : CreateDatabaseIfNotExists<BillingContext>
    {
        protected override void Seed(BillingContext context)
        {
            IList<Users> users = new List<Users>
            {
                new Users() { Username = "Admin", Password = "1234", UserType = 1, IsDeleted = 1 },
                new Users() { Username = "User", Password = "1234", UserType = 2, IsDeleted = 1 }
            };
            context.Users.AddRange(users);
            base.Seed(context);
        }
    }
}