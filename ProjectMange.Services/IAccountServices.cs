using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMange.Services
{
    public interface IAccountServices
    {
        Task<string> Login(string username, string password);
    }
}
