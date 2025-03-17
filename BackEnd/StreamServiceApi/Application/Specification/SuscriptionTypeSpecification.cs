using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specification
{
    public class SuscriptionTypeSpecification : Specification<SuscriptionType>
    {
        public SuscriptionTypeSpecification(int Id)
        {
            if(Id!= null)Query.Where(x => x.Id== Id);
        }
    }
}
