using System;
using System.Collections.Generic;
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

       public static async Task<int> SetOrderTerminal(int iD, int terminal)
        {
            try
            {
                string requestData = "SetOrderTerminal";
                await writer.WriteLineAsync(requestData);
                requestData = iD.ToString();
                await writer.WriteLineAsync(requestData);
                requestData = terminal.ToString();
                await writer.WriteLineAsync(requestData);
                string responseStr = await reader.ReadLineAsync();
                if (responseStr.Equals("success"))
                {
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        public static async Task<int> SetDeliveryNoteToSuccess(int id)
        {

            try
            {
                string requestData = "SetDeliveryNoteToSuccess";
                await writer.WriteLineAsync(requestData);
                requestData = id.ToString();
                await writer.WriteLineAsync(requestData);
                string responseStr = await reader.ReadLineAsync();
                if (responseStr.Equals("success"))
                {
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return 0;
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
        public static async Task<int> SetOrderConfirmed(int id)
        {
            try
            {
                string requestData = "SetOrderConfirmed";
                await writer.WriteLineAsync(requestData);
                requestData = id.ToString();
                await writer.WriteLineAsync(requestData);
                string responseStr = await reader.ReadLineAsync();
                if (responseStr.Equals("success"))
                {
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }
        public static async Task<List<Order>> LoadOrders()
        {
            try
            {
                string requestData = "ListOfOrders"; 
                await writer.WriteLineAsync(requestData);
                string responseStr = await reader.ReadLineAsync();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<Order> response = serializer.Deserialize<List<Order>>(responseStr);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
        
        public static async Task<List<Customer>> LoadCustomers()
        {
            try
            {
                string requestData = "ListOfCustomers";
                await writer.WriteLineAsync(requestData);
                string responseStr = await reader.ReadLineAsync();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<Customer> response = serializer.Deserialize<List<Customer>>(responseStr);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static async Task<List<DeliveryNote>> LoadDeliveryNotes()
        {
            try
            {
                string requestData = "ListOfDeliveryNotes";
                await writer.WriteLineAsync(requestData);
                string responseStr = await reader.ReadLineAsync();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<DeliveryNote> response = serializer.Deserialize<List<DeliveryNote>>(responseStr);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static async Task<Order> SendRequest(Order o)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string requestData = serializer.Serialize(o);
                await writer.WriteLineAsync(requestData);
                
                string responseStr = await reader.ReadLineAsync();
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
        public static async Task<DeliveryNote> SendDeliveryNote(DeliveryNote dn)
        {
            try
            {
                string requestData = "AddDeliveryNote";
                await writer.WriteLineAsync(requestData);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                requestData = serializer.Serialize(dn);
                await writer.WriteLineAsync(requestData);

                string responseStr = await reader.ReadLineAsync();
                DeliveryNote response = serializer.Deserialize<DeliveryNote>(responseStr);
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

        public static async Task<int> SetOrderOccupiedPlaces(int id, int FirstOP, int LastOP)
        {
            try
            {
                string requestData = "SetOrderOccupiedPlaces";
                await writer.WriteLineAsync(requestData);
                requestData = id.ToString();
                await writer.WriteLineAsync(requestData);
                requestData = FirstOP.ToString();
                await writer.WriteLineAsync(requestData);
                requestData = LastOP.ToString();
                await writer.WriteLineAsync(requestData);
                string responseStr = await reader.ReadLineAsync();
                if (responseStr.Equals("success"))
                {
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }
    }
}
