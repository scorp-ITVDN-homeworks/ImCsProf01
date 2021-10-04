using System;

namespace ModelInterface
{
    public interface IOfficeQueue
    {
        public CitizenProvider[] GetQueue();
        public CitizenProvider ServeCitizen();

        public CitizenProvider GetCitizen(int passportNumber);
        public CitizenProvider[] GetCitizen(string FirstName, string LastName);
        public CitizenProvider GetByQueueNumber(int queue);
        public CitizenProvider GetFirstCitizen();
        public CitizenProvider GetLastCitizen();

        public int GetQueueNumber(object citizen);

        public void AddCitizenAtQueue(CitizenProvider citizen);
        public bool NotEmpty();
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
