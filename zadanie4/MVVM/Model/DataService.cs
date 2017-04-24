using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    class DataService
    {
        private DataClasses1DataContext dataContext;

        public DataService()
        {
            dataContext = new DataClasses1DataContext();
        }

        public IQueryable<Vendor> ReadVendors()
        {
            return dataContext.Vendors;
        }

        public void Submit()
        {
            dataContext.SubmitChanges();
        }
    }
}
