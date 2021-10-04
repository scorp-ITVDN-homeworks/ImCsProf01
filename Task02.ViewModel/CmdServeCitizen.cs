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
            //parameter - это аргумент, передаваемый через CommandParameter
            //MessageBox.Show(parameter.GetType().ToString());
        }
        public bool ServeCitizenCanExec(object parameter)
        {
            return true;
        }
    }
}
