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
            SetStatusComboBox();
            AddSomePerson();
            SetQueue();
        }

        private void AddSomePerson()
        {
            CitizenProvider ctzOne = new CitizenProvider(999888, CitizenProvider.Status.student) { FirstName = "Paul", LastName = "Atreides" };
            CitizenProvider ctzTwo = new CitizenProvider(888999, CitizenProvider.Status.worker) { FirstName = "Duncan", LastName = "Idaho" };
            CitizenProvider ctzThree = new CitizenProvider(100500, CitizenProvider.Status.retiree) { FirstName = "Leto", LastName = "Atreides" };

            medQueue.AddCitizenAtQueue(ctzOne);
            medQueue.AddCitizenAtQueue(ctzTwo);
            medQueue.AddCitizenAtQueue(ctzThree);
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

        private ObservableCollection<CitizenProvider> citizensQueue = new ObservableCollection<CitizenProvider>();
        public ObservableCollection<CitizenProvider> CitizensQueue
        {
            get { return citizensQueue; }
            set
            {
                citizensQueue = value;
                OnPropertyChanged(nameof(CitizensQueue));
            }
        }

        #region INPUT FIELDS

        private string inputFirstName = String.Empty;
        public string InputFirstName
        {
            get { return inputFirstName; }
            set
            {
                inputFirstName = value;
                OnPropertyChanged(nameof(InputFirstName));
            }
        }

        private string inputSecondName = String.Empty;
        public string InputSecondName
        {
            get { return inputSecondName; }
            set
            {
                inputSecondName = value;
                OnPropertyChanged(nameof(InputSecondName));
            }
        }

        private ObservableCollection<string> inputStatusBox = new ObservableCollection<string>();
        public ObservableCollection<string> InputStatusBox
        {
            get { return inputStatusBox; }
            set
            {
                inputStatusBox = value;
                OnPropertyChanged(nameof(InputStatusBox));
            }
        }

        private void SetStatusComboBox()
        {
            foreach(var status in Enum.GetNames(typeof(CitizenProvider.Status)))
            {
                InputStatusBox.Add(status);
            }
        }

        private string inputCitizenStatus = String.Empty;
        public string InputCitizenStatus
        {
            get { return inputCitizenStatus; }
            set
            {
                inputCitizenStatus = value;
                OnPropertyChanged(nameof(InputCitizenStatus));
            }
        }

        private int inputPassportNumber;
        public int InputPassportNumber
        {
            get { return inputPassportNumber; }
            set
            {
                inputPassportNumber = value;
                OnPropertyChanged(nameof(InputPassportNumber));
            }
        }

        #endregion

        #region VIEW CITIZEN INFO

        private CitizenProvider selectedCititzen;
        public CitizenProvider SelectedCitizen
        {
            get { return selectedCititzen; }
            set
            {
                selectedCititzen = value;
                OnPropertyChanged(nameof(SelectedCitizen));
                if(selectedCititzen != null)
                {
                    SelectedFirstName = selectedCititzen.FirstName;
                    SelectedLastName = selectedCititzen.LastName;
                    SelectedPassportNumber = selectedCititzen.PassportNumber;
                    SelectedQueueNumber = selectedCititzen.Queue;
                    SelectedCitizenStatus = selectedCititzen.SocialRole.ToString();
                }
                else
                {
                    SelectedFirstName = "-";
                    SelectedLastName = "-";
                    SelectedPassportNumber = 0;
                    SelectedQueueNumber = 0;
                    SelectedCitizenStatus = "-";
                }
            }
        }

        private string selectedFirstName = String.Empty;
        public string SelectedFirstName
        {
            get { return selectedFirstName; }
            set
            {
                selectedFirstName = value;
                OnPropertyChanged(nameof(SelectedFirstName));
            }
        }

        private string selectedLastName = String.Empty;
        public string SelectedLastName
        {
            get { return selectedLastName; }
            set
            {
                selectedLastName = value;
                OnPropertyChanged(nameof(SelectedLastName));
            }
        }

        private string selectedCitizenStatus = String.Empty;
        public string SelectedCitizenStatus
        {
            get { return selectedCitizenStatus; }
            set
            {
                selectedCitizenStatus = value;
                OnPropertyChanged(nameof(SelectedCitizenStatus));
            }
        }

        private int selectedPassportNumber;
        public int SelectedPassportNumber
        {
            get { return selectedPassportNumber; }
            set
            {
                selectedPassportNumber = value;
                OnPropertyChanged(nameof(SelectedPassportNumber));
            }
        }

        private int selectedQueueNumber;
        public int SelectedQueueNumber
        {
            get { return selectedQueueNumber; }
            set
            {
                selectedQueueNumber = value;
                OnPropertyChanged(nameof(SelectedQueueNumber));
            }
        }

        #endregion

    }
}
