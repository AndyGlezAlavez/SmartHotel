using FluentResults;

namespace SmartHotel.Domain.Errors
{
    public static class AgreementFailedErrors
    {
        public static Error CannotExecuteAgreement =>
            new ("The agreement failed");
    }
}
