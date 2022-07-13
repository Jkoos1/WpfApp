using Caliburn.Micro;
using System;
using System.Threading;
using System.Threading.Tasks;
using WpfApp.Events;

namespace WpfApp.ViewModels {

    public class ShellViewModel : Conductor<object>, IHandle<LoginEvent>, IHandle<LogoutEvent> {

        IEventAggregator _events;
        ServersViewModel _serversViewModel;

        public ShellViewModel(IEventAggregator events, ServersViewModel serversViewModel) {

            _serversViewModel = serversViewModel;

            _events = events;
            _events.Subscribe(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>());

        }

        Task IHandle<LoginEvent>.HandleAsync(LoginEvent message, CancellationToken cancellationToken) {
            ActivateItemAsync(_serversViewModel);
            return Task.CompletedTask;
        }

        Task IHandle<LogoutEvent>.HandleAsync(LogoutEvent message, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
