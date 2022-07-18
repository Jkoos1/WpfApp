using System;
using System.Reflection;
using Caliburn.Micro;
using WpfApp.Events;
using WpfApp.Interfaces;

namespace WpfApp.ViewModels {

    public class LoginViewModel : Screen {

        private string _username;
        private string _password;
        private string _errorMessage;

        private IEventAggregator _events;
        private IAuthorizationService _authorizationService;
        private static readonly ILog _logger = LogManager.GetLog(MethodBase.GetCurrentMethod().DeclaringType);

        public LoginViewModel(IEventAggregator events, IAuthorizationService authorizationService) {
            _events = events;
            _authorizationService = authorizationService;
        }
        public string Username {
            get { return _username; }
            set {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password {
            get { return _password; }
            set {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public bool CanLogin {
            get {if (Username?.Length > 0 && Password?.Length > 0) {
                    return true;
                }
                return false;
            }
        }

        public async void Login() {
            try {
                await _authorizationService.Login(Username, Password);
                await _events.PublishOnUIThreadAsync(new LoginEvent());
            }
            catch (Exception ex) {
                _logger.Error(ex);
                ErrorMessage = ex.Message;                 
            }
            
        }
    }

}
