using Domain.Common;

namespace Domain.Entities
{
    public class SuscriptionType : AuditableBaseEntity
    {
        
        public string TypeSuscription { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }

        public virtual ICollection<CustomerSuscription> CustomerSuscriptions { get; set; }
    }
}
