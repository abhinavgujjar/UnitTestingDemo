using System;
using Tax.Display.Model;

namespace Tax.Display.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }


        public decimal GetUDFForCity(string SelectedCity)
        {
            throw new NotImplementedException();
        }
    }
}