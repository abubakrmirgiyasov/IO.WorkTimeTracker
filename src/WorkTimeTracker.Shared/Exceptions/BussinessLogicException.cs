using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Shared.Exceptions;

public class BussinessLogicException : Exception
{
    public BussinessLogicException(Error error) : base(error.Message) { }

    public BussinessLogicException(Error error, Exception exception) : base(error.Message, exception) { }
}
