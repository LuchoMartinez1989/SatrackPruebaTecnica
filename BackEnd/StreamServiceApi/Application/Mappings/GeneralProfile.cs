using Application.DTOs;
using Application.Features.Customers.Commands.CreateCustomerCommand;
using Application.Features.CustomerSuscriptions.Commands.CreateCustomerSuscriptionCommand;
using Application.Features.SuscriptionTypes.Commands.CreateSuscriptionTypeCommand;
using Application.Features.TypePurchases.Commands.CreateTypePurchaseCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile:Profile
    {

        public GeneralProfile()
        {
            #region Commmands
            CreateMap<CreateCustomerCommand, Customer>();

            CreateMap<CreateCustomerSuscriptionCommand, CustomerSuscription>();

            CreateMap<CreateSuscriptionTypeCommand, SuscriptionType>();

            CreateMap<CreateTypePurchaseCommand, TypePurchase>();
            #endregion

            #region DTOs
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerSuscription, CustomerSuscriptionDTO>();
            CreateMap<SuscriptionType, SuscriptionTypeDTO>();
            CreateMap<TypePurchase, TypePurchaseDTO>();

            #endregion


        }
    }
}
