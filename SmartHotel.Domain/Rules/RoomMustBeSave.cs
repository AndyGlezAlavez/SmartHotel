using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Rules
{
    public sealed record RoomMustBeSave(SmokeUnit Unit, double Reference, double Value) : IBusinessRule
    {
        public Result CheckRule()
        {
            switch (Unit)
            {
                case SmokeUnit.Ppt:  
                if (Value < Reference)
                    return Result.Ok();
                else
                    return Result.Fail(new Error("The room es not safe"));
            case SmokeUnit.Ppm:
                if (Value < 1000000 * Reference)
                return Result.Ok();
                else
                return Result.Fail(new Error("The room es not safe"));
            default:
                return Result.Fail(new Error("Option not avaible"));
            }
        }

        public static Result<RoomMustBeSave> Create(SmokeUnit Unit, double Reference, double Value)
        {
            switch (Unit)
            {
                case SmokeUnit.Ppt:
                    if (Value < Reference)
                        return Result.Ok();
                    else
                        return Result.Fail(new Error("The room es not safe"));
                case SmokeUnit.Ppm:
                    if (Value < 1000000 * Reference)
                        return Result.Ok();
                    else
                        return Result.Fail(new Error("The room es not safe"));
                default:
                    return Result.Fail(new Error("Option not avaible"));
            }
    }
}
}
