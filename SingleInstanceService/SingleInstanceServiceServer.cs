using Grpc.Core;
using Singleinstance;

namespace SingleInstanceService
{
    /// <summary>
    /// Single instanse service server
    /// </summary>
    public class SingleInstanceServiceServer
    {
        private Server server;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceImpl">Server implementation with arguments processing</param>
        /// <param name="host">host (by default 127.0.0.1)</param>
        /// <param name="port">port (by default 30051)</param>m>
        public SingleInstanceServiceServer(SingleInstance.SingleInstanceBase serviceImpl, string host = "127.0.0.1", int port = 30051)
        {
            this.server = new Server
            {
                Services = { SingleInstance.BindService(serviceImpl) },
                Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            };
        }

        /// <summary>
        /// Desctructor
        /// </summary>
        ~SingleInstanceServiceServer()
        {
            this.Stop();
        }

        /// <summary>
        /// Start server
        /// </summary>
        public void Start()
        {
            this.server.Start();
        }

        /// <summary>
        /// Stop server
        /// </summary>
        public void Stop()
        {
            this.server.ShutdownAsync().Wait();
        }
    }
}
