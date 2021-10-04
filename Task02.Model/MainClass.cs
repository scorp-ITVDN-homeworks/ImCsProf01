using System;
using System.Collections;

namespace Task02.Model
{
    public abstract class Citizen
    {
        public Citizen(int passportNumber)
        {
            PassportNumber = passportNumber;
        }

        public int PassportNumber
        {
            get;
            private set;
        }        

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public int QueueNumber
        {
            get;
            internal set;
        }

        public override bool Equals(object obj)
        {
            Citizen objectToEquate = (Citizen)obj;
            if (objectToEquate.PassportNumber == PassportNumber) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return PassportNumber;
        }
    }

    public class Student : Citizen
    {
        public Student(int passportNumber) : base(passportNumber)
        {

        }
    }

    public class Worker : Citizen
    {
        public Worker(int passportNumber) : base(passportNumber)
        {
            
        }
    }

    public class Retiree : Citizen
    {
        public Retiree(int passportNumber) : base(passportNumber)
        {

        }
    }    
}
