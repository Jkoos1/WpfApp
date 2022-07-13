using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using WpfApp.Models;
using WpfApp.Interfaces;
using Caliburn.Micro;

namespace WpfApp.Services {
    public class AuthorizationService : IAuthorizationHelper {

        private static readonly HttpClient client = new HttpClient();
        private static readonly string BaseUrl = "https://playground.tesonet.lt/v1/tokens";

        private Token _token;

        private IEventAggregator _events;
        public AuthorizationService(IEventAggregator events) {
            _events = events;
        }

        public Token token {
            get { return _token; }
            private set { _token = value; }
        }

        public async Task Login(string Username, string Password) {

            var values = new Dictionary<string, string>
              {
                  { "username", Username },
                  { "password", Password }
              };


            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(BaseUrl, content);

            if (response.IsSuccessStatusCode) {

                var responseString = await response.Content.ReadAsStringAsync();
                var tokenItem = JsonSerializer.Deserialize<Token>(responseString);

                if (!string.IsNullOrWhiteSpace(tokenItem.token)) {
                    token = tokenItem;
                }
                else {
                    throw new Exception("Empty Token string");
                }
            }
            else {
                throw new Exception("Login failed");
            }

        }

    }
}
