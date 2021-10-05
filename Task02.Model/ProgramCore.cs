using System;


namespace Task02.Model
{
    using ModelInterface;

    /* имеется класс для доступа к источнику данных - здесь это пользовательская коллекция
     * класс унаследован от специального интерфейса для
     * работы с ViewModel
     */
    public class ProgramCore : IOfficeQueue
    {
        IPatientsQueue queue;

        public ProgramCore()
        {
            queue = new PatientsQueue();
        }

        public void AddCitizenAtQueue(object citizen)
        {            
            queue.Add(CreateNewCitizen((CitizenProvider)citizen));
        }

        public object GetByQueueNumber(int queueNumber)
        {
            foreach(Citizen citizen in queue)
            {
                if (citizen.QueueNumber == queueNumber)
                {
                    return citizen;
                }
            }
            return null;
        }

        public object GetCitizen(int passportNumber)
        {
            foreach (Citizen citizen in queue)
            {
                if (citizen.PassportNumber == passportNumber)
                {
                    return citizen;
                }
            }
            return null;
        }

        public object[] GetCitizen(string FirstName, string LastName)
        {
            throw new NotImplementedException();
        }

        public object GetFirstCitizen()
        {
            return queue.ReturnFirst();
        }

        public object GetLastCitizen()
        {
            return queue.ReturnLast();
        }

        public object[] GetQueue()
        {
            Citizen[] citizensArray = new Citizen[] { };

            foreach(Citizen citizen in queue)
            {               
                Array.Resize<Citizen>(ref citizensArray, citizensArray.Length + 1);
                citizensArray[citizensArray.Length - 1] = citizen;
            }
            return citizensArray;
        }

        public int GetQueueNumber(object citizen)
        {
            queue.ResetQueueNumbers();
            Citizen ctz = (Citizen)citizen;
            return ctz.QueueNumber;
        }

        // не успел реализовать да это и не нужно
        public bool NotEmpty()
        {
            if (queue.Count == 0) return false;
            return true;
        }

        /* упаковка над методом по обслуживанию пациента
         * что именно делает данный метод см. в классе коллекции
         */
        public object ServeCitizen()
        {            
            return queue.ServePatient();
        }

        /* перевод в Citizen в CitizenProvider - класс, представляющий Citizen во ViewModel
         * Пока что я вижу, что во ViewModel нужен собственный класс
         * для отображения Citizen, и я пока не знаю каким образом это сделать лучше
         * чтобы в модели этот класс не светился. Возможно, следует сам класс Citizen и его свойства
         * пометить специальным атрибутом,
         * который будет читаться во viewModel
         */
        public CitizenProvider SerializeToCitizenProvider(object citizen)
        {
            Citizen castedCitizen = (Citizen)citizen;
            CitizenProvider.Status status = (CitizenProvider.Status)Enum.Parse(typeof(CitizenProvider.Status), castedCitizen.GetType().Name.ToLower());
            CitizenProvider ctProv = new CitizenProvider(castedCitizen.PassportNumber, status);
            ctProv.FirstName = castedCitizen.FirstName;
            ctProv.LastName = castedCitizen.LastName;
            ctProv.PassportNumber = castedCitizen.PassportNumber;
            ctProv.Queue = castedCitizen.QueueNumber;

            return ctProv;
        }

        /* создание нового экземпляра абстратного класса Citizen
         * на основе экземпляра типа CititzenProvider
         */
        public object CreateNewCitizen(CitizenProvider provider)
        {
            Citizen citizen = null;

            if (provider.SocialRole.ToString() == "student") citizen = new Student(provider.PassportNumber);
            if (provider.SocialRole.ToString() == "worker") citizen = new Worker(provider.PassportNumber);
            if (provider.SocialRole.ToString() == "retiree") citizen = new Retiree(provider.PassportNumber);

            citizen.FirstName = provider.FirstName;
            citizen.LastName = provider.LastName;

            return citizen;
        }
    }
}
