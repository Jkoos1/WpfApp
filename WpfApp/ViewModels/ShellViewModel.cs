using Caliburn.Micro;
using System;
using System.Threading;
using System.Threading.Tasks;
using WpfApp.Events;

namespace WpfApp.ViewModels {

    public class ShellViewModel : Conductor<object>, IHandle<LoginEvent>, IHandle<LogoutEvent> {

        IEventAggregator _events;
        ServersViewModel _serversViewModel;
        LoginViewModel _loginViewModel;

        public ShellViewModel(IEventAggregator events, ServersViewModel serversViewModel, LoginViewModel loginViewModel) {

            _serversViewModel = serversViewModel;
            _loginViewModel = loginViewModel;

            _events = events;
            _events.Subscribe(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>());
            
        }

        Task IHandle<LoginEvent>.HandleAsync(LoginEvent message, CancellationToken cancellationToken) {
            ActivateItemAsync(_serversViewModel);
            return Task.CompletedTask;
        }

        Task IHandle<LogoutEvent>.HandleAsync(LogoutEvent message, CancellationToken cancellationToken) {
            ActivateItemAsync(IoC.Get<LoginViewModel>());
            return Task.CompletedTask;
        }
    }
}
