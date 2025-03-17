using Domain.Common;

namespace Domain.Entities
{
    public class TypePurchase : AuditableBaseEntity
    {
        public string PurchaseDescription { get; set; }
        public int MonthDuration { get; set; }
        //public CustomerSuscription CustomerSuscription { get; set; }
        public virtual ICollection<CustomerSuscription> CustomerSuscriptions { get; set; }
    }
}
