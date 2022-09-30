using System.Threading.Tasks;
using Grpc.Core;
using Singleinstance;

namespace SingleInstanceService.Test
{
    internal class SingleInstantServiceTestImpl : SingleInstance.SingleInstanceBase
    {
        public override Task<SendArgsReply> SendArgs(SendArgsRequest request, ServerCallContext context)
        {
            var replyMessage = string.Join('|', request.Args);
            return Task.FromResult(new SendArgsReply { Message = replyMessage });
        }
    }
}
