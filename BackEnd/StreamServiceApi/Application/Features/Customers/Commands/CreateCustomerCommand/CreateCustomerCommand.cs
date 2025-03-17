using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string? IdenticacionCode { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// este es el mediador o manejadorel cual se encarga de cumplir la tarea haciendo uso de los componentes necesarios
    /// </summary>
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;

        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Customer>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
