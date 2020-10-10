using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Application.Queries
{
    public sealed class GetLabelsQuery : IRequest<GetLabelsQueryResponse>
    {
    }

    public sealed class GetLabelsQueryHandler : IRequestHandler<GetLabelsQuery, GetLabelsQueryResponse>
    {
        private readonly IReadRepository<Label, Guid> _labelRepository;
        private readonly IMapper _mapper;

        public GetLabelsQueryHandler(
            IReadRepository<Label, Guid> labelRepository,
            IMapper mapper)
        {
            _labelRepository = labelRepository;
            _mapper = mapper;
        }

        public async Task<GetLabelsQueryResponse> Handle(GetLabelsQuery request, CancellationToken cancellationToken)
        {
            return new GetLabelsQueryResponse
            {
                Labels = _mapper.Map<IEnumerable<GetLabelsQueryResponseLabel>>(await _labelRepository.FindAsync(x => true))
            };
        }
    }

    public sealed class GetLabelsQueryResponse
    {
        public IEnumerable<GetLabelsQueryResponseLabel> Labels { get; set; }
    }

    public sealed class GetLabelsQueryResponseLabel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public GetLabelsQueryResponseColor Color { get; set; }
    }

    public sealed class GetLabelsQueryResponseColor
    {
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte Alpha { get; set; }
    }
}
