namespace AssessmentMangement.Models.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException() : base() { }

        public UnauthorizedException(string message) : base(message) { }
    }
}