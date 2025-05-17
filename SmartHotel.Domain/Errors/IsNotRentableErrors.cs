using FluentResults;

namespace SmartHotel.Domain.Errors
{
    public static class IsNotRentableErrors
    {
        public static Error CannotExecuteExternalOperation =>
            new ("This room si not rentabled.");

        public static Error CannotExecuteAgreementOperation =>
            new ("This room si not rentabled in this period");
    }
}
