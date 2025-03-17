using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SuscriptionTypes.Commands.UpdateSuscriptionTypeCommand
{
    public class UpdateSuscriptionTypeCommand : IRequest<Response<int>>
    {
        public int IdSuscriptionType { get; set; }
        public string TypeSuscription { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }

    public class UpdateSuscriptionTypeCommandHandler
    {
        private readonly IRepositoryAsync<SuscriptionType> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateSuscriptionTypeCommandHandler(IRepositoryAsync<SuscriptionType> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSuscriptionTypeCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.IdSuscriptionType);
            if (record == null) { throw new KeyNotFoundException($"Record not found with Id: {request.IdSuscriptionType}"); }
            else
            {
                record.TypeSuscription = request.TypeSuscription;
                record.Price = request.Price;
                record.Status = request.Status;
                await _repositoryAsync.UpdateAsync(record);
            }
            var data = await _repositoryAsync.AddAsync(record);
            return new Response<int>(record.Id);
        }
    }

}
