//using System;
//using System.Threading.Tasks;
//using AsynchronousClient;
//using Communication;

//namespace ClientProcess
//{
//    class Process
//    {
//        public Process() { }
//        public void ReadAndWrite()
//        {
//            Console.Write("Név: ");
//            string sender = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Üzenet: ");
//            string data = Console.ReadLine();
//            Console.WriteLine();
//            while (data != "Bye" || sender != "Bye")
//            {
                

//                CommObject commObject = new CommObject(sender,data);

//                Task<CommObject> tsResponse = SocketClient.SendRequest(commObject);
//                Console.WriteLine("Üzenet továbbítva a szerverre, kérem várjon!");
//                CommObject dResponse = tsResponse.Result;
//                Console.WriteLine(dResponse);
//                Console.WriteLine("------------------------------------------------------------------------------------");
//                Console.Write("Név: ");
//                sender = Console.ReadLine();
//                Console.WriteLine();
//                Console.Write("Üzenet: ");
//                data = Console.ReadLine();
//                Console.WriteLine();
//            }
//        }
//    }
//}
