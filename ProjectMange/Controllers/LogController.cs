
using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMange.Services.Query;
using ProjectMange.Services;
using ProjectMange.Services.Dtos;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    public class LogController
    {

        private readonly ILogServices _logServices;
        /// <summary>
        /// INIT
        /// </summary>
        public LogController(ILogServices logServices)
        {
            _logServices = logServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<LogListOutput>>> Page([FromQuery] LogQuery parms)
        {
            return await _logServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<LogOutput>> Detail(int id)
        {
            return await _logServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(LogInput model)
        {
            return await _logServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(LogInput model)
        {
            return await _logServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _logServices.RemoveAsync(parms);
        }

    }
}


