using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscriptionListById
{
    public class GetCustomerSuscriptionListByIdQuery : IRequest<Response<List<CustomerSuscriptionDTO>>>
    {
        public int IdCustomer { get; set; }
    }
    public class GetCustomerSuscriptionListByIdQueryHandler : IRequestHandler<GetCustomerSuscriptionListByIdQuery, Response<List<CustomerSuscriptionDTO>>>
    {
        private readonly IRepositoryAsync<CustomerSuscription> _repositoryAsyncCS;
        private readonly IRepositoryAsync<SuscriptionType> _repositoryAsyncST;
        private readonly IRepositoryAsync<TypePurchase> _repositoryAsyncTp;
        private readonly IMapper _mapper;

        public GetCustomerSuscriptionListByIdQueryHandler(IRepositoryAsync<CustomerSuscription> repositoryAsyncCS, IRepositoryAsync<SuscriptionType> repositoryAsyncST, IRepositoryAsync<TypePurchase> repositoryAsyncTp, IMapper mapper)
        {
            _repositoryAsyncCS = repositoryAsyncCS;
            _repositoryAsyncST = repositoryAsyncST;
            _repositoryAsyncTp = repositoryAsyncTp;
            _mapper = mapper;
        }

        public async Task<Response<List<CustomerSuscriptionDTO>>> Handle(GetCustomerSuscriptionListByIdQuery request, CancellationToken cancellationToken)
        {
            var records = await _repositoryAsyncCS.ListAsync(new CustomerSuscriptionSpecification(request.IdCustomer));
            var recorsDTO = _mapper.Map<List<CustomerSuscriptionDTO>>(records);
            var aa =  _mapper.Map<List<SuscriptionTypeDTO>>(await _repositoryAsyncST.ListAsync(new SuscriptionTypeSpecification(1)));
            foreach( var x in recorsDTO)
            {
                //x.PurchaseDescription = x.SuscriptionTypes.rowas[0][4];
                x.SuscriptionTypes = _mapper.Map<List<SuscriptionTypeDTO>>(await _repositoryAsyncST.ListAsync(new SuscriptionTypeSpecification(x.SuscriptionTypeId)));
                x.TypePurchases = _mapper.Map<List<TypePurchaseDTO>>(await _repositoryAsyncTp.ListAsync(new TypePurchaseSpecification(x.TypePurchaseId)));
            };
            return new Response<List<CustomerSuscriptionDTO>>(recorsDTO);

        }
    }
}
