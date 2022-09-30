using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingleInstanceService.Test
{
    [TestClass]
    public class SingleInstanceServiceTest
    {
        [TestMethod]
        public void SendArgs()
        {
            SingleInstanceServiceServer server = new SingleInstanceServiceServer(new SingleInstantServiceTestImpl());
            server.Start();

            string[] args = { "one", "two", "three" };

            SingleInstanceServiceClient.SendArgs(args, out var replyMessage);

            var expectedResult = string.Join('|', args);
            Assert.AreEqual(expectedResult, replyMessage);

            server.Stop();
        }

        [TestMethod]
        public void SendArgsCustomServerHost()
        {
            SingleInstanceServiceServer server = new SingleInstanceServiceServer(new SingleInstantServiceTestImpl(), "localhost", 30052);
            server.Start();

            string[] args = { "one", "two", "three" };

            SingleInstanceServiceClient.SendArgs(args, out var replyMessage, "localhost", 30052);

            var expectedResult = string.Join('|', args);
            Assert.AreEqual(expectedResult, replyMessage);

            server.Stop();
        }
    }
}