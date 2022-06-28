using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMange.Services.Dtos;
using ProjectMange.Services.Query;
using ProjectMange.Services;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class RoleInfoController
    {

        private readonly IRoleInfoServices _roleInfoServices;
        /// <summary>
        /// INIT
        /// </summary>
        public RoleInfoController(IRoleInfoServices roleInfoServices)
        {
            _roleInfoServices = roleInfoServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<RoleInfoListOutput>>> Page([FromQuery] RoleInfoQuery parms)
        {
            return await _roleInfoServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<RoleInfoOutput>> Detail(int id)
        {
            return await _roleInfoServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(RoleInfoInput model)
        {
            return await _roleInfoServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(RoleInfoInput model)
        {
            return await _roleInfoServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _roleInfoServices.RemoveAsync(parms);
        }

    }
}


