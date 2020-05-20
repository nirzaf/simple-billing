using System.Collections.Generic;
using System.Data.Entity;

namespace SimpleBilling.Model
{
    public class BillingDBInitializer : CreateDatabaseIfNotExists<BillingContext>
    {
        protected override void Seed(BillingContext context)
        {
            IList<Users> users = new List<Users>
            {
                new Users() { Username = "Admin", Password = "1234", UserType = 1, IsDeleted = false },
                new Users() { Username = "User", Password = "1234", UserType = 2, IsDeleted = false }
            };
            context.Users.AddRange(users);
            base.Seed(context);
        }
    }
}