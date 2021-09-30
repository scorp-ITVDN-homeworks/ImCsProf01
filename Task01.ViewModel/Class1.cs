using System;

namespace Task01.ViewModel
{
    using Model;
    using System.Collections.ObjectModel;
    using MVVMadds;
    using System.Windows;

    public class MonthesViewModel : ObservableObject
    {
        IMonthCollection monthes;

        public MonthesViewModel()
        {
            monthes = new MonthCollectionProvider();

            MonthNames = new ObservableCollection<string>();

            for(int i = 0; i<monthes.MonthesInYear; i++)
            {
                string monthName = monthes.GetMonthName(monthes.GetMonthByNumber(i+1));
                MonthNames.Add(monthName);
            }
        }

        private ObservableCollection<string> monthNames;
        public ObservableCollection<string> MonthNames
        {
            get { return monthNames; }
            set 
            { 
                monthNames = value;
                OnPropertyChanged(nameof(MonthNames));
            }
        }

        private string selectedMonthName = string.Empty;
        public string SelectedMonthName
        {
            get { return selectedMonthName; }
            set
            {
                selectedMonthName = value;                
                OnPropertyChanged(nameof(SelectedMonthName));
                SetOrderNumber(SelectedMonthName);
                SetTotalDays(SelectedMonthName);
            }
        }

        private void SetTotalDays(string monthName)
        {            
            int[] daysInMonth = monthes.GetMonthDays(monthes.GetMonthByName(monthName));
            if (daysInMonth.Length == 1) TotalDays = daysInMonth[0].ToString();
            else TotalDays = daysInMonth[0].ToString() + "-" + daysInMonth[1].ToString();
        }

        private void SetOrderNumber(string monthName)
        {
            int s = monthes.GetMonthNumber((monthes.GetMonthByName(monthName)));            
            MonthOrderNumber = s.ToString();
        }

        private string totalDays = string.Empty;
        public  string TotalDays
        {
            get { return totalDays; }
            set
            {
                totalDays = value;
                OnPropertyChanged(nameof(TotalDays));
            }
        }


        private string monthOrderNumber = string.Empty;
        public  string MonthOrderNumber
        {
            get { return monthOrderNumber; }
            set 
            {
                monthOrderNumber = value;
                OnPropertyChanged(nameof(MonthOrderNumber));                
            }
        }

    }
}
