using MVVMadds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelInterface;
using System.Collections.ObjectModel;
using System.Windows;

namespace Task02.ViewModel
{
    public partial class CitizensQueueVM : ObservableObject
    {
        RelayCommand _addCitizen;
        public ICommand CmdAddCitizen
        {
            get
            {
                if (_addCitizen == null)
                {
                    _addCitizen =
                        new RelayCommand(AddCitizenExec, AddCitizenCanExec);
                }
                return _addCitizen;
            }
        }
        public void AddCitizenExec(object parameter)
        {
            MessageBox.Show("Something happens");
            CitizenProvider.Status status = (CitizenProvider.Status)Enum.Parse(typeof(CitizenProvider.Status), InputCitizenStatus);
            CitizenProvider citizen = new CitizenProvider(InputPassportNumber, status) { FirstName = InputFirstName, LastName = InputSecondName };
            medQueue.AddCitizenAtQueue(citizen);
            SetQueue();

            InputPassportNumber = 0;
            InputFirstName = String.Empty;
            InputSecondName = String.Empty;
            
        }

        public bool AddCitizenCanExec(object parameter)
        {
            return true;
        }

        private void SetQueue()
        {            
            CitizensQueue.Clear();
            foreach (var item in medQueue.GetQueue())
            {
                CitizensQueue.Add(medQueue.SerializeToCitizenProvider(item));
            }
        }
    }
}
