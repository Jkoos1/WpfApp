using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Net.Http;
using System.Text.Json;
using WpfApp.Events;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.Interfaces;

namespace WpfApp.ViewModels {

    public class LoginViewModel : Screen {

        private string _username;
        private string _password;

        private IEventAggregator _events;
        private IAuthorizationService _authorizationHelper;

        public LoginViewModel(IEventAggregator events, IAuthorizationService authorizationHelper) {
            _events = events;
            _authorizationHelper = authorizationHelper; 
        }

        public string Username {
            get { return _username; }
            set {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        public string Password {
            get { return _password; }
            set {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public async void Login() {
            try {
                await _authorizationHelper.Login(Username, Password);
                _events.PublishOnUIThreadAsync(new LoginEvent());
            }
            catch (Exception ex) {
            }
            
        }

    }

}
