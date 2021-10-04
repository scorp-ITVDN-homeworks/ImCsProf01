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
        RelayCommand _addCitizen;
        public ICommand CmdAddCitizen
        {
            get
            {
                if (_serveCitizen == null)
                {
                    _serveCitizen =
                        new RelayCommand(AddCitizenExec, AddCitizenCanExec);
                }
                return _serveCitizen;
            }
        }
        public void AddCitizenExec(object parameter)
        {
            //parameter - это аргумент, передаваемый через CommandParameter
            //MessageBox.Show(parameter.GetType().ToString());
        }
        public bool AddCitizenCanExec(object parameter)
        {
            return true;
        }
    }
}
