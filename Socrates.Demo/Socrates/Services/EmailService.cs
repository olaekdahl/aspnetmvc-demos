using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Socrates.Services
{
    public interface IEmail
    {
        void SendEmail(string msg);
    }
    public class Email : IEmail
    {
        public void SendEmail(string msg)
        {
            Debug.Write($"message sent: {msg}");
        }
    }


    public class ProductionEmail : IEmail
    {
        public void SendEmail(string msg)
        {
            Debug.Write($"message sent from production: {msg}");
        }
    }


    public interface IAnimal
    {
        void noise();
        
    }

    public class Bird : IAnimal
    {
        public void noise()
        {
            Debug.Write("chirp");
        }
    }
    public class Cat : IAnimal
    {
        public void noise()
        {
            Debug.Write("meow");
        }
    }


    public class Demo
    {
        public void foo()
        {
            Bird b = new Bird();
            Cat c = new Cat();

            List<IAnimal> animals = new List<IAnimal>();

            animals.Add(b);
            animals.Add(c);

            foreach (var animal in animals)
            {
                animal.noise();
            }

        }
    }


}