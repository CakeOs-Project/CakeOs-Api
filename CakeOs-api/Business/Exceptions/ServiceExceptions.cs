namespace CakeOs.Business.Exceptions
{
    public abstract class ServiceException : Exception
    {
        protected ServiceException(string message) : base(message) { }
    }

    public sealed class NotFoundException : ServiceException
    {
        public NotFoundException(string message) : base(message) { }
    }

    public sealed class ConflictException : ServiceException
    {
        public ConflictException(string message) : base(message) { }
    }
}
