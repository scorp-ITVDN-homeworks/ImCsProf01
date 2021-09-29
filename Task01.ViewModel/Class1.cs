using System;

namespace Task01.ViewModel
{
    using Model;

    public class MonthesViewModel
    {
        IMonthCollection monthCollection;

        public MonthesViewModel()
        {
            monthCollection = new MonthCollectionProvider();
        }
    }
}
