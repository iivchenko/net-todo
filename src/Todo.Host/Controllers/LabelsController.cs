using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Application.Commands;
using Todo.Application.Queries;

namespace Todo.Host.Controllers
{
    public sealed class LabelColorViewModel
    {
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte Alpha { get; set; }
    }

    public sealed class UpdateLabelViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public LabelColorViewModel Color { get; set; }
    }

    public sealed class CreateLabelViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public LabelColorViewModel Color { get; set; }
    }

    public sealed class LabelViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public LabelColorViewModel Color { get; set; }
    }

    [Route("api/labels")]
    [ApiController]
    public sealed class LabelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LabelsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<LabelViewModel>> Get()
        {
            var query = new GetLabelsQuery();

            var response = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<LabelViewModel>>(response.Labels);
        }

        [HttpGet("id")]
        public async Task<LabelViewModel> Get(Guid id)
        {
            var query = new GetLabelQuery
            {
                Id = id
            };

            var response = await _mediator.Send(query);

            return _mapper.Map<LabelViewModel>(response);
        }

        [HttpPost]
        public async Task<Guid> Create(CreateLabelViewModel viewModel)
        {
            var command = _mapper.Map<CreateLabelCommand>(viewModel);

            var response = await _mediator.Send(command);

            return response.Id;
        }

        [HttpPut("id")]
        public async Task Update(Guid id, UpdateLabelViewModel viewModel)
        {
            var command = _mapper.Map<UpdateLabelCommand>(viewModel);
            command.Id = id;

            await _mediator.Send(command);
        }
    }
}
