using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Model
{
    // класс самый простой, без дополнительных методов типа Find, Contains, IndexOf
    public class MonthList : IEnumerator, IEnumerable
    {
        private Month[] monthes;

        public MonthList()
        {
            monthes = new Month[12];
            DefineMonthes();
        }

        public Month this[int index]
        {
            get
            {
                if((index > 11))
                {
                    index = 0;
                }
                return monthes[index];
            }
        }

        private void DefineMonthes()
        {
            monthes[0] = new Month("January",   1,  31);
            monthes[1] = new Month("Febryary",  2,  28) { IsDaysConst = false, AltDays = 29 } ;
            monthes[2] = new Month("March",     3,  31);
            monthes[3] = new Month("April",     4,  30);
            monthes[4] = new Month("May",       5,  31);
            monthes[5] = new Month("June",      6,  30);
            monthes[6] = new Month("July",      7,  31);
            monthes[7] = new Month("August",    8,  31);
            monthes[8] = new Month("September", 9,  30);
            monthes[9] = new Month("October",   10, 31);
            monthes[10] = new Month("November", 11, 30);
            monthes[11] = new Month("December", 12, 31);
        }
        
        public object Current
        {
            get { return monthes[position]; }
        }

        public int Count
        {
            get { return monthes.Length; }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        int position = -1;

        public bool MoveNext()
        {
            position++;
            if(position > monthes.Length - 1)
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

        public class Month
        {
            int days;
            int orderNumber;
            string name;
            bool isDaysConst;
            int altDays;

            public Month(string name, int orderNumber, int days )
            {
                this.days = days;
                altDays = days;
                this.orderNumber = orderNumber;
                this.name = name;
                isDaysConst = true;
            }

            public int Days
            {
                get { return days; }
                set { days = value; }
            }

            public int OrderNumber
            {
                get { return orderNumber; }
                set { orderNumber = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public bool IsDaysConst
            {
                get { return isDaysConst; }
                set { isDaysConst = value; }
            }

            public int AltDays
            {
                get { return altDays; }
                set { altDays = value; }
            }
        }
    }

    public interface IMonthCollection
    { 
        public MonthList.Month SelectedMonth { get; }

        public bool HasAlterDaysNumber();

        public bool HasAlterDaysNumber(object requestedMonth);

        public int[] GetMonthDays();

        public int[] GetMonthDays(object requestedMonth);

        public string GetMonthName();

        public string GetMonthName(object requestedMonth);

        public int GetMonthNumber();

        public int GetMonthNumber(object requestedMonth);

        public int[] GetDaysInMonth();

        public int[] GetDaysInMonth(object requestedMonth);

        public void SetMonth(string monthName);

        public void SetMonth(int monthNumber);

        public MonthList.Month GetMonthByName(string monthName);

        public MonthList.Month GetMonthByNumber(int number);

        public IList<MonthList.Month> GetMonthByLength(int monthLength);
    }

    public class MonthCollectionProvider : IMonthCollection
    {
        private MonthList monthList;

        public MonthCollectionProvider()
        {
            monthList = new MonthList();
            SelectedMonth = monthList[0];
        }

        public MonthList.Month SelectedMonth
        {
            get;
            private set;
        }     
        
        public bool HasAlterDaysNumber()
        {
            return !SelectedMonth.IsDaysConst;
        }

        public bool HasAlterDaysNumber(object requestedMonth)
        {
            if (requestedMonth is MonthList.Month)
            {
                return !((MonthList.Month)requestedMonth).IsDaysConst;
            }
            return false;
        }

        public int[] GetMonthDays()
        {
            return GetMonthDays(SelectedMonth);
        }

        public int[] GetMonthDays(object requestedMonth)
        {
            int[] days = new int[1];
            if (requestedMonth is MonthList.Month)
            {
                MonthList.Month month = (MonthList.Month)requestedMonth;

                if (month.IsDaysConst)
                {                    
                    days[0] = month.Days;
                }
                else
                {
                    days = new int[2];
                    days[0] = month.Days;
                    days[1] = month.AltDays;
                }
            }
            return days;
        }

        public string GetMonthName()
        {
            return SelectedMonth.Name;
        }

        public string GetMonthName(object requestedMonth)
        {
            string monthName = monthList[0].Name;
            if(requestedMonth is MonthList.Month)
            {
                monthName = ((MonthList.Month)requestedMonth).Name;
            }
            return monthName;
        }

        public int GetMonthNumber()
        {
            return SelectedMonth.OrderNumber;
        }

        public int GetMonthNumber(object requestedMonth)
        {
            int number = 1;
            if (requestedMonth is MonthList.Month)
            {
                number = ((MonthList.Month)requestedMonth).OrderNumber;
            }
            return number;
        }        

        public int[] GetDaysInMonth()
        {
            return GetDaysInMonth(SelectedMonth);
        }

        public int[] GetDaysInMonth(object requestedMonth)
        {
            int[] days = new int[1];
            MonthList.Month cast = (MonthList.Month)requestedMonth;

            foreach (MonthList.Month month in monthList)
            {
                if (month == requestedMonth)
                {
                    if (month.IsDaysConst)
                    {
                        days[0] = month.Days;
                    }
                    else
                    {
                        days = new int[2];
                        days[0] = month.Days;
                        days[1] = month.AltDays;
                    }
                }
            }
            return days;
        }

        public void SetMonth(string monthName)
        {
            foreach(MonthList.Month month in monthList)
            {
                if(month.Name == monthName)
                {
                    SelectedMonth = month;
                }
            }
        }

        public void SetMonth(int monthNumber)
        {
            if(monthNumber > 12 || monthNumber < 1)
            {
                return;
            }
            else
            {
                SelectedMonth = monthList[monthNumber - 1];
            }
        }

        public MonthList.Month GetMonthByName(string monthName)
        {
            foreach (MonthList.Month month in monthList)
            {
                if (month.Name == monthName)
                {
                    return month;
                }
            }
            return monthList[0];
        }
        
        public MonthList.Month GetMonthByNumber(int number)
        {            
            foreach (MonthList.Month month in monthList)
            {
                if (month.OrderNumber == number)
                {
                    return month;
                }
            }
            return monthList[0];
        }

        public IList<MonthList.Month> GetMonthByLength(int monthLength)
        {
            List<MonthList.Month> monthes = new List<MonthList.Month>();
            foreach (MonthList.Month month in monthList)
            {
                if (month.Days == monthLength || month.AltDays == monthLength)
                {
                    monthes.Add(month);
                }
            }
            return monthes;
        }
    }
}
