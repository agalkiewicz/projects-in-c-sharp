using System.Linq;
using System.Collections.ObjectModel;
using MVVM.Model;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    class VendorsCollectionViewModel
    {
        #region Members
        private static DataService dataService = new DataService();
        private IQueryable<Vendor> vendors = dataService.ReadVendors();
        ObservableCollection<VendorViewModel> _vendors = new ObservableCollection<VendorViewModel>();
        #endregion

        #region Properties
        public ObservableCollection<VendorViewModel> Vendors
        {
            get
            {
                return _vendors;
            }
            set
            {
                _vendors = value;
            }
        }
        #endregion

        #region Construction
        public VendorsCollectionViewModel()
        {

            foreach (var vendor in vendors)
            {
                VendorViewModel vendor1 = new VendorViewModel { Vendor = vendor };
                vendor1.Details.Add(new VendorDetailsViewModel { Vendor = vendor });
                _vendors.Add(vendor1);
            }
       
        }
        #endregion

        public ICommand UpdateCommand
        {
            get { return new UpdateCommand(dataService); }
        }

        public ICommand RevertCommand
        {
            get { return new RevertCommand(); }
        }
    }
}
