using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Interfaces {
    public interface IServerService {

        Task<List<Server>> ListServers();

    }
}
