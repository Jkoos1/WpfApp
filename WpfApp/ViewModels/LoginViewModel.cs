using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace WpfApp.ViewModels {

    public class LoginViewModel : Screen {

        private IEventAggregator _events;

        public LoginViewModel( IEventAggregator events) {       
            _events = events;
        }
        /*public bool CanLogin(string username, string password) {
            return !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password);
        }

        public string Login(string username, string password) {
            return "hey";
        }*/


    }
}
