using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Model
{
    public class PatientsQueue : ICollection, IList, IEnumerable, IEnumerator, IPatientsQueue
    {
        public PatientsQueue()
        {
            peopleInQueue = new Citizen[] { };
            IsFixedSize = false;
            IsReadOnly = false;
        }

        // remember StringBuilder
        private Citizen[] peopleInQueue;

        #region IEnumerator

        public object Current
        {
            get { return peopleInQueue[position]; }
        }

        private int position = -1;

        public bool MoveNext()
        {
            position++;
            if (position == Count)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            position = -1;
        }

        #endregion

        #region IList

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();                
                if (Count == 0) throw new ArgumentOutOfRangeException();
                return peopleInQueue[index];
            }
            set {; }
        }

        public bool IsFixedSize
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get;
            private set;
        }

        public int Count
        {
            get { return peopleInQueue.Length; }
        }

        public bool IsSynchronized
        {
            get;
            set;
        }

        private object syncObject = new object();

        public object SyncRoot
        {
            get { return syncObject; }
        }

        public int Add(object value)
        {
            if (!(value is Citizen) || Contains(value)) return -1;
            if (value is Retiree)
            {
                Insert(Count, value);
            }
            else
            {
                
                Array.Resize(ref peopleInQueue, Count + 1);
                peopleInQueue[Count - 1] = value as Citizen;
            }
            ResetQueueNumbers();
            return IndexOf(value) + 1;
        }

        public void Clear()
        {
            peopleInQueue = Array.Empty<Citizen>();
        }

        public bool Contains(object value)
        {
            if (value is Citizen && Count > 0)
            {
                Citizen citizen = (Citizen)value;
                return Array.Exists<Citizen>(peopleInQueue, (citizenInQueue) => { return citizen.Equals(citizenInQueue); });
            }
            return false;
        }

        // данный может нарушить очередь пенсионеров
        public void CopyTo(Array array, int index)
        {            
            if (index >= Count || index < 0) throw new ArgumentOutOfRangeException();
            if (index + array.Length > Count) throw new IndexOutOfRangeException();
            if (!(array is Citizen[])) throw new ArgumentException();
            Array.Copy(array, 0, peopleInQueue, index, array.Length);
            ResetQueueNumbers();
        }

        // этот метод может нарушить очередь пенсионеров 
        public void Extend(Array array, int index)
        {
            if (!(array is Citizen[])) throw new ArgumentException();
            if (index >= Count || index < 0) throw new ArgumentOutOfRangeException();
            Array.Resize(ref peopleInQueue, Count + array.Length);
            int len = Count - index - 1;
            Array.Copy(peopleInQueue, index, peopleInQueue, index + array.Length, len);
            ResetQueueNumbers();
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        public int IndexOf(object value)
        {
            if (value is Citizen && Count > 0)
            {
                if (Contains(value))
                {
                    Citizen citizen = (Citizen)value;
                    return Array.IndexOf<Citizen>(peopleInQueue, citizen);
                }
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if (!(value is Citizen) || Contains(value) ) return;
            if (index > Count || index < 0) throw new ArgumentOutOfRangeException();
            if (value is Retiree)
            {
                if(Array.Exists(peopleInQueue,(item) => { return item is Retiree; }))
                index = Array.FindLastIndex(peopleInQueue, (item) => { return (item is Retiree); }) + 1;
                else
                {
                    index = 0;
                }
            }
            Array.Resize<Citizen>(ref peopleInQueue, Count + 1);
            Array.Copy(peopleInQueue, index, peopleInQueue, index + 1, Count - index - 1);
            peopleInQueue[index] = value as Citizen;
            ResetQueueNumbers();
        }

        public void Remove(object value)
        {
            if(Contains(value))
            peopleInQueue = Array.FindAll<Citizen>(peopleInQueue, (item) => { return (item != value); });
            ResetQueueNumbers();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
            if(index == Count - 1)
            {
                Array.Resize(ref peopleInQueue, Count - 1);
                return;
            }
            if(index > -1 || index < Count)
            {
                Array.Copy(peopleInQueue, index + 1, peopleInQueue, index, Count - index - 1);
                Array.Resize<Citizen>(ref peopleInQueue, Count - 1);
            }
            ResetQueueNumbers();
        }

        public object ServePatient()
        {
            Citizen firstPatient = null;
            if (Count > 0)
            {
                firstPatient = peopleInQueue[0];
                RemoveAt(0);
            }
            return firstPatient;
        }

        public int GetNumberInQueue(object value)
        {            
            return (value as Citizen).QueueNumber;
        }

        public void ResetQueueNumbers()
        {
            int counter = 1;
            foreach(Citizen citizen in this)
            {
                citizen.QueueNumber = counter++;
            }
        }

        public object ReturnFirst()
        {
            return peopleInQueue[0];
        }

        public object ReturnLast()
        {
            return peopleInQueue[Count - 1];
        }

        #endregion
    }

    public interface IPatientsQueue : IEnumerable, IEnumerator // нужно чтобы можно было пройтись foreach
    {
        object? this[int index] { get; set; }

        // дублирование сигнатур из других интерфейсов
        public int  Add(object value);
        public bool Contains(object value);
        public void Clear();

        // специализированные методы коллекции
        public object ServePatient();
        public int  GetNumberInQueue(object value);

        public object ReturnFirst();
        public object ReturnLast();

        public void ResetQueueNumbers();
    }
}
