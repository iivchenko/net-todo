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
    public sealed class CreateLabelCommanHandlerTests
    {
        private CreateLabelCommanHandler _handler;

        private Mock<IRepository<Label, Guid>> _labelRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _labelRepository = new Mock<IRepository<Label, Guid>>();

            _unitOfWork = new Mock<IUnitOfWork>();

            _handler = new CreateLabelCommanHandler(_labelRepository.Object, _unitOfWork.Object);
        }

        [Test]
        public async Task Handle_Success()
        {
            // Arrange
            var command = new CreateLabelCommand
            {
                Name = "test-name",
                Description = "test-description",
                Color = new CreateLabelCommanColor()
            };

            var expectedLabelId = Guid.NewGuid(); 

            _labelRepository
                .Setup(x => x.CreateAsync(It.IsAny<Label>()))
                .ReturnsAsync(expectedLabelId);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _labelRepository.Verify(x => x.CreateAsync(It.IsAny<Label>()), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(), Times.Once);

            Assert.That(response.Id, Is.EqualTo(expectedLabelId));
        }
    }
}
