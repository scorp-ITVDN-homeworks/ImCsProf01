using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ModelInterface;
using MVVMadds;

namespace Task02.ViewModel
{
    

    public partial class CitizensQueueVM : ObservableObject
    {
        private IOfficeQueue medQueue;

        public CitizensQueueVM(IOfficeQueue ctzQueue)
        {
            this.medQueue = ctzQueue;
        }

        private CitizenProvider citizen;
        public CitizenProvider Citizen
        {
            get { return citizen; }
            set
            {
                citizen = value;
                OnPropertyChanged(nameof(Citizen));
            }
        }

        private ObservableCollection<CitizenProvider> citizensQueue;
        public ObservableCollection<CitizenProvider> CitizensQueue
        {
            get { return citizensQueue; }
            set
            {
                citizensQueue = value;
                OnPropertyChanged(nameof(CitizensQueue));
            }
        }



        

        public int TestParameter
        {
            get { return 1; }
        }
    }
}
