using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Application.Commands
{
    public sealed class UpdateLabelCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UpdateLabelCommanColor Color { get; set; }
    }

    public sealed class UpdateLabelCommanColor
    {
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte Alpha { get; set; }
    }

    public sealed class UpdateLabelCommanHandler : IRequestHandler<UpdateLabelCommand, Unit>
    {
        private readonly IRepository<Label, Guid> _labelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLabelCommanHandler(
            IRepository<Label, Guid> labelRepository,
            IUnitOfWork unitOfWork)
        {
            _labelRepository = labelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateLabelCommand request, CancellationToken cancellationToken)
        {
            var label = await _labelRepository.FindByIdAsync(request.Id);
            var color = new Color(request.Color.Red, request.Color.Green, request.Color.Blue, request.Color.Alpha);

            if (label.Name != request.Name)
            {
                label.UpdateName(request.Name);
            }

            if (label.Description != request.Description)
            {
                label.UpdateDescription(request.Description);
            }

            if (label.Color != color)
            {
                label.UpdateColor(color);
            }

            await _labelRepository.UpdateAsync(label);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
