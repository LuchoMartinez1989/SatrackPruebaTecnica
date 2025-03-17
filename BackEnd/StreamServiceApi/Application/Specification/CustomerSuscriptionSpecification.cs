using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class CustomerSuscriptionSpecification : Specification<CustomerSuscription>
    {

        public CustomerSuscriptionSpecification(int IdCustomer) {
            if (IdCustomer != null)Query.Where(x => x.IdCustomer==IdCustomer);
        }
    }
}