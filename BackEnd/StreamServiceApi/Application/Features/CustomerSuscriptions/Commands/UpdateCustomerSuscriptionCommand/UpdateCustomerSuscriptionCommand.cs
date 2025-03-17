using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Application.Features.CustomerSuscriptions.Commands.UpdateCustomerSuscriptionCommand
{
    public class UpdateCustomerSuscriptionCommand : IRequest<Response<int>>
    {
        
        public int Id { get; set; }
        public int IdSuscriptionType { get; set; }
        public int IdTypePurchase { get; set; }
        
        public DateTime FinishDate { get; set; }
        public string SuscriptionStatus { get; set; }
        public double SuscriptionRefund { get; set; }
    }
    public class UpdateCustomerSuscriptionCommandHandler:IRequestHandler<UpdateCustomerSuscriptionCommand,Response<int>>
    {

        private readonly IRepositoryAsync<CustomerSuscription> _repositoryAsyncCS;
        private readonly IRepositoryAsync<CustomerSuscription> _repositoryAsync;
        private readonly IRepositoryAsync<TypePurchase> _repositoryAsyncTp;

        private readonly IMapper _mapper;
        public UpdateCustomerSuscriptionCommandHandler(IRepositoryAsync<CustomerSuscription> repositoryAsync, IMapper mapper,  IRepositoryAsync<TypePurchase> repositoryAsyncTp)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _repositoryAsyncTp = repositoryAsyncTp;

        }

        public async Task<Response<int>> Handle(UpdateCustomerSuscriptionCommand request, CancellationToken cancellationToken)
        {
            var recordDTO = _mapper.Map<CustomerSuscriptionDTO>(await _repositoryAsync.GetByIdAsync(request.Id));
            var updateRecord = new CustomerSuscription();
            
            if (recordDTO == null) { throw new KeyNotFoundException($"Record not found with Id: {request.Id}"); }
            else
            {
                switch (request.SuscriptionStatus)
                {
                    case "Cancel":
                        cancelSuscription(request, recordDTO);
                        break;
                    case "Updated":
                        UpdateSuscription(request, recordDTO);
                        break;
                    
                    default:
                        break;
                }
                updateRecord.Id = recordDTO.Id;
                updateRecord.StartDate = recordDTO.StartDate;
                updateRecord.SuscriptionPrice = recordDTO.SuscriptionPrice;
                updateRecord.IdCustomer = recordDTO.IdCustomer;
                updateRecord.SuscriptionTypeId = recordDTO.SuscriptionTypeId;
                updateRecord.TypePurchaseId = request.IdTypePurchase;
                updateRecord.FinishDate = request.FinishDate;
                updateRecord.SuscriptionStatus = request.SuscriptionStatus;
                updateRecord.SuscriptionRefund = request.SuscriptionRefund;
                await _repositoryAsync.UpdateAsync(updateRecord);
            }

            return new Response<int>(recordDTO.Id);
        }

        void cancelSuscription(UpdateCustomerSuscriptionCommand request, CustomerSuscriptionDTO  record) 
        {
            DateTime fechaActual = DateTime.Today;
            int mesesRestantes = ((record.FinishDate.Year - fechaActual.Year) * 12) + record.FinishDate.Month - fechaActual.Month;

            DateTime fechaCancelacion = FechaCancelacion(record.FinishDate);
            request.FinishDate = fechaCancelacion;
            int diasFaltantes = (fechaCancelacion - fechaActual).Days;
            request.SuscriptionRefund = 0;
            if (mesesRestantes > 0 && request.IdTypePurchase != 1)
            {
                request.SuscriptionRefund = refund(record.SuscriptionPrice, mesesRestantes);
            }
            
        }

        void UpdateSuscription(UpdateCustomerSuscriptionCommand request, CustomerSuscriptionDTO record)
        {
            
            DateTime fechaActual = DateTime.Today;
            int mesesRestantes = ((record.FinishDate.Year - fechaActual.Year) * 12) + record.FinishDate.Month - fechaActual.Month;

            DateTime fechaCancelacion = FechaCancelacion (record.FinishDate);
            request.FinishDate = fechaCancelacion;
            int diasFaltantes = (fechaCancelacion - fechaActual).Days;
            request.SuscriptionRefund = 0;
            if (mesesRestantes > 0 && request.IdTypePurchase != 1)
            {
                request.SuscriptionRefund = refund(record.SuscriptionPrice, mesesRestantes);
            }
           
        }

        double refund(double price, int mesesFaltantes) {
            double refund = price-((price/12) * mesesFaltantes);
            return refund;
        }

        DateTime FechaCancelacion(DateTime fechaFinSuscripcion) {
            DateTime fechaFinal = fechaFinSuscripcion;
            DateTime fechaActual = DateTime.Today;

            // Calcular la diferencia en meses
            int mesesRestantes = ((fechaFinal.Year - fechaActual.Year) * 12) + fechaFinal.Month - fechaActual.Month;
            int numeroDia = fechaFinSuscripcion.Day;
            // calcular fecha final
            int nuevoDia = numeroDia;
            int nuevoMes = fechaActual.Month + 1; // Mes siguiente
            int nuevoAnio = fechaActual.Year;
            if (nuevoMes > 12)
            {
                nuevoMes = 1;
                nuevoAnio++;
            }
            DateTime fechaCancelacion = new DateTime(nuevoAnio, nuevoMes, numeroDia);
            return fechaCancelacion;
        }
        DateTime finishDate(int TypePurchaseId, DateTime start)
        {

            var list = _repositoryAsyncTp.ListAsync().Result;
            int months = list.Where(m => m.Id == TypePurchaseId) // Filtra por una condición
            .Select(m => m.MonthDuration)
            .FirstOrDefault();
            DateTime finish = start.AddMonths(months);
            return finish;

        }

    }
}
