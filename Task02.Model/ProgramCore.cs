using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task02.Model
{
    using ModelInterface;

    public class ProgramCore : IOfficeQueue
    {
        public void AddCitizenAtQueue(CitizenProvider citizen)
        {
            throw new NotImplementedException();
        }

        public CitizenProvider GetByQueueNumber(int queue)
        {
            throw new NotImplementedException();
        }

        public CitizenProvider GetCitizen(int passportNumber)
        {
            throw new NotImplementedException();
        }

        public CitizenProvider[] GetCitizen(string FirstName, string LastName)
        {
            throw new NotImplementedException();
        }

        public CitizenProvider GetFirstCitizen()
        {
            throw new NotImplementedException();
        }

        public CitizenProvider GetLastCitizen()
        {
            throw new NotImplementedException();
        }

        public CitizenProvider[] GetQueue()
        {
            throw new NotImplementedException();
        }

        public int GetQueueNumber(object citizen)
        {
            throw new NotImplementedException();
        }

        public bool NotEmpty()
        {
            throw new NotImplementedException();
        }

        public CitizenProvider ServeCitizen()
        {
            throw new NotImplementedException();
        }
    }
}
