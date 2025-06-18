using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentResults;

namespace SmartHotel.Application.Common
{
    public interface ICommandHandler<T> : IRequestHandler<T, Result>
        where T : ICommand
    { }
    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : ICommand<TResponse>
    {
    }
}
