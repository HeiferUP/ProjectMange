using LDFCore.Authorized.Web;
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using ProjectMange.Services.CommonSvc;
using ProjectMange.Services.CommonSvc.Dtos;
using ProjectMange.Services.CommonSvc.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectMange.Api.Controllers.CommonApi
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    public class PowerInfoController : ControllerAbstract
    {

        private readonly IPowerInfoServices _powerInfoServices;
        /// <summary>
        /// INIT
        /// </summary>
        public PowerInfoController(IPowerInfoServices powerInfoServices)
        {
            _powerInfoServices = powerInfoServices;
        }
        
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<PowerInfoListOutput>>> Page([FromQuery] PowerInfoQuery parms)
        {
            return await _powerInfoServices.PageAsync(parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PowerInfoOutput>> Detail(int id)
        {
            return await _powerInfoServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Add(PowerInfoInput model)
        {
            return await _powerInfoServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(PowerInfoInput model)
        {
            return await _powerInfoServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _powerInfoServices.RemoveAsync(parms);
        }
    
    }
}


