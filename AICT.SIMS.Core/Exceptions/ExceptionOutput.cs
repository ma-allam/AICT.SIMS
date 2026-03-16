namespace AICT.SIMS.Core.Exceptions
{
    public class ExceptionOutput
    {

        public WebApiExceptionSource ErrorMessageType { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public string? ExtraDetails { get; set; }
    }
}