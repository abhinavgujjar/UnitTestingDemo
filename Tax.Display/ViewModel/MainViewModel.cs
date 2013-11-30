using GalaSoft.MvvmLight;
using Tax.Display.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace Tax.Display.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataAccess)
        {
            this._dataService = dataAccess;
            this.SubmitCommand = new RelayCommand(OnSubmitCommand);
        }

        /// <summary>
        /// Cities
        /// </summary>
        public ObservableCollection<string> Cities { get; set; }

        /// <summary>
        /// Submit Command
        /// </summary>
        public ICommand SubmitCommand { get; set; }

        public string SelectedCity { get; set; }

        public decimal UDFForCity { get; set; }

        /// <summary>
        /// Handles the Submit command
        /// </summary>
        private void OnSubmitCommand()
        {
            UDFForCity = this._dataService.GetUDFForCity(SelectedCity);
        }

    }
}