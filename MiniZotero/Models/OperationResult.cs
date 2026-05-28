namespace MiniZotero.Models
{
    public class OperationResult
    {
        protected OperationResult(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; }

        public string Message { get; }

        public static OperationResult Success(string message = "")
        {
            return new OperationResult(true, message);
        }

        public static OperationResult Failure(string message)
        {
            return new OperationResult(false, message);
        }
    }

    public sealed class OperationResult<T> : OperationResult
    {
        private OperationResult(bool succeeded, string message, T? value)
            : base(succeeded, message)
        {
            Value = value;
        }

        public T? Value { get; }

        public static OperationResult<T> Success(T value, string message = "")
        {
            return new OperationResult<T>(true, message, value);
        }

        public static new OperationResult<T> Failure(string message)
        {
            return new OperationResult<T>(false, message, default);
        }
    }
}
