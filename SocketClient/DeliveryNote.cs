using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeliveryNote
    {
        private static int currentID { get; set; }
        public bool success { get; set; }
        public int foremanid { get; set; }
        public int orderid { get; set; }
        public int ID { get; set; }

        public DeliveryNote(int id, bool success, int foremanid, int orderid)
        {
            ID = id;
            this.success = success;
            this.foremanid = foremanid;
            this.orderid = orderid;
    }

        protected int getNextID()
        {
            return ++currentID;
        }

    public DeliveryNote() { }

    public DeliveryNote(bool success, int foremanid, int orderid)
    {
        this.success = success;
        this.foremanid = foremanid;
        this.orderid = orderid;
    }

    public void Print()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("MegrendelesID: " + orderid);
        Console.WriteLine("MuszakvezetoID: " + foremanid);
        if (success)
        {
            Console.WriteLine("Teljesített");
        }
        else
        {
            Console.WriteLine("Még nem teljesített");
        }
        Console.WriteLine("-------------------------------");
    }

 }
