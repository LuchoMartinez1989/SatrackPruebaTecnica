using Domain.Entities;

namespace Application.DTOs
{
    public class CustomerSuscriptionDTO
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        
        public int SuscriptionTypeId { get; set; }
        public int TypePurchaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string SuscriptionStatus { get; set; }
        public double SuscriptionPrice { get; set; }

        public string TypeSuscription { get; set; }

        public string PurchaseDescription { get; set; }

        public virtual ICollection<TypePurchaseDTO> TypePurchases{ get; set; } // Debe ser virtual si usas Lazy Loading


        public virtual ICollection<SuscriptionTypeDTO> SuscriptionTypes{ get; set; } // Debe ser virtual si usas Lazy Loading

    }
}
