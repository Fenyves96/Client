using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeliveryNote
    {
        private static int currentID;
        public bool success;
        public int foremanid;
        public int orderid;
        public int ID { get; set; }

        public DeliveryNote(int id, bool success, int foremanid, int orderid)
        {
            id = getNextID();
            this.success = success;
            this.foremanid = foremanid;
            this.orderid = orderid;
    }

        protected int getNextID()
        {
            return ++currentID;
        }

    public void Print()
    {

    }

    }
