using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using MVVM.Model;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel
{
    class VendorViewModel : ObservableObject
    {
        #region Construction
        public VendorViewModel()
        {
            _vendor = new Vendor();
        }
        #endregion

        #region Members
        private Vendor _vendor;
        private ObservableCollection<VendorDetailsViewModel> _details
            = new ObservableCollection<VendorDetailsViewModel>();
        private string _name;
        #endregion

        #region Properties
        public Vendor Vendor
        {
            get
            {
                return _vendor;
            }
            set
            {
                _vendor = value;
                _name = value.Name;
            }
        }

        public ObservableCollection<VendorDetailsViewModel> Details
        {
            get
            {
                return _details;
            }
        }

        public int BusinessEntityID
        {
            get { return Vendor.BusinessEntityID; }
            set { Vendor.BusinessEntityID = value;  }
        }

        public string Name
        {
            get { return Vendor.Name; }
            set
            {
                if (Vendor.Name != value)
                {
                    Vendor.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string NewName
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("NewName");
                }
            }
        }
        #endregion

        #region Methods
        public void SaveChanges()
        {
            Name = _name;
        }

        public void RevertChanges()
        {
            NewName = Name;
        }

        public bool IsEdited
        {
            get { return Name != NewName; }
        }
        #endregion

    }
}
