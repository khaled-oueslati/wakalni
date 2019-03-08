using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wakalni.Application.Infrastructure
{
    public class RequestIlogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger logger;

        public RequestIlogger(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;
            //TODO add User Details
            logger.LogInformation("[{date}] Wakalni Request {name} {@Request}",
                DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff"), name, request);
            return Task.CompletedTask;
        }
    }
}
