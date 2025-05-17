using FluentResults;

namespace EquipmentMonitoring.Domain.Errors
{
    public static class AgreementFailed
    {
        public static Error CannotExecuteAgreement =>
            new Error("The agreement failed");
    }
}
