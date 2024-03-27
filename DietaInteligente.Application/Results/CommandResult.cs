public class CommandResult
{
    public bool Success { get; }
    public string Message { get; }
    public IEnumerable<string> Errors { get; }

    public CommandResult(bool success, string message = "", IEnumerable<string> errors = null)
    {
        Success = success;
        Message = message;
        Errors = errors ?? Enumerable.Empty<string>();
    }

    public static CommandResult SuccessResult(string message)
    {
        return new CommandResult(true, message);
    }

    public static CommandResult FailureResult(IEnumerable<string> errors)
    {
        return new CommandResult(false, errors: errors);
    }
}