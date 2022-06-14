
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMange.Services;
using ProjectMange.Services.Query;
using ProjectMange.Services.Dtos;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    public class WorkFlowInstanceController
    {

        private readonly IWorkFlowInstanceServices _workFlowInstanceServices;
        /// <summary>
        /// INIT
        /// </summary>
        public WorkFlowInstanceController(IWorkFlowInstanceServices workFlowInstanceServices)
        {
            _workFlowInstanceServices = workFlowInstanceServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<WorkFlowInstanceListOutput>>> Page([FromQuery] WorkFlowInstanceQuery parms)
        {
            return await _workFlowInstanceServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<WorkFlowInstanceOutput>> Detail(int id)
        {
            return await _workFlowInstanceServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(WorkFlowInstanceInput model)
        {
            return await _workFlowInstanceServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(WorkFlowInstanceInput model)
        {
            return await _workFlowInstanceServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _workFlowInstanceServices.RemoveAsync(parms);
        }

    }
}


