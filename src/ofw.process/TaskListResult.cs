using ofw.core;

namespace ofw.process
{
    public class TaskListResult<T> where T : CoreObject, IReadOnlyList<T>
    {
        public TaskListResult(ResultStatus status, TaskProcess? next = null, string? message = null)
        {
            Status = status;
            Next = next;
            Message = message;
        }

        public ResultStatus Status { get; } = ResultStatus.Success;

        public TaskProcess? Next { get; }

        public string? Message { get; }
    }
}