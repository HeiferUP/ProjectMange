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
    public class WorkFlowModelController : ControllerAbstract
    {

        private readonly IWorkFlowModelServices _workFlowModelServices;
        /// <summary>
        /// INIT
        /// </summary>
        public WorkFlowModelController(IWorkFlowModelServices workFlowModelServices)
        {
            _workFlowModelServices = workFlowModelServices;
        }
        
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<WorkFlowModelListOutput>>> Page([FromQuery] WorkFlowModelQuery parms)
        {
            return await _workFlowModelServices.PageAsync(parms);
        }
    
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<WorkFlowModelOutput>> Detail(int id)
        {
            return await _workFlowModelServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Add(WorkFlowModelInput model)
        {
            return await _workFlowModelServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(WorkFlowModelInput model)
        {
            return await _workFlowModelServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _workFlowModelServices.RemoveAsync(parms);
        }
    
    }
}


