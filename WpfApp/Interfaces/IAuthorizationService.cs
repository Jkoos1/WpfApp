using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Interfaces {
    public interface IAuthorizationService {

        Token token { get; }

        Task Login(string username, string password);
    }
}
