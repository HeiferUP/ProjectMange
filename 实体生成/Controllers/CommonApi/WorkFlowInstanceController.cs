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
    public class WorkFlowInstanceController : ControllerAbstract
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


