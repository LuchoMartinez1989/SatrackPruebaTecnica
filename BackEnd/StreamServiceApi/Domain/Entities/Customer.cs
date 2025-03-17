using Domain.Common;

namespace Domain.Entities
{
    public class Customer : AuditableBaseEntity
    {
        #region Properties
        //public int IdRow { get; set; }
        public string? IdenticacionCode { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }

        public string Mail { get; set; }
        public string Password { get; set; }
        //navigation properties
        public virtual ICollection<CustomerSuscription> CustomerSuscriptions { get; set; }

        #endregion
    }
}
