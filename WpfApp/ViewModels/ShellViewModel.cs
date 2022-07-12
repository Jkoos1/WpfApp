using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels {

    public class ShellViewModel : Conductor<object> {

        IEventAggregator _events;
        public ShellViewModel(IEventAggregator events) {

            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

    }
}
