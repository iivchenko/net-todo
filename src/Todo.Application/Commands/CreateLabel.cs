using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Application.Commands
{
    public sealed class CreateLabelCommand : IRequest<CreateLabelCommandResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CreateLabelCommanColor Color { get; set; }
    }

    public sealed class CreateLabelCommanColor
    {
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte Alpha { get; set; }
    }

    public sealed class CreateLabelCommanHandler : IRequestHandler<CreateLabelCommand, CreateLabelCommandResponse>
    {
        private readonly IRepository<Label, Guid> _labelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLabelCommanHandler(
            IRepository<Label, Guid> labelRepository,
            IUnitOfWork unitOfWork)
        {
            _labelRepository = labelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateLabelCommandResponse> Handle(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            var color = new Color(request.Color.Red, request.Color.Green, request.Color.Blue, request.Color.Alpha);
            var label = new Label(Guid.NewGuid(), request.Name, request.Description, color);

            var id = await _labelRepository.CreateAsync(label);

            await _unitOfWork.CommitAsync();

            return new CreateLabelCommandResponse
            {
                Id = id
            };
        }
    }

    public sealed class CreateLabelCommandResponse
    {
        public Guid Id { get; set; }
    }
}
