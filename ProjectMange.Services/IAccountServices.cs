using LDFCore.Platform.Result;
using ProjectMange.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMange.Services
{
    public interface IAccountServices
    {
        Task<IResultModel<LoginUserOutput>> Login(string username, string password);
    }
}
