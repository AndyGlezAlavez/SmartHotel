using FluentResults;

namespace SmartHotel.Domain.Errors
{
    public class IsNotRentableErrors
    {
        public static Error YouMostPayMoreMoney =>
            new ("You most pay more money");

        public static Error CannotExecuteAgreementOperation =>
            new ("This room si not rentabled, try another datetime or a diferent room");

       }
}
