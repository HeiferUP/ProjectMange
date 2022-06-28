
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMange.Services.Dtos;
using ProjectMange.Services;
using ProjectMange.Services.Query;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class WorkFlowInstanceStepController
    {

        private readonly IWorkFlowInstanceStepServices _workFlowInstanceStepServices;
        /// <summary>
        /// INIT
        /// </summary>
        public WorkFlowInstanceStepController(IWorkFlowInstanceStepServices workFlowInstanceStepServices)
        {
            _workFlowInstanceStepServices = workFlowInstanceStepServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<WorkFlowInstanceStepListOutput>>> Page([FromQuery] WorkFlowInstanceStepQuery parms)
        {
            return await _workFlowInstanceStepServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<WorkFlowInstanceStepOutput>> Detail(int id)
        {
            return await _workFlowInstanceStepServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(WorkFlowInstanceStepInput model)
        {
            return await _workFlowInstanceStepServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(WorkFlowInstanceStepInput model)
        {
            return await _workFlowInstanceStepServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _workFlowInstanceStepServices.RemoveAsync(parms);
        }

    }
}


