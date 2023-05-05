using ofw.core;

namespace ofw.process
{
    public class TaskResult<T> where T : CoreObject
    {
        public TaskResult(ResultStatus status, T? value, TaskProcess? next = null, string? message = null)
        {
            Status = status;
            Value = value;
            Next = next;
            Message = message;
        }

        public ResultStatus Status { get; } = ResultStatus.Success;

        public TaskProcess? Next { get; }

        public string? Message { get; }

        public T? Value { get; }
    }

}