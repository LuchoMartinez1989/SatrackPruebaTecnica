using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string IdenticacionCode { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }


    }
    public class UpdateCustomerCommandHandler
    {

        private readonly IRepositoryAsync<Customer> _repositoryAsync;

        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null) { throw new KeyNotFoundException($"Record not found with Id: {request.Id}"); }
            else
            {
                record.Name = request.Name;
                record.Lastnames = request.Lastnames;
                record.Mail = request.Mail;
                record.Password = request.Password;
                await _repositoryAsync.UpdateAsync(record);
            }

            var data = await _repositoryAsync.AddAsync(record);
            return new Response<int>(record.Id);
        }
    }
}
