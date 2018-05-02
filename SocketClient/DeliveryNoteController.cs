using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsynchronousClient;
using Communication;
using System.Xml.Serialization;

public class DeliveryNoteController
    {
        public static void MakeSomeDeliveryNote()
        {
            DeliveryNote dn1 = new DeliveryNote(1, false, 1, 2);
            Storage.deliverynotes.Add(dn1);
        }

        internal static void setDeliveryNotes(List<DeliveryNote> deliverynotes)
        {
            Storage.deliverynotes = deliverynotes;
        }

        public static void AddDeliveryNote(bool success, int foremanid, int orderid)
        {

            int ID = GetNextID();
            DeliveryNote deliverynote = new DeliveryNote(ID, success, foremanid, orderid);
            Storage.deliverynotes.Add(deliverynote);
            Task<DeliveryNote> tsResponse = SocketClient.SendDeliveryNote(deliverynote);
            // Console.WriteLine("Üzenet továbbítva a szerverre, kérem várjon!");
            DeliveryNote dResponse = tsResponse.Result;
            //Console.WriteLine(dResponse);
            // Console.WriteLine("------------------------------------------------------------------------------------");

        }

        public static void ListDeliveryNotes()
        {
            try
            {
                foreach (DeliveryNote dn in Storage.deliverynotes)
                {
                    dn.Print();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Üres a lista");
            }
            
        }

        public static void EditDeliveryNote(int value)
        {
            Console.WriteLine("1 - Sikeresre állítani");
            Console.WriteLine("2 - Rendelés száma");
            int response = Convert.ToInt32(Console.ReadLine());
        if (response == 1)
        {
            Storage.deliverynotes.Find(x => x.ID == value).success = true;
            Console.WriteLine("A szállítólevél sikeresre állítva!");

        }
        else if (response == 2)
        {
            Console.WriteLine("Írjon be egy új rendelés számot!");
            int neworderid = Convert.ToInt32(Console.ReadLine());
            Storage.deliverynotes.Find(x => x.ID == value).orderid = neworderid;
            Console.WriteLine("Rendelés szám módosítva!");
        }
        else Console.WriteLine("Nincs ilyen menüpont!");
    }

    private static int GetNextID()
    {
        return (Storage.deliverynotes.Count() + 1);
    }
}
