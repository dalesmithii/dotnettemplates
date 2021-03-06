﻿using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceName.Api.Application.Behaviors
{

    namespace Ordering.API.Infrastructure.Behaviors
    {
        public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        {
            private readonly IValidator<TRequest>[] _validators;
            public ValidatorBehavior(IValidator<TRequest>[] validators) => _validators = validators;

            public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
            {
                var failures = _validators
                    .Select(v => v.Validate(request))
                    .SelectMany(result => result.Errors)
                    .Where(error => error != null)
                    .ToList();

                if (failures.Any())
                {
                    throw new ApplicationException(
                        $"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));
                }

                var response = await next();
                return response;
            }
        }
    }
}
