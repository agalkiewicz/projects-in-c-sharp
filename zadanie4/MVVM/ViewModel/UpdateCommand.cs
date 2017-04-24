using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    class UpdateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private DataService _ds;

        public UpdateCommand(DataService ds)
        {
            _ds = ds;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VendorViewModel _vendor = parameter as VendorViewModel;
            if (_vendor == null) return;
            _vendor.SaveChanges();
            _ds.Submit();
        }
    }
}
