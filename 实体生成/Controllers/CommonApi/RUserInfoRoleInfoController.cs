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
    public class RUserInfoRoleInfoController : ControllerAbstract
    {

        private readonly IRUserInfoRoleInfoServices _rUserInfoRoleInfoServices;
        /// <summary>
        /// INIT
        /// </summary>
        public RUserInfoRoleInfoController(IRUserInfoRoleInfoServices rUserInfoRoleInfoServices)
        {
            _rUserInfoRoleInfoServices = rUserInfoRoleInfoServices;
        }
        
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<RUserInfoRoleInfoListOutput>>> Page([FromQuery] RUserInfoRoleInfoQuery parms)
        {
            return await _rUserInfoRoleInfoServices.PageAsync(parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<RUserInfoRoleInfoOutput>> Detail(int id)
        {
            return await _rUserInfoRoleInfoServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Add(RUserInfoRoleInfoInput model)
        {
            return await _rUserInfoRoleInfoServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(RUserInfoRoleInfoInput model)
        {
            return await _rUserInfoRoleInfoServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _rUserInfoRoleInfoServices.RemoveAsync(parms);
        }
    
    }
}


