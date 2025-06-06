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
    public sealed record DateMustBeFree(DateTime StartDate, DateTime FinalDate, List<Agreement> Agreements) : IBusinessRule
    {
        public Result CheckRule()
        {
            if(!Agreements.Any(a => StartDate < a.FinalDate && FinalDate > a.StartDate))
                return Result.Ok();
            return Result.Fail(new Error("Room is not free in this period"));
        }
    }
}
