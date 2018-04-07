using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //Ebből származik a Customer és a Dispatcher
    public class User
    {
        private static int currentID;
        protected string Name;
        protected int ID;

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

