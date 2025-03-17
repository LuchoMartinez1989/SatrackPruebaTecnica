using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TypePurchases.Commands.CreateTypePurchaseCommand
{
    public class CreateTypePurchaseCommand : IRequest<Response<int>>
    {
        public int IdTypePurchase { get; set; }
        public string PurchaseDescription { get; set; }
        public int MonthDuration { get; set; }
    }

    public class CreateTypePurchaseCommandHandler : IRequestHandler<CreateTypePurchaseCommand, Response<int>>
    {
        private readonly IRepositoryAsync<TypePurchase> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateTypePurchaseCommandHandler(IRepositoryAsync<TypePurchase> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async  Task<Response<int>> Handle(CreateTypePurchaseCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<TypePurchase>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
