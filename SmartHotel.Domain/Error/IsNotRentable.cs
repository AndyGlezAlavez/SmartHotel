using FluentResults;

namespace EquipmentMonitoring.Domain.Errors
{
    public static class IsNotRentable
    {
        public static Error CannotExecuteExternalOperation =>
            new Error("This room si not rentabled.");

        public static Error CannotExecuteAgreementOperation =>
            new Error("This room si not rentabled in this period");
    }
}
