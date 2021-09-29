using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Model
{
    public class MonthList : IEnumerator, IEnumerable
    {
        private Month[] monthes;

        public MonthList()
        {
            monthes = new Month[12];
        }

        private void DefineMonthes()
        {
            monthes[0] = new Month("January",   1,  31);
            monthes[1] = new Month("Febryary",  2,  28) { IsDaysConst = true, AltDays = 29 } ;
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
        
        public object Current => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public struct Month
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
}
