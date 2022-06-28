using LDFCore.Platform.Models;
using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMange.Services;
using ProjectMange.Services.Dtos;
using ProjectMange.Services.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectMange.Controllers
{
    /// <summary>
    /// Common服务接口
    ///</summary>
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class GoodsConsumableInputController
    {

        private readonly IGoodsConsumableInputServices _goodsConsumableInputServices;
        /// <summary>
        /// INIT
        /// </summary>
        public GoodsConsumableInputController(IGoodsConsumableInputServices goodsConsumableInputServices)
        {
            _goodsConsumableInputServices = goodsConsumableInputServices;
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<PageList<GoodsConsumableInputListOutput>>> Page([FromQuery] GoodsConsumableInputQuery parms)
        {
            return await _goodsConsumableInputServices.PageAsync(parms);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResultModel<GoodsConsumableInputOutput>> Detail(int id)
        {
            return await _goodsConsumableInputServices.DetailAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Add(GoodsConsumableInputInput model)
        {
            return await _goodsConsumableInputServices.AddAsync(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Edit(GoodsConsumableInputInput model)
        {
            return await _goodsConsumableInputServices.EditAsync(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> Remove(RemoveModel<int> parms)
        {
            return await _goodsConsumableInputServices.RemoveAsync(parms);
        }

    }
}


