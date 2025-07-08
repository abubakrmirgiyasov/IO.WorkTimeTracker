using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Shared.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(Error error) : base(error.Message) { }

    public ResourceNotFoundException(Error error, Exception exception) : base(error.Message, exception) { }
}
