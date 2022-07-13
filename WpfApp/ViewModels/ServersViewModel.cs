using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WpfApp.Interfaces;
using WpfApp.Models;

namespace WpfApp.ViewModels {
    public class ServersViewModel : Screen {

        IServerService _serverService;
        private BindingList<Server> _serverList;
        
        public ServersViewModel(IServerService serverService) {
            _serverService = serverService;
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
            var yes = 5;
        }

    }
}
