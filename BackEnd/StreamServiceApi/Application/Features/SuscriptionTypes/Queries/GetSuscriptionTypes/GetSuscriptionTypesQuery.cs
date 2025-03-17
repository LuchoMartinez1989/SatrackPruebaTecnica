using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Data;

namespace Application.Features.SuscriptionTypes.Queries.GetSuscriptionTypes
{
    public class GetSuscriptionTypesQuery : IRequest<Response<List<SuscriptionTypeDTO>>>
    {

        public class GetSuscriptionTypesQueryHandler : IRequestHandler<GetSuscriptionTypesQuery, Response<List<SuscriptionTypeDTO>>>
        {
            private readonly IRepositoryAsync<SuscriptionType> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetSuscriptionTypesQueryHandler(IRepositoryAsync<SuscriptionType> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<List<SuscriptionTypeDTO>>> Handle(GetSuscriptionTypesQuery request, CancellationToken cancellationToken)
            {
               
                var records = await _repositoryAsync.ListAsync();
                var recorsDTO = _mapper.Map<List<SuscriptionTypeDTO>>(records);
                return new Response<List<SuscriptionTypeDTO>>(recorsDTO);
               
            }
        }
    }
   
}
