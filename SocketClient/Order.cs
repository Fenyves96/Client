using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Communication
{
    [Serializable]
    public class Order
    {
        //másoló konstuktor, még szükség lehet rá
        public Order(Order previousOrder)
        {
            CustomerID = previousOrder.CustomerID;
            ID = previousOrder.ID;
            DateIn = previousOrder.DateIn;
            DateOut = previousOrder.DateOut;
            PalletQuantity = previousOrder.PalletQuantity;
            Cooled = previousOrder.Cooled;
            Comment = previousOrder.Comment;
            OrderTime = previousOrder.OrderTime;
            DispatcherID = previousOrder.DispatcherID;
            Terminal = previousOrder.Terminal;
        }
        public static int NextID = 0;
        /// <summary>
        //új kód
        
        public int FirstOccupiedPlace { get; set; }
        public int LastOccupiedPlace { get; set; }

        public string GetOccupiedPlaces()
        {
            string occupiedPlaces="";

            
            for(int i = FirstOccupiedPlace; i < LastOccupiedPlace; i++)
            {
                
                if (Cooled)
                {
                    
                    occupiedPlaces += "H";
                    if (i < 10)
                    {
                        occupiedPlaces += "00" + i.ToString();
                    }
                    else if (i < 100)
                    {
                        occupiedPlaces += "0" + i.ToString();
                    }
                    else if (i < 1000)
                    {
                        occupiedPlaces += "" + i.ToString();
                    }

                    occupiedPlaces += "\n";
                }
                else
                {
                    occupiedPlaces += "S";
                    if (i < 10)
                    {
                        occupiedPlaces += "00" + i.ToString();
                    }
                    else if (i < 100)
                    {
                        occupiedPlaces += "0" + i.ToString();
                    }
                    else if (i < 1000)
                    {
                        occupiedPlaces += i.ToString();
                    }
                    occupiedPlaces += "\n";
                }
            }


            return occupiedPlaces;
        }

        /// </summary>
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateIn
        {
            get { return dateIn; }
            set { dateIn = value.ToLocalTime(); }
        }
        public DateTime dateIn;
        public DateTime DateOut
        {
            get { return dateOut; }
            set { dateOut = value.ToLocalTime(); }
        }
        public DateTime dateOut;
        public int PalletQuantity { get; set; }
        public bool Cooled { get; set; }
        public bool Confirmed { get; set; }
        public int Terminal { get; set; }
        public DateTime OrderTime { get; set; } //Mikor lett leadva a megrendelés
        public int DispatcherID { get; set; } //Ki dolgozta fel a megrendelést?


        public string Comment;

        public Order() { NextID++; ID = NextID; }

        public Order(int customerID, string dateIn, string dateOut, int productQuantity, bool cooled, string comment = "")
        {
            NextID++;
            ID = NextID;
            this.dateIn = DateTime.Parse(dateIn);
            DateOut = DateTime.Parse(dateOut);
            PalletQuantity = productQuantity;
            Cooled = cooled;
            Comment = comment;
            OrderTime = DateTime.Now;
            DispatcherID = 0;
            Terminal = 0;
            CustomerID = customerID;

        }

        public Order(int OrderID, int customerID, string dateIn, string dateOut, int productQuantity, bool cooled, string comment = "")
        {
            ID = OrderID;
            this.dateIn = DateTime.Parse(dateIn);
            DateOut = DateTime.Parse(dateOut);
            PalletQuantity = productQuantity;
            Cooled = cooled;
            Comment = comment;
            OrderTime = DateTime.Now;
            DispatcherID = 0;
            Terminal = 0;
            CustomerID = customerID;

        }
        //változott
        public void Print()
        {

            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Tervezett beérkezés: " + DateIn.ToShortDateString());
            Console.WriteLine("Tervezett kivitel: " + DateOut.ToShortDateString());
            Console.WriteLine("Megrendelés leadva: " + OrderTime.ToString());
            Console.WriteLine("Mennyiség: " + PalletQuantity);
            if (Comment != "")
                Console.WriteLine("Megjegyzés: " + Comment);
            if (Cooled)
                Console.WriteLine("Hűtött: igen");
            else
                Console.WriteLine("Hűtött:nem");
            if (Confirmed)
                Console.WriteLine("Jóváhagyott: igen ");
            else
                Console.WriteLine("Jóváhagyott: nem ");
            if (Terminal != 0)
            {
                Console.WriteLine("Kocsiszín: " + Terminal);
            }
            Console.WriteLine();
            if(FirstOccupiedPlace >0 && LastOccupiedPlace > 0)
            {
                if(Cooled)
                Console.WriteLine("H"+FirstOccupiedPlace + ":H" + LastOccupiedPlace);
                else
                Console.WriteLine("S" + FirstOccupiedPlace + ":S" + LastOccupiedPlace);
            }
            Console.WriteLine();

        }

        public override bool Equals(Object o)
        {
            try
            {
                Order order = (Order)o;
                if (order.ID == ID)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override string ToString()
        {
            return ID.ToString();
        }

    }
}