using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Caliburn.Micro;
using WpfApp.Interfaces;
using WpfApp.Models;
using WpfApp.Events;

namespace WpfApp.ViewModels {
    public class ServersViewModel : Screen {

        private IServerService _serverService;
        private IEventAggregator _events;
        private BindingList<Server> _serverList;
        
        public ServersViewModel(IServerService serverService, IEventAggregator events) {
            _serverService = serverService;
            _events = events;
        }

        public BindingList<Server> ServerList {
            get { return _serverList; }
            set {
                _serverList = value;
                NotifyOfPropertyChange(() => ServerList);
            }
        }

        protected override async void OnViewLoaded(object view) {
            base.OnViewLoaded(view);
            await ListServers();
        }

        public async Task ListServers() {

            var serversList = await _serverService.ListServers();
            ServerList = new BindingList<Server>(serversList);
        }

        public async void Logout() {           
            try {
                _events.PublishOnUIThreadAsync(new LogoutEvent());
            }
            catch (Exception ex) {
            }
        }

    }
}
