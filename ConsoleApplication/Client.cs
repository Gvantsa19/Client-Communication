using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public partial class Client
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readdata = null;

        public void Connect1(string host, int port)
        {

            tcpClient.Connect(host, port);

            Thread ct = new Thread(getMessage);
            ct.Start();
        }

        private void getMessage()
        {
            string returnData;
            while (true)
            {
                serverStream = tcpClient.GetStream();
                var buffSize = tcpClient.ReceiveBufferSize;
                byte[] inStream = new byte[buffSize];
                serverStream.Read(inStream, 0, buffSize);

                returnData = Encoding.ASCII.GetString(inStream);

                readdata = returnData;
                Console.WriteLine(readdata);
                sendMessage();
            }


        }
        private void sendMessage()
        {
            var text = Console.ReadLine();
            byte[] outStream = Encoding.ASCII.GetBytes(text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }
    }
}
