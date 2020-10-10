using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Commands;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Application.Tests.Commands
{
    [TestFixture]
    public sealed class UpdateLabelCommanHandlerTests
    {
        private UpdateLabelCommanHandler _handler;

        private Mock<IRepository<Label, Guid>> _labelRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _labelRepository = new Mock<IRepository<Label, Guid>>();

            _unitOfWork = new Mock<IUnitOfWork>();

            _handler = new UpdateLabelCommanHandler(_labelRepository.Object, _unitOfWork.Object);
        }

        [Test]
        public async Task Handle_Success()
        {
            // Arrange
            var labelId = Guid.NewGuid();

            var command = new UpdateLabelCommand
            {
                Id = labelId,
                Name = "new-name",
                Description = "new-description",
                Color = new UpdateLabelCommanColor
                {
                    Red = 10,
                    Green = 11,
                    Blue = 12,
                    Alpha = 13
                }
            };

            var label = new Label(labelId, "test-name", "test-description", new Color(1, 2, 3, 4));

            _labelRepository
                .Setup(x => x.FindByIdAsync(labelId))
                .ReturnsAsync(label);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _labelRepository.Verify(x => x.UpdateAsync(label), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(), Times.Once);

            Assert.That(label.Name, Is.EqualTo("new-name"));
            Assert.That(label.Description, Is.EqualTo("new-description"));
            Assert.That(label.Color, Is.EqualTo(new Color(10, 11, 12, 13)));
        }
    }
}
