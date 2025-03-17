using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class CustomerSpecification : Specification<Customer>
    {
        public CustomerSpecification(string Mail) 
        {
            if (!string.IsNullOrEmpty(Mail)) Query.Search(x => x.Mail, "%" + Mail + "%");
        }
    }
}
