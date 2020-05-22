using System.Data.Entity;

namespace SimpleBilling.Model
{
    public class BillingDBInitializer : CreateDatabaseIfNotExists<BillingContext>
    {
    }
}