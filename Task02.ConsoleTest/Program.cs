using System;
using Task02.Model;

namespace Task02.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestArrayCopyResize();
            TestMedicalQueue();
            
            Console.ReadKey();
        }

        public static void TestArrayCopyResize()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            //numbers = new int[] { 1, 2, 3 };
            //numbers = new int[] { 1, 2 };
            int index = 2;
            int num = 3;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine("remove------------------");

            Array.Copy(numbers, index + 1, numbers, index, numbers.Length - index - 1);
            Array.Resize(ref numbers, numbers.Length - 1);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine("add---------------------");

            Array.Resize(ref numbers, numbers.Length + 1);
            Array.Copy(numbers, index, numbers, index + 1, numbers.Length - index - 1);
            numbers[index] = num;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine("------------------------");
            Console.ReadKey();
        }

        public static void TestMedicalQueue()
        {
            IPatientsQueue queue = new PatientsQueue();
            queue.Add(new Student(111666) { FirstName = "Андрей", LastName = "Тарковский" });
            queue.Add(new Retiree(777888) { FirstName = "Владимир", LastName = "Маяковский" });
            queue.Add(new Worker(666111) { FirstName = "Георгий", LastName = "Данелия" });
            queue.Add(new Retiree(888777) { FirstName = "Владимир", LastName = "Набоков" });
            queue.Add(new Retiree(777888) { FirstName = "Какой-то", LastName = "Самозванец" });

            //Console.WriteLine(queue.Count);

            foreach(Citizen citizen in queue)
            {
                Console.WriteLine($"{citizen.FirstName} {citizen.LastName} - {citizen.QueueNumber}");
            }

            Console.WriteLine("------------------------------");

            queue.ServePatient();

            foreach (Citizen citizen in queue)
            {
                Console.WriteLine($"{citizen.FirstName} {citizen.LastName} - {citizen.QueueNumber}");
            }

        }
    }
}
