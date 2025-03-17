using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
        {
            private readonly IRepositoryAsync<Customer> _repositoryAsync;

            private readonly IMapper _mapper;

            public DeleteCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {

                var record = await _repositoryAsync.GetByIdAsync(request.Id);
                if (record == null) { throw new KeyNotFoundException($"Record not found with Id: {request.Id}"); }
                else
                {
                    await _repositoryAsync.DeleteAsync(record);
                }
                return new Response<int>(record.Id);
            }
        }
    }
}
