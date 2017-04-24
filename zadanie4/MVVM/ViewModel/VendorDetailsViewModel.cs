using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    class VendorDetailsViewModel : ObservableObject
    {
        #region Construction
        public VendorDetailsViewModel()
        {
            _vendor = new Vendor();
        }
        #endregion

        #region Members
        private Vendor _vendor;
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
            }
        }

        public int BusinessEntityID
        {
            get { return Vendor.BusinessEntityID; }
            set
            {
                if (Vendor.BusinessEntityID != value)
                {
                    Vendor.BusinessEntityID = value;
                    RaisePropertyChanged("BusinessEntityID");
                }
            }
        }

        public string AccountNumber
        {
            get { return Vendor.AccountNumber; }
            set
            {
                if (Vendor.AccountNumber != value)
                {
                    Vendor.AccountNumber = value;
                    RaisePropertyChanged("AccountNumber");
                }
            }
        }

        public bool ActiveFlag
        {
            get { return Vendor.ActiveFlag; }
            set
            {
                if (Vendor.ActiveFlag != value)
                {
                    Vendor.ActiveFlag = value;
                    RaisePropertyChanged("ActiveFlag");
                }
            }
        }

        public byte CreditRating
        {
            get { return Vendor.CreditRating; }
            set
            {
                if (Vendor.CreditRating != value)
                {
                    Vendor.CreditRating = value;
                    RaisePropertyChanged("CreditRating");
                }
            }
        }

        public DateTime ModifiedDate
        {
            get { return Vendor.ModifiedDate; }
            set
            {
                if (Vendor.ModifiedDate != value)
                {
                    Vendor.ModifiedDate = value;
                    RaisePropertyChanged("ModifiedDate");
                }
            }
        }

        public bool PreferredVendorStatus
        {
            get { return Vendor.PreferredVendorStatus; }
            set
            {
                if (Vendor.PreferredVendorStatus != value)
                {
                    Vendor.PreferredVendorStatus = value;
                    RaisePropertyChanged("PreferredVendorStatus");
                }
            }
        }
        #endregion
    }
}
