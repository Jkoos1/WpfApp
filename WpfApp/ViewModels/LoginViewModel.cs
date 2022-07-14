using System;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using WpfApp.Events;
using WpfApp.Interfaces;

namespace WpfApp.ViewModels {

    public class LoginViewModel : Screen {

        private string _username;
        private string _password;
        private string _errorMessage;

        private IEventAggregator _events;
        private IAuthorizationService _authorizationHelper;
        private static readonly ILog _logger = LogManager.GetLog(MethodBase.GetCurrentMethod().DeclaringType);

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

        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }
        public async void Login() {
            try {
                await _authorizationHelper.Login(Username, Password);
                await _events.PublishOnUIThreadAsync(new LoginEvent());         
            }
            catch (Exception ex) {
                _logger.Error(ex);
                ErrorMessage = ex.Message;                 
            }
            
        }
    }

}
