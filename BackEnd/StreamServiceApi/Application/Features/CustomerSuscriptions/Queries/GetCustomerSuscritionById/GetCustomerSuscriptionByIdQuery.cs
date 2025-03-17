using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscritionById
{
    public class GetCustomerSuscriptionByIdQuery : IRequest<Response<CustomerSuscriptionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCustomerSuscriptionByIdQueryHandler : IRequestHandler<GetCustomerSuscriptionByIdQuery, Response<CustomerSuscriptionDTO>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;


        public GetCustomerSuscriptionByIdQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<CustomerSuscriptionDTO>> Handle(GetCustomerSuscriptionByIdQuery request, CancellationToken cancellationToken)
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
