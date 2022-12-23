using System.IO.Ports;
using System.Net.Sockets;
using System.Net;
using System.Text;
using ConsoleApplication;

Client client = new Client();
client.Connect1("127.0.0.1", 23);
Console.ReadLine();

