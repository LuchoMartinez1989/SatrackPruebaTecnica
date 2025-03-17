using Application.DTOs;
using Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscriptionByIdCustomer;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscriptionByIdCustomer
{
    public class GetCustomerSuscriptionByIdCustomerQuery : IRequest<Response<CustomerSuscriptionDTO>>
    {
        public int Id { get; set; }
    }
    public class GetCustomerSuscriptionByIdCustomerQueryHandler : IRequestHandler<GetCustomerSuscriptionByIdCustomerQuery, Response<CustomerSuscriptionDTO>>
    {
        private readonly IRepositoryAsync<CustomerSuscription> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetCustomerSuscriptionByIdCustomerQueryHandler(IRepositoryAsync<CustomerSuscription> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<CustomerSuscriptionDTO>> Handle(GetCustomerSuscriptionByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null) { throw new KeyNotFoundException($"Record not found with Id: {request.Id}"); }
            else
            {
                var recordDTO = _mapper.Map<CustomerSuscriptionDTO>(record);

                return new Response<CustomerSuscriptionDTO>(recordDTO);
            }

        }


    }
}
