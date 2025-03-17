using Domain.Common;
namespace Domain.Entities
{
    public class CustomerSuscription : AuditableBaseEntity
    {
       
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string SuscriptionStatus { get; set; }
        public double SuscriptionPrice { get; set; }
        public double SuscriptionRefund { get; set; }

        //foreign keys 
        public int IdCustomer { get; set; }


        public int SuscriptionTypeId { get; set; }
        //public SuscriptionType SuscriptionType { get; set; }

        public int TypePurchaseId { get; set; }
        //public TypePurchase TypePurchase { get; set; }

    }


}
