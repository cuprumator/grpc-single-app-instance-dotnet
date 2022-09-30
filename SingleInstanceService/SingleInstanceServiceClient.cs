using Grpc.Core;
using Singleinstance;

namespace SingleInstanceService
{
    /// <summary>
    /// Single instanse service client
    /// </summary>
    public class SingleInstanceServiceClient
    {
        /// <summary>
        /// Send command line argumets to sevice server
        /// </summary>
        /// <param name="args">argumetns array</param>
        /// <param name="replyMessage">reply message</param>
        /// <param name="host">host (by default 127.0.0.1)</param>
        /// <param name="port">port (by default 30051)</param>
        public static void SendArgs(string[] args, out string replyMessage, string host = "127.0.0.1", int port = 30051)
        {
            var channel = new Channel(host, port, ChannelCredentials.Insecure);

            var client = new SingleInstance.SingleInstanceClient(channel);

            var reply = client.SendArgs(new SendArgsRequest { Args = { args } });

            replyMessage = reply.Message;

            channel.ShutdownAsync().Wait();
        }
    }
}
