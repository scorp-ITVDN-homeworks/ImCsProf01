using ModelInterface;
using MVVMadds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task02.ViewModel
{
    public partial class CitizensQueueVM : ObservableObject
    {
        RelayCommand _serveCitizen;
        public ICommand CmdServeCitizen
        {
            get
            {
                if (_serveCitizen == null)
                {
                    _serveCitizen =
                        new RelayCommand(ServeCitizenExec, ServeCitizenCanExec);
                }
                return _serveCitizen;
            }
        }
        public void ServeCitizenExec(object parameter)
        {
            CitizenProvider servingCitizen = medQueue.SerializeToCitizenProvider(medQueue.ServeCitizen());

            if (SelectedCitizen != null && SelectedCitizen.PassportNumber == servingCitizen.PassportNumber)
            {
                SelectedCitizen = null;
            }


            SetQueue();
        }
        public bool ServeCitizenCanExec(object parameter)
        {
            return true;
        }
    }
}
