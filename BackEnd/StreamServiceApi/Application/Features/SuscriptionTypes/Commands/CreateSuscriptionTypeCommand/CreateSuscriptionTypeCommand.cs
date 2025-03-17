using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SuscriptionTypes.Commands.CreateSuscriptionTypeCommand
{
    public class CreateSuscriptionTypeCommand : IRequest<Response<int>>
    {
        public int IdSuscriptcionType { get; set; }
        public string TypeSuscription { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }

    public class CreateSuscriptionTypeCommandHandler : IRequestHandler<CreateSuscriptionTypeCommand, Response<int>>
    {
        private readonly IRepositoryAsync<SuscriptionType> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateSuscriptionTypeCommandHandler(IRepositoryAsync<SuscriptionType> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateSuscriptionTypeCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<SuscriptionType>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
