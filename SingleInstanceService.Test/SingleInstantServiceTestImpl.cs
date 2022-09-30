using System.Threading.Tasks;
using Grpc.Core;
using Singleinstance;

namespace SingleInstanceService.Test
{
    /// <summary>
    /// Single instance service imeplemntation for arguments processing
    /// </summary>
    internal class SingleInstantServiceTestImpl : SingleInstance.SingleInstanceBase
    {
        public override Task<SendArgsReply> SendArgs(SendArgsRequest request, ServerCallContext context)
        {
            var replyMessage = string.Join('|', request.Args);
            return Task.FromResult(new SendArgsReply { Message = replyMessage });
        }
    }
}
