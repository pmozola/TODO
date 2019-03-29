using System.Collections.Generic;

using ToDo.Domain.TaskAggregate;
using ToDo.Domain.TaskAggregate.Exceptions;
using Xunit;

namespace ToDo.Domain.Tests.TaskTests
{
    public class ChangeTaskStatusTests
    {
        private const string FakeTaskTitle = "title";

        [Theory]
        [MemberData(nameof(IllegalTaskStatusChangeData))]
        public void ChangeState_WhenNewStateIsInvalid_ShouldThrowIncorrectChangeOfStatusException(TaskStatus oldStatus, TaskStatus newStatus)
        {
            // Arrange
            var task = new Task(FakeTaskTitle);
            task.ChangeStatus(oldStatus);

            // Act, Assert
            Assert.Throws<IncorrectChangeOfStatusException>(() => task.ChangeStatus(newStatus));
        }

        [Theory]
        [MemberData(nameof(LegalTaskStatusChangeData))]
        public void ChangeState_WhenNewStateIsValid_ShouldChangeStatus(TaskStatus oldStatus, TaskStatus newStatus)
        {
            // Arrange
            var task = new Task(FakeTaskTitle);
            task.ChangeStatus(oldStatus);

            // Act
            task.ChangeStatus(newStatus);

            // Assert
            Assert.Equal(newStatus, task.Status);
        }

        public static IEnumerable<object[]> IllegalTaskStatusChangeData => new List<object[]>
        {
            new[] { (object)TaskStatus.Finished, TaskStatus.InProgress },
            new[] { (object)TaskStatus.Finished, TaskStatus.Ready },
            new[] { (object)TaskStatus.InProgress, TaskStatus.Ready }
        };

        public static IEnumerable<object[]> LegalTaskStatusChangeData => new List<object[]>
        {
            new[] { (object)TaskStatus.Ready, TaskStatus.InProgress },
            new[] { (object)TaskStatus.Ready, TaskStatus.Finished },
            new[] { (object)TaskStatus.InProgress, TaskStatus.Finished },
            new[] { (object)TaskStatus.InProgress, TaskStatus.InProgress },
            new[] { (object)TaskStatus.Ready, TaskStatus.Ready },
            new[] { (object)TaskStatus.Finished, TaskStatus.Finished }
        };
    }
}