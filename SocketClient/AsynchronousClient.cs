using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Communication;

/*Ez az osztály gondoskodik a TCP/IP kapcsolat kliens oldalával
 * Megadunk egy hostot, amire kapcsolódni szeretnénk és egy hozzá tartozó portot.
 */

namespace AsynchronousClient
{
    public class SocketClient
    {
        private const string host = "127.0.0.1";
        private const int port = 50000;

        private static StreamWriter writer;
        private static StreamReader reader;
        private static TcpClient client;

        public static NetworkStream GetStream()
        {
            return client.GetStream();
        }

        public static void StartClient()
        {
            try
            {
                //Server IP address
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

                if (ipAddress == null)
                    throw new Exception("No IPv4 address for server");
                client = new TcpClient();
                client.Connect(ipAddress, port); // Connect
                Console.WriteLine("Sikeres kapcsolódás");
                //Console.WriteLine("Connect to server " + ipAddress + " on port " + port);
                NetworkStream networkStream = client.GetStream();
                writer = new StreamWriter(networkStream);
                reader = new StreamReader(networkStream);
                writer.AutoFlush = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nem sikerült kapcsolódni, újrapróbálkozás 5 másodperc múlva");
                System.Threading.Thread.Sleep(5000);
                StartClient();
            }
        }

        public static void Close()
        {
            if (client.Connected)
            {
                client.Close();
            }
        }
        /*Ez a függvény szolgál a Megrendelések elküldésére a szerverre
        A serializer átalakítja json formátumra (egy sztringre), amit továbbítunk a szervernek, ahol egy
        egy másik serializer visszalakítja objektummá*/
        public static async Task<Order> SendRequest(Order o)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string requestData = serializer.Serialize(o);
                await writer.WriteLineAsync(requestData);
                
                string responseStr = await reader.ReadLineAsync();
                Console.WriteLine(responseStr);
                Order response = serializer.Deserialize<Order>(responseStr);
                
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                //Console.WriteLine("Valami nem jó.");
                return null;
            }
        }
    }
}
