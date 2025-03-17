using Application.DTOs;
using Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscriptionByIdCustomer;
using Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscriptionListById;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerSuscriptions.Queries.GetCustomerActiveSuscriptionsByIdCustomer
{
    public class GetCustomerActiveSuscriptionsByIdCustomerQuery : IRequest<Response<List<CustomerSuscriptionDTO>>>
    {
        public int IdCustomer { get; set; }

        public class GetCustomerActiveSuscriptionsByIdCustomerQueryHandler : IRequestHandler<GetCustomerActiveSuscriptionsByIdCustomerQuery, Response<List<CustomerSuscriptionDTO>>>
        {
            private readonly IRepositoryAsync<CustomerSuscription> _repositoryAsyncCS;
            private readonly IRepositoryAsync<SuscriptionType> _repositoryAsyncST;
            private readonly IRepositoryAsync<TypePurchase> _repositoryAsyncTp;
            private readonly IMapper _mapper;

            public GetCustomerActiveSuscriptionsByIdCustomerQueryHandler(IRepositoryAsync<CustomerSuscription> repositoryAsyncCS, IRepositoryAsync<SuscriptionType> repositoryAsyncST, IRepositoryAsync<TypePurchase> repositoryAsyncTp, IMapper mapper)
            {
                _repositoryAsyncCS = repositoryAsyncCS;
                _repositoryAsyncST = repositoryAsyncST;
                _repositoryAsyncTp = repositoryAsyncTp;
                _mapper = mapper;
            }

            public async Task<Response<List<CustomerSuscriptionDTO>>> Handle(GetCustomerActiveSuscriptionsByIdCustomerQuery request, CancellationToken cancellationToken)
            {
                var records = await _repositoryAsyncCS.ListAsync(new CustomerSuscriptionSpecification(request.IdCustomer));
                var recorsDTO = _mapper.Map<List<CustomerSuscriptionDTO>>(records);
                
                foreach (var x in recorsDTO)
                {
                    //x.PurchaseDescription = x.SuscriptionTypes.rowas[0][4];
                    x.SuscriptionTypes = _mapper.Map<List<SuscriptionTypeDTO>>(await _repositoryAsyncST.ListAsync(new SuscriptionTypeSpecification(x.SuscriptionTypeId)));
                    x.TypePurchases = _mapper.Map<List<TypePurchaseDTO>>(await _repositoryAsyncTp.ListAsync(new TypePurchaseSpecification(x.TypePurchaseId)));
                }
                recorsDTO = recorsDTO.Where(x => x.SuscriptionStatus == "Active").ToList();
                return new Response<List<CustomerSuscriptionDTO>>(recorsDTO);

            }
        }
    }
}
