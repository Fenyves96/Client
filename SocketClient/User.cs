using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //Ebből származik a Customer, a Dispatcher és a Foreman
    public class User
    {
        private static int currentID;
        public string Name { get; set; }
        public int ID { get; set; }

        public User() { }

        public User(string Name)
        {
            ID = getNextID();
            this.Name = Name;
        }

        protected int getNextID()
        {
            return ++currentID;
        }


    }

