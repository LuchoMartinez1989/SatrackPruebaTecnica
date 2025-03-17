using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetCustomers
{
    public class GetCustomersByEmailQuery : IRequest<Response<List<CustomerDTO>>>
    {
        public string Mail { get; set; }
        //public string Password { get; set; }

    }
    public class GetCustomersByEmailQueryHandler : IRequestHandler<GetCustomersByEmailQuery, Response<List<CustomerDTO>>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetCustomersByEmailQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<List<CustomerDTO>>> Handle(GetCustomersByEmailQuery request, CancellationToken cancellationToken)
        {
            var records = await _repositoryAsync.ListAsync(new CustomerSpecification(request.Mail));
            var recorsDTO = _mapper.Map<List<CustomerDTO>>(records);
            return new Response<List<CustomerDTO>>(recorsDTO);

        }
    }
}
