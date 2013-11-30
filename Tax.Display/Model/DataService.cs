using System;
using System.ComponentModel.Composition;

namespace Tax.Display.Model
{
    [Export]
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }


        public decimal GetUDFForCity(string SelectedCity)
        {
            throw new NotImplementedException();
        }
    }
}