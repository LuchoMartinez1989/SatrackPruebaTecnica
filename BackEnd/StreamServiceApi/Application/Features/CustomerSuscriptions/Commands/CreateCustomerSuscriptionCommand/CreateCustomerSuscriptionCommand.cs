using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomerSuscriptions.Commands.CreateCustomerSuscriptionCommand
{
    public class CreateCustomerSuscriptionCommand : IRequest<Response<int>>
    {

        public int IdCustomer { get; set; }
        
        public int SuscriptionTypeId { get; set; }
        public int TypePurchaseId { get; set; }
        public DateTime StartDate { get; set; }
        
        public float SuscriptionPrice { get; set; }

    }
    /// <summary>
    /// este es el mediador o manejadorel cual se encarga de cumplir la tarea haciendo uso de los componentes necesarios
    /// </summary>
    public class CreateCustomerSuscriptionCommandHandler : IRequestHandler<CreateCustomerSuscriptionCommand, Response<int>>
    {
        private readonly IRepositoryAsync<CustomerSuscription> _repositoryAsync;
        private readonly IRepositoryAsync<TypePurchase> _repositoryAsyncTp;

        private readonly IMapper _mapper;

        public CreateCustomerSuscriptionCommandHandler(IRepositoryAsync<CustomerSuscription> repositoryAsync, IMapper mapper,IRepositoryAsync<TypePurchase> repositoryAsyncTp)
        {
            _repositoryAsync = repositoryAsync;
            _repositoryAsyncTp = repositoryAsyncTp;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomerSuscriptionCommand request, CancellationToken cancellationToken)
        {

            var newRecord = _mapper.Map<CustomerSuscription>(request);
            newRecord.SuscriptionStatus = "Active";
            newRecord.FinishDate = finishDate(newRecord.TypePurchaseId,newRecord.StartDate);

            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
        DateTime finishDate(int TypePurchaseId,DateTime start) {
           
            var list = _repositoryAsyncTp.ListAsync().Result;
            int months= list.Where(m => m.Id== TypePurchaseId) // Filtra por una condición
    .       Select(m => m.MonthDuration)
            .FirstOrDefault();
            DateTime finish= start.AddMonths(months);
            return finish;

        }
    }
}