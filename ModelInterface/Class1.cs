using System;

namespace ModelInterface
{
    /* здесь содержится интерфейс для взаимодействия 
     * Model и ViewModel для второго задания
     * 
     * А также класс для передачи Citizen из Model во ViewModel
     * - лучшего решения пока не нашёл
     */


    public interface IOfficeQueue
    {
        public object[] GetQueue();
        public object ServeCitizen();
               
        public object GetCitizen(int passportNumber);
        public object[] GetCitizen(string FirstName, string LastName);
        public object GetByQueueNumber(int queue);
        public object GetFirstCitizen();
        public object GetLastCitizen();

        public int GetQueueNumber(object citizen);

        public void AddCitizenAtQueue(object citizen);
        public bool NotEmpty();

        public CitizenProvider SerializeToCitizenProvider(object citizen);
    }

    public class CitizenProvider
    {
        public CitizenProvider(int passport, Status social)
        {
            SocialRole = social;
            PassportNumber = passport;
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

        public int PassportNumber
        {
            get;
            set;
        }

        public int Queue
        {
            get;
            set;
        }

        public Status SocialRole
        {
            get;
            set;
        }

        public enum Status
        {
            student,
            worker,
            retiree,
        }
    }
}
