using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Interfaces;
using WpfApp.Models;
using System.Net.Http;
using Caliburn.Micro;
using System.Text.Json;


namespace WpfApp.Services {
    public class ServerService : IServerService {

        private static readonly HttpClient client = new HttpClient();
        private static readonly string BaseUrl = "https://playground.tesonet.lt/v1/servers";

        IAuthorizationService _authorizationService;
        IEventAggregator _eventAggregator;
     
        public ServerService(IAuthorizationService authorizationService, IEventAggregator eventAggregator) {
            _authorizationService = authorizationService;
            _eventAggregator = eventAggregator;
        }

        public async Task<List<Server>> ListServers() {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_authorizationService.token.token}");
            var response = await client.GetAsync(BaseUrl);

            var responseString = await response.Content.ReadAsStringAsync();
            var serverList = JsonSerializer.Deserialize<List<Server>>(responseString);

            return serverList;
        }
    }
}
