using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TypePurchases.Queries.GetTypePurchases
{
    public class GetTypePurchaseQuery : IRequest<Response<List<TypePurchaseDTO>>>
    {
        public class GetTypePurchaseQueryHandler : IRequestHandler<GetTypePurchaseQuery, Response<List<TypePurchaseDTO>>>
        {
            private readonly IRepositoryAsync<TypePurchase> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetTypePurchaseQueryHandler(IRepositoryAsync<TypePurchase> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<List<TypePurchaseDTO>>> Handle(GetTypePurchaseQuery request, CancellationToken cancellationToken)
            {
                var records = await _repositoryAsync.ListAsync();
                var recorsDTO = _mapper.Map<List<TypePurchaseDTO>>(records);
                return new Response<List<TypePurchaseDTO>>(recorsDTO);
            }
        }
    }
}
