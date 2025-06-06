using FluentResults;
using SmartHotel.Domain.Common;
using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Rules
{
    public sealed record ComparationPrice(double Value, double Price) : IBusinessRule
    {
        public Result CheckRule()
        {
            if (Value < Price)
            return Result.Ok();
            return Result.Fail(new Error("Verify your payment, you have to pay more"));
        }
    }
}
