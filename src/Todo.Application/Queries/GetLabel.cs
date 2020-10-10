using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Application.Queries
{
    public sealed class GetLabelQuery : IRequest<GetLabelQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetLabelQueryHandler : IRequestHandler<GetLabelQuery, GetLabelQueryResponse>
    {
        private readonly IReadRepository<Label, Guid> _labelRepository;
        private readonly IMapper _mapper;

        public GetLabelQueryHandler(
            IReadRepository<Label, Guid> labelRepository,
            IMapper mapper)
        {
            _labelRepository = labelRepository;
            _mapper = mapper;
        }

        public async Task<GetLabelQueryResponse> Handle(GetLabelQuery request, CancellationToken cancellationToken)
        {
            var entity = await _labelRepository.FindByIdAsync(request.Id);

            return _mapper.Map<GetLabelQueryResponse>(entity);
        }
    }

    public sealed class GetLabelQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public GetLabelQueryResponseColor Color { get; set; }
    }

    public sealed class GetLabelQueryResponseColor
    {
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte Alpha { get; set; }
    }
}
