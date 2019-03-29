using System;

using ToDo.Domain.TaskAggregate;
using ToDo.Domain.TaskAggregate.Exceptions;
using Xunit;

namespace ToDo.Domain.Tests.TaskTests
{
    public class CreateTaskTests
    {
        private const string FakeTaskTitle = "Title";
        private const string FakeTaskDescription = "Description";

        [Fact]
        public void Task_WhenTitleIsProvided_ShouldBeenCreatedWithCorrectTitle()
        {
            // Act
            var task = new Task(FakeTaskTitle);

            // Assert
            Assert.Equal(FakeTaskTitle, task.Title);
        }

        [Fact]
        public void Task_WhenTitleAndDescriptionIsProvided_ShouldBeenCreated()
        {
            // Act
            var task = new Task(FakeTaskTitle, FakeTaskDescription);

            // Assert
            Assert.Equal(FakeTaskTitle, task.Title);
            Assert.Equal(FakeTaskDescription, task.Description);
        }

        [Fact]
        public void Task_WhenTitleIsNull_ShouldThrowTaskTitleDomainException()
        {
            // Assert
            Assert.Throws<TaskTitleDomainException>(() => new Task(null));
        }

        [Fact]
        public void Task_WhenTitleIsEmpty_ShouldThrowTaskTitleDomainException()
        {
            // Assert
            Assert.Throws<TaskTitleDomainException>(() => new Task(String.Empty));
        }
    }
}