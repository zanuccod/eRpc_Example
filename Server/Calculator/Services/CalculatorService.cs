using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Calculator
{
    public class CalculatorService : Svc.SvcBase
    {
        private readonly ILogger<CalculatorService> _logger;

        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        public override async Task<CalculateReply> Calculate(CalculateRequest request, ServerCallContext context)
        {
            long result = -1;
            switch (request.Op)
            {
                case "+":
                    result = request.X + request.Y;
                    break;
                case "-":
                    result = request.X - request.Y;
                    break;
                case "*":
                    result = request.X * request.Y;
                    break;
                case "/":
                    if (request.Y != 0)
                    {
                        result = (long)request.X / request.Y;
                    }
                    break;
                default:
                    break;
            }
            return await Task.FromResult(new CalculateReply { Result = result });
        }
    }
}
