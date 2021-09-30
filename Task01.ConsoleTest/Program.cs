using System;
using System.Collections;
//using Task01.Model;

namespace Task01.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable listOfMonthes = new MonthList();
            //foreach(var item in listOfMonthes)
            //{
            //    MonthList.Month month = (MonthList.Month)item;
            //    string altDays = month.IsDaysConst ? "" : "-" + month.AltDays.ToString();
            //    Console.WriteLine($"{month.Name} - {month.Days}{altDays} - {month.OrderNumber}");
            //}
            //Console.ReadKey();
            Task01.Model.IMonthCollection monthCollection = new Model.MonthCollectionProvider();
            monthCollection.SetMonth(2);
            Console.WriteLine(monthCollection.SelectedMonth.Name);
            for(int i = 0; i < monthCollection.GetMonthDays().Length; i++)
            {
                if (i > 0)
                {
                    Console.Write("-");
                }
                Console.Write(monthCollection.GetMonthDays()[i]);
            }
            Console.ReadKey();

            int monthNumber = monthCollection.GetMonthNumber(monthCollection.GetMonthByName("June"));
            Console.WriteLine(monthNumber.ToString());

            Console.ReadKey();
        }
    }
}
