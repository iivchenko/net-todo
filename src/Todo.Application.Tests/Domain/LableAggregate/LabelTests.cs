using NUnit.Framework;
using System;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Application.Tests.Domain.LableAggregate
{
    [TestFixture]
    public sealed class LabelTests
    {
        [Test]
        public void Constructor_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "test-name";
            var description = "test-description";
            var color = new Color(1, 2, 3, 4);

            var date = DateTime.UtcNow;

            // Act
            var label = new Label(id, name, description, color);

            // Assert
            Assert.That(label.Id, Is.EqualTo(id));
            Assert.That(label.Name, Is.EqualTo(name));
            Assert.That(label.Description, Is.EqualTo(description));
            Assert.That(label.Color, Is.EqualTo(color));
            Assert.That(label.DateCreated, Is.EqualTo(date).Within(3).Seconds);
            Assert.That(label.DateUpdated, Is.EqualTo(date).Within(3).Seconds);
        }

        [Test]
        public void UpdateName_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "test-name";
            var description = "test-description";
            var color = new Color(1, 2, 3, 4);

            var expectedName = "new-name";

            var label = new Label(id, name, description, color);

            // Act
            label.UpdateName(expectedName);

            // Assert
            Assert.That(label.Name, Is.EqualTo(expectedName));
            Assert.That(label.DateUpdated, Is.GreaterThan(label.DateCreated));
        }

        [Test]
        public void UpdateDescription_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "test-name";
            var description = "test-description";
            var color = new Color(1, 2, 3, 4);

            var expectedDescription = "new-description";

            var label = new Label(id, name, description, color);

            // Act
            label.UpdateDescription(expectedDescription);

            // Assert
            Assert.That(label.Description, Is.EqualTo(expectedDescription));
            Assert.That(label.DateUpdated, Is.GreaterThan(label.DateCreated));
        }

        [Test]
        public void UpdateColor_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "test-name";
            var description = "test-description";
            var color = new Color(1, 2, 3, 4);

            var expectedColor = new Color(5, 6, 7, 8);

            var label = new Label(id, name, description, color);

            // Act
            label.UpdateColor(expectedColor);

            // Assert
            Assert.That(label.Color, Is.EqualTo(expectedColor));
            Assert.That(label.DateUpdated, Is.GreaterThan(label.DateCreated));
        }
    }
}
