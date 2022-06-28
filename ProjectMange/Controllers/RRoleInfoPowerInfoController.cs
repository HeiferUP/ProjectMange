
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMange.Services.Query;
using ProjectMange.Services.Dtos;
using ProjectMange.Services;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class RRoleInfoPowerInfoController
    {

        private readonly IRRoleInfoPowerInfoServices _rRoleInfoPowerInfoServices;
        /// <summary>
        /// INIT
        /// </summary>
        public RRoleInfoPowerInfoController(IRRoleInfoPowerInfoServices rRoleInfoPowerInfoServices)
        {
            _rRoleInfoPowerInfoServices = rRoleInfoPowerInfoServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<RRoleInfoPowerInfoListOutput>>> Page([FromQuery] RRoleInfoPowerInfoQuery parms)
        {
            return await _rRoleInfoPowerInfoServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<RRoleInfoPowerInfoOutput>> Detail(int id)
        {
            return await _rRoleInfoPowerInfoServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(RRoleInfoPowerInfoInput model)
        {
            return await _rRoleInfoPowerInfoServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(RRoleInfoPowerInfoInput model)
        {
            return await _rRoleInfoPowerInfoServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _rRoleInfoPowerInfoServices.RemoveAsync(parms);
        }

    }
}


