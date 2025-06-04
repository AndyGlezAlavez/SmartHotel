using FluentResults;
using SmartHotel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Rules
{
    public sealed record EmailMustBeGmail(string Email) : IBusinessRule
    {
        public Result CheckRule()
        {
            if (Email.EndsWith("@gmail.com"))
                return Result.Ok();
            return Result.Fail(new Error("Email must be a Gmail address"));
    }
    }
}
