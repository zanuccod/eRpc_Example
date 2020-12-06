using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Count() != 5)
                return;

            string host = args[0];
            int port = int.Parse(args[1]);
            long x = long.Parse(args[2]);
            string op = args[3];
            long y = long.Parse(args[4]);

            var channel = new Channel(
                host,
                port,
                ChannelCredentials.Insecure);

            var client = new Svc.SvcClient(channel);
            var reply = client.Calculate(new CalculateRequest
            {
                X = x,
                Y = y,
                Op = op
            });
            Console.WriteLine($"The calculated result is: {reply.Result}");
        }
    }
}
