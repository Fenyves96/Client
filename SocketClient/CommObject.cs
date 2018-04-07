using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Communication
{
    //ezt nem hasznájuk már, de mutatja, hogy hogy kell kinéznie egy osztálynak, 
    //ahhoz, hogy el lehessen küldeni a servernek
    //fontos kikötés: 
    //-[Serializable] az osztály deklaráció előtt
    //-Üres konstruktor
    //-Minden attribútumnak legyen settere, mivel a szerver oldalon az üres konstruktor hívódik meg
    //a deserializálás során és ezt követően a setterek
    
    [Serializable]
    public class CommObject
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public CommObject() { }

        public CommObject(string msg)
        {
            this.Message = msg;
            this.Date = DateTime.Now;
        }
        public CommObject(string sender, string msg)
        {
            this.Sender = sender;
            this.Message = msg;
            this.Date = DateTime.Now;
        }

        public override string ToString()
        {
            return Sender+" "+Message;
        }
    }
}
