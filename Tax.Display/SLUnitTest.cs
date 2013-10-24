using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Tax.Display.ViewModel;

namespace Tax.Display
{
    [TestClass]
    public class SLUnitTest
    {

        [TestMethod]
        public void General()
        {
            var vm = new MainViewModel(null);

            Assert.IsNotNull(vm.WelcomeTitle);
        }
    }
}
